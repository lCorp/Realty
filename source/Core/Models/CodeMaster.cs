﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class MasterCode : BaseEntity
    {
        public string Code { get; set; }
        public string Category { get; set; }
        public string Value { get; set; }
    }
}