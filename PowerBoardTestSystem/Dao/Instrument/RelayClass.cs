using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace PowerBoardTestSystem.Dao
{
    public class RelayClass : InstrumentBaseClass
    {
        public static SerialPort port;

        public RelayClass():base()
        {

        }

        public RelayClass(int id) : base(Types.RELAY, id)
        {

        }

        public RelayClass(int id, string alias) : base(Types.RELAY, id, alias)
        {

        }

        public RelayClass(int id, SerialPort port) : base(Types.RELAY, id)
        {
            RelayClass.port = port;
        }

        public RelayClass(int id, string alias, SerialPort port) : base(Types.RELAY, id, alias)
        {
            RelayClass.port = port;
        }

        public static void Reset()
        {
        }

        public void Open(int deviceId)
        {
            //TODO open the relay by its id            
        }

        public void Close(int deviceId)
        {
            //TODO close the relay by its id
            //////
        }

        public static void writeport(string cmd, SerialPort port)
        {
            int i = 0;
            while (true)
            {
                port.Write(cmd + "\r\n");
                Thread.Sleep(500);
                if (port.ReadTo(cmd) != cmd)
                {
                    return;
                }
                else
                {
                    i++;
                    if (i == 3)
                    {
                        Console.WriteLine(cmd + " Failed, Timeout");
                        return;
                    }
                }
            }
        }
    }
}
