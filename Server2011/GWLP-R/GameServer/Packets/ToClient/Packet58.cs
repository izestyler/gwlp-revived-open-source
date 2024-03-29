using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 58)]
        public class Packet58 : IPacket
        {
                public class PacketSt58 : IPacketTemplate
                {
                        public UInt16 Header { get { return 58; } }
                        public UInt32 Data1;
                        public UInt32 Data2;
                        public UInt32 ID1;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt58>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt58)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt58> pParser;

        }
}
