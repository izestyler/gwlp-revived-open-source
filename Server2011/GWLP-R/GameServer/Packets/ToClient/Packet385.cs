using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 385)]
        public class Packet385 : IPacket
        {
                public class PacketSt385 : IPacketTemplate
                {
                        public UInt16 Header { get { return 385; } }
                        public UInt16 Data1;
                        public UInt16 Data2;
                        public UInt32 Data3;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt385>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt385)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt385> pParser;

        }
}