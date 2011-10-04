using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 24)]
        public class Packet24 : IPacket
        {
                public class PacketSt24 : IPacketTemplate
                {
                        public UInt16 Header { get { return 24; } }
                        public byte Data1;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt24>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt24> pParser;
        }
}
