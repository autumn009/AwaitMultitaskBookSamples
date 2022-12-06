using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
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
                Dispatcher.Invoke(() =>
                {
                    reportIt(i.ToString(), tid, taskid);
                });
                Task.Delay(1000).Wait();
            }
        }

        private void reportIt(string s, int tid, int? taskid)
        {
            var t = "null";
            if (taskid != null) t = taskid.ToString();
            textBox1.Text += $"{s}: Thread ID:{tid} Task ID:{t}\r\n";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var tid = Thread.CurrentThread.ManagedThreadId;
            var taskid = Task.CurrentId;
            reportIt("Button", tid, taskid);
        }
    }
}
