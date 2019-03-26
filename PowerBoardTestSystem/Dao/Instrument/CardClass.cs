using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace PowerBoardTestSystem.Dao
{
    class CardClass : InstrumentBaseClass
    {
        public static SerialPort port;

        public CardClass():base()
        {

        }

        public CardClass(int id) : base(Types.CARD, id)
        {

        }

        public CardClass(int id, string alias) : base(Types.CARD, id, alias)
        {

        }

        public CardClass(int id, SerialPort port) : base(Types.CARD, id)
        {
            CardClass.port = port;
        }

        public CardClass(int id, string alias, SerialPort port) : base(Types.CARD, id, alias)
        {
            CardClass.port = port;
        }

        public void Read()
        {
            //TODO read the voltcard by its id
        }

        public void Open()
        {
            //TODO open the voltcard by its id
        }

        public void Close()
        {
            //TODO close the voltcard by its id
        }
    }
}
