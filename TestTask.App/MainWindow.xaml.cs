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
using TestTask.Models;
namespace TestTask.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AuthorChangeService authorChangeService;

        public MainWindow()
        {
            authorChangeService = new AuthorChangeService(new TestTask.DataAccess.AuthorChangeRepository());
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.OpenFileDialog();
            if(dialog.ShowDialog()!=System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            var changes = authorChangeService.LoadChanges(dialog.FileName);
            assemblyGrid.ItemsSource = changes;
        }

        private void buttonAddToDB_Click(object sender, RoutedEventArgs e)
        {
            authorChangeService.AddChanges((IEnumerable<AuthorChange>)assemblyGrid.ItemsSource);
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = authorChangeService.LoadChanges();
        }
    }
}
