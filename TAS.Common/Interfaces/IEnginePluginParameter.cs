﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAS.Common.Interfaces
{
    public interface IEnginePluginParameter
    {
        IReadOnlyCollection<IPlayoutServerProperties> Servers { get; }        
    }
}
