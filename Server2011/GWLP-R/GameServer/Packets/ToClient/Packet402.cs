using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 402)]
        public class Packet402 : IPacket
        {
                public class PacketSt402 : IPacketTemplate
                {
                        public UInt16 Header { get { return 402; } }
                        public byte Data1;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt402>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt402)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt402> pParser;

        }
}
