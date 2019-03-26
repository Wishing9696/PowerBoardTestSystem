using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace PowerBoardTestSystem.Dao
{
    public abstract class InstrumentBaseClass
    {
        public Types type;
        public string alias;
        public int deviceId;     

        public InstrumentBaseClass()
        {

        }

        public InstrumentBaseClass(Types type, int deviceId)
        {
            this.type = type;
            this.deviceId = deviceId;
            this.alias = type.ToString() + deviceId;
        }

        public InstrumentBaseClass(Types type, int deviceId, string alias)
        {
            this.type = type;
            this.deviceId = deviceId;
            this.alias = alias;
        }

    }
}
