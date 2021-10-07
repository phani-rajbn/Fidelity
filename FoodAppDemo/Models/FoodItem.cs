using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodAppDemo.Models
{
    public class FoodItem
    {
        public int ItemId { get; private set; }
        public string ItemName { get; private set; }
        public string ItemImage { get; private set; }
        public int ItemCost { get; private set; }
        public int Rating { get; private set; }
        public FoodItem(int id, string name, string image, int cost, int rating =4)
        {
            ItemId = id;
            ItemImage = image;
            ItemCost = cost;
            ItemName = name;
        }
    }

    public static class FoodData
    {
        private static FoodItem[] createFoodItems()
        {
            FoodItem[] items = new FoodItem[6];
            items[0] = new FoodItem(1, "Masala Dosa", "../Images/Mdosa.jfif", 60);
            items[1] = new FoodItem(2, "Set Dosa", "../Images/setDosa.jfif", 70);
            items[2] = new FoodItem(3, "Chow Chow Bath", "../Images/ccbath.jfif", 50);
            items[3] = new FoodItem(4, "Kara Bath", "../Images/kBath.jfif", 25);
            items[4] = new FoodItem(5, "Mini Tiffin", "../Images/MiniTiffin.jfif", 100);
            items[5] = new FoodItem(6, "Kesari Bath", "../Images/kesariBath.jfif", 30);
            return items;
        }
        public static FoodItem[] AllItems => createFoodItems();
    }
}