using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicoPlus.Views;
using Prism.Events;

namespace MedicoPlus.Presenters
{
    public class TopViewPresenter
    {
        private readonly IEventAggregator _eventAggregator;

        public TopViewPresenter(TopView view, IEventAggregator eventAggregator)
        {
            View = view;
            _eventAggregator = eventAggregator;
            
        }
        public TopView View { get; }
       
    }
}
