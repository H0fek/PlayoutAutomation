﻿using System;
using System.ComponentModel.Composition;
using TAS.Client.Common;
using TAS.Common.Interfaces;
using TAS.Common.Interfaces.Configurator;

namespace TAS.Server.Router.Configurator
{
    [Export(typeof(IPluginConfigurator))]
    public class RouterConfiguratorViewModel : ViewModelBase, IPluginConfigurator
    {
        private IConfigEngine _engine = null;
        private Router _router = new Router();
        private bool _isEnabled;

        [ImportingConstructor]
        public RouterConfiguratorViewModel([Import("Engine")]IConfigEngine engine)
        {
            _engine = engine;
        }   

        public string PluginName => "Router";

        public bool IsEnabled 
        {
            get => _isEnabled;
            set
            {
                if (!SetField(ref _isEnabled, value))
                    return;
                
                _router.IsEnabled = value;
                PluginChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler PluginChanged;

        public object GetModel()
        {
            return _router;
        }

        public void Initialize(object parameter)
        {
            
        }

        public void Save()
        {
            //_engine.Plugins.Add(_router);
        }

        protected override void OnDispose()
        {            
        }
    }
}