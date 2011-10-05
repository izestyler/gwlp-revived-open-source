﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GameServer.DataBase;
using GameServer.Enums;
using GameServer.Interfaces;
using GameServer.Packets.ToClient;
using GameServer.ServerData;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.StaticConvert;

namespace GameServer.Commands
{
        [CommandAttribute(Description = "Parameter: MapID (see database). Tries to transfer to another map.")]
        class ChangeMap : IAction
        {
                private int newCharID;
                private int mapID;
                private bool validCommand;

                public ChangeMap(int charID, string mapID)
                {
                        newCharID = charID;
                        validCommand = int.TryParse(mapID, out this.mapID);
                }

                public void Execute(Map oldMap)
                {
                        if (validCommand)
                        {

                                // remove the char's map subscription
                                oldMap.CharIDs.Remove(newCharID);

                                // build the map (if its the same it wont be build again!)
                                World.BuildMap(mapID);
                                
                                // alter status
                                GameServerWorld.Instance.Get<DataClient>(Clients.CharID, newCharID).Status = SyncStatus.Dispatching;

                                // alter mapID
                                GameServerWorld.Instance.Get<DataClient>(Clients.CharID, newCharID).MapID = mapID;
                                GameServerWorld.Instance.Get<DataCharacter>(Chars.CharID, newCharID).MapID = mapID;

                                // create server connection array
                                var con = new MemoryStream();
                                RawConverter.WriteUInt16(2, con);
                                //RawConverter.WriteUInt16(57367, con);
                                RawConverter.WriteUInt16(38947, con);
                                RawConverter.WriteByteAr(new byte[] { 0x7F, 0x00, 0x00, 0x01 }, con);
                                RawConverter.WriteByteAr(new byte[16], con);

                                // Note: DISPATCH
                                var chatMsg = new NetworkMessage((int)GameServerWorld.Instance.Get<DataCharacter>(Chars.CharID, newCharID)[Chars.NetID]);
                                chatMsg.PacketTemplate = new P406_Dispatch.PacketSt406()
                                {
                                        ConnectionInfo = con.ToArray(),
                                        Key1 = GameServerWorld.Instance.Get<DataClient>(Clients.CharID, newCharID).SecurityKeys[0],
                                        Key2 = GameServerWorld.Instance.Get<DataClient>(Clients.CharID, newCharID).SecurityKeys[1],
                                        ZoneID = (ushort)(int)GameServerWorld.Instance.Get<DataMap>(Maps.MapID, mapID)[Maps.GameMapID],
                                        Region = 0,
                                        IsOutpost = 0
                                };
                                QueuingService.PostProcessingQueue.Enqueue(chatMsg);

                                // free the agent ids
                                var chara = GameServerWorld.Instance.Get<DataCharacter>(Chars.CharID, newCharID);
                                
                                World.UnRegisterCharacterIDs((int)chara[Chars.LocalID], (int)chara[Chars.AgentID], (int)oldMap[Maps.MapID]);
                        }
                }
        }
}
