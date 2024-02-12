using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KomodoCafe.Data;

namespace KomodoCafe.Repository
{
    public class KomodoCafeRepository
    {
        private List<KomodoCafeData> _menuDirectory = new List<KomodoCafeData>();
    
//NOTE - Create new menu items

    public bool AddMenuItem (KomodoCafeData komodoCafeData)
    {
            int startingCount = _menuDirectory.Count;
            _menuDirectory.Add(komodoCafeData);
            bool wasAdded = (_menuDirectory.Count >startingCount) ? true: false;
            return wasAdded;
    }

//NOTE - List of Meals (READ)
    public List<KomodoCafeData> GetMenuList()
    {
            return _menuDirectory;
    }

//NOTE - Update Menu Items (UPDATE)
public bool UpdateExistingMenuItem (int menuId, int fieldId, string updatedValue)
        {
            KomodoCafeData oldKomodoCafeData = _menuDirectory[menuId];
            if (fieldId == 1)
            {
                oldKomodoCafeData.MealId = Convert.ToInt32(updatedValue);
            }
            else if (fieldId == 2)
            {
                oldKomodoCafeData.MealName = updatedValue;
            }
            else if (fieldId == 3)
            {
                oldKomodoCafeData.MealDescription = updatedValue;
            }
            else if (fieldId == 4)
            {
                oldKomodoCafeData.IngredientsList = updatedValue;
            }
            else if (fieldId == 5)
            {
                oldKomodoCafeData.MealPrice = Convert.ToDouble(updatedValue);
            }

            _menuDirectory[menuId] = oldKomodoCafeData;
            return true;

        }

/*public bool UpdateExistingMenuItem (int mealId, string mealName, string mealDescription, string ingredientsList, double mealPrice)
        {
            KomodoCafeData oldKomodoCafeData = _menuDirectory[mealId];

            if (oldKomodoCafeData != null)
            {
                oldKomodoCafeData.MealId = mealId;
                oldKomodoCafeData.MealName = mealName;
                oldKomodoCafeData.MealDescription = mealDescription;
                oldKomodoCafeData.IngredientsList = ingredientsList;
                oldKomodoCafeData.MealPrice = mealPrice;

            _menuDirectory[mealId] = oldKomodoCafeData;

                return true;
            }
            else
            {
                return false;
            }
        }*/

//NOTE - Delete Menu Item (Delete)
        public bool RemoveMealFromList(int id)
        {
            
            int initialCount = _menuDirectory.Count;
            _menuDirectory.RemoveAt(id);

            if (initialCount > _menuDirectory.Count)
            {
            return true;
            }
            else
            {
            return false;
            }
         }
    }
}