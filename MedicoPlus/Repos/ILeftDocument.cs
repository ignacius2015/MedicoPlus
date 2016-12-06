using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoPlus.Repos
{
    public interface ILeftDocument
    {
        IList<Document> GetData(string module);
    }
}
