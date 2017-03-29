using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTModbus
{
    class IO
    {
        private static int currentID;

        protected int IOId { get; set; }
        protected string IOType { get; set; }

        protected int inputVal { get; set; }
        protected int outputVal { get; set; }

        protected short inputReg;
        protected short outputReg;

        public IO(short _inputReg,short _outputReg)
        {
            IOId = 0;
            IOType = "Unspecified";
            inputReg = _inputReg;
            outputReg = _outputReg;
        }
        static IO()
        {
            currentID = 0;
        }

        protected int getNextId()
        {
            return currentID++;
        }
        public virtual int GetOutputValue()
        {
            return outputVal;
        }
        public short InputRegister
        {
            get { return inputReg; }
            set { inputReg = value; }
        }
        public short OutputRegister
        {
            get { return outputReg; }
            set { outputReg = value; }
        }
    }

    class  analogIO : IO
    {
        private double maxV = 10;
        private double minV = -10;

        public analogIO(short _inputReg, short _outputReg) :base(_inputReg,_outputReg)
        {
            IOId = getNextId();
            IOType = "Analog";
            inputReg = _inputReg;
            outputReg = _outputReg;
        }

        public override int GetOutputValue()
        {
            return inputVal;
        }
    }
    class digitalIO : IO
    {
        private int high = 255;
        private int low = 0;

        public digitalIO(short _inputReg,short _outputReg) :base(_inputReg,_outputReg)
        {
            IOId = getNextId();
            IOType = "Digital";
            inputReg = _inputReg;
            outputReg = _outputReg;
        }
        public override int GetOutputValue()
        {
            if (inputVal >= 1) return high;
            else return low;
        }
    }
}
