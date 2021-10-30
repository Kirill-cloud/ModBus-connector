using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBus_connector
{
    public class ModBusPackage
    {
        private byte[] transactionId = new byte[2];
        public byte[] TransactionId
        {
            get { return transactionId; }
            set { transactionId = value; }
        }

        private byte[] protocolId = new byte[2];
        public byte[] ProtocolId
        {
            get { return protocolId; }
            set { protocolId = value; }
        }

        private byte[] dataSize = new byte[2];
        public byte[] DataSize
        {
            get { return dataSize; }
            set { dataSize = value; }
        }

        private byte slaveId;
        public byte SlaveId
        {
            get { return slaveId; }
            set { slaveId = value; }
        }

        private PDU pdu = new(0,1);
        public PDU PDU
        {
            get { return pdu; }
            set { pdu = value; }
        }
        public ModBusPackage()
        {

        }

        public ModBusPackage(byte[] byteArrayEq)
        {
            Array.Copy(byteArrayEq, 0, transactionId, 0, transactionId.Length);
            Array.Copy(byteArrayEq, 2, protocolId, 0, protocolId.Length);
            Array.Copy(byteArrayEq, 4, dataSize, 0, dataSize.Length);
            slaveId = byteArrayEq[6];
            pdu.FunctionCode = byteArrayEq[7];

            pdu.RequestData = new byte[ToBytesToShort(dataSize[0], dataSize[1]) - 1];
            Array.Copy(byteArrayEq, 8, pdu.RequestData, 0, pdu.RequestData.Length - 1);
        }

        short ToBytesToShort(byte left, byte right)
        {
            short result = left;
            result = (short)(result << 8);
            result += right;
            return result;
        }

        public byte[] GetPackage()
        {
            byte[] result = new byte[7 + pdu.Length];
            Array.Copy(transactionId, 0, result, 0, transactionId.Length);
            Array.Copy(protocolId, 0, result, 2, protocolId.Length);
            Array.Copy(dataSize, 0, result, 4, dataSize.Length);
            result[6] = slaveId;
            result[7] = pdu.FunctionCode;
            Array.Copy(pdu.RequestData, 0, result, 8, pdu.RequestData.Length);
            return result;
        }
    }
}
