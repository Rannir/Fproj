﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models
{
    public class Goals : Measurements
    {
        public Menu GoalMenu { get; set; }
    }
}