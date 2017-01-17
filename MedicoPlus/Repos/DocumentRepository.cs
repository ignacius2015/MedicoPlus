﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using MedicoPlus.Helpers;
using MedicoPlus.Models;
using MedicoPlus.Views;

namespace MedicoPlus.Repos
{
    public class DocumentRepository : IDocumentRepository
    {
        public string name = Login.userAccess;
        List<Document> document = new List<Document>();
        public IList<Document> GetData()
        {
            
            XmlDocument xDoc = new XmlDocument();
            // xDoc.Load("Helpers\\"+name+".xml");
            xDoc.Load("Helpers\\admin.xml");
            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;
            // обход всех узлов в корневом элементе
            if (xRoot != null)
            {
               
                foreach (XmlNode xnode in xRoot)
                {
                    Document doc = new Document();
                    
                    
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        // если узел - ImageName
                        if (childnode.Name == "ImageName")
                        {
                            doc.ImageName = childnode.InnerText;
                        }
                        if (childnode.Name == "ModuleName"|| childnode.Name == "modulename")
                        {
                            doc.ModuleName = childnode.InnerText;
                        }
                        if (childnode.Name == "linkmame"|| childnode.Name == "LinkName")
                        {
                            doc.LinkName = childnode.InnerText;
                        }
                        if (childnode.Name == "hint")
                        {
                            doc.Hint = childnode.InnerText;
                        }

                    }
                    document.Add(doc);
                }
            }

            return document;
        }
    }
}
