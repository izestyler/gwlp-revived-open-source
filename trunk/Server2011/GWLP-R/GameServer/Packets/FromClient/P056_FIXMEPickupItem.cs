using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 56)]
        public class P056_FIXMEPickupItem : IPacket
        {
                public class PacketSt56 : IPacketTemplate
                {
                        public UInt16 Header { get { return 56; } }
                        public UInt32 AgentID; //was ID!!
                        public byte Flag;//0
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt56>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt56> pParser;
        }
}
