using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicoPlus.Models;
using Prism.Events;

namespace MedicoPlus.Helpers
{
    public class SelectedDocumentEvent: PubSubEvent<Document>
    {
    }
}
