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
using WpfApp1;
using static _7kinPC.MainWindow;

namespace _7kinPC
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
        public static bool boolme = false;

        public static int buddjet = 0;



        private void gettolistPC(object sender, RoutedEventArgs e)
        {
            buddjet = Convert.ToInt32(tbb1.Text);
            if (Top1PC.IsChecked == true)
            {
                boolme = true;
            }
            
           this.Hide();
            
            ListPC listPC = new ListPC();
            listPC.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            if (Kode.Text == "Admin")
            {
                this.Hide();

                NewPC newPC = new NewPC();
                newPC.Show();
            }
            else if (Kode.Text == "ArtemZmeya")
            {
                this.Hide();

                snakee snakee = new snakee();
                snakee.Show();

            }
        }
    }
}
