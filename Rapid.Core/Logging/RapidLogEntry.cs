﻿using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rapid.Core.Logging
{
    public class RapidLogEntry : LogEntry
    {
        public string UserId { get; set; }
    }
}
