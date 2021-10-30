using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBus_connector
{
    public class PDU // TODO change name to readDiscreteInputs PDU,create :IPDU interface, add more PDUs
    {
        private byte functionCode = 2;
        public byte FunctionCode
        {
            get { return functionCode; }
            set { functionCode = value; }
        }

        private byte[] requestData = new byte[4];

        public byte[] RequestData
        {
            get { return requestData; }
            set { requestData = value; }
        }

        public int Length
        {
            get
            {
                return RequestData.Length + 1;
            }
        }
        public PDU(short startInx, short count)
        {
            requestData[0] = SplitShort(startInx).l;
            requestData[1] = SplitShort(startInx).r;
            requestData[2] = SplitShort(count).l;
            requestData[3] = SplitShort(count).r;
        }

        (byte l, byte r) SplitShort(short value)
        {
            (byte l, byte r) result = new();
            result.r = (byte)(value & 0xF);
            result.l = (byte)(value >> 8);
            return result;
        }
    }
}
