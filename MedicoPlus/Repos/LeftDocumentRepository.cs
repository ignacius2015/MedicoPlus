using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MedicoPlus.Views;

namespace MedicoPlus.Repos
{
    class LeftDocumentRepository : ILeftDocument
    {
        public string name = Login.userAccess;
        //public static string loadmodule= LeftDocumentRepository.loadmodule;
        List<Document> document = new List<Document>();
        public IList<Document> GetData(string module)
        {
            
            XmlDocument xDoc = new XmlDocument();
            if (module == null)
                xDoc.Load("Helpers\\Background.xml");
            else xDoc.Load("Helpers\\"+module+".xml");
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
                        if (childnode.Name == "ModuleName" || childnode.Name == "modulename")
                        {
                            doc.ModuleName = childnode.InnerText;
                        }
                        if (childnode.Name == "linkname" || childnode.Name == "LinkName")
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
