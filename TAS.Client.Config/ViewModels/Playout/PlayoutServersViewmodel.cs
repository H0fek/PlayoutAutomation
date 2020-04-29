﻿using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Windows.Input;
using TAS.Client.Common;
using TAS.Common;

namespace TAS.Client.Config.ViewModels.Playout
{
    public class PlayoutServersViewmodel: EditViewmodelBase<Model.PlayoutServers>, IOkCancelViewModel
    {
        private bool _isCollectionChanged;
        private PlayoutServerViewmodel _selectedServer;

        public PlayoutServersViewmodel(DatabaseType databaseType, ConnectionStringSettingsCollection connectionStringSettingsCollection) : base(new Model.PlayoutServers(databaseType, connectionStringSettingsCollection))
        {
            PlayoutServers = new ObservableCollection<PlayoutServerViewmodel>(Model.Servers.Select(s => new PlayoutServerViewmodel(s)));
            PlayoutServers.CollectionChanged += PlayoutServers_CollectionChanged;
            CommandAdd = new UiCommand(Add);
            CommandDelete = new UiCommand(o => PlayoutServers.Remove(_selectedServer), o => _selectedServer != null);
        }

        public override bool IsModified { get { return _isCollectionChanged || PlayoutServers.Any(s => s.IsModified); } }

        public ICommand CommandAdd { get; }

        public ICommand CommandDelete { get; }

        public PlayoutServerViewmodel SelectedServer
        {
            get => _selectedServer;
            set
            {
                if (_selectedServer == value)
                    return;
                _selectedServer = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<PlayoutServerViewmodel> PlayoutServers { get; }

        protected override void Update(object destObject = null)
        {
            foreach (PlayoutServerViewmodel s in PlayoutServers)
                s.Save();
            Model.Save();
            base.Update(destObject);
        }

        protected override void OnDispose()
        {
            PlayoutServers.CollectionChanged -= PlayoutServers_CollectionChanged;
            Model.Dispose();
        }

        private void PlayoutServers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Model.Servers.Add(((PlayoutServerViewmodel)e.NewItems[0]).Model);
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                Model.Servers.Remove(((PlayoutServerViewmodel)e.OldItems[0]).Model);
                Model.DeletedServers.Add(((PlayoutServerViewmodel)e.OldItems[0]).Model);
            }
            _isCollectionChanged = true;
        }

        private void Add(object obj)
        {
            var newPlayoutServer = new Model.CasparServer();
            Model.Servers.Add(newPlayoutServer);
            var newPlayoutServerViewmodel = new PlayoutServerViewmodel(newPlayoutServer);
            PlayoutServers.Add(newPlayoutServerViewmodel);
            SelectedServer = newPlayoutServerViewmodel;            
        }

        public bool Ok(object obj)
        {
            Update();
            return true;
        }

        public void Cancel(object obj) { }

        public bool CanOk(object obj)
        {
            return IsModified;
        }

        public bool CanCancel(object obj)
        {
            return true;
        }
    }
}
