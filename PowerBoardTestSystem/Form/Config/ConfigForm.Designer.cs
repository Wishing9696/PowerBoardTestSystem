namespace PowerBoardTestSystem.Form.Config
{
    partial class ConfigForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.控制器属性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_relayProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_measureChannelProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btn_addRelayFlow = new System.Windows.Forms.Button();
            this.btn_addMeasureFlow = new System.Windows.Forms.Button();
            this.btn_addDelayFlow = new System.Windows.Forms.Button();
            this.btn_addAlertFlow = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.bt_update = new System.Windows.Forms.Button();
            this.bt_del = new System.Windows.Forms.Button();
            this.bt_up = new System.Windows.Forms.Button();
            this.bt_down = new System.Windows.Forms.Button();
            this.floderchoose = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.控制器属性ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 控制器属性ToolStripMenuItem
            // 
            this.控制器属性ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_relayProperty,
            this.tsmi_measureChannelProperty});
            this.控制器属性ToolStripMenuItem.Name = "控制器属性ToolStripMenuItem";
            this.控制器属性ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.控制器属性ToolStripMenuItem.Text = "控制器属性";
            // 
            // tsmi_relayProperty
            // 
            this.tsmi_relayProperty.Name = "tsmi_relayProperty";
            this.tsmi_relayProperty.Size = new System.Drawing.Size(148, 22);
            this.tsmi_relayProperty.Text = "继电器属性";
            this.tsmi_relayProperty.Click += new System.EventHandler(this.tsmi_relayProperty_Click);
            // 
            // tsmi_measureChannelProperty
            // 
            this.tsmi_measureChannelProperty.Name = "tsmi_measureChannelProperty";
            this.tsmi_measureChannelProperty.Size = new System.Drawing.Size(148, 22);
            this.tsmi_measureChannelProperty.Text = "测量通道属性";
            this.tsmi_measureChannelProperty.Click += new System.EventHandler(this.tsmi_measureChannelProperty_Click);
            // 
            // listView1
            // 
            this.listView1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.Location = new System.Drawing.Point(23, 28);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1019, 485);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            // 
            // btn_addRelayFlow
            // 
            this.btn_addRelayFlow.Location = new System.Drawing.Point(23, 519);
            this.btn_addRelayFlow.Name = "btn_addRelayFlow";
            this.btn_addRelayFlow.Size = new System.Drawing.Size(199, 35);
            this.btn_addRelayFlow.TabIndex = 2;
            this.btn_addRelayFlow.Text = "添加继电器流程";
            this.btn_addRelayFlow.UseVisualStyleBackColor = true;
            this.btn_addRelayFlow.Click += new System.EventHandler(this.btn_addRelayFlow_Click);
            // 
            // btn_addMeasureFlow
            // 
            this.btn_addMeasureFlow.Location = new System.Drawing.Point(228, 519);
            this.btn_addMeasureFlow.Name = "btn_addMeasureFlow";
            this.btn_addMeasureFlow.Size = new System.Drawing.Size(199, 35);
            this.btn_addMeasureFlow.TabIndex = 3;
            this.btn_addMeasureFlow.Text = "添加测量流程";
            this.btn_addMeasureFlow.UseVisualStyleBackColor = true;
            this.btn_addMeasureFlow.Click += new System.EventHandler(this.btn_addMeasureFlow_Click);
            // 
            // btn_addDelayFlow
            // 
            this.btn_addDelayFlow.Location = new System.Drawing.Point(433, 519);
            this.btn_addDelayFlow.Name = "btn_addDelayFlow";
            this.btn_addDelayFlow.Size = new System.Drawing.Size(199, 35);
            this.btn_addDelayFlow.TabIndex = 4;
            this.btn_addDelayFlow.Text = "添加延时流程";
            this.btn_addDelayFlow.UseVisualStyleBackColor = true;
            this.btn_addDelayFlow.Click += new System.EventHandler(this.btn_addDelayFlow_Click);
            // 
            // btn_addAlertFlow
            // 
            this.btn_addAlertFlow.Location = new System.Drawing.Point(638, 519);
            this.btn_addAlertFlow.Name = "btn_addAlertFlow";
            this.btn_addAlertFlow.Size = new System.Drawing.Size(199, 35);
            this.btn_addAlertFlow.TabIndex = 5;
            this.btn_addAlertFlow.Text = "添加提示流程";
            this.btn_addAlertFlow.UseVisualStyleBackColor = true;
            this.btn_addAlertFlow.Click += new System.EventHandler(this.btn_addAlertFlow_Click);
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(843, 533);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(199, 35);
            this.bt_save.TabIndex = 6;
            this.bt_save.Text = "保存";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // bt_update
            // 
            this.bt_update.Location = new System.Drawing.Point(23, 558);
            this.bt_update.Name = "bt_update";
            this.bt_update.Size = new System.Drawing.Size(199, 35);
            this.bt_update.TabIndex = 7;
            this.bt_update.Text = "修改此子流程";
            this.bt_update.UseVisualStyleBackColor = true;
            this.bt_update.Click += new System.EventHandler(this.bt_update_Click);
            // 
            // bt_del
            // 
            this.bt_del.Location = new System.Drawing.Point(228, 558);
            this.bt_del.Name = "bt_del";
            this.bt_del.Size = new System.Drawing.Size(199, 35);
            this.bt_del.TabIndex = 8;
            this.bt_del.Text = "删除此子流程";
            this.bt_del.UseVisualStyleBackColor = true;
            this.bt_del.Click += new System.EventHandler(this.bt_del_Click);
            // 
            // bt_up
            // 
            this.bt_up.Location = new System.Drawing.Point(433, 558);
            this.bt_up.Name = "bt_up";
            this.bt_up.Size = new System.Drawing.Size(199, 35);
            this.bt_up.TabIndex = 9;
            this.bt_up.Text = "上移";
            this.bt_up.UseVisualStyleBackColor = true;
            this.bt_up.Click += new System.EventHandler(this.bt_up_Click);
            // 
            // bt_down
            // 
            this.bt_down.Location = new System.Drawing.Point(638, 558);
            this.bt_down.Name = "bt_down";
            this.bt_down.Size = new System.Drawing.Size(199, 35);
            this.bt_down.TabIndex = 10;
            this.bt_down.Text = "下移";
            this.bt_down.UseVisualStyleBackColor = true;
            this.bt_down.Click += new System.EventHandler(this.bt_down_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1067, 603);
            this.Controls.Add(this.bt_down);
            this.Controls.Add(this.bt_up);
            this.Controls.Add(this.bt_del);
            this.Controls.Add(this.bt_update);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.btn_addAlertFlow);
            this.Controls.Add(this.btn_addDelayFlow);
            this.Controls.Add(this.btn_addMeasureFlow);
            this.Controls.Add(this.btn_addRelayFlow);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConfigForm";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.Shown += new System.EventHandler(this.ConfigForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 控制器属性ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_relayProperty;
        private System.Windows.Forms.ToolStripMenuItem tsmi_measureChannelProperty;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btn_addRelayFlow;
        private System.Windows.Forms.Button btn_addMeasureFlow;
        private System.Windows.Forms.Button btn_addDelayFlow;
        private System.Windows.Forms.Button btn_addAlertFlow;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Button bt_update;
        private System.Windows.Forms.Button bt_del;
        private System.Windows.Forms.Button bt_up;
        private System.Windows.Forms.Button bt_down;
        private System.Windows.Forms.FolderBrowserDialog floderchoose;
    }
}