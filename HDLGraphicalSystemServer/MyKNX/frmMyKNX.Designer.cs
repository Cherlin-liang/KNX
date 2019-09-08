namespace HDLGraphicalSystemServer
{
    partial class frmMyKNX
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.num3 = new System.Windows.Forms.NumericUpDown();
            this.num2 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.num1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.DeviceType = new System.Windows.Forms.ComboBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbTemp = new System.Windows.Forms.Label();
            this.temp = new System.Windows.Forms.NumericUpDown();
            this.CbSpeed = new System.Windows.Forms.ComboBox();
            this.lbSpeed = new System.Windows.Forms.Label();
            this.lbModel = new System.Windows.Forms.Label();
            this.CbModel = new System.Windows.Forms.ComboBox();
            this.lbCurtain = new System.Windows.Forms.Label();
            this.CbCurtainEdit = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSwitch = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dgvKNX = new System.Windows.Forms.DataGridView();
            this.DevicesType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKNX)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.dgvKNX);
            this.groupBox1.Controls.Add(this.num3);
            this.groupBox1.Controls.Add(this.num2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.num1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DeviceType);
            this.groupBox1.Controls.Add(this.btnShow);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(925, 523);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // num3
            // 
            this.num3.Location = new System.Drawing.Point(237, 40);
            this.num3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.num3.Name = "num3";
            this.num3.Size = new System.Drawing.Size(47, 21);
            this.num3.TabIndex = 19;
            this.num3.ValueChanged += new System.EventHandler(this.Num1_ValueChanged);
            // 
            // num2
            // 
            this.num2.Location = new System.Drawing.Point(173, 40);
            this.num2.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.num2.Name = "num2";
            this.num2.Size = new System.Drawing.Size(47, 21);
            this.num2.TabIndex = 18;
            this.num2.ValueChanged += new System.EventHandler(this.Num1_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "Group Address";
            // 
            // num1
            // 
            this.num1.Location = new System.Drawing.Point(108, 40);
            this.num1.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.num1.Name = "num1";
            this.num1.Size = new System.Drawing.Size(47, 21);
            this.num1.TabIndex = 16;
            this.num1.ValueChanged += new System.EventHandler(this.Num1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "Devices";
            // 
            // DeviceType
            // 
            this.DeviceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeviceType.FormattingEnabled = true;
            this.DeviceType.Items.AddRange(new object[] {
            "Light",
            "Curtain",
            "Air Conditioning"});
            this.DeviceType.Location = new System.Drawing.Point(108, 81);
            this.DeviceType.Name = "DeviceType";
            this.DeviceType.Size = new System.Drawing.Size(121, 20);
            this.DeviceType.TabIndex = 13;
            this.DeviceType.SelectedIndexChanged += new System.EventHandler(this.DeviceType_SelectedIndexChanged);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(566, 167);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(94, 23);
            this.btnShow.TabIndex = 10;
            this.btnShow.Text = "ClearList";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Location = new System.Drawing.Point(298, 20);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(621, 141);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.RichTextBox1_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.lbTemp);
            this.groupBox2.Controls.Add(this.temp);
            this.groupBox2.Controls.Add(this.CbSpeed);
            this.groupBox2.Controls.Add(this.lbSpeed);
            this.groupBox2.Controls.Add(this.lbModel);
            this.groupBox2.Controls.Add(this.CbModel);
            this.groupBox2.Controls.Add(this.lbCurtain);
            this.groupBox2.Controls.Add(this.CbCurtainEdit);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.btnSend);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbSwitch);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 400);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SendData";
            // 
            // lbTemp
            // 
            this.lbTemp.AutoSize = true;
            this.lbTemp.Location = new System.Drawing.Point(21, 221);
            this.lbTemp.Name = "lbTemp";
            this.lbTemp.Size = new System.Drawing.Size(65, 12);
            this.lbTemp.TabIndex = 22;
            this.lbTemp.Text = "TempSelect";
            // 
            // temp
            // 
            this.temp.Location = new System.Drawing.Point(98, 219);
            this.temp.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.temp.Minimum = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.temp.Name = "temp";
            this.temp.Size = new System.Drawing.Size(57, 21);
            this.temp.TabIndex = 21;
            this.temp.Value = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.temp.ValueChanged += new System.EventHandler(this.Temp_ValueChanged);
            // 
            // CbSpeed
            // 
            this.CbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbSpeed.FormattingEnabled = true;
            this.CbSpeed.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "High",
            "Auto",
            "Stop"});
            this.CbSpeed.Location = new System.Drawing.Point(98, 162);
            this.CbSpeed.Name = "CbSpeed";
            this.CbSpeed.Size = new System.Drawing.Size(121, 20);
            this.CbSpeed.TabIndex = 20;
            // 
            // lbSpeed
            // 
            this.lbSpeed.AutoSize = true;
            this.lbSpeed.Location = new System.Drawing.Point(21, 165);
            this.lbSpeed.Name = "lbSpeed";
            this.lbSpeed.Size = new System.Drawing.Size(65, 12);
            this.lbSpeed.TabIndex = 19;
            this.lbSpeed.Text = "SpeedModel";
            // 
            // lbModel
            // 
            this.lbModel.AutoSize = true;
            this.lbModel.Location = new System.Drawing.Point(27, 113);
            this.lbModel.Name = "lbModel";
            this.lbModel.Size = new System.Drawing.Size(35, 12);
            this.lbModel.TabIndex = 18;
            this.lbModel.Text = "Model";
            // 
            // CbModel
            // 
            this.CbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbModel.FormattingEnabled = true;
            this.CbModel.Items.AddRange(new object[] {
            "Cool",
            "Fan",
            "Heat",
            "Auto"});
            this.CbModel.Location = new System.Drawing.Point(98, 110);
            this.CbModel.Name = "CbModel";
            this.CbModel.Size = new System.Drawing.Size(121, 20);
            this.CbModel.TabIndex = 17;
            // 
            // lbCurtain
            // 
            this.lbCurtain.AutoSize = true;
            this.lbCurtain.Location = new System.Drawing.Point(27, 77);
            this.lbCurtain.Name = "lbCurtain";
            this.lbCurtain.Size = new System.Drawing.Size(47, 12);
            this.lbCurtain.TabIndex = 16;
            this.lbCurtain.Text = "UP/Down";
            // 
            // CbCurtainEdit
            // 
            this.CbCurtainEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbCurtainEdit.FormattingEnabled = true;
            this.CbCurtainEdit.Items.AddRange(new object[] {
            "UP",
            "Down"});
            this.CbCurtainEdit.Location = new System.Drawing.Point(98, 69);
            this.CbCurtainEdit.Name = "CbCurtainEdit";
            this.CbCurtainEdit.Size = new System.Drawing.Size(121, 20);
            this.CbCurtainEdit.TabIndex = 15;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(74, 287);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(204, 21);
            this.textBox1.TabIndex = 14;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(102, 337);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(111, 27);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "OFF/ON";
            // 
            // cbSwitch
            // 
            this.cbSwitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSwitch.FormattingEnabled = true;
            this.cbSwitch.Items.AddRange(new object[] {
            "on",
            "off"});
            this.cbSwitch.Location = new System.Drawing.Point(98, 37);
            this.cbSwitch.Name = "cbSwitch";
            this.cbSwitch.Size = new System.Drawing.Size(121, 20);
            this.cbSwitch.TabIndex = 11;
            this.cbSwitch.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "ExtraData:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // dgvKNX
            // 
            this.dgvKNX.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvKNX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKNX.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DevicesType,
            this.Column2,
            this.Column1,
            this.Column4,
            this.Column3,
            this.Column5,
            this.Column6});
            this.dgvKNX.EnableHeadersVisualStyles = false;
            this.dgvKNX.Location = new System.Drawing.Point(298, 194);
            this.dgvKNX.Name = "dgvKNX";
            this.dgvKNX.ReadOnly = true;
            this.dgvKNX.RowHeadersVisible = false;
            this.dgvKNX.RowTemplate.Height = 23;
            this.dgvKNX.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKNX.Size = new System.Drawing.Size(621, 308);
            this.dgvKNX.TabIndex = 20;
            // 
            // DevicesType
            // 
            this.DevicesType.HeaderText = "Module";
            this.DevicesType.Name = "DevicesType";
            this.DevicesType.ReadOnly = true;
            this.DevicesType.Width = 60;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "PhysicalAddress";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "GroupAddress";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "DataType";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 70;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Status";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "FdbackAddress";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "ON";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 40;
            // 
            // frmMyKNX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 538);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMyKNX";
            this.Text = "MyKNX";
            this.Load += new System.EventHandler(this.FrmMyKNX_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKNX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.ComboBox cbSwitch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox DeviceType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox CbCurtainEdit;
        private System.Windows.Forms.Label lbCurtain;
        private System.Windows.Forms.NumericUpDown num3;
        private System.Windows.Forms.NumericUpDown num2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown num1;
        private System.Windows.Forms.Label lbModel;
        private System.Windows.Forms.ComboBox CbModel;
        private System.Windows.Forms.Label lbSpeed;
        private System.Windows.Forms.ComboBox CbSpeed;
        private System.Windows.Forms.NumericUpDown temp;
        private System.Windows.Forms.Label lbTemp;
        private System.Windows.Forms.DataGridView dgvKNX;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevicesType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column6;
    }
}