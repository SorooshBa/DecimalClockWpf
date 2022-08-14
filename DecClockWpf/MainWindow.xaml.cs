using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DecClockWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0,0,0,0,1);
            dispatcherTimer.Tick += new EventHandler(dispatcher_tick);
            dispatcherTimer.Start();
            dt = new DecimalTime();
        }
        DecimalTime dt;
        private void dispatcher_tick(Object sender , EventArgs e)
        {
            setAngleForHands(dt.Hours, dt.Minuts, dt.Seconds);
            
        }
        private void setAngleForHands(int hour,int min,double second)
        {
            double angleMin = (360 * min) / (double)100;
            canMinHand.RenderTransform = new RotateTransform(angleMin);
            double angleHour = (((hour * 100) + min) * (double)360) /(double) 1000;
            canHouHand.RenderTransform = new RotateTransform(angleHour);
            double angleSecond = (360 * second) / (double)100;
            canSecHand.RenderTransform = new RotateTransform(angleSecond);
        }


    }
}
