using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PianoLoad {
    public partial class GuideForm : Form {
        private Dictionary<Label, string> dic = new Dictionary<Label, string>();
        private string text = "加载中";
        private int index = 0;
        public GuideForm() {
            InitializeComponent();
            dic.Add(d1, "Resources/1.png");
            dic.Add(d2, "Resources/2.png");
            dic.Add(d3, "Resources/3.png");
            this.pictureBox1.Image = Image.FromFile(dic[d1]);
        }

        private void textTimer_Tick(object sender, EventArgs e) {
            if (text.Length > 14) {
                text = "加载中";
            } else {
                text += '.';
                this.title.Text = text;
            }
        }

        private void picTimer_Tick(object sender, EventArgs e) {
            whiteAll();
            this.pictureBox1.Image = Image.FromFile(dic.Values.ToList<string>()[index]);
            dic.Keys.ToList<Label>()[index].ForeColor = Color.Red;
            index++;
            if (index == 3) {
                index = 0;
            }
        }
        private void whiteAll() {
            foreach (var item in dic) {
                item.Key.ForeColor = Color.White;
            }
        }
    }
}
