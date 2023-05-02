using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public EditWindow()
        {
            InitializeComponent();
        }


        bd18Entities db = bd18Entities.GetContext();

        Accounting p1 = new Accounting();

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EditRecord_Click(object sender, RoutedEventArgs e)
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
                db.SaveChanges();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            p1 = db.Accountings.Find(ClassDannie.id);

            idTextBox.Text = p1.ID.ToString();
            surnameTextBox.Text = p1.Surname;
            nameTextBox.Text = p1.Name;
            thierdNameTextBox.Text = p1.ThirdName;
            mondayTextBox.Text = p1.MondayDetailsNumber.ToString();
            ToesdayTextBox.Text = p1.ToesdayDetailsNumber.ToString();
            WednesdayTextBox.Text = p1.WednesdayDetailsNumber.ToString();
            ThursdayTextBox.Text = p1.ThursdayDetailsNumber.ToString();
            FridayTextBox.Text = p1.FridayDetailsNumber.ToString();
            WorkshopTextBox.Text = p1.Workshop;
            ProductTextBox.Text = p1.Product;
            PriceTextBox.Text = p1.Price.ToString();
        }
    }
}
