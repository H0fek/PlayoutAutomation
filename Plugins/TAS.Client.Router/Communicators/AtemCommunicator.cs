﻿using System;
using System.Threading;
using System.Threading.Tasks;
using TAS.Common;
using TAS.Server.VideoSwitch.Helpers;
using TAS.Server.VideoSwitch.Model;

namespace TAS.Server.VideoSwitch.Communicators
{    
    public class AtemCommunicator : IRouterCommunicator
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();        
        private int _disposed;

        private VideoSwitch _device;
        private BMDSwitcherWrapper _atem;

        public event EventHandler<EventArgs<CrosspointInfo>> OnInputPortChangeReceived;
        public event EventHandler<EventArgs<PortState[]>> OnRouterPortsStatesReceived;
        public event EventHandler<EventArgs<bool>> OnRouterConnectionStateChanged;

        public AtemCommunicator(VideoSwitch device)
        {            
            _device = device;

            //ensure MTA
            Task.Run(() => _atem = new BMDSwitcherWrapper()).Wait();            
            
            _atem.ProgramInputChanged += Switcher_ProgramInputChanged;
            _atem.Disconnected += Atem_Disconnected;
        }

        private void Atem_Disconnected(object sender, EventArgs e)
        {
            OnRouterConnectionStateChanged?.Invoke(this, new EventArgs<bool>(false));
        }

        private void Switcher_ProgramInputChanged(object sender, MixEffectEventArgs e)
        {
            OnInputPortChangeReceived?.Invoke(this, new EventArgs<CrosspointInfo>(new CrosspointInfo((short)e.ProgramInput, -1)));
        }        
                
        public async Task<bool> Connect()
        {
            _disposed = default(int);
            _cancellationTokenSource = new CancellationTokenSource();

            while (true)
            {                
                Logger.Debug("Setting up ATEM TVS...");
                try
                {
                    if (_cancellationTokenSource.IsCancellationRequested)
                        throw new OperationCanceledException(_cancellationTokenSource.Token);

                    bool isConnected = false;
                    await Task.Run(() => isConnected = _atem.Connect(_device.IpAddress, _device.Level));
                    
                    if (!isConnected)
                    {                        
                        Logger.Trace("Could not connect to ATEM. Reconnecting in 3 seconds...");
                        await Task.Delay(3000);
                        continue;
                    }                    

                    Logger.Trace("Connected to ATEM TVS");                                                                                    
                    return true;
                }
                catch (Exception ex)
                {
                    if (ex is OperationCanceledException)
                    {
                        Logger.Trace("ATEM connecting canceled");
                        break;
                    }
                    else
                    {
                        Logger.Error(ex);
                        await Task.Delay(3000);
                        continue;
                    }
                }
            }
            return false;
        }

        public void Dispose()
        {
            if (Interlocked.Exchange(ref _disposed, 1) != default(int))
                return;
            
            _cancellationTokenSource.Cancel();
        }

        public async Task<CrosspointInfo> GetCurrentInputPort()
        {
            return await Task.Run(() => new CrosspointInfo((short)_atem.GetCurrentInputPort(), -1)); 
        }

        public async Task<PortInfo[]> GetInputPorts()
        {
            return await Task.Run(() => _atem.GetInputPorts());
        }
                
        public void SelectInput(int inPort)
        {
            //ensure MTA
            Task.Run(() => _atem.SelectInput(inPort)); 
        }        
    }
}