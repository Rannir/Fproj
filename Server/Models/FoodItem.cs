﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Server.Models.BaseClasses;

namespace Server.Models
{
    public class FoodItem : BasicNutrients
    {
        public FoodItem Clone()
        {
            return this;
        }
    }
}