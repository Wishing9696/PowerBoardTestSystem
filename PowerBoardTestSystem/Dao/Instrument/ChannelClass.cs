using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace PowerBoardTestSystem.Dao
{
    class ChannelClass : InstrumentBaseClass
    {
        public static SerialPort port;


        public ChannelClass() : base()
        {

        }

        public ChannelClass(int id) : base(Types.CHANNEL, id)
        {

        }

        public ChannelClass(int id, string alias) : base(Types.CHANNEL, id, alias)
        {

        }
        public ChannelClass(int id, SerialPort port) : base(Types.CHANNEL, id)
        {
            ChannelClass.port = port;
        }

        public ChannelClass(int id, string alias, SerialPort port) : base(Types.CHANNEL, id, alias)
        {
            ChannelClass.port = port;
        }

        public static void Reset()
        {

        }

        public void Open(int id)
        {
            //TODO open the relay by its id
        }

        public void Close(int id)
        {
            //TODO close the relay by its id
        }
    }
}
