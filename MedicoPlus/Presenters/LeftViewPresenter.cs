using System.Collections.Generic;
using MedicoPlus.Helpers;
using MedicoPlus.Repos;
using MedicoPlus.Views;
using Prism.Events;
using System.ComponentModel;
using MedicoPlus.Annotations;

namespace MedicoPlus.Presenters
{
    public class LeftViewPresenter:INotifyPropertyChanged
    {
        private string _loadmodule;
        private readonly ILeftDocument _repository;
        private readonly IDocumentRepository _rep;
        private readonly IEventAggregator _eventAggregator;
        public static int count = 0;
        
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
            OnPropertyChanged("SelectedDocument");
            _loadmodule = SelectedDocument.ModuleName;
        }
        private void PopulateDocuments()
        {
            ((List<Document>)_rep.GetData()).ForEach(x =>
            {
                //var model = 
                _models.Add(x, new DocumentPresentationModel(x));
            });
        }
        public LeftView View { get; set; }
        public DocumentPresentationModel SelectedDocument { get; set; }

        public IList<Document> LeftDocuments =>_repository.GetData(_loadmodule);
       

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
