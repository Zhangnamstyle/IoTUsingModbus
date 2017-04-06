using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Collections;

namespace IoTModbus
{
    
    class ComHandler 
    {        
        // ------------------------------------------------------------------------
        // Private declarations
        private ModbusTCP modbusTCP;
        private Report report;

        private static string username;
        private static int userId;

        private static bool connected;

        // ------------------------------------------------------------------------
        // Supported Modbus Exeption Codes
        private const byte exIllegalFunction = 1;
        private const byte exIllegalDataAddress = 2;
        private const byte exIllegalDataValue = 3;
        private const byte exSlaveDeviceFailure = 4;
        private const byte exAcknowledge = 5;
        private const byte exSlaveDeviceBusy = 6;
        private const byte exMemoryParityError = 8;
        private const byte exGatewayPathUnavailable = 10;
        private const byte exGatewayTargetNoResponse = 11;
        private const byte exTimeout = 12;
        private const byte transactionTimeout = 0;

        // ------------------------------------------------------------------------
        /// <summary>Exception data event. This event is called when the data is incorrect</summary>
        public delegate void ExceptionData(ushort id, byte unit, byte function, string exMessage);
        /// <summary>Exception data event. This event is called when the data is incorrect</summary>
        public event ExceptionData OnException;
        /// <summary>Response data event. This event is called when new data arrives</summary>
        public delegate void ResponseData(ushort id, byte unit, byte function, byte[] data,byte[] adu,ushort startAddress,ushort lenght);
        /// <summary>Response data event. This event is called when new data arrives</summary>
        public event ResponseData OnResponseData;
        /// <summary>Response data event. This event is called when new data arrives</summary>
        public delegate void OutData(byte[] adu);
        /// <summary>Response data event. This event is called when new data arrives</summary>
        public event OutData OnOutData;
        /// <summary>Response data event. This event is called when new data arrives</summary>
        public delegate void ErrorData(Exception ex);
        /// <summary>Response data event. This event is called when new data arrives</summary>
        public event ErrorData OnError;

        // ------------------------------------------------------------------------
        /// <summary>Constructor for Report class</summary>
        /// <param name="_username
        public ComHandler(string _username,int _userId)
        {
                username = _username;
                userId = _userId;
                report = new Report();
                report.OpenTime = DateTime.Now;   
        }

        // ------------------------------------------------------------------------
        /// <summary>Connects to the Modbus slave</summary>
        public void connect(string ip,ushort port)
        {
            try
            {
                modbusTCP = new ModbusTCP(ip, port, report);
                modbusTCP.OnResponseDataTCP += new ModbusTCP.ResponseDataTCP(ModbusTCP_OnResponseData);
                modbusTCP.OnExceptionTCP += new ModbusTCP.ExceptionDataTCP(ModbusTCP_OnException);
                modbusTCP.OnOutgoingDataTCP += new ModbusTCP.OutgoingDataTCP(ModbusTCP_OnOutgoingData);
                connected = true;
            }
            catch(Exception ex)
            {
                connected = false;
                disconnect();
                OnError(ex);
            }
        }

        private void ModbusTCP_OnOutgoingData(byte[] adu)
        {
            OnOutData(adu);
        }

        private void ModbusTCP_OnException(ushort id, byte unit, byte function, byte exception)
        {
            string exM = exMessage(exception);
            if(exception != transactionTimeout) report.recordException(id, function, exception, exM);
            disconnect();
            if (OnException != null) OnException(id, unit, function, exM);
        }

        private void ModbusTCP_OnResponseData(ushort id, byte unit, byte function, byte[] data,byte[] adu,ushort startAddress,ushort lenght)
        {
            if (OnResponseData != null) OnResponseData(id, unit, function, data,adu,startAddress,lenght);
        }

        // ------------------------------------------------------------------------
        /// <summary>Disconnect from the Modbus slave</summary>
        public void disconnect()
        {
            connected = false;
            if (modbusTCP != null)
            {
                modbusTCP.disconnect();
                modbusTCP = null;
            }
        }

        // ------------------------------------------------------------------------
        /// <summary>Sends a write message to IoT Device </summary>
        /// <param name="funcNr">Modbus Function Code.</param>
        /// <param name="tId">Transaction Id. This needs to be unique</param>
        /// <param name="unit"></param>
        /// <param name="startAddress"></param>
        /// <param name="numBits"></param>
        /// <param name="values"></param>
        public void send(byte funcNr, ushort tId, byte unit, ushort startAddress, ushort numBits, byte[] values)
        {
            if (connected)
            {
                try
                {
                    if ((funcNr == 6 && startAddress >= 100) || (funcNr == 16 && startAddress >= 99))
                    {
                        throw new System.ArgumentException("Can't write to holding register above register 99", "startAddress");
                    }
                    modbusTCP.sendTCP(funcNr, tId, unit, startAddress, numBits, values);
                }
                catch (Exception ex)
                {
                    disconnect();
                    if(OnError != null) OnError(ex);
                }
            }
            
        }

        // ------------------------------------------------------------------------
        /// <summary>Sends a read message to IoT Device </summary>
        /// <param name="funcNr">Modbus Function Code.</param>
        /// <param name="tId">Transaction Id. This needs to be unique</param>
        /// <param name="unit"></param>
        /// <param name="startAddress"></param>
        /// <param name="numBits"></param>
        /// <param name="values"></param>
        public void send(byte funcNr, ushort tId, byte unit, ushort startAddress, ushort numInputs)
        {
            if (connected)
            { 
                try
                {
                    modbusTCP.sendTCP(funcNr, tId, unit, startAddress, numInputs);
                }
                catch (Exception ex)
                {
                    disconnect();
                    OnError(ex);
                }
            }   
        }

        public void reportSlaveID(byte tId,byte unit)
        {
            try
            {
                modbusTCP.reportSlaveID(tId, unit);
            }
            catch(Exception ex)
            {
                disconnect();
                OnError(ex);
            }
        }
        public void generateReport()
        {
            try
            {
                report.CloseTime = DateTime.Now;
                report.generateReport();
            }
            catch (Exception ex)
            {
                disconnect();
                OnError(ex);
            }
        }
        public static string Username
        {
            get { return username; }
        }
        public static int UserId
        {
            get { return userId; }
        }
        public static bool Connected
        {
            get { return connected; }
        }
        // ------------------------------------------------------------------------
        /// <summary>Returns the exeption type </summary>
        /// <param name="FuncEx">Modbus Exeption Code.</param>
        private string exMessage(byte funcEx)
        {
            string ex;
            switch (funcEx)
            {
                case exIllegalFunction:
                    ex = "Illegal Function";
                    break;
                case exIllegalDataAddress:
                    ex = "Illegal Data Address";
                    break;
                case exIllegalDataValue:
                    ex = "Illegal Data Value";
                    break;
                case exSlaveDeviceFailure:
                    ex = "Slave Devie Failure";
                    break;
                case exAcknowledge:
                    ex = "Acknowledge";
                    break;
                case exSlaveDeviceBusy:
                    ex = "Slave Device Busy";
                    break;
                case exMemoryParityError:
                    ex = "Memory Parity Error";
                    break;
                case exGatewayPathUnavailable:
                    ex = "Gateway Path Unavailable";
                    break;
                case exGatewayTargetNoResponse:
                    ex = "Gateway Target Device Failed to Respond";
                    break;
                case transactionTimeout:
                    ex = "Transaction timed out";
                    break;
                default:
                    ex = "Unkown Exeption Code";
                    break;
            }

            return ex;
        }

    }
}
