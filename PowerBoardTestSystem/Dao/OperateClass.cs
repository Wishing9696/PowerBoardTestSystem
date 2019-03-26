using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerBoardTestSystem.Service;

namespace PowerBoardTestSystem.Dao
{
    class OperateClass
    {
        public int deviceId;
        public string operate;
        public string alias;

        public OperateClass()
        {

        }

        public OperateClass(string alias,string operate)
        {
            this.alias = alias;
            this.operate = operate;

        }

        public OperateClass(int deviceId, string operate,Types type ,string dbpath)
        {
            SqLiteService sqs = new SqLiteService(dbpath);
            this.deviceId = deviceId;
            this.alias = sqs.Selectalias("device", deviceId, type,"alias");
            this.operate = operate;
        }

        public OperateClass(string alias, string dbpath, string operate,Types type)
        {
            SqLiteService sqs = new SqLiteService(dbpath);
            this.deviceId = sqs.SelectdeviceId("device", alias,type, "deviceId");
            this.alias = alias;
            this.operate = operate;
        }

        public override string ToString()
        {
            return this.alias + "," + this.operate;
        }

    }
}
