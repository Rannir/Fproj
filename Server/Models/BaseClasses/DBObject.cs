using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models.BaseClasses
{
    public abstract class DBObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}