using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoPlus.Models
{
    public class DocumentRepository : IDocumentRepository
    {
        List<Document> document = new List<Document>();
        public IList<Document> GetData()
        {
            throw new NotImplementedException();
        }
    }
}
