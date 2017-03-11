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
        private int payload;
        private int seqNo;
        private int timestamp;

        /// <summary>
        /// initialize the header array and data array
        /// </summary>
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

                //Index[1] = Payload Type 
                //Index[3] = Sequence Number
                //Index[4-7] = timestamp
            }

            payload = header[1]; //get the payload number
            seqNo = header[3]; //get the sequence number
            timestamp = (header[4] * 100000) + (header[5] * 10000) + (header[6] * 1000) + (header[7]); //add up the values of the timestamp bytes
            //not 100% sure if this is actually correct but that's my take away so hopefully it is :) 

            return header;
        }

        /// <summary>
        /// Get the payload from header
        /// </summary>
        /// <returns></returns>
        public int GetPayload()
        {
            return payload;
        }

        /// <summary>
        /// Get the sequence number from header
        /// </summary>
        /// <returns></returns>
        public int GetSeqNo()
        {
            return seqNo;
        }

        /// <summary>
        /// Get the time stamp from header
        /// </summary>
        /// <returns></returns>
        public int GetTimeStamp()
        {
            return timestamp;
        }

        /// <summary>
        /// Store the frame into the data array
        /// </summary>
        /// <param name="packet"></param>
        /// <returns></returns>
        public byte[] GetData(byte [] packet)
        {
            //start at 12 to ignore the 12 bytes designated for the header
            for(int i = 12; i < packet.Length; i++)
            {
                data[i - 12] = packet[i];
            }

            return data;
        }

    }
}
