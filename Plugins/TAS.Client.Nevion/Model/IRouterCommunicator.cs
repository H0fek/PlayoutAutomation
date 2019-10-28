﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TAS.Common;
using TAS.Common.Interfaces;

namespace TAS.Server.Model
{
    public interface IRouterCommunicator : IDisposable
    {
        Task<bool> Connect();       
        void SelectInput(int inPort);
        
        void RequestInputPorts();
        void RequestOutputPorts();
        void RequestRouterState();
        void RequestCurrentInputPort();       

        event EventHandler<EventArgs<IEnumerable<IRouterPort>>> OnInputPortsListReceived;
        event EventHandler<EventArgs<IEnumerable<Crosspoint>>> OnInputPortChangeReceived;
        event EventHandler<EventArgs<IEnumerable<IRouterPort>>> OnRouterStateReceived;

        event EventHandler<EventArgs<bool>> OnRouterConnectionStateChanged;

        event EventHandler<EventArgs<IEnumerable<IRouterPort>>> OnOutputPortsListReceived;      
    }
}