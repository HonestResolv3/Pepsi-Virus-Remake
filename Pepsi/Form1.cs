using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Pepsi
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        readonly Random rnd = new Random();
        readonly int resolutionX = Screen.PrimaryScreen.Bounds.Width;
        readonly int resolutionY = Screen.PrimaryScreen.Bounds.Height;

        int positionOfCursorX;
        int positionOfCursorY;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            do
            {
                positionOfCursorX = rnd.Next(0, resolutionX);
                positionOfCursorY = rnd.Next(0, resolutionY);
                Cursor.Position = new Point(positionOfCursorX, positionOfCursorY);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, positionOfCursorX, positionOfCursorY, 0, 0);
            } while (true);
        }
    }
}
