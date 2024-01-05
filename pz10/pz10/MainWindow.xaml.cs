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
using System.IO;
using System.Runtime.CompilerServices;

namespace pz10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Stack<TextSnapshot> snapshots;
        private TextSnapshot currentSnapshot;

        public event PropertyChangedEventHandler PropertyChanged;

        private double fontSize;
        public double FontSize
        {
            get { return fontSize; }
            set
            {
                if (fontSize != value)
                {
                    fontSize = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool isBold;
        public bool IsBold
        {
            get { return isBold; }
            set
            {
                if (isBold != value)
                {
                    isBold = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool isItalic;
        public bool IsItalic
        {
            get { return isItalic; }
            set
            {
                if (isItalic != value)
                {
                    isItalic = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool isUnderline;
        public bool IsUnderline
        {
            get { return isUnderline; }
            set
            {
                if (isUnderline != value)
                {
                    isUnderline = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            snapshots = new Stack<TextSnapshot>();
            currentSnapshot = new TextSnapshot();

            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveSnapshot();
            SaveToFile();
        }

        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            if (snapshots.Count > 0)
            {
                currentSnapshot = snapshots.Pop();
                RestoreSnapshot();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SaveSnapshot()
        {
            var snapshot = new TextSnapshot
            {
                FontSize = FontSize,
                IsBold = IsBold,
                IsItalic = IsItalic,
                IsUnderline = IsUnderline,
                Text = TextBox.Text
            };

            snapshots.Push(currentSnapshot);
            currentSnapshot = snapshot;
        }

        private void RestoreSnapshot()
        {
            FontSize = currentSnapshot.FontSize;
            IsBold = currentSnapshot.IsBold;
            IsItalic = currentSnapshot.IsItalic;
            IsUnderline = currentSnapshot.IsUnderline;
            TextBox.Text = currentSnapshot.Text;
        }

        private void SaveToFile()
        {
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, TextBox.Text);
            }
        }

        private void ItalicCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            TextBox.FontStyle = FontStyles.Italic;
        }

        private void BoldCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            TextBox.FontWeight = FontWeights.Bold;
        }

        private void UnderlineCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            TextBox.TextDecorations = TextDecorations.Underline;
        }
    }

    public class TextSnapshot
    {
        public double FontSize { get; set; }
        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }
        public bool IsUnderline { get; set; }
        public string Text { get; set; }
    }
}