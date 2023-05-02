using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
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

namespace WPF_18
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void IsAdmin()
        {
                buttonDelete.IsEnabled = false;
                buttonDelete2.IsEnabled = false;
                buttonRead.IsEnabled = false;
                buttonUpdate1.IsEnabled = false;
                buttonUpdate2.IsEnabled = false;
                buttonAdd.IsEnabled = false;
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            WindowAuthorization autorization = new WindowAuthorization();
            autorization.ShowDialog();

            if (Data.Login == false) Close();

            if (Data.Right == "Администратор") ;
            else
            {
                //fff
            }
            autorization.Title = Data.Familia + " " +
            Data.Name + " " + Data.Otchestvo + " - " + Data.Right;
        }

        bd18Entities db = bd18Entities.GetContext();
        //List<Accounting> _Accounting;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Accountings.Load();
            dataGrid.ItemsSource = db.Accountings.Local.ToBindingList();

            if (!Data.IsAdmin)
            {
                IsAdmin();
            }
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            AddRecordWindow f = new AddRecordWindow();
            f.ShowDialog();
            dataGrid.Focus();
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            int indexRow = dataGrid.SelectedIndex;
            if (indexRow != -1)
            {
                Accounting row = (Accounting)dataGrid.Items[indexRow];
                ClassDannie.id = row.ID;

                EditWindow f = new EditWindow();
                f.ShowDialog();
                dataGrid.Items.Refresh();
                dataGrid.Focus();
            }
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи.", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Accounting row = (Accounting)dataGrid.SelectedItems[0];

                    db.Accountings.Remove(row);
                    db.SaveChanges();

                    dataGrid.ItemsSource = db.Accountings.ToList();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись!");
                }
            }
        }
/*
        private void Button_Find(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.Items.Count; i++)
            {
                var row = (Accounting)dataGrid.Items[i];
                string findContent = row.Surname;
                try
                {
                    if (findContent != null && findContent.Contains(txtFind.Text))
                    {
                        object item = dataGrid.Items[i];
                        dataGrid.SelectedItem = item;
                        dataGrid.ScrollIntoView(item);
                        dataGrid.Focus();
                        break;
                    }
                }
                catch { }
            }
        }
*/
        private void Viborka1_Click(object sender, RoutedEventArgs e)
        {
            var filteredRows = from row in db.Accountings
                               where row.Price > 50
                               select row;
            dataGrid.ItemsSource = filteredRows.ToList();
        }

        private void Viborka2_Click(object sender, RoutedEventArgs e)
        {
            var filteredRows = from row in db.Accountings
                               where row.Price < 50
                               select row;
            dataGrid.ItemsSource = filteredRows.ToList();
        }

        private void Viborka3_Click(object sender, RoutedEventArgs e)
        {
            var filteredRows = from row in db.Accountings
                               where row.ThirdName == null
                               select row;
            dataGrid.ItemsSource = filteredRows.ToList();
        }

        private void Viborka4_Click(object sender, RoutedEventArgs e)
        {
            var filteredRows = from row in db.Accountings
                               let weekTotal = row.MondayDetailsNumber + row.ToesdayDetailsNumber + row.WednesdayDetailsNumber + row.ThursdayDetailsNumber + row.FridayDetailsNumber
                               where weekTotal > 300
                               select row;
            dataGrid.ItemsSource = filteredRows.ToList();
        }

        private void Viborka5_Click(object sender, RoutedEventArgs e)
        {
            var filteredRows = from row in db.Accountings
                               where row.Product == "123"
                               select row;
            dataGrid.ItemsSource = filteredRows.ToList();
        }

        private void Update1_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();

            var records = db.Accountings.ToList();

            foreach (var record in records)
            {
                int randomNumber = random.Next(1, 151);

                record.MondayDetailsNumber = randomNumber;
            }

            db.SaveChanges();
            dataGrid.ItemsSource = records.ToList();
        }

        private void Update2_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();

            var records = db.Accountings.ToList();

            foreach (var record in records)
            {
                int randomNumber = random.Next(1, 501);

                record.Price = randomNumber;
            }

            db.SaveChanges();
            dataGrid.ItemsSource = records.ToList();
        }

        private void Delete1_Click(object sender, RoutedEventArgs e)
        {
            var lastRecord = db.Accountings.OrderByDescending(x => x.ID).FirstOrDefault();

            if (lastRecord != null)
            {
                db.Accountings.Remove(lastRecord);
                db.SaveChanges();
            }
        }

        private void ViewDataGrid_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = db.Accountings.ToList();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Автор - Иванов Михаил ИСП-31\nЗадание\nУчет изделий, собранных в цехе за неделю. База данных должна содержать следующую \r\nинформацию: фамилию, имя, отчество сборщика, количество изготовленных изделий за \r\nкаждый день недели раздельно, название цеха, а также тип изделия и его стоимость.", "Справка");
        }
    }
}