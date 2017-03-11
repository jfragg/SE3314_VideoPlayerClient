using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace se3314_assignment2
{
    class RTPModel
    {

        private Socket UDPSocket;
        private IPEndPoint clientEndPoint;
        private RTPPacket rtpHelper;
        byte[] data = new byte[4096];
        byte[] header = new byte[12];

        public RTPModel()
        {
            rtpHelper = new RTPPacket();
        }

        public void CreateConnection(int port, string address)
        {
            //must bind to a local end point 
            IPAddress serverAddress = IPAddress.Parse(address);
            clientEndPoint = new IPEndPoint(serverAddress, port);

            try
            {
                UDPSocket = new Socket(serverAddress.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
                UDPSocket.Bind(clientEndPoint);

            } catch(SocketException err)
            {
                if(UDPSocket != null)
                {
                    UDPSocket.Close();
                }
            }
        }

        public void ReceivePackets()
        {
            //size determined from checking incoming packet size from video server made in assignment 2 (roughly between >50000)
            byte[] encodedFrame = new byte[100000];
            try
            {
                EndPoint endPoint = clientEndPoint;
                UDPSocket.ReceiveFrom(encodedFrame, ref endPoint);

                data = rtpHelper.GetData(encodedFrame);
                header = rtpHelper.GetHeader(encodedFrame);

            } catch(SocketException err)
            {
                Console.WriteLine("ReceiveFrom failed: {0}", err.Message);
            }
        }

        public void TerminateConnection()
        {
            UDPSocket.Close();
        }

        public byte[] GetData()
        {
            return data;
        }

        public byte[] GetHeader()
        {
            return header;
        }

        public int GetPayload()
        {
            return rtpHelper.GetPayload();
        }

        public int GetTimeStamp()
        {
            return rtpHelper.GetTimeStamp();
        }

        public int GetSeqNo()
        {
            return rtpHelper.GetSeqNo();
        }
    }
}
