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
using MedicoPlus.Models;

namespace MedicoPlus.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static string userAccess;
        public Login()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            MySQL db= new MySQL();
            var users = db.users;
            try
            {
                foreach (users u in users)
                {

                    if (login.Text.Equals(u.login) && password.Password.Equals(u.password))
                    {
                        //userAccess = u.rules; пока закрыто, данные в другой базе
                        Bootstrapper bootstrapper = new Bootstrapper();
                        bootstrapper.Run();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Користувача не знайдено.");
                    }
                }
            }
            finally
            { }


        }
    }
}
