using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicoPlus.Presenters;
using MedicoPlus.Repos;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace MedicoPlus.Modules
{
    public class LeftViewModule:IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _manager;
        
        public LeftViewModule(IUnityContainer container, IRegionManager manager)
        {
            _container = container;
            _manager = manager;
        }
        public void Initialize()
        {
            _container.RegisterType(typeof(ILeftDocument), typeof(LeftDocumentRepository));
            _manager.AddToRegion("LeftContent", _container.Resolve<LeftViewPresenter>().View);
        }
    }
}
