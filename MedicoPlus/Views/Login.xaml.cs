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
        private int userAccess;
        public Login()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            MySQL db= new MySQL();
            var Users = db.users;
            foreach (users u in Users)
            {
                if (login.Text.Equals(u.login) && password.Password.Equals(u.password))
                {
                    //userAccess = u.rules;
                    Bootstrapper bootstrapper = new Bootstrapper();
                    bootstrapper.Run();
                }
                else
                {
                    MessageBox.Show("Користувача не знайдено.");
                }
            }


        }
    }
}
