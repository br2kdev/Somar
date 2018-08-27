using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ProjetoSomarUI
{
    public class FormBase : Form
    {
        
        [DllImport("User32.dll")]
        private static extern int RegisterHotKey(IntPtr hWnd, int id, int
        fsModifiers, int vk);
        [DllImport("User32.dll")]
        private static extern int UnregisterHotKey(IntPtr hWnd, int id);

        public static FormBase f1 = new FormBase();

        public static int Register(Form f)
        {
            IntPtr ip = f.Handle;
            return RegisterHotKey(ip, 1, 0, (int)Keys.Escape);
        }

        /*
        public static void b1_click(object sender, EventArgs e)
        {
            //Blah Blah stuff
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                MessageBox.Show("wow");
            }

            base.WndProc(ref m);
        }
        */

        protected override void WndProc(ref Message message)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }

            base.WndProc(ref message);
        }
    }
}
