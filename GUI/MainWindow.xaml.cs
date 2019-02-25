using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        servant s;
        public MainWindow()
        {
            InitializeComponent();
        }
        /// 0 start
        /// 1 think
        /// 2 w8
        /// 3 eat
        public void set(int cond, int i)
        {
            i++;
            this.Dispatcher.Invoke((Action)(() =>
            {
                if (i == 1)
                {
                    if (cond == 0)
                    {
                        b1.Visibility = Visibility.Hidden;
                        pl1.Visibility = Visibility.Hidden;
                        fpl1.Visibility = Visibility.Hidden;
                        t1.Text = "1:Connecting...";
                    }
                    if (cond == 1)
                    {
                        b1.Visibility = Visibility.Visible;
                        pl1.Visibility = Visibility.Hidden;
                        fpl1.Visibility = Visibility.Hidden;
                        ep1.Fill = Brushes.LightCyan;
                        t1.Text = "1:Thincking";
                    }
                    if (cond == 2)
                    {
                        b1.Visibility = Visibility.Hidden;
                        pl1.Visibility = Visibility.Hidden;
                        fpl1.Visibility = Visibility.Visible;
                        ep1.Fill = Brushes.Pink;
                        t1.Text = "1:Waiting";
                    }
                    if (cond == 3)
                    {
                        b1.Visibility = Visibility.Hidden;
                        pl1.Visibility = Visibility.Visible;
                        fpl1.Visibility = Visibility.Hidden;
                        ep1.Fill = Brushes.LightGreen;
                        t1.Text = "1:Eating";
                    }
                }
                if (i == 2)
                {
                    if (cond == 0)
                    {
                        b2.Visibility = Visibility.Hidden;
                        pl2.Visibility = Visibility.Hidden;
                        fpl2.Visibility = Visibility.Hidden;
                        t2.Text = "2:Connecting...";
                    }
                    if (cond == 1)
                    {
                        b2.Visibility = Visibility.Visible;
                        pl2.Visibility = Visibility.Hidden;
                        fpl2.Visibility = Visibility.Hidden;
                        ep2.Fill = Brushes.LightCyan;
                        t2.Text = "2:Thincking";
                    }
                    if (cond == 2)
                    {
                        b2.Visibility = Visibility.Hidden;
                        pl2.Visibility = Visibility.Hidden;
                        fpl2.Visibility = Visibility.Visible;
                        ep2.Fill = Brushes.Pink;
                        t2.Text = "2:Waiting";
                    }
                    if (cond == 3)
                    {
                        b2.Visibility = Visibility.Hidden;
                        pl2.Visibility = Visibility.Visible;
                        fpl2.Visibility = Visibility.Hidden;
                        ep2.Fill = Brushes.LightGreen;
                        t2.Text = "2:Eating";
                    }
                }
                if (i == 3)
                {
                    if (cond == 0)
                    {
                        b3.Visibility = Visibility.Hidden;
                        pl3.Visibility = Visibility.Hidden;
                        fpl3.Visibility = Visibility.Hidden;
                        t3.Text = "3:Connecting...";
                    }
                    if (cond == 1)
                    {
                        b3.Visibility = Visibility.Visible;
                        pl3.Visibility = Visibility.Hidden;
                        fpl3.Visibility = Visibility.Hidden;
                        ep3.Fill = Brushes.LightCyan;
                        t3.Text = "3:Thincking";
                    }
                    if (cond == 2)
                    {
                        b3.Visibility = Visibility.Hidden;
                        pl3.Visibility = Visibility.Hidden;
                        fpl3.Visibility = Visibility.Visible;
                        ep3.Fill = Brushes.Pink;
                        t3.Text = "3:Waiting";
                    }
                    if (cond == 3)
                    {
                        b3.Visibility = Visibility.Hidden;
                        pl3.Visibility = Visibility.Visible;
                        fpl3.Visibility = Visibility.Hidden;
                        ep3.Fill = Brushes.LightGreen;
                        t3.Text = "3:Eating";
                    }
                }
                if (i == 4)
                {
                    if (cond == 0)
                    {
                        b4.Visibility = Visibility.Hidden;
                        pl4.Visibility = Visibility.Hidden;
                        fpl4.Visibility = Visibility.Hidden;
                        t4.Text = "4:Connecting...";
                    }
                    if (cond == 1)
                    {
                        b4.Visibility = Visibility.Visible;
                        pl4.Visibility = Visibility.Hidden;
                        fpl4.Visibility = Visibility.Hidden;
                        ep4.Fill = Brushes.LightCyan;
                        t4.Text = "4:Thincking";
                    }
                    if (cond == 2)
                    {
                        b4.Visibility = Visibility.Hidden;
                        pl4.Visibility = Visibility.Hidden;
                        fpl4.Visibility = Visibility.Visible;
                        ep4.Fill = Brushes.Pink;
                        t4.Text = "4:Waiting";
                    }
                    if (cond == 3)
                    {
                        b4.Visibility = Visibility.Hidden;
                        pl4.Visibility = Visibility.Visible;
                        fpl4.Visibility = Visibility.Hidden;
                        ep4.Fill = Brushes.LightGreen;
                        t4.Text = "4:Eating";
                    }
                }
                if (i == 5)
                {
                    if (cond == 0)
                    {
                        b5.Visibility = Visibility.Hidden;
                        pl5.Visibility = Visibility.Hidden;
                        fpl5.Visibility = Visibility.Hidden;
                        t5.Text = "5:Connecting...";
                    }
                    if (cond == 1)
                    {
                        b5.Visibility = Visibility.Visible;
                        pl5.Visibility = Visibility.Hidden;
                        fpl5.Visibility = Visibility.Hidden;
                        ep5.Fill = Brushes.LightCyan;
                        t5.Text = "5:Thincking";
                    }
                    if (cond == 2)
                    {
                        b5.Visibility = Visibility.Hidden;
                        pl5.Visibility = Visibility.Hidden;
                        fpl5.Visibility = Visibility.Visible;
                        ep5.Fill = Brushes.Pink;
                        t5.Text = "5:Waiting";
                    }
                    if (cond == 3)
                    {
                        b5.Visibility = Visibility.Hidden;
                        pl5.Visibility = Visibility.Visible;
                        fpl5.Visibility = Visibility.Hidden;
                        ep5.Fill = Brushes.LightGreen;
                        t5.Text = "5:Eating";
                    }
                }
            }));
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            string ip="";
            int port=0;
            this.Dispatcher.Invoke((Action)(() =>
            {
                ip = ipbox.Text;
                port = int.Parse(portbox.Text);
            }));
            if (ip == "loop back") ip = "127.0.0.1";
            s = new servant(ip,port);
            s.OnSetCondition += set;
            start.IsEnabled = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            s.close();
            //Application.ExitThread();
            this.Close();
        }
    }
}
