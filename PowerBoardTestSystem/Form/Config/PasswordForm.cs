using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerBoardTestSystem.Form.Config
{
    public partial class PasswordForm : System.Windows.Forms.Form
    {
        public PasswordForm()
        {
            InitializeComponent();
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            if(tb_password.Text !="123456")
            {
                lb_result.Text = "密码错误！";
                DialogResult = DialogResult.No;
            }
            else
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void cb_show_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_show.Checked)
            {
                tb_password.PasswordChar = '\0';
            }
            else
            {
                tb_password.PasswordChar = '*';
            }
        }

        private void PasswordForm_Load(object sender, EventArgs e)
        {
            tb_password.PasswordChar = '*';
        }
    }
}
