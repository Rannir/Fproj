using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Server.Models.BaseClasses;

namespace Server.Models
{
    public class Menu : DBObject
    {
        public IList<FoodItem> Breakfast { get; set; }
        public IList<FoodItem> Lunch { get; set; }
        public IList<FoodItem> Dinner { get; set; }
        public IList<FoodItem> Foods
        {
            get
            {
                return Breakfast.Concat(Lunch).Concat(Dinner).ToList();
            }
        }

        public float MenuFitness { get; set; }

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

        public void RemoveFood(FoodItem food)
        {
            this.Breakfast.Remove(food);
            this.Lunch.Remove(food);
            this.Dinner.Remove(food);
        }

        public void AddFood(FoodItem food)
        {

        }

        public Menu Clone()
        {
            Menu returnValue = new Menu();

            returnValue.Breakfast = new List<FoodItem>();
            returnValue.Lunch = new List<FoodItem>();
            returnValue.Dinner = new List<FoodItem>();

            foreach (FoodItem Food in this.Breakfast)
            {
                returnValue.Breakfast.Add(Food.Clone());
            }

            foreach (FoodItem Food in this.Lunch)
            {
                returnValue.Lunch.Add(Food.Clone());
            }

            foreach (FoodItem Food in this.Dinner)
            {
                returnValue.Dinner.Add(Food.Clone());
            }

            return returnValue;
        }
    }
}