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
        public int Gender { get; set; }
        public Goals Goals { get; set; }
        public float Rmr
        {
            get
            {
                float result = (float)(10 * this.Measurements.Weight + 6.25 * this.Height - (5 * (DateTime.Now.Year - this.BirthDate.Year)));
                // female
                if (this.Gender == 0)
                    result = result - 161;
                // male cause he got 1 ;)
                else
                    result = result + 5;

                return (float)(result * 1.2);
            }
        }
    }
}