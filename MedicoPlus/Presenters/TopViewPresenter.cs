using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicoPlus.Helpers;
using MedicoPlus.Models;
using MedicoPlus.Repos;
using MedicoPlus.Views;
using Prism.Events;

namespace MedicoPlus.Presenters
{
    public class TopViewPresenter
    {
        private readonly IDocumentRepository _repository;
        private readonly IEventAggregator _eventAggregator;

        public TopViewPresenter(TopView view, IDocumentRepository repository, IEventAggregator eventAggregator)
        {
            View = view;
            _eventAggregator = eventAggregator;
            _repository = repository;
            View.Model = this;
        }

        public TopView View { get; }
        public IList<Document> Documents => _repository.GetData();
        public Document SelectedItem
        {
            set { _eventAggregator.GetEvent<SelectedDocumentEvent>().Publish(value); }
        }
    }
}
