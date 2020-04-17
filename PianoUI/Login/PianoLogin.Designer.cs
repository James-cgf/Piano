namespace PinaoUI.Login {
    partial class PianoLogin {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PianoLogin));
            this.tbId = new System.Windows.Forms.TextBox();
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Go = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.RememberCB = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbId
            // 
            this.tbId.BackColor = System.Drawing.Color.Teal;
            this.tbId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbId.Font = new System.Drawing.Font("Comic Sans MS", 18F);
            this.tbId.Location = new System.Drawing.Point(183, 177);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(353, 34);
            this.tbId.TabIndex = 0;
            this.tbId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbId_KeyPress);
            // 
            // tbPwd
            // 
            this.tbPwd.BackColor = System.Drawing.Color.Teal;
            this.tbPwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPwd.Font = new System.Drawing.Font("Comic Sans MS", 18F);
            this.tbPwd.Location = new System.Drawing.Point(183, 284);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '*';
            this.tbPwd.Size = new System.Drawing.Size(353, 34);
            this.tbPwd.TabIndex = 2;
            this.tbPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPwd_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(183, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "账号:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(183, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "密码:";
            // 
            // Go
            // 
            this.Go.BackColor = System.Drawing.Color.Teal;
            this.Go.Cursor = System.Windows.Forms.Cursors.Default;
            this.Go.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Go.Font = new System.Drawing.Font("Comic Sans MS", 15F);
            this.Go.ForeColor = System.Drawing.Color.Black;
            this.Go.Location = new System.Drawing.Point(115, 431);
            this.Go.Name = "Go";
            this.Go.Size = new System.Drawing.Size(499, 40);
            this.Go.TabIndex = 3;
            this.Go.Text = "GO";
            this.Go.UseVisualStyleBackColor = false;
            this.Go.Click += new System.EventHandler(this.Go_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(3, 573);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "没有账号？点击注册";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(183, 336);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "邮箱:";
            this.label4.Visible = false;
            // 
            // tbEmail
            // 
            this.tbEmail.BackColor = System.Drawing.Color.Teal;
            this.tbEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbEmail.Font = new System.Drawing.Font("Comic Sans MS", 18F);
            this.tbEmail.Location = new System.Drawing.Point(183, 362);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(353, 34);
            this.tbEmail.TabIndex = 1;
            this.tbEmail.Visible = false;
            this.tbEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbEmail_KeyPress);
            // 
            // RememberCB
            // 
            this.RememberCB.AutoSize = true;
            this.RememberCB.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.RememberCB.ForeColor = System.Drawing.Color.White;
            this.RememberCB.Location = new System.Drawing.Point(452, 402);
            this.RememberCB.Name = "RememberCB";
            this.RememberCB.Size = new System.Drawing.Size(84, 23);
            this.RememberCB.TabIndex = 8;
            this.RememberCB.Text = "记住密码";
            this.RememberCB.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.label5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label5.Location = new System.Drawing.Point(591, 573);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "忘记密码？点击找回";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 20F);
            this.button1.ForeColor = System.Drawing.Color.Cyan;
            this.button1.Location = new System.Drawing.Point(686, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 11;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-2, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(91, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PianoLogin
            // 
            this.AcceptButton = this.Go;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(729, 595);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RememberCB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Go);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPwd);
            this.Controls.Add(this.tbId);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PianoLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.TextBox tbPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Go;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.CheckBox RememberCB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
    }
}