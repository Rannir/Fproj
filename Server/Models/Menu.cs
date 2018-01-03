using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Server.Models.BaseClasses;

namespace Server.Models
{
    public class Menu : DBObject
    {
        public IList<FoodItem> Foods { get; set; }

        public float TotalProtien
        {
            get
            {
                if (Foods.Count == 0)
                    return 0;
                else
                    return Foods.Sum(food => food.Protein);
            }
        }

        public float TotalFat
        {
            get
            {
                if (Foods.Count == 0)
                    return 0;
                else
                    return Foods.Sum(food => food.Fat);
            }
        }

        public float TotalCarbohydrates
        {
            get
            {
                if (Foods.Count == 0)
                    return 0;
                else
                    return Foods.Sum(food => food.Carbohydrates);
            }
        }

        public float TotalCalories
        {
            get
            {
                if (Foods.Count == 0)
                    return 0;
                else
                    return Foods.Sum(food => food.Calories);
            }
        }
    }
}