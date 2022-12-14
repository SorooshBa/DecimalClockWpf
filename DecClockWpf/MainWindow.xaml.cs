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
            changeBackgroundByTime(dt.Hours);
            lblDigital.Content = dt.ToString();

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
        private void changeBackgroundByTime(int Hour)
        {
            
            LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush();
            myLinearGradientBrush.StartPoint = new Point(0, 0);
            myLinearGradientBrush.EndPoint = new Point(1, 1);
            switch (Hour)
            {
                case 0:
                    myLinearGradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(1,36,89), 0.0));
                    myLinearGradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 19, 34), 1.0));
                    break;
                case 1:
                    myLinearGradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 67, 114), 0.0));
                    myLinearGradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(1, 29, 52), 1.0));
                    break;
                case 2:
                    myLinearGradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(116, 212, 204), 0.0));
                    myLinearGradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(19, 134, 166), 1.0));
                    break;
                case 3:
                    myLinearGradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(254, 225, 84), 0.0));
                    myLinearGradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(163, 222, 198), 1.0));
                    break;
                case 4:
                    myLinearGradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(253, 195, 82), 0.0));
                    myLinearGradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(232, 237, 146), 1.0));
                    break;
                case 5:
                    myLinearGradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 172, 111), 0.0));
                    myLinearGradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 228, 103), 1.0));
                    break;
                case 6:
                    myLinearGradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(241, 132, 72), 0.0));
                    myLinearGradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 211, 100), 1.0));
                    break;
                case 7:
                    myLinearGradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(240, 107, 126), 0.0));
                    myLinearGradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(249, 168, 86), 1.0));
                    break;
                case 8:
                    myLinearGradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(91, 44, 131), 0.0));
                    myLinearGradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(209, 98, 139), 1.0));
                    break;
                case 9:
                    myLinearGradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(55, 26, 121), 0.0));
                    myLinearGradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(113, 54, 132), 1.0));
                    break;

            }
            MainGrid.Background = myLinearGradientBrush;
        }


    }
}
