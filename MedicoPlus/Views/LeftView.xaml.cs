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
    /// Interaction logic for LeftView.xaml
    /// </summary>
    public partial class LeftView : UserControl
    {
        public LeftView()
        {
            InitializeComponent();
        }
        public LeftViewPresenter Model
        {
            get { return DataContext as LeftViewPresenter; }
            set { DataContext = value; }
        }
    }
}
