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

        protected ushort inputReg;
        protected ushort outputReg;

        public IO(ushort _inputReg,ushort _outputReg)
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
        public ushort InputRegister
        {
            get { return inputReg; }
            set { inputReg = value; }
        }
        public ushort OutputRegister
        {
            get { return outputReg; }
            set { outputReg = value; }
        }
        public int InputValue
        {
            get { return inputVal; }
            set { inputVal = value; }
        }
    }

    class  analogIO : IO
    {
        private double maxV = 10;
        private double minV = -10;

        public analogIO(ushort _inputReg, ushort _outputReg) :base(_inputReg,_outputReg)
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

        public digitalIO(ushort _inputReg,ushort _outputReg) :base(_inputReg,_outputReg)
        {
            IOId = getNextId();
            IOType = "Digital";
            inputReg = _inputReg;
            outputReg = _outputReg;
        }
        public override int GetOutputValue()
        {
            if (inputVal >= 1) return low;
            else return high;
        }
    }
}
