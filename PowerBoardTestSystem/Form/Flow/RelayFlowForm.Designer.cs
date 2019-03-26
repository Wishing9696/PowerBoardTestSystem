namespace PowerBoardTestSystem.Form.Flow
{
    partial class RelayFlowForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cb_relay = new System.Windows.Forms.ComboBox();
            this.cb_action = new System.Windows.Forms.ComboBox();
            this.bt_ok = new System.Windows.Forms.Button();
            this.bt_add = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_reset = new System.Windows.Forms.CheckBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.bt_up = new System.Windows.Forms.Button();
            this.bt_down = new System.Windows.Forms.Button();
            this.bt_del = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_relay
            // 
            this.cb_relay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_relay.FormattingEnabled = true;
            this.cb_relay.Location = new System.Drawing.Point(341, 70);
            this.cb_relay.Name = "cb_relay";
            this.cb_relay.Size = new System.Drawing.Size(121, 20);
            this.cb_relay.TabIndex = 0;
            // 
            // cb_action
            // 
            this.cb_action.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_action.FormattingEnabled = true;
            this.cb_action.Location = new System.Drawing.Point(377, 112);
            this.cb_action.Name = "cb_action";
            this.cb_action.Size = new System.Drawing.Size(85, 20);
            this.cb_action.TabIndex = 1;
            // 
            // bt_ok
            // 
            this.bt_ok.Location = new System.Drawing.Point(272, 284);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(190, 42);
            this.bt_ok.TabIndex = 2;
            this.bt_ok.Text = "完成";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(272, 150);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(190, 36);
            this.bt_add.TabIndex = 5;
            this.bt_add.Text = "添加";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "选择继电器";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "选择该继电器状态";
            // 
            // cb_reset
            // 
            this.cb_reset.AutoSize = true;
            this.cb_reset.Location = new System.Drawing.Point(272, 27);
            this.cb_reset.Name = "cb_reset";
            this.cb_reset.Size = new System.Drawing.Size(192, 16);
            this.cb_reset.TabIndex = 8;
            this.cb_reset.Text = "此流程开始之前重置所有继电器";
            this.cb_reset.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(237, 314);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            // 
            // bt_up
            // 
            this.bt_up.Location = new System.Drawing.Point(272, 231);
            this.bt_up.Name = "bt_up";
            this.bt_up.Size = new System.Drawing.Size(91, 47);
            this.bt_up.TabIndex = 10;
            this.bt_up.Text = "上移";
            this.bt_up.UseVisualStyleBackColor = true;
            this.bt_up.Click += new System.EventHandler(this.bt_up_Click);
            // 
            // bt_down
            // 
            this.bt_down.Location = new System.Drawing.Point(371, 231);
            this.bt_down.Name = "bt_down";
            this.bt_down.Size = new System.Drawing.Size(93, 47);
            this.bt_down.TabIndex = 11;
            this.bt_down.Text = "下移";
            this.bt_down.UseVisualStyleBackColor = true;
            this.bt_down.Click += new System.EventHandler(this.bt_down_Click);
            // 
            // bt_del
            // 
            this.bt_del.Location = new System.Drawing.Point(272, 192);
            this.bt_del.Name = "bt_del";
            this.bt_del.Size = new System.Drawing.Size(190, 33);
            this.bt_del.TabIndex = 12;
            this.bt_del.Text = "删除";
            this.bt_del.UseVisualStyleBackColor = true;
            this.bt_del.Click += new System.EventHandler(this.bt_del_Click);
            // 
            // RelayFlowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 338);
            this.Controls.Add(this.bt_del);
            this.Controls.Add(this.bt_down);
            this.Controls.Add(this.bt_up);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.cb_reset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_add);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.cb_action);
            this.Controls.Add(this.cb_relay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "RelayFlowForm";
            this.Text = "RelayFlowForm";
            this.Load += new System.EventHandler(this.RelayFlowForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_relay;
        private System.Windows.Forms.ComboBox cb_action;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cb_reset;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button bt_up;
        private System.Windows.Forms.Button bt_down;
        private System.Windows.Forms.Button bt_del;
    }
}