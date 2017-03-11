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

        /// <summary>
        /// initializes the rtp helper class
        /// </summary>
        public RTPModel()
        {
            rtpHelper = new RTPPacket();
        }

        /// <summary>
        /// creates a UDP connection with the server and the clients local port
        /// </summary>
        /// <param name="port"></param>
        /// <param name="address"></param>
        public void CreateConnection(int port, string address)
        {
            //must bind to a local end point 
            IPAddress serverAddress = IPAddress.Parse(address);
            clientEndPoint = new IPEndPoint(serverAddress, port);

            try
            {
                UDPSocket = new Socket(serverAddress.AddressFamily, SocketType.Dgram, ProtocolType.Udp); //create udp socket
                UDPSocket.Bind(clientEndPoint); //bind to the clients port

            } catch(SocketException err)
            {
                if(UDPSocket != null)
                {
                    UDPSocket.Close();
                }
            }
        }

        /// <summary>
        /// Receive packets from the UDP socket, and break apart the header from the frame.
        /// </summary>
        public void ReceivePackets()
        {
            //size determined from checking incoming packet size from video server made in assignment 2 (roughly >50000)
            byte[] encodedFrame = new byte[100000];
            try
            {
                EndPoint endPoint = clientEndPoint;
                UDPSocket.ReceiveFrom(encodedFrame, ref endPoint); //receive bytes from server and store in encodedFrame array

                data = rtpHelper.GetData(encodedFrame); //store the frame data in the data specific array
                header = rtpHelper.GetHeader(encodedFrame); //store the header data in the header specific array

            } catch(SocketException err)
            {
                Console.WriteLine("ReceiveFrom failed: {0}", err.Message);
            }
        }

        /// <summary>
        /// Close the connection to the socket
        /// </summary>
        public void TerminateConnection()
        {
            UDPSocket.Close();
        }

        /// <summary>
        /// Get packet frame data
        /// </summary>
        /// <returns>data</returns>
        public byte[] GetData()
        {
            return data;
        }

        /// <summary>
        /// Get header packet data
        /// </summary>
        /// <returns>header</returns>
        public byte[] GetHeader()
        {
            return header;
        }

        /// <summary>
        /// Get the payload value from the header
        /// </summary>
        /// <returns></returns>
        public int GetPayload()
        {
            return rtpHelper.GetPayload();
        }

        /// <summary>
        /// Get the timestamp value from the header
        /// </summary>
        /// <returns></returns>
        public int GetTimeStamp()
        {
            return rtpHelper.GetTimeStamp();
        }

        /// <summary>
        /// Get the sequence number value from the header
        /// </summary>
        /// <returns></returns>
        public int GetSeqNo()
        {
            return rtpHelper.GetSeqNo();
        }
    }
}
