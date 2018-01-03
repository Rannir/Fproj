using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models.BaseClasses
{
    public abstract class BodyDetails : DBObject
    {
        public float Weight { get; set; }
        public float BodyFat { get; set; }
    }
}