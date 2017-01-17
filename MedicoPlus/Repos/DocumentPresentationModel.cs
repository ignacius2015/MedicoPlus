﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Modularity;

namespace MedicoPlus.Repos
{
    public class DocumentPresentationModel : INotifyPropertyChanged
    {
        private string modulename;

        public DocumentPresentationModel(Document document)
        {
            Document = document;
            modulename = document.ModuleName;
        }

        
        public string ModuleName
        {
            get { return modulename; }
            set
            {
                if (value != modulename)
                {
                    modulename = value;
                    OnPropertyChanged("ModuleName");
                }
            }
        }
        public Document Document { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
