using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using MedicoPlus.Helpers;
using MedicoPlus.Views;

namespace MedicoPlus.Models
{
    public class DocumentRepository : IDocumentRepository
    {
        public string name = Login.userAccess;
        List<Document> document = new List<Document>();
        public IList<Document> GetData()
        {
            Document doc= new Document();
            XmlDocument xDoc = new XmlDocument();
            // xDoc.Load("Helpers\\"+name+".xml");
            xDoc.Load("Helpers\\admin.xml");
            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;
            // обход всех узлов в корневом элементе
            if (xRoot != null)
                foreach (XmlNode xnode in xRoot)
                {
                    // получаем атрибут Name
                    if (xnode.Attributes != null && xnode.Attributes.Count > 0)
                    {
                        XmlNode attr = xnode.Attributes.GetNamedItem("Name");
                        if (attr != null)
                        {
                            doc.LinkName = attr.Value;
                        }
                    }
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        // если узел - ImageName
                        if (childnode.Name == "ImageName")
                        {
                            doc.ImageName = childnode.InnerText;
                        }
                        
                    }
                    if (xnode.Name == "count")
                    {
                        doc.count = Convert.ToInt32(xnode.InnerText);
                    }
                    document.Add(doc);
                }
            
            return document;
        }
    }
}
