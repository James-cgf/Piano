namespace PianoLoad {
    partial class GuideForm {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuideForm));
            this.title = new System.Windows.Forms.Label();
            this.textTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.d1 = new System.Windows.Forms.Label();
            this.d2 = new System.Windows.Forms.Label();
            this.d3 = new System.Windows.Forms.Label();
            this.picTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("宋体", 20F);
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(346, 12);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(233, 27);
            this.title.TabIndex = 0;
            this.title.Text = "加载中..........";
            // 
            // textTimer
            // 
            this.textTimer.Enabled = true;
            this.textTimer.Interval = 200;
            this.textTimer.Tick += new System.EventHandler(this.textTimer_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(784, 488);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // d1
            // 
            this.d1.AutoSize = true;
            this.d1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.d1.ForeColor = System.Drawing.Color.Red;
            this.d1.Location = new System.Drawing.Point(402, 548);
            this.d1.Name = "d1";
            this.d1.Size = new System.Drawing.Size(20, 17);
            this.d1.TabIndex = 2;
            this.d1.Text = "〇";
            // 
            // d2
            // 
            this.d2.AutoSize = true;
            this.d2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.d2.ForeColor = System.Drawing.Color.White;
            this.d2.Location = new System.Drawing.Point(428, 548);
            this.d2.Name = "d2";
            this.d2.Size = new System.Drawing.Size(20, 17);
            this.d2.TabIndex = 2;
            this.d2.Text = "〇";
            // 
            // d3
            // 
            this.d3.AutoSize = true;
            this.d3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.d3.ForeColor = System.Drawing.Color.White;
            this.d3.Location = new System.Drawing.Point(454, 548);
            this.d3.Name = "d3";
            this.d3.Size = new System.Drawing.Size(20, 17);
            this.d3.TabIndex = 2;
            this.d3.Text = "〇";
            // 
            // picTimer
            // 
            this.picTimer.Enabled = true;
            this.picTimer.Interval = 3000;
            this.picTimer.Tick += new System.EventHandler(this.picTimer_Tick);
            // 
            // GuideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(783, 575);
            this.Controls.Add(this.d3);
            this.Controls.Add(this.d2);
            this.Controls.Add(this.d1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GuideForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading...";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Timer textTimer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label d1;
        private System.Windows.Forms.Label d2;
        private System.Windows.Forms.Label d3;
        private System.Windows.Forms.Timer picTimer;
    }
}

