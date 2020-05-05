﻿using jNet.RPC;
using TAS.Database.Common;

namespace TAS.Client.Config.Model
{
    public class RemoteHost: IRemoteHostConfig
    {
        [Hibernate]
        public ushort ListenPort {get; set;}
    }
}
