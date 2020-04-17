namespace PinaoUI.Donate {
    partial class DonacePayment {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DonacePayment));
            this.pb_WeChat = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tm_banner = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_WeChat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_WeChat
            // 
            this.pb_WeChat.Image = ((System.Drawing.Image)(resources.GetObject("pb_WeChat.Image")));
            this.pb_WeChat.Location = new System.Drawing.Point(19, 208);
            this.pb_WeChat.Name = "pb_WeChat";
            this.pb_WeChat.Size = new System.Drawing.Size(234, 175);
            this.pb_WeChat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_WeChat.TabIndex = 2;
            this.pb_WeChat.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(288, 180);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(234, 203);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(107, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "  ";
            // 
            // tm_banner
            // 
            this.tm_banner.Enabled = true;
            this.tm_banner.Interval = 300;
            this.tm_banner.Tick += new System.EventHandler(this.tm_banner_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(16, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "每日12点整更新捐献排行，请务必备注ID！！！！！";
            // 
            // DonacePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 390);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pb_WeChat);
            this.Controls.Add(this.label2);
            this.EffectBack = System.Drawing.Color.Transparent;
            this.EffectWidth = 10;
            this.ForeColor = System.Drawing.Color.Maroon;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DonacePayment";
            this.Text = "感谢您的支持";
            this.TitleColor = System.Drawing.Color.Green;
            ((System.ComponentModel.ISupportInitialize)(this.pb_WeChat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pb_WeChat;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer tm_banner;
        private System.Windows.Forms.Label label1;
    }
}