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

        public IList<LeftSideDocument> GetData()
        {
            XmlDocument xDoc = new XmlDocument();
            // xDoc.Load("Helpers\\"+name+".xml");
            xDoc.Load("Helpers\\admin.xml");
            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;

            return document;
        }
    }
}
