using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 441)]
        public class Packet441 : IPacket
        {
                public class PacketSt441 : IPacketTemplate
                {
                        public UInt16 Header { get { return 441; } }
                        public UInt16 Data1;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt441>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt441)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt441> pParser;

        }
}
