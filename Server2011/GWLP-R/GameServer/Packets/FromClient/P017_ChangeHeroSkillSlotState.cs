using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 17)]
        public class P017_ChangeHeroSkillSlotState : IPacket
        {
                public class PacketSt17 : IPacketTemplate
                {
                        public UInt16 Header { get { return 17; } }
                        public UInt32 AgentID;
                        public UInt32 SkillSlot;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt17>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt17> pParser;
        }
}
