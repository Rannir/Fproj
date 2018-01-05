using Server.Models.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models
{
    public class Goals : BodyDetails
    {
        public Menu GoalMenu { get; set; }
        public float SuccessRate { get; set; }
        public float AlgorithmScore { get; set; }



        /// <summary>
        /// helper functions
        /// </summary>

        // 1 gr = 4 calo
        public float NeededProteins {
            get
            {
                return this.Weight * 2;
            }
        }

        // 1 gr = 9 calo
        public float NeededFat
        {
            get
            {
                return this.Weight * 1;
            }
        }

        public float NeededCalories(User usr)
        {
            if (usr.Measurements.Weight > this.Weight)
                return usr.Rmr - 300;
            else if (usr.Measurements.Weight < this.Weight)
                return usr.Rmr + 300;
            else
                return usr.Rmr;
        }

        // 1gr = 4 calo
        public float NeededCarbohydrates(User usr)
        {
            return (float)((this.NeededCalories(usr) - this.NeededProteins * 4 - this.NeededFat * 9) / 4);
        }
    }
}