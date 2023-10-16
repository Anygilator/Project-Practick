using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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

namespace _7kinPC
{
    /// <summary>
    /// Логика взаимодействия для NewPC.xaml
    /// </summary>
    public partial class NewPC : Window
    {
        public NewPC()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string directoty = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string path = System.IO.Path.GetDirectoryName(directoty);
            string currentPath = $"{path}\\PcBd.mdf";

            if (Id.Text.Length != 0 && nazv.Text.Length != 0 && GPU.Text.Length != 0 && RAM.Text.Length != 0 && CPU.Text.Length != 0 && Price.Text.Length != 0 && Count.Text.Length != 0)
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + currentPath + ";Integrated Security=True";
                string sqlExpression = $"insert into PC values ('{Convert.ToInt32(Id.Text)}','{nazv.Text}','{GPU.Text}','{Convert.ToInt32(RAM.Text)}','{CPU.Text}','{Convert.ToDouble(Price.Text)}','{Convert.ToInt32(Count.Text)}')";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            object id = reader.GetValue(0);
                            object nazv = reader.GetValue(1);
                            object videocarta = reader.GetValue(2);
                            object kolvoOpMem = reader.GetValue(3);
                            object proc = reader.GetValue(4);
                            int price = Convert.ToInt32(reader.GetValue(5));
                            object kolvoSklad = reader.GetValue(6);
                        }
                    }
                    reader.Close();

                    MessageBox.Show("Сборка успешно добавлена");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!!!");
            }
        }

        private void GetToMainWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
