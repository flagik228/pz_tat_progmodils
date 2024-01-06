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
using System.ComponentModel;
using System.Threading;

namespace pz14
{
    public partial class MainWindow : Window
    {
        private readonly Random _random = new Random();
        private const int criticaltemperature = 0;
        private Timer _timer;

        public MainWindow()
        {
            InitializeComponent();
            GenerateTemperature(3);
            _timer = new Timer(GenerateTemperature, null, TimeSpan.Zero, TimeSpan.FromSeconds(2));
        }
        private void GenerateTemperature(object state)
        {
            int temperature = _random.Next(-20, 40);
            Dispatcher.Invoke(() =>
            {
                TemperatureText.Text = temperature.ToString();
                if (temperature <= criticaltemperature)
                {
                    MessageBox.Show("температура приближается к критической точке!", "внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });
        }
    }
}