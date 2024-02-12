//using Internal;
//using System.Xml.Xsl.Runtime;
using System.ComponentModel;
using System.Xml;
using System.Drawing;
using System.Reflection.Metadata;
using System.Net.Http.Headers;
using System.Collections.Concurrent;
using System.Runtime.Serialization;
using System.Reflection.Emit;
using System.Data;
using System.Dynamic;
//using Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KomodoCafe.Data;
using KomodoCafe.Repository;

namespace KomodoCafe.UI
{
        public class UIHelper 
        {
            KomodoCafeRepository komodoCafeDataList = new KomodoCafeRepository();
            public void AddMenuItem()
            {
                KomodoCafeData NewKomodoCafeData = new KomodoCafeData();
                Console.WriteLine ("Please type the meal number.");
                int inputId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine ("Please provide the meal name.");
                string inputName = Console.ReadLine();
                Console.WriteLine ("Please provide the meal description.");
                string inputDescription = Console.ReadLine();
                Console.WriteLine ("Please provide the list of ingredients.");
                string inputIngredients = Console.ReadLine();
                Console.WriteLine ("Please provide the meal price.");
                double inputPrice = Convert.ToDouble(Console.ReadLine());
                NewKomodoCafeData.MealId = inputId;
                NewKomodoCafeData.MealName = inputName;
                NewKomodoCafeData.MealDescription = inputDescription;
                NewKomodoCafeData.IngredientsList = inputIngredients;
                NewKomodoCafeData.MealPrice = inputPrice;
                bool AddMenuItem = komodoCafeDataList.AddMenuItem(NewKomodoCafeData);
            }

            public void ListofMenuItems()
            {
            List<KomodoCafeData> KomodoCafeDataList = komodoCafeDataList.GetMenuList();
            Console.WriteLine ("Menu List Amount = " + KomodoCafeDataList.Count);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Meal #         | Meal Name                 | Description              | List of Ingredients            | Price");             
            Console.WriteLine("====================================================================================================================");
            for (int i = 0; i < KomodoCafeDataList.Count; i++ )
            {
            Console.WriteLine("  " + KomodoCafeDataList[i].MealId + "           " + KomodoCafeDataList[i].MealName + "             " + KomodoCafeDataList[i].MealDescription + "             " 
            + KomodoCafeDataList[i].MealDescription + "               " + "$" + KomodoCafeDataList[i].MealPrice);
            }
            }

            public void UpdateMenuItems()
            {
            Console.WriteLine("Please type the number next to the menu item you would like to update.");
            List<KomodoCafeData> KomodoCafeDataList = komodoCafeDataList.GetMenuList();
            for (int i = 0; i < KomodoCafeDataList.Count; i++)
            {
                Console.WriteLine(i + "  " + KomodoCafeDataList[i].MealName);
            }
            int updateUserInput = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine ("Type 1 to update the meal number.");
            Console.WriteLine ("Type 2 to update the meal name.");
            Console.WriteLine ("Type 3 to update the meal description.");
            Console.WriteLine ("Type 4 to update the list of ingredients.");
            Console.WriteLine ("Type 5 to update the meal price.");
            int updateUserInput2 = Convert.ToInt32(Console.ReadLine());
            if (updateUserInput2 == 1)
            {
                Console.WriteLine ("Please provide the new meal number.");
            }
            else if (updateUserInput2 == 2)
            {
                Console.WriteLine ("Please provide the new meal name.");
            }
            else if (updateUserInput2 == 3)
            {
                Console.WriteLine ("Please provide the new meal description.");
            }
            else if (updateUserInput2 == 4)
            {
                Console.WriteLine ("Please provide the new list of ingredients.");
            }
            else if (updateUserInput2 == 5)
            {
                Console.WriteLine ("Please provide the new meal price.");
            }
            else
            {
                Console.WriteLine("That is not a valid option, returning to the main menu.");
                return;
            }
            string UserUpdateChoice = Console.ReadLine();
            bool UpdateExistingMenuItem = komodoCafeDataList.UpdateExistingMenuItem(updateUserInput, updateUserInput2, UserUpdateChoice);
            }

            public void DeleteMenuItems()
            {
            Console.WriteLine("Please type the number next to the meal you would like to remove from the menu.");
            List<KomodoCafeData> KomodoCafeDataList = komodoCafeDataList.GetMenuList();
            for (int i = 0; i < KomodoCafeDataList.Count; i++)
            {
                Console.WriteLine(i + "  " + KomodoCafeDataList[i].MealName);
            }
            int deleteUserInput = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Deleting Meal # " + deleteUserInput);
            bool DeleteDeliverybyId = komodoCafeDataList.RemoveMealFromList(deleteUserInput);
            }
        }

    public class KomodoCafeUI
    {
        public static void Main (string[] args)
        {
            UIHelper uih = new UIHelper();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(" ");
            Console.WriteLine("---------------------> KOMODO CAFE  <------------------------");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("==============================================================");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------->  How can we help you manage your menu?  <------------");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("MENU");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("A. Create New Menu Items");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("B. List of Menu Items");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("C. Update A Menu Item");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("D. Delete Menu Items");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("X. EXIT THE APPLICATION");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("==============================================================");
    
            string menuUserInput = Console.ReadLine().ToLower();
            //Console.WriteLine("menu input = "+menuUserInput);
            switch(menuUserInput)
                {
                case "a":
                    uih.AddMenuItem();
                    break;
                case "b":
                    uih.ListofMenuItems();
                    break;
                case "c":
                    uih.UpdateMenuItems();
                    break;
                case "d":
                    uih.DeleteMenuItems();
                    break;        
                case "x":
                    return;
                    break;
                }
            }
        }
    }
}