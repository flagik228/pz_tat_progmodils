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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace pz11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Book> _books;
        private string _bookTitle;
        private string _year;
        private string _author;

        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set
            {
                _books = value;
                OnPropertyChanged();
            }
        }

        public string BookTitle
        {
            get { return _bookTitle; }
            set
            {
                _bookTitle = value;
                OnPropertyChanged();
            }
        }

        public string Year
        {
            get { return _year; }
            set
            {
                _year = value;
                OnPropertyChanged();
            }
        }

        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            Books = new ObservableCollection<Book>();

            SaveCommand = new RelayCommand(SaveBook);
        }

        private void SaveBook()
        {
            var newBook = new Book
            {
                Title = BookTitle,
                Year = Year,
                Author = Author
            };

            Books.Add(newBook);

            BookTitle = string.Empty;
            Year = string.Empty;
            Author = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Получаем введенные значения из текстовых полей
            string bookTitle = bookTitleTextBox.Text;
            string year = yearTextBox.Text;
            string author = authorTextBox.Text;

            // Создаем новый объект с данными
            Book newBook = new Book { Title = bookTitle, Year = year, Author = author };

            // Получаем источник данных для ListView
            ObservableCollection<Book> books = (ObservableCollection<Book>)ListBibly.ItemsSource;

            // Добавляем новую запись в список
            books.Add(newBook);
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Author { get; set; }
    }
}