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
using System.Threading;
using System.Windows.Threading;

namespace pz6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isCalculating;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isCalculating)
            {
                isCalculating = true;
                progressBar.Value = 0;
                outputText.Text = "";

                Thread calculationThread = new Thread(PerformCalculations);
                calculationThread.Start();
            }
        }

        private void PerformCalculations()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread.Sleep(500);
                UpdateProgressBar(i * 10);
                UpdateOutputText($"Процесс {i + 1} выполнен");
            }

            isCalculating = false;
        }

        private void UpdateProgressBar(int value)
        {
            Dispatcher.Invoke(() => progressBar.Value = value, DispatcherPriority.Background);
        }

        private void UpdateOutputText(string text)
        {
            Dispatcher.Invoke(() => outputText.Text += $"{text}\n", DispatcherPriority.Background);
        }
    }
}

/* 
 Выводы и анализ работы приложения:
 - При нажатии на кнопку "Start" вычисления начинаются и отображается прогресс выполнения.
 - Пользователь может в это время также рисовать на InkCanvas.
 - Приложение не зависает и продолжает отвечать на действия пользователя, благодаря использованию многопоточности.
 - По завершении вычислений выводится информация о каждой итерации в текстовом блоке.
 - Результат вычислений может занять продолжительное время, но пользователь не блокируется и имеет возможность рисования или других действий.
*/