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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int _width = 0;
        public int _height = 0;
        public bool _start = false;
        public Random rnd = new Random();
        public int _cnt = 0;

        public MainWindow()
        {
            InitializeComponent();
            //MessageBox.Show($"Width {myWindow.Width} Height {myWindow.Height}");
            _width = (int)myWindow.Width;
            _height = (int)myWindow.Height;
            buttonLocation(_width/2, _height/2);
        }

        public void buttonLocation(int nWidth, int nHeight)
        {
            myButton.Margin = new Thickness(Math.Min(nWidth - myButton.Width / 2, _width - myButton.Width / 2)
                , Math.Min(nHeight - myButton.Height / 2, _height - myButton.Height / 2), 0, 0);
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            _start = !_start;

            if (_start)
            {
                myButton.Content = "End Game!";
                myLabel.Content = "Chase Count = 0";
                buttonLocation(rnd.Next(0, (int)(_width - myButton.Width)), rnd.Next(0, (int)(_height - myButton.Height)));

            }
            else
            {
                myButton.Content = "Start";
                buttonLocation(_width / 2, _height / 2);
                MessageBox.Show($"Congratulations! It took you {_cnt} attempts!");

            }
        }

        private void myButton_MouseEnter(object sender, MouseEventArgs e)
        {
            if (_start)
            {
                buttonLocation(rnd.Next(0, (int)(_width - myButton.Width)), rnd.Next(0, (int)(_height - myButton.Height)));
                _cnt++;
                myLabel.Content = $"Chase Count = {_cnt}";
            }
        }
    }
}
