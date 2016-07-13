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
            //теоретически можно добавить контейнер внедрения зависимостей, но дабы не стрелять из пушки по мухе, сделал проще.
            authorChangeService = new AuthorChangeService(new TestTask.DataAccess.AuthorChangeRepository());
            InitializeComponent();

            var loadBind = new CommandBinding(ApplicationCommands.Open);
            var saveBind = new CommandBinding(ApplicationCommands.Save);
            var updateBind = new CommandBinding(NavigationCommands.Refresh);
            loadBind.Executed += loadBind_Executed;
            saveBind.Executed += saveBind_Executed;
            updateBind.Executed += updateBind_Executed;

            this.CommandBindings.Add(loadBind);
            this.CommandBindings.Add(saveBind);
            this.CommandBindings.Add(updateBind);
        }
        /// <summary>
        /// Обновление данных на вкладке БД
        /// </summary>
        void updateBind_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            dataGrid.ItemsSource = authorChangeService.LoadChanges();
        }
        /// <summary>
        /// Сохранение изменений в БД
        /// </summary>
        void saveBind_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            authorChangeService.AddChanges((IEnumerable<AuthorChange>)assemblyGrid.ItemsSource);
        }
        /// <summary>
        /// Загрузка данных со сборки
        /// </summary>
        void loadBind_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.OpenFileDialog();
            if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            var changes = authorChangeService.LoadChanges(dialog.FileName);
            assemblyGrid.ItemsSource = changes;
        }
    }
}
