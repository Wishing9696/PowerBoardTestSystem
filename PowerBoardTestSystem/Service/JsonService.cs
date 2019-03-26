using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using PowerBoardTestSystem.Dao;


namespace PowerBoardTestSystem.Service
{
    class JsonService
    {
        string jsonstring;

        public JsonService()
        {

        }

        public JsonService(string jsonstring)
        {
            this.jsonstring = jsonstring;
        }

        public OperateClass[] GetOperate()
        {
            OperateClass[] operates = JsonConvert.DeserializeObject<OperateClass[]>(jsonstring);
            return operates;
        }

        public OperateClass[] GetOperate(string jsonstring)
        {
            OperateClass[] operates = JsonConvert.DeserializeObject<OperateClass[]>(jsonstring);
            return operates;
        }

        public string SetOperate(OperateClass[] operates)
        {
            string strJson = JsonConvert.SerializeObject(operates);
            return strJson;
        }
    }


}
