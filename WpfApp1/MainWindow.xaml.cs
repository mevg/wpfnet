using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using Json.Net;


namespace WpfApp1
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


        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var http = new  HttpClient();
            var response = await http.GetAsync("https://jsonplaceholder.typicode.com/todos/1");
            response.EnsureSuccessStatusCode();
            var contet = await response.Content.ReadAsStringAsync();

            var todo = JsonNet.Deserialize<Todo>(contet);
            this.id.Content = todo.id;
            this.title.Content = todo.title;
            this.completed.Content = todo.completed;

            Console.Write(todo);
           
        }
    }

    class Todo
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }
    }
}

