using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicoPlus.Helpers;
using MedicoPlus.Repos;
using MedicoPlus.Views;
using Prism.Events;

namespace MedicoPlus.Presenters
{
    public class LeftViewPresenter
    {
        private readonly LeftView _view;
        private readonly ILeftSideRepository _repository;
        private readonly IEventAggregator _eventAggregator;

        public LeftViewPresenter(LeftView view, ILeftSideRepository repository, IEventAggregator eventAggregator)
        {
            View = view;
            _repository = repository;
            _eventAggregator = eventAggregator;
            View.Model = this;
        }

        public LeftView View { get; }
        public IList<LeftSideDocument> Documents => _repository.GetData();
        public LeftSideDocument SelectedItem
        {
            set { _eventAggregator.GetEvent<SelectedLeftDocumentEvent>().Publish(value); }
        }

    }
}
