using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 330)]
        public class Packet330 : IPacket
        {
                public class PacketSt330 : IPacketTemplate
                {
                        public UInt16 Header { get { return 330; } }
                        public UInt32 Data1;
                        public byte Data2;
                        public byte Data3;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt330>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt330)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt330> pParser;

        }
}
