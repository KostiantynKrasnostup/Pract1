using System;
using System.Collections.Generic;
using System.Xml;

namespace CustomersApp
{
    // Клас для представлення клієнта
    public class Customer
    {
        public string FullName { get; private set; } 
        public string Address { get; private set; } 
        public string City { get; private set; }
        public string State { get; private set; } 
        public string Phone { get; private set; } 

        // Конструктор для створення нового об'єкта клієнта
        public Customer(string fullName, string address, string city, string state, string phone)
        {
            FullName = fullName;
            Address = address;
            City = city;
            State = state;
            Phone = phone;
        }

        // Метод для виведення деталей клієнта у консоль
        public void PrintToConsole()
        {
            Console.WriteLine($"Клієнт: {FullName}");
            Console.WriteLine($"Адреса: {Address}");
            Console.WriteLine($"Місто: {City}");
            Console.WriteLine($"Штат: {State}");
            Console.WriteLine($"Телефон: {Phone}");
        }
    }

    // Статичний клас для представлення списку клієнтів
    public static class Customers
    {
        public static List<Customer> CustomersList = new List<Customer>(); // Список клієнтів

        // Метод для додавання клієнта до списку
        public static void Add(Customer customer)
        {
            CustomersList.Add(customer);
        }

        // Метод для відображення усіх клієнтів у списку
        public static void Show()
        {
            foreach (Customer customer in CustomersList)
            {
                customer.PrintToConsole();
            }
        }
    }

    // Головний клас програми
    class Program
    {
        static void Main(string[] args)
        {
            // Завантаження XML-документа
            XmlDocument xml = new XmlDocument();
            xml.Load("XMLFile3.xml");

            // Ітерація через усі вузли XML-документа
            foreach (XmlNode node in xml.DocumentElement)
            {
                // Отримання інформації про клієнта з вузла XML-документа
                string fullName = node.Attributes["fullname"].Value;
                string address = node.Attributes["address"].Value;
                string city = node.Attributes["city"].Value;
                string state = node.Attributes["state"].Value;
                string phone = node.Attributes["phone"].Value;

                // Створення нового об'єкта клієнта та додавання до списку
                Customers.Add(new Customer(fullName, address, city, state, phone));
            }

            // Відображення усіх клієнтів у списку
            Customers.Show();
        }
    }
}