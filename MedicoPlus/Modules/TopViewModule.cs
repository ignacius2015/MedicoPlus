using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicoPlus.Presenters;
using MedicoPlus.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace MedicoPlus.Modules
{
    public class TopViewModule: IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _manager;

        public TopViewModule(IUnityContainer container, IRegionManager manager)
        {
            _container = container;
            _manager = manager;
        }
        public void Initialize()
        {
           // _container.RegisterType(typeof(IDocumentRepository), typeof(DocumentRepository));
            _manager.AddToRegion("MainContent", _container.Resolve<AdminView>());
        }
    }
}
