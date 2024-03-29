using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 156)]
        public class Packet156 : IPacket
        {
                public class PacketSt156 : IPacketTemplate
                {
                        public UInt16 Header { get { return 156; } }
                        public Single Data1;
                        public Single Data2;
                        public UInt16 Data3;
                        public UInt32 Data4;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt156>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt156)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt156> pParser;

        }
}
