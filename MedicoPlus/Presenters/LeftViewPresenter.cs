using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicoPlus.Helpers;
using MedicoPlus.Repos;
using MedicoPlus.Views;
using Prism.Events;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MedicoPlus.Annotations;

namespace MedicoPlus.Presenters
{
    public class LeftViewPresenter:INotifyPropertyChanged
    {
        private readonly ILeftSideRepository peRepository;
        private readonly IDocumentRepository _repository;
        private readonly IEventAggregator _eventAggregator;
        private readonly IDictionary<Document, DocumentPresentationModel> _models = new Dictionary<Document, DocumentPresentationModel>();
        public LeftViewPresenter(LeftView view, ILeftSideRepository _peRepository, IDocumentRepository repository, IEventAggregator eventAggregator)
        {
            View = view;
            peRepository = _peRepository;
            _repository = repository;
            _eventAggregator = eventAggregator;
            View.Model = this;
            PopulateDocuments();
            _eventAggregator.GetEvent<SelectedDocumentEvent>().Subscribe(OnSelect);

        }
        private void OnSelect(Document obj)
        {
            SelectedDocument = _models[obj];
            OnPropertyChanged(nameof(SelectedDocument));
        }
        private void PopulateDocuments()
        {
            var documents = _repository.GetData() as List<Document>;
            documents?.ForEach(x =>
            {
                var model = new DocumentPresentationModel(x);
                _models.Add(x, model);
            });
        }
        public LeftView View { get; }
        public DocumentPresentationModel SelectedDocument { get; set; }
        public IList<LeftSideDocument> LeftDocuments => peRepository.GetDocs();
        public LeftSideDocument SelectedItem
        {
            set { _eventAggregator.GetEvent<SelectedLeftDocumentEvent>().Publish(value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
