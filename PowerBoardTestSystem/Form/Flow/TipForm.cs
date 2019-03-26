using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PowerBoardTestSystem.Dao;
using PowerBoardTestSystem.Service;

namespace PowerBoardTestSystem.Form.Flow
{
    public partial class TipForm : System.Windows.Forms.Form
    {
        private int flowId;
        public string dbpath;
        static SqLiteService sqs;

        public TipForm(string dbpath)
        {
            InitializeComponent();            
            this.dbpath = dbpath;
            sqs = new SqLiteService(dbpath);
            flowId = sqs.GetNewflowId("flow");
        }

        public TipForm(int flowId,string dbpath)
        {
            InitializeComponent();     
            this.dbpath = dbpath;
            sqs = new SqLiteService(dbpath);
            this.flowId = flowId;
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {            
            string tip = tb_tip.Text;
            if (tip != "")
            {
                OperateClass[] operate = { new OperateClass(Types.TIP.ToString(), tip) };
                string tipoperate = new JsonService().SetOperate(operate);
                FlowClass tipflow = new FlowClass(flowId, Types.TIP, tipoperate);
                sqs.InsertOrUpdateData("flow", tipflow);
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入提示语！");
            }
        }

        private void TipForm_Load(object sender, EventArgs e)
        {
            FlowClass delayflow = new FlowClass();
            delayflow.flowId = flowId;
            delayflow.type = Types.TIP;
            FlowClass delayresult = sqs.selectflow("flow", delayflow);
            OperateClass[] operate = new JsonService().GetOperate(delayresult.operates);
            tb_tip.Text = operate[0].operate;
        }
    }
}
