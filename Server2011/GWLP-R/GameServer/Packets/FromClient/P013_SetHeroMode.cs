using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 13)]
        public class P013_SetHeroMode : IPacket
        {
                public class PacketSt13 : IPacketTemplate
                {
                        public UInt16 Header { get { return 13; } }
                        public UInt32 AgentID;
                        public UInt32 Mode; //0=Fight 1=Guard 2=Avoid
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt13>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt13> pParser;
        }
}
