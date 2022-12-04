using System.Diagnostics;

namespace WinForm1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var tid = Thread.CurrentThread.ManagedThreadId;
            var taskid = Task.CurrentId;
            reportIt("Load", tid, taskid);
            _ = Task.Run(sub);
        }

        private void sub()
        {
            var tid = Thread.CurrentThread.ManagedThreadId;
            var taskid = Task.CurrentId;
            for (int i = 0; i < 10; i++)
            {
                Invoke(() =>
                {
                    reportIt(i.ToString(), tid, taskid);
                });
                Task.Delay(1000).Wait();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tid = Thread.CurrentThread.ManagedThreadId;
            var taskid = Task.CurrentId;
            reportIt("Button", tid, taskid);
        }

        private void reportIt(string s, int tid, int? taskid)
        {
            var t = "null";
            if (taskid != null) t = taskid.ToString();
            textBox1.Text += $"{s}: Thread ID:{tid} Task ID:{t}\r\n";
        }
    }
}