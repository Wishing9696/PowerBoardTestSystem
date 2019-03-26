using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace PowerBoardTestSystem.Dao
{
    class ElectricmeterClass : InstrumentBaseClass
    {
        public static SerialPort port;
        public ElectricmeterClass() : base()
        {

        }

        public ElectricmeterClass(int id) : base(Types.ELECTRICMETER, id)
        {

        }

        public ElectricmeterClass(int id, string alias) : base(Types.ELECTRICMETER, id, alias)
        {

        }

        public ElectricmeterClass(int id, SerialPort port) : base(Types.ELECTRICMETER, id)
        {
            ElectricmeterClass.port = port;
        }

        public ElectricmeterClass(int id, string alias, SerialPort port) : base(Types.ELECTRICMETER, id, alias)
        {
            ElectricmeterClass.port = port;
        }



        public void Read()
        {
            //TODO read the electricmeter by its id
        }

        public void Open()
        {
            //TODO open the electricmeter by its id
        }

        public void Close()
        {
            //TODO close the electricmeter by its id
        }
    }
}
