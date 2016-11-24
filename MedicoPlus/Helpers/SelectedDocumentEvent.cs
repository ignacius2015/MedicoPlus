﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MedicoPlus.Models;
using MedicoPlus.Repos;
using Prism.Events;

namespace MedicoPlus.Helpers
{
    public class SelectedDocumentEvent: PubSubEvent<Document>
    {
    }
    public class SelectedLeftDocumentEvent : PubSubEvent<LeftSideDocument>
    {
    }
}
