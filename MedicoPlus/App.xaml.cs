﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MedicoPlus
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            if (!File.Exists(FirstStart.filename))
            {
                FirstStart fs= new FirstStart();
                fs.Show();
            }
            else
            {
                Bootstrapper bootstrapper = new Bootstrapper();
                bootstrapper.Run();
            }

        }
    }
}
