﻿using System;
using GameServer.Actions;
using GameServer.Enums;
using GameServer.Interfaces;
using GameServer.Packets.ToClient;
using GameServer.ServerData;
using ServerEngine.ProcessorQueues;

namespace GameServer.Commands
{
        [CommandAttribute(Description = "No parameters. Shows the available commands.")]
        public class HelpMe : IAction
        {
                private int newCharID;

                public HelpMe(int charID)
                {
                        newCharID = charID;
                }

                public void Execute(Map map)
                {
                        foreach (var cmd in World.ChatCommandsDict.Values)
                        {
                                var attributes = cmd.GetCustomAttributes(typeof(CommandAttribute), false);
                                if (attributes.Length == 1)
                                {
                                        var name = "[/" + cmd.Name + "]: ";
                                        var message = ((CommandAttribute)attributes[0]).Description;

                                        Character chara;
                                        lock (chara = World.GetCharacter(Chars.CharID, newCharID))
                                        {
                                                var reNetID = (int)chara[Chars.NetID];

                                                // Note: CHAT MESSAGE
                                                var chatMsg = new NetworkMessage(reNetID);
                                                chatMsg.PacketTemplate = new P081_GeneralChatMessage.PacketSt81()
                                                {
                                                        Message =
                                                        BitConverter.ToChar(new byte[] { 0x08, 0x01 }, 0).ToString() +
                                                        BitConverter.ToChar(new byte[] { 0x07, 0x01 }, 0).ToString() +
                                                        name +
                                                        message +
                                                        BitConverter.ToChar(new byte[] { 0x01, 0x00 }, 0).ToString()
                                                };
                                                QueuingService.PostProcessingQueue.Enqueue(chatMsg);

                                                // Note: CHAT MESSAGE NO OWNER
                                                var chatOwner = new NetworkMessage(reNetID);
                                                chatOwner.PacketTemplate = new P082_GeneralChatNoOwner.PacketSt82()
                                                {
                                                        Data1 = 0,
                                                        Data2 = (byte)ChatColors.DarkOrange_DarkOrange
                                                };
                                                QueuingService.PostProcessingQueue.Enqueue(chatOwner);
                                        }
                                }
                        }
                }
        }
}