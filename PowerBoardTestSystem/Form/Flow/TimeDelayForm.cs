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
    public partial class TimeDelayForm : System.Windows.Forms.Form
    {
        private int flowId;

        public string dbpath;
        static SqLiteService sqs;

        public TimeDelayForm(string dbpath)
        {
            InitializeComponent();
            this.dbpath = dbpath;
            sqs = new SqLiteService(dbpath);
            flowId = sqs.GetNewflowId("flow");
        }

        public TimeDelayForm(int flowId, string dbpath)
        {
            InitializeComponent();
            this.dbpath = dbpath;
            sqs = new SqLiteService(dbpath);
            this.flowId = flowId;
        }

        private void TimeDelayForm_Load(object sender, EventArgs e)
        {
            FlowClass delayflow = new FlowClass();
            delayflow.flowId = flowId;
            delayflow.type = Types.TIMEDELAY;
            FlowClass delayresult = sqs.selectflow("flow", delayflow);
            OperateClass[] operate = new JsonService().GetOperate(delayresult.operates);
            tb_time.Text = (Convert.ToInt32(operate[0].operate) / 1000).ToString();
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            if (IsNumber(tb_time.Text))
            {                
                int delay = Convert.ToInt32(tb_time.Text) * 1000;
                OperateClass[] operate = { new OperateClass(Types.TIMEDELAY.ToString(), delay.ToString()) };
                string delayoperate = new JsonService().SetOperate(operate);
                FlowClass delayflow = new FlowClass(flowId, Types.TIMEDELAY, delayoperate);
                sqs.InsertOrUpdateData("flow", delayflow);
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入需要延时的秒数");
            }
        }

        private bool IsNumber(string message)
        {
            try
            {
                int result = Convert.ToInt32(message);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
