using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 342)]
        public class Packet342 : IPacket
        {
                public class PacketSt342 : IPacketTemplate
                {
                        public UInt16 Header { get { return 342; } }
                        public UInt32 Data1;
                        public UInt32 Data2;
                        public UInt32 Data3;
                        [PacketFieldType(ConstSize = false, MaxSize = 64)]
                        public string Data4;
                        public byte ArraySize1;
                        [PacketFieldType(ConstSize = false, MaxSize = 256)]
                        public UInt32[] Data5;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt342>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt342)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt342> pParser;

        }
}