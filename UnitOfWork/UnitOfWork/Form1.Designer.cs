namespace UnitOfWork
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDocLeave = new System.Windows.Forms.Button();
            this.btnDList = new System.Windows.Forms.Button();
            this.btnDAdd = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnNurseLeave = new System.Windows.Forms.Button();
            this.btnNList = new System.Windows.Forms.Button();
            this.btnNAdd = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnPList = new System.Windows.Forms.Button();
            this.btnPAdd = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnUserList = new System.Windows.Forms.Button();
            this.btnUserAdd = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnUnitList = new System.Windows.Forms.Button();
            this.btnUnitAdd = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnPolyclinicList = new System.Windows.Forms.Button();
            this.btnPolyclinicAdd = new System.Windows.Forms.Button();
            this.panel14 = new System.Windows.Forms.Panel();
            this.btnAppointmentList = new System.Windows.Forms.Button();
            this.btnAppointmentAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.btnDocPatientList = new System.Windows.Forms.Button();
            this.panel18 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel17.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(549, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Patient Operations";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(275, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nurse Operations";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Doctor Operations";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDocLeave);
            this.panel2.Controls.Add(this.btnDList);
            this.panel2.Controls.Add(this.btnDAdd);
            this.panel2.Location = new System.Drawing.Point(148, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(124, 180);
            this.panel2.TabIndex = 13;
            // 
            // btnDocLeave
            // 
            this.btnDocLeave.BackgroundImage = global::UnitOfWork.Properties.Resources.icons8_leave_1000;
            this.btnDocLeave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDocLeave.Location = new System.Drawing.Point(3, 115);
            this.btnDocLeave.Name = "btnDocLeave";
            this.btnDocLeave.Size = new System.Drawing.Size(55, 50);
            this.btnDocLeave.TabIndex = 21;
            this.btnDocLeave.UseVisualStyleBackColor = true;
            this.btnDocLeave.Click += new System.EventHandler(this.btnDocLeave_Click);
            this.btnDocLeave.MouseLeave += new System.EventHandler(this.Leave_MouseLeave);
            this.btnDocLeave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Leave_MouseMove);
            // 
            // btnDList
            // 
            this.btnDList.BackgroundImage = global::UnitOfWork.Properties.Resources.Bulleted_List_icon;
            this.btnDList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDList.Location = new System.Drawing.Point(3, 3);
            this.btnDList.Name = "btnDList";
            this.btnDList.Size = new System.Drawing.Size(55, 50);
            this.btnDList.TabIndex = 10;
            this.btnDList.UseVisualStyleBackColor = true;
            this.btnDList.Click += new System.EventHandler(this.btnDList_Click);
            this.btnDList.MouseLeave += new System.EventHandler(this.List_MouseLeave);
            this.btnDList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.List_MouseMove);
            // 
            // btnDAdd
            // 
            this.btnDAdd.BackgroundImage = global::UnitOfWork.Properties.Resources.add_icon__1_;
            this.btnDAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDAdd.Location = new System.Drawing.Point(3, 59);
            this.btnDAdd.Name = "btnDAdd";
            this.btnDAdd.Size = new System.Drawing.Size(55, 50);
            this.btnDAdd.TabIndex = 11;
            this.btnDAdd.UseVisualStyleBackColor = true;
            this.btnDAdd.Click += new System.EventHandler(this.btnDAdd_Click);
            this.btnDAdd.MouseLeave += new System.EventHandler(this.Add_MouseLeave);
            this.btnDAdd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Add_MouseMove);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnNurseLeave);
            this.panel4.Controls.Add(this.btnNList);
            this.panel4.Controls.Add(this.btnNAdd);
            this.panel4.Location = new System.Drawing.Point(419, 35);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(124, 180);
            this.panel4.TabIndex = 14;
            // 
            // btnNurseLeave
            // 
            this.btnNurseLeave.BackgroundImage = global::UnitOfWork.Properties.Resources.icons8_leave_1000;
            this.btnNurseLeave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNurseLeave.Location = new System.Drawing.Point(3, 115);
            this.btnNurseLeave.Name = "btnNurseLeave";
            this.btnNurseLeave.Size = new System.Drawing.Size(55, 50);
            this.btnNurseLeave.TabIndex = 22;
            this.btnNurseLeave.UseVisualStyleBackColor = true;
            this.btnNurseLeave.Click += new System.EventHandler(this.btnNurseLeave_Click);
            this.btnNurseLeave.MouseLeave += new System.EventHandler(this.Leave_MouseLeave);
            this.btnNurseLeave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Leave_MouseMove);
            // 
            // btnNList
            // 
            this.btnNList.BackgroundImage = global::UnitOfWork.Properties.Resources.Bulleted_List_icon;
            this.btnNList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNList.Location = new System.Drawing.Point(3, 3);
            this.btnNList.Name = "btnNList";
            this.btnNList.Size = new System.Drawing.Size(55, 50);
            this.btnNList.TabIndex = 0;
            this.btnNList.UseVisualStyleBackColor = true;
            this.btnNList.Click += new System.EventHandler(this.btnNList_Click);
            this.btnNList.MouseLeave += new System.EventHandler(this.List_MouseLeave);
            this.btnNList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.List_MouseMove);
            // 
            // btnNAdd
            // 
            this.btnNAdd.BackgroundImage = global::UnitOfWork.Properties.Resources.add_icon__1_;
            this.btnNAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNAdd.Location = new System.Drawing.Point(3, 59);
            this.btnNAdd.Name = "btnNAdd";
            this.btnNAdd.Size = new System.Drawing.Size(55, 50);
            this.btnNAdd.TabIndex = 2;
            this.btnNAdd.UseVisualStyleBackColor = true;
            this.btnNAdd.Click += new System.EventHandler(this.btnNAdd_Click);
            this.btnNAdd.MouseLeave += new System.EventHandler(this.Add_MouseLeave);
            this.btnNAdd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Add_MouseMove);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnPList);
            this.panel6.Controls.Add(this.btnPAdd);
            this.panel6.Location = new System.Drawing.Point(694, 35);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(58, 180);
            this.panel6.TabIndex = 15;
            // 
            // btnPList
            // 
            this.btnPList.BackgroundImage = global::UnitOfWork.Properties.Resources.Bulleted_List_icon;
            this.btnPList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPList.Location = new System.Drawing.Point(3, 3);
            this.btnPList.Name = "btnPList";
            this.btnPList.Size = new System.Drawing.Size(55, 50);
            this.btnPList.TabIndex = 0;
            this.btnPList.UseVisualStyleBackColor = true;
            this.btnPList.Click += new System.EventHandler(this.btnPList_Click);
            this.btnPList.MouseLeave += new System.EventHandler(this.List_MouseLeave);
            this.btnPList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.List_MouseMove);
            // 
            // btnPAdd
            // 
            this.btnPAdd.BackgroundImage = global::UnitOfWork.Properties.Resources.add_icon__1_;
            this.btnPAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPAdd.Location = new System.Drawing.Point(3, 59);
            this.btnPAdd.Name = "btnPAdd";
            this.btnPAdd.Size = new System.Drawing.Size(55, 50);
            this.btnPAdd.TabIndex = 2;
            this.btnPAdd.UseVisualStyleBackColor = true;
            this.btnPAdd.Click += new System.EventHandler(this.btnPAdd_Click);
            this.btnPAdd.MouseLeave += new System.EventHandler(this.Add_MouseLeave);
            this.btnPAdd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Add_MouseMove);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnUserList);
            this.panel8.Controls.Add(this.btnUserAdd);
            this.panel8.Location = new System.Drawing.Point(148, 259);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(124, 180);
            this.panel8.TabIndex = 14;
            // 
            // btnUserList
            // 
            this.btnUserList.BackgroundImage = global::UnitOfWork.Properties.Resources.Bulleted_List_icon;
            this.btnUserList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUserList.Location = new System.Drawing.Point(3, 3);
            this.btnUserList.Name = "btnUserList";
            this.btnUserList.Size = new System.Drawing.Size(55, 50);
            this.btnUserList.TabIndex = 0;
            this.btnUserList.UseVisualStyleBackColor = true;
            this.btnUserList.Click += new System.EventHandler(this.btnUserList_Click);
            this.btnUserList.MouseLeave += new System.EventHandler(this.List_MouseLeave);
            this.btnUserList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.List_MouseMove);
            // 
            // btnUserAdd
            // 
            this.btnUserAdd.BackgroundImage = global::UnitOfWork.Properties.Resources.add_icon__1_;
            this.btnUserAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUserAdd.Location = new System.Drawing.Point(3, 56);
            this.btnUserAdd.Name = "btnUserAdd";
            this.btnUserAdd.Size = new System.Drawing.Size(55, 50);
            this.btnUserAdd.TabIndex = 2;
            this.btnUserAdd.UseVisualStyleBackColor = true;
            this.btnUserAdd.Click += new System.EventHandler(this.btnUserAdd_Click);
            this.btnUserAdd.MouseLeave += new System.EventHandler(this.Add_MouseLeave);
            this.btnUserAdd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Add_MouseMove);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btnUnitList);
            this.panel10.Controls.Add(this.btnUnitAdd);
            this.panel10.Location = new System.Drawing.Point(419, 259);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(124, 180);
            this.panel10.TabIndex = 15;
            // 
            // btnUnitList
            // 
            this.btnUnitList.BackgroundImage = global::UnitOfWork.Properties.Resources.Bulleted_List_icon;
            this.btnUnitList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUnitList.Location = new System.Drawing.Point(3, 3);
            this.btnUnitList.Name = "btnUnitList";
            this.btnUnitList.Size = new System.Drawing.Size(55, 50);
            this.btnUnitList.TabIndex = 0;
            this.btnUnitList.UseVisualStyleBackColor = true;
            this.btnUnitList.Click += new System.EventHandler(this.btnUnitList_Click);
            this.btnUnitList.MouseLeave += new System.EventHandler(this.List_MouseLeave);
            this.btnUnitList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.List_MouseMove);
            // 
            // btnUnitAdd
            // 
            this.btnUnitAdd.BackgroundImage = global::UnitOfWork.Properties.Resources.add_icon__1_;
            this.btnUnitAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUnitAdd.Location = new System.Drawing.Point(3, 56);
            this.btnUnitAdd.Name = "btnUnitAdd";
            this.btnUnitAdd.Size = new System.Drawing.Size(55, 50);
            this.btnUnitAdd.TabIndex = 2;
            this.btnUnitAdd.UseVisualStyleBackColor = true;
            this.btnUnitAdd.Click += new System.EventHandler(this.btnUnitAdd_Click);
            this.btnUnitAdd.MouseLeave += new System.EventHandler(this.Add_MouseLeave);
            this.btnUnitAdd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Add_MouseMove);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.btnPolyclinicList);
            this.panel12.Controls.Add(this.btnPolyclinicAdd);
            this.panel12.Location = new System.Drawing.Point(694, 259);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(58, 180);
            this.panel12.TabIndex = 16;
            // 
            // btnPolyclinicList
            // 
            this.btnPolyclinicList.BackgroundImage = global::UnitOfWork.Properties.Resources.Bulleted_List_icon;
            this.btnPolyclinicList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPolyclinicList.Location = new System.Drawing.Point(3, 3);
            this.btnPolyclinicList.Name = "btnPolyclinicList";
            this.btnPolyclinicList.Size = new System.Drawing.Size(55, 50);
            this.btnPolyclinicList.TabIndex = 0;
            this.btnPolyclinicList.UseVisualStyleBackColor = true;
            this.btnPolyclinicList.Click += new System.EventHandler(this.btnPolyclinicList_Click);
            this.btnPolyclinicList.MouseLeave += new System.EventHandler(this.List_MouseLeave);
            this.btnPolyclinicList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.List_MouseMove);
            // 
            // btnPolyclinicAdd
            // 
            this.btnPolyclinicAdd.BackgroundImage = global::UnitOfWork.Properties.Resources.add_icon__1_;
            this.btnPolyclinicAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPolyclinicAdd.Location = new System.Drawing.Point(3, 56);
            this.btnPolyclinicAdd.Name = "btnPolyclinicAdd";
            this.btnPolyclinicAdd.Size = new System.Drawing.Size(55, 50);
            this.btnPolyclinicAdd.TabIndex = 2;
            this.btnPolyclinicAdd.UseVisualStyleBackColor = true;
            this.btnPolyclinicAdd.Click += new System.EventHandler(this.btnPolyclinicAdd_Click);
            this.btnPolyclinicAdd.MouseLeave += new System.EventHandler(this.Add_MouseLeave);
            this.btnPolyclinicAdd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Add_MouseMove);
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.btnAppointmentList);
            this.panel14.Controls.Add(this.btnAppointmentAdd);
            this.panel14.Location = new System.Drawing.Point(148, 470);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(124, 180);
            this.panel14.TabIndex = 15;
            // 
            // btnAppointmentList
            // 
            this.btnAppointmentList.BackgroundImage = global::UnitOfWork.Properties.Resources.Bulleted_List_icon;
            this.btnAppointmentList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAppointmentList.Location = new System.Drawing.Point(3, 3);
            this.btnAppointmentList.Name = "btnAppointmentList";
            this.btnAppointmentList.Size = new System.Drawing.Size(55, 50);
            this.btnAppointmentList.TabIndex = 0;
            this.btnAppointmentList.UseVisualStyleBackColor = true;
            this.btnAppointmentList.Click += new System.EventHandler(this.btnAppointmentList_Click);
            this.btnAppointmentList.MouseLeave += new System.EventHandler(this.List_MouseLeave);
            this.btnAppointmentList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.List_MouseMove);
            // 
            // btnAppointmentAdd
            // 
            this.btnAppointmentAdd.BackgroundImage = global::UnitOfWork.Properties.Resources.add_icon__1_;
            this.btnAppointmentAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAppointmentAdd.Location = new System.Drawing.Point(3, 59);
            this.btnAppointmentAdd.Name = "btnAppointmentAdd";
            this.btnAppointmentAdd.Size = new System.Drawing.Size(55, 50);
            this.btnAppointmentAdd.TabIndex = 2;
            this.btnAppointmentAdd.UseVisualStyleBackColor = true;
            this.btnAppointmentAdd.Click += new System.EventHandler(this.btnAppointmentAdd_Click);
            this.btnAppointmentAdd.MouseLeave += new System.EventHandler(this.Add_MouseLeave);
            this.btnAppointmentAdd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Add_MouseMove);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 24);
            this.label4.TabIndex = 17;
            this.label4.Text = "User Operations";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(275, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 24);
            this.label5.TabIndex = 18;
            this.label5.Text = "Unit Operations";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(554, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 24);
            this.label6.TabIndex = 19;
            this.label6.Text = "Polyclinic Operations";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 443);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(228, 24);
            this.label7.TabIndex = 20;
            this.label7.Text = "Appointment Operations";
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 60000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.label3);
            this.panel15.Controls.Add(this.label7);
            this.panel15.Controls.Add(this.label2);
            this.panel15.Controls.Add(this.panel14);
            this.panel15.Controls.Add(this.label6);
            this.panel15.Controls.Add(this.panel13);
            this.panel15.Controls.Add(this.panel1);
            this.panel15.Controls.Add(this.label5);
            this.panel15.Controls.Add(this.panel2);
            this.panel15.Controls.Add(this.panel12);
            this.panel15.Controls.Add(this.label4);
            this.panel15.Controls.Add(this.panel11);
            this.panel15.Controls.Add(this.panel3);
            this.panel15.Controls.Add(this.panel6);
            this.panel15.Controls.Add(this.panel4);
            this.panel15.Controls.Add(this.panel5);
            this.panel15.Controls.Add(this.panel7);
            this.panel15.Controls.Add(this.label1);
            this.panel15.Controls.Add(this.panel8);
            this.panel15.Controls.Add(this.panel9);
            this.panel15.Controls.Add(this.panel10);
            this.panel15.Location = new System.Drawing.Point(22, 15);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(772, 674);
            this.panel15.TabIndex = 21;
            // 
            // panel13
            // 
            this.panel13.BackgroundImage = global::UnitOfWork.Properties.Resources.stethoscope_icon;
            this.panel13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel13.Location = new System.Drawing.Point(7, 470);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(135, 180);
            this.panel13.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::UnitOfWork.Properties.Resources.People_Doctor_Male_icon;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(7, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(135, 180);
            this.panel1.TabIndex = 12;
            // 
            // panel11
            // 
            this.panel11.BackgroundImage = global::UnitOfWork.Properties.Resources._42491_hospital_icon;
            this.panel11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel11.Location = new System.Drawing.Point(553, 259);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(135, 180);
            this.panel11.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::UnitOfWork.Properties.Resources.Medical_Nurse_Female_Light_icon;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.Location = new System.Drawing.Point(278, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(135, 180);
            this.panel3.TabIndex = 13;
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = global::UnitOfWork.Properties.Resources.People_Patient_Male_icon;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel5.Location = new System.Drawing.Point(553, 35);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(135, 180);
            this.panel5.TabIndex = 14;
            // 
            // panel7
            // 
            this.panel7.BackgroundImage = global::UnitOfWork.Properties.Resources.Admin_icon;
            this.panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel7.Location = new System.Drawing.Point(7, 259);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(135, 180);
            this.panel7.TabIndex = 13;
            // 
            // panel9
            // 
            this.panel9.BackgroundImage = global::UnitOfWork.Properties.Resources.Hospital_icon;
            this.panel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel9.Location = new System.Drawing.Point(278, 259);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(135, 180);
            this.panel9.TabIndex = 14;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.panel17);
            this.panel16.Controls.Add(this.panel18);
            this.panel16.Controls.Add(this.label8);
            this.panel16.Location = new System.Drawing.Point(29, 1);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(280, 255);
            this.panel16.TabIndex = 22;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.btnDocPatientList);
            this.panel17.Location = new System.Drawing.Point(178, 44);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(58, 180);
            this.panel17.TabIndex = 18;
            // 
            // btnDocPatientList
            // 
            this.btnDocPatientList.BackgroundImage = global::UnitOfWork.Properties.Resources.Bulleted_List_icon;
            this.btnDocPatientList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDocPatientList.Location = new System.Drawing.Point(3, 3);
            this.btnDocPatientList.Name = "btnDocPatientList";
            this.btnDocPatientList.Size = new System.Drawing.Size(55, 50);
            this.btnDocPatientList.TabIndex = 0;
            this.btnDocPatientList.UseVisualStyleBackColor = true;
            this.btnDocPatientList.Click += new System.EventHandler(this.btnDocPatientList_Click_1);
            this.btnDocPatientList.MouseLeave += new System.EventHandler(this.List_MouseLeave);
            this.btnDocPatientList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.List_MouseMove);
            // 
            // panel18
            // 
            this.panel18.BackgroundImage = global::UnitOfWork.Properties.Resources.People_Patient_Male_icon;
            this.panel18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel18.Location = new System.Drawing.Point(37, 44);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(135, 180);
            this.panel18.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(33, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(176, 24);
            this.label8.TabIndex = 16;
            this.label8.Text = "Patient Operations";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 677);
            this.Controls.Add(this.panel15);
            this.Controls.Add(this.panel16);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hospital Automation ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnNAdd;
        private System.Windows.Forms.Button btnNList;
        private System.Windows.Forms.Button btnPAdd;
        private System.Windows.Forms.Button btnPList;
        private System.Windows.Forms.Button btnPolyclinicAdd;
        private System.Windows.Forms.Button btnPolyclinicList;
        private System.Windows.Forms.Button btnUserAdd;
        private System.Windows.Forms.Button btnUserList;
        private System.Windows.Forms.Button btnUnitAdd;
        private System.Windows.Forms.Button btnUnitList;
        private System.Windows.Forms.Button btnAppointmentAdd;
        private System.Windows.Forms.Button btnAppointmentList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDAdd;
        private System.Windows.Forms.Button btnDList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDocLeave;
        private System.Windows.Forms.Button btnNurseLeave;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Button btnDocPatientList;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Label label8;
    }
}

