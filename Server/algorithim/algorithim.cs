using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.algorithim
{
    public class algorithim
    {
        public void startAlgo(List<Menu> menuPopulation, User user)
        {
            fitness(menuPopulation, user);
            List<Menu> bestFivePopulation = menuPopulation.OrderBy(x => x.MenuFitness).Take(5).ToList();
            geneticAlgo(bestFivePopulation, user, 1);
        }

        private List<Menu> geneticAlgo(List<Menu> menuPopulation, User user, int generation)
        {
            var Population = breed(menuPopulation);
            fitness(Population, user);
            List<Menu> bestFivePopulation = Population.OrderBy(x => x.MenuFitness).Take(5).ToList();
            if (generation == 5)
                return bestFivePopulation;
            else
                return geneticAlgo(bestFivePopulation, user, generation + 1);
        }

        private List<Menu> breed(List<Menu> menuPopulation)
        {
            List<Menu> res = new List<Menu>();

            Random random = new Random();
            int randomMenues = random.Next(3, 8);
            int randomItemsToSwap = random.Next(2, 4);

            for (int i = 0; i < randomMenues; i++)
            {
                int randomMenu1 = random.Next(1, 5);
                int randomMenu2 = random.Next(1, 5);

                while (randomMenu2 == randomMenu1)
                    randomMenu2 = random.Next(1, 5);

                Menu newMenu1 = menuPopulation[randomMenu1].Clone();
                Menu newMenu2 = menuPopulation[randomMenu2].Clone();

                for (int j = 0; j < randomItemsToSwap; j++)
                {
                    // 1 - breakfast, 2 - Lunch, 3 - dinner
                    int randomMeal = random.Next(1, 3);

                    switch ((MealType)randomMeal)
                    {
                        case MealType.Breakfast:
                            {
                                mergeMeals(newMenu1.Breakfast.ToList(), newMenu2.Breakfast.ToList());
                                break;
                            }
                        case MealType.Lunch:
                            {
                                mergeMeals(newMenu1.Lunch.ToList(), newMenu2.Lunch.ToList());
                                break;
                            }
                        case MealType.Dinner:
                            {
                                mergeMeals(newMenu1.Dinner.ToList(), newMenu2.Dinner.ToList());
                                break;
                            }
                    }
                }

                res.Add(newMenu1);
                res.Add(newMenu2);
            }
            
            int randomMutation = random.Next(2, 4);
            menuPopulation = menuPopulation.Concat(res).ToList();

            for (int i = 0; i < randomMutation; i++)
            {
                int randomMutationIndex = random.Next(0, menuPopulation.Count() - 1);
                // 1 - breakfast, 2 - Lunch, 3 - dinner
                int randomMeal = random.Next(1, 3);

                switch ((MealType)randomMeal)
                {
                    case MealType.Breakfast:
                        {
                            int randomFood1 = random.Next(0, menuPopulation[randomMutationIndex].Breakfast.Count - 1);
                            menuPopulation[randomMutationIndex].Breakfast.RemoveAt(randomFood1);
                            menuPopulation[randomMutationIndex].Breakfast.Add(getFoodRand(MealType.Breakfast));
                            break;
                        }
                    case MealType.Lunch:
                        {
                            int randomFood1 = random.Next(0, menuPopulation[randomMutationIndex].Lunch.Count - 1);
                            menuPopulation[randomMutationIndex].Lunch.RemoveAt(randomFood1);
                            menuPopulation[randomMutationIndex].Lunch.Add(getFoodRand(MealType.Lunch));
                            break;
                        }
                    case MealType.Dinner:
                        {
                            int randomFood1 = random.Next(0, menuPopulation[randomMutationIndex].Dinner.Count - 1);
                            menuPopulation[randomMutationIndex].Dinner.RemoveAt(randomFood1);
                            menuPopulation[randomMutationIndex].Dinner.Add(getFoodRand(MealType.Dinner));
                            break;
                        }
                }
            }

            return menuPopulation;
        }

        private FoodItem getFoodRand(MealType mealType)
        {
            return new FoodItem();
        }

        private void mergeMeals(List<FoodItem> meal1, List<FoodItem> meal2)
        {
            Random random = new Random();
            int randomFood1 = random.Next(0, meal1.Count - 1);
            int randomFood2 = random.Next(0, meal2.Count - 1);

            FoodItem temp = meal1[randomFood1];
            meal1.Remove(temp);
            meal1.Add(meal2[randomFood2]);

            meal2.Remove(meal2[randomFood2]);
            meal2.Add(temp);
        }

        private void fitness(List<Menu> menuPopulation, User user)
        {
            foreach (var menuIndividual in menuPopulation)
            {
                menuIndividual.MenuFitness = 0;
                menuIndividual.MenuFitness += calculateRate(user.Goals.NeededCalories(user), menuIndividual.TotalCalories);
                menuIndividual.MenuFitness += calculateRate(user.Goals.NeededCarbohydrates(user), menuIndividual.TotalCarbohydrates);
                menuIndividual.MenuFitness += calculateRate(user.Goals.NeededFat, menuIndividual.TotalFat);
                menuIndividual.MenuFitness += calculateRate(user.Goals.NeededProteins, menuIndividual.TotalProtien);
            }
        }

        private float calculateRate(float x, float y)
        {
            if (y == 0 || x == 0)
                return 0;

            return (float)((y > x) ? x / y : y / x);
        }

        private enum MealType
        {
            Breakfast =1,
            Lunch,
            Dinner 
        }
    }
}