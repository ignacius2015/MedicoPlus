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
                foreach(users user in users)
                {
                    if(login.Text.Equals(user.login) && password.Password.Equals(user.password))
                    {

                        Bootstrapper bootstrapper = new Bootstrapper();
                        bootstrapper.Run();
                    }
                    else
                    {
                        MessageBox.Show("Користувача не знайдено.");
                    }
                }
            }
            catch(Exception ex)
            {

            }


        }
    }
}
