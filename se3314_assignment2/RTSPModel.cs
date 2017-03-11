using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace se3314_assignment2
{
    class RTSPModel
    {
        int port;
        string address;
        Socket _sock;
        IPEndPoint connectEndPoint;
        IPAddress serverAddr;

        /// <summary>
        /// Create the TCP connection through RTSP
        /// </summary>
        /// <param name="port"></param>
        /// <param name="address"></param>
        public RTSPModel(int port, string address)
        {
            this.port = port;
            this.address = address;

            //connect the rtsp socket on server address and port
            serverAddr = IPAddress.Parse(address);
            connectEndPoint = new IPEndPoint(serverAddr, port);

            try
            {
                _sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //create the socket
                _sock.Connect(connectEndPoint); //connect to the socket end point
            }
            catch (SocketException err)
            {
                if (_sock != null)
                {
                    _sock.Close();
                }
            }
        }

        /// <summary>
        /// Get the local end point of the socket
        /// </summary>
        /// <returns></returns>
        public IPEndPoint GetLocalEndpoint()
        {
            return (IPEndPoint)_sock.LocalEndPoint;
        }

        /// <summary>
        /// Send request to server
        /// </summary>
        /// <param name="s"></param>
        public void SendRequest(string s)
        {
            byte[] dataBuffer = new byte[4096];
            dataBuffer = Encoding.UTF8.GetBytes(s);

            try
            {
                _sock.Send(dataBuffer); //send encoded string to the server

            } catch(SocketException err)
            {
                Console.WriteLine("Send Failed: {0}", err.Message);
            }
        }

        /// <summary>
        /// get the response from the server
        /// </summary>
        /// <returns></returns>
        public string GetResponse()
        {
            byte[] rcvBuffer = new byte[4096];
            string response = "";

            try
            {
                _sock.Receive(rcvBuffer); //receive the response from the server 
                response = Encoding.UTF8.GetString(rcvBuffer); //decoding the bytes to string
                return response;
                
            } catch(SocketException err)
            {
                Console.WriteLine("Receive Failed: {0}", err.Message);
            }

            return response;
        }

    }
}
