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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace _7kinPC
{
    /// <summary>
    /// Логика взаимодействия для ListPC.xaml
    /// </summary>
    public partial class ListPC : Window
    {
        public ListPC()
        {

            InitializeComponent();

            string directoty = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string path = System.IO.Path.GetDirectoryName(directoty);
            string currentPath = $"{path}\\PcBd.mdf";


            if (MainWindow.boolme == true)
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + currentPath + ";Integrated Security=True";
                string sqlExpression = "SELECT Top 1 * FROM PC order by price";
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

                            if (price < MainWindow.buddjet || price == MainWindow.buddjet)
                            {
                                list_PC.Text = Convert.ToString($"{id} {nazv} {videocarta} {kolvoOpMem} {proc} {price} {kolvoSklad}\n");
                            }
                        }
                    }
                    reader.Close();
                }
            }
            else
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +currentPath + ";Integrated Security=True";
                string sqlExpression = "SELECT * FROM PC";
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

                            if (price < MainWindow.buddjet || price == MainWindow.buddjet)
                            {
                                list_PC.Text += Convert.ToString($"{id} {nazv} {videocarta} {kolvoOpMem} {proc} {price} {kolvoSklad}\n");
                            }
                        }
                    }
                    reader.Close();
                }
            }
            
        }

        private void GetToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            MainWindow main = new MainWindow();
            main.Show();
        }

        
    }
}
