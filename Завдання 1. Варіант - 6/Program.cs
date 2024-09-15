using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace Ind
{
    // Клас, що представляє рослину з різними властивостями
    public class Plant
    {
        // Властивості рослини
        public string Common { get; private set; }
        public string Botanical { get; private set; }
        public int Zone { get; private set; }
        public string Light { get; private set; }
        public decimal Price { get; private set; }
        public string Availability { get; private set; }

        // Конструктор для ініціалізації властивостей рослини
        public Plant(string common, string botanical, int zone, string light, decimal price, string availability)
        {
            Common = common;
            Botanical = botanical;
            Zone = zone;
            Light = light;
            Price = price;
            Availability = availability;
        }

        // Метод для виведення інформації про рослину в консоль
        public void PrintToConsole()
        {
            Console.WriteLine($"Рослина: {Common}");
            Console.WriteLine($"Ботанічна назва: {Botanical}");
            Console.WriteLine($"Зона: {Zone}");
            Console.WriteLine($"Світло: {Light}");
            Console.WriteLine($"Ціна: {Price:C}");
            Console.WriteLine($"Наявність: {Availability}");
        }
    }

    // Статичний клас для управління каталогом рослин
    public static class Catalog
    {
        // Список рослин
        public static List<Plant> PlantsList = new List<Plant>();

        // Метод для додавання рослини до списку
        public static void Add(Plant p)
        {
            PlantsList.Add(p);
        }

        // Метод для виведення інформації про всі рослини в консоль
        public static void Show()
        {
            foreach (Plant plant in PlantsList)
            {
                plant.PrintToConsole();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Завантаження XML-документу
            XmlDocument xml = new XmlDocument();
            xml.Load("XMLFile2.xml");

            // Обробка кожного вузла в XML
            foreach (XmlNode node in xml.DocumentElement)
            {
                // Зчитування даних з XML
                string common = node["COMMON"].InnerText;
                string botanical = node["BOTANICAL"].InnerText;
                int zone = Int32.Parse(node["ZONE"].InnerText);
                string light = node["LIGHT"].InnerText;
                decimal price = Decimal.Parse(node["PRICE"].InnerText.Replace("$", ""), CultureInfo.InvariantCulture);
                string availability = node["AVAILABILITY"].InnerText;

                // Додавання нової рослини до каталогу
                Catalog.Add(new Plant(common, botanical, zone, light, price, availability));
            }

            // Виведення всіх рослин в консоль
            Catalog.Show();
        }
    }
}
