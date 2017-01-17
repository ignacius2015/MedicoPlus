using System.Collections.Generic;
using System.Collections.ObjectModel;
using MedicoPlus.Helpers;
using MedicoPlus.Repos;
using MedicoPlus.Views;
using Prism.Events;
using System.ComponentModel;
using System.Linq;
using MedicoPlus.Annotations;
using Microsoft.Practices.ObjectBuilder2;

namespace MedicoPlus.Presenters
{
    public class LeftViewPresenter:INotifyPropertyChanged
    {
        private string _loadmodule;
        private readonly ILeftDocument _repository;
        private readonly IDocumentRepository _rep;
        private readonly IEventAggregator _eventAggregator;
        
        private readonly IDictionary<Document, DocumentPresentationModel> _models = new Dictionary<Document, DocumentPresentationModel>();
        public LeftViewPresenter(LeftView view, IDocumentRepository rep, ILeftDocument repository, IEventAggregator eventAggregator)
        {
            View = view;
            _repository = repository;
            _rep = rep;
            _eventAggregator = eventAggregator;
            View.Model = this;
            PopulateDocuments();
            _eventAggregator.GetEvent<SelectedDocumentEvent>().Subscribe(OnSelect);

        }
       
        private void OnSelect(Document obj)
        {
            SelectedDocument = _models[obj];
            OnPropertyChanged(nameof(SelectedDocument));
            _loadmodule = SelectedDocument.ModuleName;
           // PopulateDocuments();
            Read(_loadmodule);
        }
        private void PopulateDocuments()
        {
            ((List<Document>)_rep.GetData()).ForEach(x =>
            {
                _models.Add(x, new DocumentPresentationModel(x));
            });
        }
        public LeftView View { get;}
        public DocumentPresentationModel SelectedDocument { get; set; }

        public IList<Document> LeftDocuments =>_repository.GetData(_loadmodule);

        public IList<Document> Read(string loadmodule)
        {
           return _repository.GetData(loadmodule);
        }

        public Document SelectedItem
        {
            set { _eventAggregator.GetEvent<SelectedDocumentEvent>().Publish(value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
