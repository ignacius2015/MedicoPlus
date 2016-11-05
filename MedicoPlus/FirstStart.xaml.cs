using MedicoPlus.FolderBrowser;
using System;
using System.IO;
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
using System.Runtime.Serialization.Formatters.Binary;

namespace MedicoPlus
{
    
    struct sett
    {
        public string docs;
        public string forms;
        public string templates;
        public string database;
        public string basename;

        public sett(string d, string f, string t, string da, string ba)
        {
            docs = d;
            forms = f;
            templates = t;
            database = da;
            basename = ba;
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FirstStart : Window
    {
        string[] databases = { "MySQL", "Microsoft SQL Server", "PostgreSQL", "ORACLE Database", "MongoDB", "SyBase", "SQLite" };
        public static string filename = System.IO.Path.Combine(Environment.CurrentDirectory, "settings.dat");
        public FirstStart()
        {
            this.InitializeComponent();
            databasesList.ItemsSource = databases;
            DocsFolder.Text = System.IO.Path.Combine(Environment.CurrentDirectory, "UserDocs");
            FormFolder.Text = System.IO.Path.Combine(Environment.CurrentDirectory, "UserForms");
            TemplatePath.Text= System.IO.Path.Combine(Environment.CurrentDirectory, "Templates");
            // Insert code required on object creation below this point.
        }


        private void buttonDocs_Click(object sender, RoutedEventArgs e)
        {
            DialogSelectFolder SelectFolder = new DialogSelectFolder();
            SelectFolder.ShowDialog();
            DocsFolder.Text = csPathToFolder.PathOfSelectedFolder;
            SelectFolder.Close();
        }

        private void buttonFolder_Click(object sender, RoutedEventArgs e)
        {
            DialogSelectFolder SelectFolder = new DialogSelectFolder();
            SelectFolder.ShowDialog();
            FormFolder.Text=csPathToFolder.PathOfSelectedFolder;
            SelectFolder.Close();
        }

        private void databasesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: Add event handler implementation here.
        }

        private void TemplateChoice_Click(object sender, RoutedEventArgs e)
        {
            DialogSelectFolder SelectFolder = new DialogSelectFolder();
            SelectFolder.ShowDialog();
            TemplatePath.Text= csPathToFolder.PathOfSelectedFolder;
        }

        
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var obj = new sett(DocsFolder.Text, FormFolder.Text, TemplatePath.Text,databasesList.SelectedItem.ToString(), databaseName.Text);
            
            FileStream fout = File.OpenWrite(filename);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fout, obj);
            fout.Close();

            //FileStream fin = File.OpenRead(path);

            //BinaryFormatter bf = new BinaryFormatter();

            //newBody = (body)bf.Deserialize(fs);

            //fin.Close();
        }
    }
}
