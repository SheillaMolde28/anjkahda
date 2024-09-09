namespace CS311ETEEAP2024_1
{
    partial class frmupdateequipment
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
            this.label8 = new System.Windows.Forms.Label();
            this.cmbdepartment = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbbranch = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtyearmodel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtmanufacturer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnequipmentsave = new System.Windows.Forms.Button();
            this.cmbtype = new System.Windows.Forms.ComboBox();
            this.txtserialnumber = new System.Windows.Forms.TextBox();
            this.txtassetnumber = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbstatus = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 235);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 65;
            this.label8.Text = "Department:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbdepartment
            // 
            this.cmbdepartment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbdepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdepartment.FormattingEnabled = true;
            this.cmbdepartment.Location = new System.Drawing.Point(94, 231);
            this.cmbdepartment.Margin = new System.Windows.Forms.Padding(2);
            this.cmbdepartment.Name = "cmbdepartment";
            this.cmbdepartment.Size = new System.Drawing.Size(200, 21);
            this.cmbdepartment.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 210);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 63;
            this.label7.Text = "Branch:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbbranch
            // 
            this.cmbbranch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbbranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbranch.FormattingEnabled = true;
            this.cmbbranch.Location = new System.Drawing.Point(94, 206);
            this.cmbbranch.Margin = new System.Windows.Forms.Padding(2);
            this.cmbbranch.Name = "cmbbranch";
            this.cmbbranch.Size = new System.Drawing.Size(200, 21);
            this.cmbbranch.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 146);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 61;
            this.label6.Text = "Description:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtdescription
            // 
            this.txtdescription.Location = new System.Drawing.Point(94, 142);
            this.txtdescription.Margin = new System.Windows.Forms.Padding(2);
            this.txtdescription.Multiline = true;
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.Size = new System.Drawing.Size(200, 60);
            this.txtdescription.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 122);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Year Model:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtyearmodel
            // 
            this.txtyearmodel.Location = new System.Drawing.Point(94, 119);
            this.txtyearmodel.Margin = new System.Windows.Forms.Padding(2);
            this.txtyearmodel.MaxLength = 4;
            this.txtyearmodel.Name = "txtyearmodel";
            this.txtyearmodel.Size = new System.Drawing.Size(200, 20);
            this.txtyearmodel.TabIndex = 5;
            this.txtyearmodel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtyearmodel_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 97);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 57;
            this.label3.Text = "Manufacturer:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtmanufacturer
            // 
            this.txtmanufacturer.Location = new System.Drawing.Point(94, 95);
            this.txtmanufacturer.Margin = new System.Windows.Forms.Padding(2);
            this.txtmanufacturer.Name = "txtmanufacturer";
            this.txtmanufacturer.Size = new System.Drawing.Size(200, 20);
            this.txtmanufacturer.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 72);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "Type:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Serial Number:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnequipmentsave
            // 
            this.btnequipmentsave.Location = new System.Drawing.Point(194, 296);
            this.btnequipmentsave.Margin = new System.Windows.Forms.Padding(2);
            this.btnequipmentsave.Name = "btnequipmentsave";
            this.btnequipmentsave.Size = new System.Drawing.Size(96, 24);
            this.btnequipmentsave.TabIndex = 10;
            this.btnequipmentsave.Text = "&Save";
            this.btnequipmentsave.UseVisualStyleBackColor = true;
            this.btnequipmentsave.Click += new System.EventHandler(this.btnequipmentsave_Click);
            // 
            // cmbtype
            // 
            this.cmbtype.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtype.FormattingEnabled = true;
            this.cmbtype.Location = new System.Drawing.Point(94, 70);
            this.cmbtype.Margin = new System.Windows.Forms.Padding(2);
            this.cmbtype.Name = "cmbtype";
            this.cmbtype.Size = new System.Drawing.Size(200, 21);
            this.cmbtype.TabIndex = 3;
            // 
            // txtserialnumber
            // 
            this.txtserialnumber.Location = new System.Drawing.Point(94, 45);
            this.txtserialnumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtserialnumber.Name = "txtserialnumber";
            this.txtserialnumber.Size = new System.Drawing.Size(200, 20);
            this.txtserialnumber.TabIndex = 2;
            // 
            // txtassetnumber
            // 
            this.txtassetnumber.Location = new System.Drawing.Point(94, 21);
            this.txtassetnumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtassetnumber.Name = "txtassetnumber";
            this.txtassetnumber.ReadOnly = true;
            this.txtassetnumber.Size = new System.Drawing.Size(200, 20);
            this.txtassetnumber.TabIndex = 1;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Asset Number:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 259);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 67;
            this.label9.Text = "Status:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbstatus
            // 
            this.cmbstatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbstatus.FormattingEnabled = true;
            this.cmbstatus.Location = new System.Drawing.Point(94, 256);
            this.cmbstatus.Margin = new System.Windows.Forms.Padding(2);
            this.cmbstatus.Name = "cmbstatus";
            this.cmbstatus.Size = new System.Drawing.Size(200, 21);
            this.cmbstatus.TabIndex = 9;
            // 
            // frmupdateequipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(324, 327);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbstatus);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbdepartment);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbbranch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtdescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtyearmodel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtmanufacturer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnequipmentsave);
            this.Controls.Add(this.cmbtype);
            this.Controls.Add(this.txtserialnumber);
            this.Controls.Add(this.txtassetnumber);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmupdateequipment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EMS - Update equipment";
            this.Load += new System.EventHandler(this.frmupdateequipment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbdepartment;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbbranch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtyearmodel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtmanufacturer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnequipmentsave;
        private System.Windows.Forms.ComboBox cmbtype;
        private System.Windows.Forms.TextBox txtserialnumber;
        private System.Windows.Forms.TextBox txtassetnumber;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbstatus;
    }
}