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
        IPAddress clientAddr;

        public RTSPModel(int port, string address)
        {
            this.port = port;
            this.address = address;

            serverAddr = IPAddress.Parse(address);
            connectEndPoint = new IPEndPoint(serverAddr, port);

            try
            {
                _sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _sock.Connect(connectEndPoint);
            }
            catch (SocketException err)
            {
                if (_sock != null)
                {
                    _sock.Close();
                }
            }
        }

        public void SendRequest(string s)
        {
            byte[] dataBuffer = new byte[4096];
            dataBuffer = Encoding.UTF8.GetBytes(s);

            try
            {
                _sock.Send(dataBuffer);

            } catch(SocketException err)
            {
                Console.WriteLine("Send Failed: {0}", err.Message);
            }
        }

        public string GetResponse()
        {
            byte[] rcvBuffer = new byte[4096];
            string response = "";

            try
            {
                _sock.Receive(rcvBuffer);
                response = Encoding.UTF8.GetString(rcvBuffer);
                return response;
                
            } catch(SocketException err)
            {
                Console.WriteLine("Receive Failed: {0}", err.Message);
            }

            return response;
        }

    }
}
