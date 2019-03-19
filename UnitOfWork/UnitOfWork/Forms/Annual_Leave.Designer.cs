namespace UnitOfWork.Forms
{
    partial class Annual_Leave
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
            this.pnlDoctor = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbExtraDoctor = new System.Windows.Forms.ComboBox();
            this.btnDocLeave = new System.Windows.Forms.Button();
            this.chkDHasReport = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLeaveDuration = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDoc = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlNurse = new System.Windows.Forms.Panel();
            this.btnNLeave = new System.Windows.Forms.Button();
            this.chkHasReport = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLeaveDurationN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbNurse = new System.Windows.Forms.ComboBox();
            this.pnlDoctor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlNurse.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDoctor
            // 
            this.pnlDoctor.BackColor = System.Drawing.Color.Transparent;
            this.pnlDoctor.Controls.Add(this.label5);
            this.pnlDoctor.Controls.Add(this.cmbExtraDoctor);
            this.pnlDoctor.Controls.Add(this.btnDocLeave);
            this.pnlDoctor.Controls.Add(this.chkDHasReport);
            this.pnlDoctor.Controls.Add(this.label2);
            this.pnlDoctor.Controls.Add(this.txtLeaveDuration);
            this.pnlDoctor.Controls.Add(this.label1);
            this.pnlDoctor.Controls.Add(this.cmbDoc);
            this.pnlDoctor.Location = new System.Drawing.Point(13, 13);
            this.pnlDoctor.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDoctor.Name = "pnlDoctor";
            this.pnlDoctor.Size = new System.Drawing.Size(434, 247);
            this.pnlDoctor.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(64, 96);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "Temp Doctor:";
            // 
            // cmbExtraDoctor
            // 
            this.cmbExtraDoctor.FormattingEnabled = true;
            this.cmbExtraDoctor.Location = new System.Drawing.Point(212, 96);
            this.cmbExtraDoctor.Margin = new System.Windows.Forms.Padding(4);
            this.cmbExtraDoctor.Name = "cmbExtraDoctor";
            this.cmbExtraDoctor.Size = new System.Drawing.Size(180, 26);
            this.cmbExtraDoctor.TabIndex = 6;
            // 
            // btnDocLeave
            // 
            this.btnDocLeave.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnDocLeave.Location = new System.Drawing.Point(280, 162);
            this.btnDocLeave.Margin = new System.Windows.Forms.Padding(4);
            this.btnDocLeave.Name = "btnDocLeave";
            this.btnDocLeave.Size = new System.Drawing.Size(112, 32);
            this.btnDocLeave.TabIndex = 5;
            this.btnDocLeave.Text = "Confirm";
            this.btnDocLeave.UseVisualStyleBackColor = true;
            this.btnDocLeave.Click += new System.EventHandler(this.btnDocLeave_Click);
            // 
            // chkDHasReport
            // 
            this.chkDHasReport.AutoSize = true;
            this.chkDHasReport.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.chkDHasReport.Location = new System.Drawing.Point(256, 127);
            this.chkDHasReport.Margin = new System.Windows.Forms.Padding(4);
            this.chkDHasReport.Name = "chkDHasReport";
            this.chkDHasReport.Size = new System.Drawing.Size(136, 27);
            this.chkDHasReport.TabIndex = 4;
            this.chkDHasReport.Text = "Has Report";
            this.chkDHasReport.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(43, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Leave Duration:";
            // 
            // txtLeaveDuration
            // 
            this.txtLeaveDuration.Location = new System.Drawing.Point(212, 60);
            this.txtLeaveDuration.Margin = new System.Windows.Forms.Padding(4);
            this.txtLeaveDuration.Name = "txtLeaveDuration";
            this.txtLeaveDuration.Size = new System.Drawing.Size(180, 26);
            this.txtLeaveDuration.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(123, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Doctor:";
            // 
            // cmbDoc
            // 
            this.cmbDoc.FormattingEnabled = true;
            this.cmbDoc.Location = new System.Drawing.Point(212, 23);
            this.cmbDoc.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDoc.Name = "cmbDoc";
            this.cmbDoc.Size = new System.Drawing.Size(180, 26);
            this.cmbDoc.TabIndex = 0;
            this.cmbDoc.SelectedIndexChanged += new System.EventHandler(this.cmbExtraDoctor_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::UnitOfWork.Properties.Resources.close_button_png_30241;
            this.pictureBox1.Location = new System.Drawing.Point(421, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pnlNurse
            // 
            this.pnlNurse.BackColor = System.Drawing.Color.Transparent;
            this.pnlNurse.Controls.Add(this.btnNLeave);
            this.pnlNurse.Controls.Add(this.chkHasReport);
            this.pnlNurse.Controls.Add(this.label3);
            this.pnlNurse.Controls.Add(this.txtLeaveDurationN);
            this.pnlNurse.Controls.Add(this.label4);
            this.pnlNurse.Controls.Add(this.cmbNurse);
            this.pnlNurse.Location = new System.Drawing.Point(51, 9);
            this.pnlNurse.Margin = new System.Windows.Forms.Padding(4);
            this.pnlNurse.Name = "pnlNurse";
            this.pnlNurse.Size = new System.Drawing.Size(392, 258);
            this.pnlNurse.TabIndex = 6;
            // 
            // btnNLeave
            // 
            this.btnNLeave.Location = new System.Drawing.Point(242, 169);
            this.btnNLeave.Margin = new System.Windows.Forms.Padding(4);
            this.btnNLeave.Name = "btnNLeave";
            this.btnNLeave.Size = new System.Drawing.Size(112, 32);
            this.btnNLeave.TabIndex = 5;
            this.btnNLeave.Text = "Confirm";
            this.btnNLeave.UseVisualStyleBackColor = true;
            this.btnNLeave.Click += new System.EventHandler(this.btnNLeave_Click);
            // 
            // chkHasReport
            // 
            this.chkHasReport.AutoSize = true;
            this.chkHasReport.Location = new System.Drawing.Point(244, 137);
            this.chkHasReport.Margin = new System.Windows.Forms.Padding(4);
            this.chkHasReport.Name = "chkHasReport";
            this.chkHasReport.Size = new System.Drawing.Size(110, 22);
            this.chkHasReport.TabIndex = 4;
            this.chkHasReport.Text = "Has Report";
            this.chkHasReport.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(5, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Leave Duration:";
            // 
            // txtLeaveDurationN
            // 
            this.txtLeaveDurationN.Location = new System.Drawing.Point(174, 103);
            this.txtLeaveDurationN.Margin = new System.Windows.Forms.Padding(4);
            this.txtLeaveDurationN.Name = "txtLeaveDurationN";
            this.txtLeaveDurationN.Size = new System.Drawing.Size(180, 26);
            this.txtLeaveDurationN.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(93, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nurse:";
            // 
            // cmbNurse
            // 
            this.cmbNurse.FormattingEnabled = true;
            this.cmbNurse.Location = new System.Drawing.Point(174, 66);
            this.cmbNurse.Margin = new System.Windows.Forms.Padding(4);
            this.cmbNurse.Name = "cmbNurse";
            this.cmbNurse.Size = new System.Drawing.Size(180, 26);
            this.cmbNurse.TabIndex = 0;
            // 
            // Annual_Leave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UnitOfWork.Properties.Resources.f7b9a2e85187dbcc6537c3cde2080857;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(466, 411);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlDoctor);
            this.Controls.Add(this.pnlNurse);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Annual_Leave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Annual_Leave";
            this.Load += new System.EventHandler(this.Annual_Leave_Load);
            this.pnlDoctor.ResumeLayout(false);
            this.pnlDoctor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlNurse.ResumeLayout(false);
            this.pnlNurse.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDoctor;
        private System.Windows.Forms.ComboBox cmbDoc;
        private System.Windows.Forms.Panel pnlNurse;
        private System.Windows.Forms.Button btnNLeave;
        private System.Windows.Forms.CheckBox chkHasReport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLeaveDurationN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbNurse;
        private System.Windows.Forms.Button btnDocLeave;
        private System.Windows.Forms.CheckBox chkDHasReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLeaveDuration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbExtraDoctor;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}