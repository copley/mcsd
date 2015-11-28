using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

namespace UILock
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
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var worker = new BackgroundWorker();

            worker.DoWork += (s, a) =>
            {
                for (int i = 0; i < 20; i++)
                {
                    this.Dispatcher.Invoke(
                        () =>
                        {
                            this.CountOutput.Text = "Count: " + i;
                        });
                    Thread.Sleep(500);
                }
            };

            worker.RunWorkerAsync();
        }
    }
}
