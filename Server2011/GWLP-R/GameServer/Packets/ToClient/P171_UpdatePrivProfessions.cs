using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 171)]
        public class P171_UpdatePrivProfessions : IPacket
        {
                public class PacketSt171 : IPacketTemplate
                {
                        public UInt16 Header { get { return 171; } }
                        public UInt32 ID1;
                        public byte Prof1;
                        public byte Prof2;
                        public byte IsPvp;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt171>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt171)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt171> pParser;

        }
}
