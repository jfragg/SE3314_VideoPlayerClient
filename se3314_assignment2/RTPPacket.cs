using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace se3314_assignment2
{
    class RTPPacket
    {
        private byte[] header;
        private byte[] data;

        public RTPPacket()
        {
            header = new byte[12];
            data = new byte[100000];
        }

        //header will be the same as my asssignment 1 as this function is built off of how I created each packet in assignment 1
        //there are some discrepencies with how Prof. Ouda created his header and the entire packet
        public byte[] GetHeader(byte [] packet)
        {

            for(int i = 0; i < 12; i++)
            {
                header[i] = packet[i];
            }

            return header;
        }

        public byte[] GetData(byte [] packet)
        {
            for(int i = 12; i < packet.Length; i++)
            {
                data[i - 12] = packet[i];
            }

            return data;
        }

    }
}
