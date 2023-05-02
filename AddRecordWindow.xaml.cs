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
using System.Windows.Shapes;

namespace WPF_18
{
    /// <summary>
    /// Логика взаимодействия для AddRecordWindow.xaml
    /// </summary>
    public partial class AddRecordWindow : Window
    {
        public AddRecordWindow()
        {
            InitializeComponent();
        }

        bd18Entities db = bd18Entities.GetContext();

        Accounting p1 = new Accounting();

        private void AddRecord_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            //if (!int.TryParse(idTextBox.Text, out int id)) errors.AppendLine("Введите ID");

            if (surnameTextBox.Text.Length == 0) errors.AppendLine("Введите фамилию");
            if (nameTextBox.Text.Length == 0) errors.AppendLine("Введите имя");
            //if (thierdNameTextBox.Text.Length == 0) errors.AppendLine("Введите отчество");
/*
            if (!int.TryParse(idTextBox.Text, out int monday)) errors.AppendLine("Введите кол-во деталей в понедельник");
            if (!int.TryParse(idTextBox.Text, out int toesday)) errors.AppendLine("Введите кол-во деталей во вторник");
            if (!int.TryParse(idTextBox.Text, out int wednesday)) errors.AppendLine("Введите кол-во деталей в среду");
            if (!int.TryParse(idTextBox.Text, out int thursday)) errors.AppendLine("Введите кол-во деталей в четверг");
            if (!int.TryParse(idTextBox.Text, out int friday)) errors.AppendLine("Введите кол-во деталей в пятницу");
*/
            if (WorkshopTextBox.Text.Length == 0) errors.AppendLine("Введите наименование цеха");
            if (ProductTextBox.Text.Length == 0) errors.AppendLine("Введите наименование продукта");

            //if (!int.TryParse(idTextBox.Text, out int price)) errors.AppendLine("Цена изделия");

        if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (int.TryParse(idTextBox.Text, out int id) && int.TryParse(mondayTextBox.Text, out int monday) && int.TryParse(ToesdayTextBox.Text, out int toesday) && int.TryParse(WednesdayTextBox.Text, out int wednesday) && int.TryParse(ThursdayTextBox.Text, out int thursday) && int.TryParse(FridayTextBox.Text, out int friday) && int.TryParse(PriceTextBox.Text, out int price))
            {
                p1.ID = id;
                p1.Surname = surnameTextBox.Text;
                p1.Name = nameTextBox.Text;
                p1.ThirdName = thierdNameTextBox.Text;
                p1.MondayDetailsNumber = monday;
                p1.ToesdayDetailsNumber = toesday;
                p1.WednesdayDetailsNumber = wednesday;
                p1.ThursdayDetailsNumber = thursday;
                p1.FridayDetailsNumber = friday;
                p1.Workshop = WorkshopTextBox.Text;
                p1.Product = ProductTextBox.Text;
                p1.Price = price;
            }
            try
            {
                db.Accountings.Add(p1);

                db.SaveChanges();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}