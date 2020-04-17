﻿using TAS.Client.Common;
using TAS.Client.Config.Model;
using TAS.Common.Interfaces;

namespace TAS.Client.Config.ViewModels.Playout
{
    public class PlayoutRecorderViewmodel: EditViewmodelBase<CasparRecorder>, IRecorderProperties
    {
        private int _id;
        private string _recorderName;
        private int _defaultChannel;

        public PlayoutRecorderViewmodel(CasparRecorder r): base(r)
        {
            _id = r.Id;
            _recorderName = r.RecorderName;
        }

        public int Id
        {
            get => _id;
            set => SetField(ref _id, value);
        }

        public string RecorderName
        {
            get => _recorderName;
            set => SetField(ref _recorderName, value);
        }

        public int DefaultChannel
        {
            get => _defaultChannel;
            set => SetField(ref _defaultChannel, value);
        }

        protected override void OnDispose()
        {
            
        }

        public void Save()
        {
            Update(Model);
        }
    }
}
