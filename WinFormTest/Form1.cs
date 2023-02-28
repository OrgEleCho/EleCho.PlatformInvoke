using EleCho.PlatformInvoke.Windows;

namespace WinFormTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NativeMethods.AnimateWindow(this.Handle, 100, AnimateWindowFlag.Center | AnimateWindowFlag.Hide);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NativeMethods.AnimateWindow(this.Handle, 100, AnimateWindowFlag.Center | AnimateWindowFlag.Activate);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
    }
}