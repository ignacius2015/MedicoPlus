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
using MedicoPlus.Presenters;

namespace MedicoPlus.Views
{
    /// <summary>
    /// Interaction logic for TopView.xaml
    /// </summary>
    public partial class TopView : UserControl
    {
        public string name = Login.userAccess;
        public TopView()
        {
            InitializeComponent();
        }

        public TopViewPresenter Model
        {
            get { return DataContext as TopViewPresenter; }
            set { DataContext = value; }
        }
        private void lobby_Click(object sender, RoutedEventArgs e)
        {

        }

        private void setup_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
