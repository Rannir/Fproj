using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models.BaseClasses
{
    public abstract class BasicNutrients : DBObject
    {
        public float Protein { get; set; }
        public float Fat { get; set; }
        public float Carbohydrates { get; set; }
        public float Calories { get; set; }
    }
}