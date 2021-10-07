using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;

namespace SampleWebApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; } = 1;//Default value for the Quantity.
    }

    public static class ProductDB
    {
        const string filename = @"C:\Users\phani\source\repos\Fidelity Training\SampleWebApp\AllProducts.xml";
        private static List<Product> getProducts()
        {
            var doc = XDocument.Load(filename);//create the file from Mockaroo before trying the code.
            var data = from element in doc.Descendants("Product")
                       select new Product
                       {
                           ProductId = int.Parse(element.Element("ProductID").Value),
                           ProductName = element.Element("ProductName").Value,
                           Price = int.Parse(element.Element("Price").Value)
                       };
            return data.ToList();
        }

        public static List<Product> AllProducts => getProducts();//Use the C#7 feature of Lambda Properties.
    }
}