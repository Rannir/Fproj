using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Server.Models.BaseClasses;

namespace Server.Models
{
    public class User : DBObject
    {
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public float Height { get; set; }
        public Measurements Measurements { get; set; }
        public Goals Goals { get; set; }
    }
}