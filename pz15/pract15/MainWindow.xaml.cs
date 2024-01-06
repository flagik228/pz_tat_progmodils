using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;

namespace pract15
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();

            // Инициализация таймера
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;

            // Запуск таймера
            timer.Start();

            // Заполнение ComboBox с доступными сетевыми интерфейсами
            foreach (var networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                InterfaceComboBox.Items.Add(networkInterface);
            }

            // Выбор первого интерфейса
            if (InterfaceComboBox.Items.Count > 0)
            {
                InterfaceComboBox.SelectedIndex = 0;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Обновление информации каждую секунду
            UpdateNetworkInfo();
        }

        private void UpdateNetworkInfo()
        {
            // Получение выбранного интерфейса из ComboBox
            var selectedInterface = InterfaceComboBox.SelectedItem as NetworkInterface;
            if (selectedInterface == null)
            {
                return;
            }

            // Получение информации о сетевом интерфейсе
            var interfaceType = selectedInterface.NetworkInterfaceType;
            var maxSpeed = selectedInterface.Speed;
            var bytesSent = selectedInterface.GetIPv4Statistics().BytesSent;
            var bytesReceived = selectedInterface.GetIPv4Statistics().BytesReceived;
            var downloadSpeed = selectedInterface.GetIPv4Statistics().BytesReceived - bytesReceived;
            var uploadSpeed = selectedInterface.GetIPv4Statistics().BytesSent - bytesSent;
            var mama = selectedInterface.GetPhysicalAddress();

            // Отображение информации в TextBlock
            InfoTextBlock.Text = $"Тип интерфейса: {interfaceType}\n" +
                                 $"Максимальная скорость: {maxSpeed} bps\n" +
                                 $"Передано байт: {bytesSent}\n" +
                                 $"Получено байт: {bytesReceived}\n" +
                                 $"Скорость загрузки: {downloadSpeed} bps\n" +
                                 $"Скорость отдачи: {uploadSpeed} bps\n" +
                                 $"Скорость отдачи: {mama} bps";
        }
    }
}