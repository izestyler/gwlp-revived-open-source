using System;
using ServerEngine.ProcessorQueues;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 82)]
        public class P082_GeneralChatNoOwner : IPacket
        {
                public class PacketSt82 : IPacketTemplate
                {
                        public UInt16 Header { get { return 82; } }
                        public UInt16 Data1;
                        public byte Data2;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt82>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt82)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt82> pParser;

        }
}
