using LogicManager;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PinaoUI.Donate {
    public partial class DonateForm : Form {
        private string str = "Id:$ 邮箱:$ 捐献$元";
        private Label[] label = new Label[10];
        public int id { get; set; } = 0;
        private int index = 0;
        private Color[] color = new Color[] { Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Cyan, Color.Blue, Color.Violet };
        public DonateForm() {
            InitializeComponent();
            label[0] = b1;
            label[1] = b2;
            label[2] = b3;
            label[3] = b4;
            label[4] = b5;
            label[5] = b6;
            label[6] = b7;
            label[7] = b8;
            label[8] = b9;
            label[9] = b10;
        }

        private void tm_nowTime_Tick(object sender, EventArgs e) {
            this.lb_nowTime.Text = DateTime.Now.ToString();
            this.b1.ForeColor = color[index];
            if (++index >= color.Length) {
                index = 0;
            }
        }

        private void lb_goToDonace_MouseLeave(object sender, EventArgs e) {
            this.lb_goToDonace.BackColor = Color.Maroon;

        }

        private void lb_goToDonace_MouseEnter(object sender, EventArgs e) {
            this.lb_goToDonace.BackColor = Color.Brown;

        }

        private void lb_goToDonace_Click(object sender, EventArgs e) {
            if (id != 0) {
                new DonacePayment(id).ShowDialog();
            } else {
                MessageBox.Show("请先登录!");
            }
        }
        /// <summary>
        /// Load Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DonateForm_Load(object sender, EventArgs e) {
            System.Collections.Generic.Dictionary<object, object> dic = GetGonates.getDonateID();
            System.Collections.Generic.List<object> list = GetGonates.getDonateEmail(10);
            int index = 0;
            foreach (var item in dic) {
                string str = Middleware.ParseString.parse(this.str, new string[] { item.Key.ToString(), list[index].ToString(), item.Value.ToString() }, '$');
                label[index].Text = str;
                index++;
            }
        }
    }
}
