using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MedicoPlus.Repos
{
    class LeftSideDocumentRepository:ILeftSideRepository
    {
        List<LeftSideDocument> document = new List<LeftSideDocument>();

        public IList<LeftSideDocument> GetDocs()
        {
            XmlDocument xDoc = new XmlDocument();
            // xDoc.Load("Helpers\\"+name+".xml");
            xDoc.Load("Helpers\\Setup.xml");
            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                foreach (XmlNode xnode in xRoot)
                {
                    LeftSideDocument doc=new LeftSideDocument();
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        // если узел - ImageName
                        if (childnode.Name == "linkmame")
                        {
                            doc.LinkName = childnode.InnerText;
                        }
                        if (childnode.Name == "modulename")
                        {
                            doc.ModuleName = childnode.InnerText;
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
