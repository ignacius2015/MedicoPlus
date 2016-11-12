using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MedicoPlus.Views;
using Prism.Modularity;
using Prism.Unity;

namespace MedicoPlus
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            Shell shell = new Shell();
            shell.Show();
            return shell;
        }


        protected override IModuleCatalog CreateModuleCatalog()
        {
            ModuleCatalog catalog = new ModuleCatalog();
            catalog.AddModule(typeof(AdminView));
           // catalog.AddModule(typeof(Form001.Views.Form001));
            return catalog;
        }
    }
}
