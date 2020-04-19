using System;
using System.IO;
using System.Text;

namespace AccessService {
    public class WriteError {
        private static readonly string str = "\n";
        #region 有备无患
        /// <summary>
        /// 初始化103按键和视图键盘对应
        /// </summary>
        /*private void initPic() {
            //第一行
            keyPic.Add(Keys.Escape, esc);
            keyPic.Add(Keys.F1, f1);
            keyPic.Add(Keys.F2, f1);
            keyPic.Add(Keys.F3, f1);
            keyPic.Add(Keys.F4, f1);
            keyPic.Add(Keys.F5, f1);
            keyPic.Add(Keys.F6, f1);
            keyPic.Add(Keys.F7, f1);
            keyPic.Add(Keys.F8, f1);
            keyPic.Add(Keys.F9, f1);
            keyPic.Add(Keys.F10, f1);
            keyPic.Add(Keys.F11, f1);
            keyPic.Add(Keys.F12, f1);

            keyPic.Add(Keys.PrintScreen, printScreen);
            keyPic.Add(Keys.Scroll, scrollLock);
            keyPic.Add(Keys.Pause, pause);

            //没算上灯，第二行从右边开始

            keyPic.Add(Keys.Subtract, numsubtract);
            keyPic.Add(Keys.Multiply, nummultiply);
            keyPic.Add(Keys.Divide, numdivide);
            keyPic.Add(Keys.NumLock, numLock);

            keyPic.Add(Keys.PageUp, pageUp);
            keyPic.Add(Keys.Home, home);
            keyPic.Add(Keys.Insert, insert);
            keyPic.Add(Keys.Delete, delete);
            keyPic.Add(Keys.End, end);
            keyPic.Add(Keys.PageDown, pageDown);
            //右数字键
            keyPic.Add(Keys.NumPad7, num7);
            keyPic.Add(Keys.NumPad8, num8);
            keyPic.Add(Keys.NumPad9, num9);
            keyPic.Add(Keys.NumPad4, num4);
            keyPic.Add(Keys.NumPad5, num5);
            keyPic.Add(Keys.NumPad6, num6);
            keyPic.Add(Keys.NumPad1, num1);
            keyPic.Add(Keys.NumPad2, num2);
            keyPic.Add(Keys.NumPad3, num3);
            keyPic.Add(Keys.NumPad0, num0);
            //右加和enter
            keyPic.Add(Keys.Add, numadd);
            //keyPic.Add(Keys.Enter, numenter);
            //方向键
            keyPic.Add(Keys.Up, up);
            keyPic.Add(Keys.Down, down);
            keyPic.Add(Keys.Left, left);
            keyPic.Add(Keys.Right, right);
            //回到左边从~开始
            keyPic.Add(Keys.Oemtilde, separator);
            keyPic.Add(Keys.D1, top1);
            keyPic.Add(Keys.D2, top2);
            keyPic.Add(Keys.D3, top3);
            keyPic.Add(Keys.D4, top4);
            keyPic.Add(Keys.D5, top5);
            keyPic.Add(Keys.D6, top6);
            keyPic.Add(Keys.D7, top7);
            keyPic.Add(Keys.D8, top8);
            keyPic.Add(Keys.D9, top9);
            keyPic.Add(Keys.D0, top0);
            keyPic.Add(Keys.OemMinus, Minus);


            keyPic.Add(Keys.Oemplus, equals);//可能不对
            keyPic.Add(Keys.Back, backSpance);

            //字母第一行
            keyPic.Add(Keys.Tab, tab);
            keyPic.Add(Keys.Q, q);
            keyPic.Add(Keys.W, w);
            keyPic.Add(Keys.E, e);
            keyPic.Add(Keys.R, r);
            keyPic.Add(Keys.T, t);
            keyPic.Add(Keys.Y, y);
            keyPic.Add(Keys.U, u);
            keyPic.Add(Keys.I, i);
            keyPic.Add(Keys.O, o);
            keyPic.Add(Keys.P, p);

            keyPic.Add(Keys.OemOpenBrackets, openingBracket);
            keyPic.Add(Keys.Oem6, closingBracket);
            keyPic.Add(Keys.Oem5, backslash);//缺一个、键

            //第二行
            keyPic.Add(Keys.CapsLock, capsLK);
            keyPic.Add(Keys.A, a);
            keyPic.Add(Keys.S, s);
            keyPic.Add(Keys.D, d);
            keyPic.Add(Keys.F, f);
            keyPic.Add(Keys.G, g);
            keyPic.Add(Keys.H, h);
            keyPic.Add(Keys.J, j);
            keyPic.Add(Keys.K, k);
            keyPic.Add(Keys.L, l);
            keyPic.Add(Keys.Oem1, semicolon);
            keyPic.Add(Keys.Oem7, singleQuote);
            keyPic.Add(Keys.Return, enter);

            //第三行
            keyPic.Add(Keys.LShiftKey, shift);
            keyPic.Add(Keys.Z, z);
            keyPic.Add(Keys.X, x);
            keyPic.Add(Keys.C, c);
            keyPic.Add(Keys.V, v);
            keyPic.Add(Keys.B, b);
            keyPic.Add(Keys.N, n);
            keyPic.Add(Keys.M, m);
            keyPic.Add(Keys.Oemcomma, comma);
            keyPic.Add(Keys.OemPeriod, dot);
            keyPic.Add(Keys.OemQuestion, slash);
            keyPic.Add(Keys.RShiftKey, shiftRight);

            //最底下一行
            keyPic.Add(Keys.ControlKey, ctrl);
            keyPic.Add(Keys.LWin, win);
            keyPic.Add(Keys.LMenu, alt);
            keyPic.Add(Keys.Space, space);
            keyPic.Add(Keys.RMenu, altRight);
            keyPic.Add(Keys.RWin, winRight);
            keyPic.Add(Keys.Apps, menu);
            keyPic.Add(Keys.RControlKey, ctrlRight);
        }*/
        /// <summary>
        /// 初始化按键和按钮对应
        /// </summary>
        /* private void initBtn() {
             //第一行
             keyBtn.Add(Keys.Escape, a1);
             keyBtn.Add(Keys.F1, a2);
             keyBtn.Add(Keys.F2, a3);
             keyBtn.Add(Keys.F3, a4);
             keyBtn.Add(Keys.F4, a5);
             keyBtn.Add(Keys.F5, a6);
             keyBtn.Add(Keys.F6, a7);
             keyBtn.Add(Keys.F7, a8);
             keyBtn.Add(Keys.F8, a9);
             keyBtn.Add(Keys.F9, a10);
             keyBtn.Add(Keys.F10, a11);
             keyBtn.Add(Keys.F11, a12);
             keyBtn.Add(Keys.F12, a13);

             keyBtn.Add(Keys.PrintScreen, a14);
             keyBtn.Add(Keys.Scroll, a15);
             keyBtn.Add(Keys.Pause, a16);

             //没算上灯，第二行从右边开始

             keyBtn.Add(Keys.Subtract, a17);
             keyBtn.Add(Keys.Multiply, a18);
             keyBtn.Add(Keys.Divide, a19);
             keyBtn.Add(Keys.NumLock, a20);

             keyBtn.Add(Keys.PageUp, a21);
             keyBtn.Add(Keys.Home, a22);
             keyBtn.Add(Keys.Insert, a23);
             keyBtn.Add(Keys.Delete, a24);
             keyBtn.Add(Keys.End, a25);
             keyBtn.Add(Keys.PageDown, a26);
             //右数字键
             keyBtn.Add(Keys.NumPad7, a27);
             keyBtn.Add(Keys.NumPad8, a28);
             keyBtn.Add(Keys.NumPad9, a29);
             keyBtn.Add(Keys.NumPad4, a30);
             keyBtn.Add(Keys.NumPad5, a31);
             keyBtn.Add(Keys.NumPad6, a32);
             keyBtn.Add(Keys.NumPad1, a33);
             keyBtn.Add(Keys.NumPad2, a34);
             keyBtn.Add(Keys.NumPad3, a35);
             keyBtn.Add(Keys.NumPad0, a36);
             //右加和enter
             keyBtn.Add(Keys.Add, a37);
             keyBtn.Add(Keys.Enter, numenter);
             //方向键
             keyBtn.Add(Keys.Up, up);
             keyBtn.Add(Keys.Down, down);
             keyBtn.Add(Keys.Left, left);
             keyBtn.Add(Keys.Right, right);
             //回到左边从~开始
             keyBtn.Add(Keys.Oemtilde, b1);
             keyBtn.Add(Keys.D1, b2);
             keyBtn.Add(Keys.D2, b3);
             keyBtn.Add(Keys.D3, b4);
             keyBtn.Add(Keys.D4, b5);
             keyBtn.Add(Keys.D5, b6);
             keyBtn.Add(Keys.D6, b7);
             keyBtn.Add(Keys.D7, b8);
             keyBtn.Add(Keys.D8, b9);
             keyBtn.Add(Keys.D9, b10);
             keyBtn.Add(Keys.D0, b11);
             keyBtn.Add(Keys.OemMinus, b12);


             keyBtn.Add(Keys.Oemplus, b13);
             keyBtn.Add(Keys.Back, b14);

             //字母第一行
             //keyBtn.Add(Keys.Tab, tab);//废弃
             keyBtn.Add(Keys.Q, b15);
             keyBtn.Add(Keys.W, b16);
             keyBtn.Add(Keys.E, b17);
             keyBtn.Add(Keys.R, b18);
             keyBtn.Add(Keys.T, b19);
             keyBtn.Add(Keys.Y, b20);
             keyBtn.Add(Keys.U, b21);
             keyBtn.Add(Keys.I, b22);
             keyBtn.Add(Keys.O, b23);
             keyBtn.Add(Keys.P, b24);

             keyBtn.Add(Keys.OemOpenBrackets, b25);
             keyBtn.Add(Keys.Oem6, b26);
             keyBtn.Add(Keys.Oem5, b27);

             //第二行
             keyBtn.Add(Keys.CapsLock, b28);
             keyBtn.Add(Keys.A, b29);
             keyBtn.Add(Keys.S, b30);
             keyBtn.Add(Keys.D, b31);
             keyBtn.Add(Keys.F, b32);
             keyBtn.Add(Keys.G, b33);
             keyBtn.Add(Keys.H, b34);
             keyBtn.Add(Keys.J, b35);
             keyBtn.Add(Keys.K, b36);
             keyBtn.Add(Keys.L, b37);
             keyBtn.Add(Keys.Oem1, b38);
             keyBtn.Add(Keys.Oem7, b39);
             keyBtn.Add(Keys.Return, b40);

             //第三行
             keyBtn.Add(Keys.LShiftKey, b41);
             keyBtn.Add(Keys.Z, b42);
             keyBtn.Add(Keys.X, b43);
             keyBtn.Add(Keys.C, b44);
             keyBtn.Add(Keys.V, b45);
             keyBtn.Add(Keys.B, b46);
             keyBtn.Add(Keys.N, b47);
             keyBtn.Add(Keys.M, b48);
             keyBtn.Add(Keys.Oemcomma, b49);
             keyBtn.Add(Keys.OemPeriod, b50);
             keyBtn.Add(Keys.OemQuestion, b51);

             *//*//最底下一行
             keyBtn.Add(Keys.ControlKey, b53);
             keyBtn.Add(Keys.LWin, b54);
             keyBtn.Add(Keys.LMenu, alt);
             keyBtn.Add(Keys.Space, space);
             keyBtn.Add(Keys.RMenu, altRight);
             keyBtn.Add(Keys.RWin, winRight);
             keyBtn.Add(Keys.Apps, menu);
             keyBtn.Add(Keys.RControlKey, ctrlRight);


         }*/
        /// <summary>
        /// 初始化按钮对应音乐
        /// </summary>
        /* private void iniBtnMusic() {
             //1
             btnMusic.Add(a1, "Music/A!.wav");
             btnMusic.Add(a2, "Music/C!.wav");
             btnMusic.Add(a3, "Music/D!.wav");
             btnMusic.Add(a4, "Music/F!.wav");
             btnMusic.Add(a5, "Music/G!.wav");
             //2
             btnMusic.Add(a6, "Music/2A!.wav");
             btnMusic.Add(a7, "Music/2C!.wav");
             btnMusic.Add(a8, "Music/2D!.wav");
             btnMusic.Add(a9, "Music/2F!.wav");
             btnMusic.Add(a10, "Music/2G!.wav");
             //3
             btnMusic.Add(a11, "Music/3A!.wav");
             btnMusic.Add(a12, "Music/3C!.wav");
             btnMusic.Add(a13, "Music/3D!.wav");
             btnMusic.Add(a14, "Music/3F!.wav");
             btnMusic.Add(a15, "Music/3G!.wav");
             //4
             btnMusic.Add(a16, "Music/4A!.wav");
             btnMusic.Add(a17, "Music/4C!.wav");
             btnMusic.Add(a18, "Music/4D!.wav");
             btnMusic.Add(a19, "Music/4F!.wav");
             btnMusic.Add(a20, "Music/4G!.wav");
             //5
             btnMusic.Add(a21, "Music/5A!.wav");
             btnMusic.Add(a22, "Music/5C!.wav");
             btnMusic.Add(a23, "Music/5D!.wav");
             btnMusic.Add(a24, "Music/5F!.wav");
             btnMusic.Add(a25, "Music/5G!.wav");
             //6
             btnMusic.Add(a26, "Music/6A!.wav");
             btnMusic.Add(a27, "Music/6C!.wav");
             btnMusic.Add(a28, "Music/6D!.wav");
             btnMusic.Add(a29, "Music/6F!.wav");
             btnMusic.Add(a30, "Music/6G!.wav");
             //7
             btnMusic.Add(a31, "Music/7A!.wav");
             btnMusic.Add(a32, "Music/7C!.wav");
             btnMusic.Add(a33, "Music/7D!.wav");
             btnMusic.Add(a34, "Music/7F!.wav");
             btnMusic.Add(a35, "Music/7G!.wav");
             //8
             btnMusic.Add(a36, "Music/8A!.wav");



             //1
             btnMusic.Add(b1, "Music/A.wav");
             btnMusic.Add(b2, "Music/B.wav");
             btnMusic.Add(b3, "Music/C.wav");
             btnMusic.Add(b4, "Music/D.wav");
             btnMusic.Add(b5, "Music/E.wav");
             btnMusic.Add(b6, "Music/F.wav");
             btnMusic.Add(b7, "Music/G!.wav");
             //2
             btnMusic.Add(b8, "Music/2A.wav");
             btnMusic.Add(b9, "Music/2B.wav");
             btnMusic.Add(b10, "Music/2C.wav");
             btnMusic.Add(b11, "Music/2D.wav");
             btnMusic.Add(b12, "Music/2E.wav");
             btnMusic.Add(b13, "Music/2F.wav");
             btnMusic.Add(b14, "Music/2G.wav");
             //3
             btnMusic.Add(b15, "Music/3A.wav");
             btnMusic.Add(b16, "Music/3B.wav");
             btnMusic.Add(b17, "Music/3C.wav");
             btnMusic.Add(b18, "Music/3D.wav");
             btnMusic.Add(b19, "Music/3E.wav");
             btnMusic.Add(b20, "Music/3F.wav");
             btnMusic.Add(b21, "Music/3G.wav");
             //4
             btnMusic.Add(b22, "Music/4A.wav");
             btnMusic.Add(b23, "Music/4B.wav");
             btnMusic.Add(b24, "Music/4C.wav");
             btnMusic.Add(b25, "Music/4D.wav");
             btnMusic.Add(b26, "Music/4E.wav");
             btnMusic.Add(b27, "Music/4F.wav");
             btnMusic.Add(b28, "Music/4G.wav");
             //5
             btnMusic.Add(b29, "Music/5A.wav");
             btnMusic.Add(b30, "Music/5B.wav");
             btnMusic.Add(b31, "Music/5C.wav");
             btnMusic.Add(b32, "Music/5D.wav");
             btnMusic.Add(b33, "Music/5E.wav");
             btnMusic.Add(b34, "Music/5F.wav");
             btnMusic.Add(b35, "Music/5G.wav");
             //6
             btnMusic.Add(b36, "Music/6A.wav");
             btnMusic.Add(b37, "Music/6B.wav");
             btnMusic.Add(b38, "Music/6C.wav");
             btnMusic.Add(b39, "Music/6D.wav");
             btnMusic.Add(b40, "Music/6E.wav");
             btnMusic.Add(b41, "Music/6F.wav");
             btnMusic.Add(b42, "Music/6G.wav");
             //7
             btnMusic.Add(b43, "Music/7A.wav");
             btnMusic.Add(b44, "Music/7B.wav");
             btnMusic.Add(b45, "Music/7C.wav");
             btnMusic.Add(b46, "Music/7D.wav");
             btnMusic.Add(b47, "Music/7E.wav");
             btnMusic.Add(b48, "Music/7F.wav");
             btnMusic.Add(b49, "Music/7G.wav");
             //8
             btnMusic.Add(b50, "Music/8A.wav");
             btnMusic.Add(b51, "Music/8B.wav");
             btnMusic.Add(b52, "Music/8C.wav");
         } */
        #endregion

        public static void write(string error) {
            FileStream fs = null;
            StreamReader sr = null;
            StreamWriter sw = null;
            try {
                fs = new FileStream("ERROR/Piano.err", FileMode.Open);
                sr = new StreamReader(fs);
                sw = new StreamWriter(fs);
                StringBuilder sb = new StringBuilder(sr.ReadToEnd());
                sb.Append(error);
                sw.Write(sb.ToString() + "\r\n" + str + "\r\n" + DateTime.Now + "\r\n");
                sw.Flush();
            } catch {

            } finally {
                if (sw != null) {
                    sw.Close();
                }
                if (fs != null) {
                    fs.Close();
                }
            }
        }
    }
}
