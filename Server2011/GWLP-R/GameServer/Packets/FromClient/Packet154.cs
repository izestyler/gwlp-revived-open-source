using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 154)]
        public class Packet154 : IPacket
        {
                public class PacketSt154 : IPacketTemplate
                {
                        public UInt16 Header { get { return 154; } }
                        [PacketFieldType(ConstSize = false, MaxSize = 20)]
                        public string Data1;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt154>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt154> pParser;
        }
}
