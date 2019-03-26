using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerBoardTestSystem.Dao
{
    class FlowClass
    {
        public int flowId;
        public Types type;
        public string operates;

        public FlowClass(int flowId, Types type, string operates)
        {
            this.flowId = flowId;
            this.type = type;
            this.operates = operates;
        }

         public FlowClass()
        {

        }

    }
}
