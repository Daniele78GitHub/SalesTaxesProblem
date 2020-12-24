using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesTaxProblem
{
    public class Program
    {
        static void Main(string[] args)
        {
            Interface productClass = new ClassProduct();
            List<Product> cartItems = new List<Product>();
            int count = 0;

            while (true)
            {
                
                Console.WriteLine($"Articolo {++count}");
                
                Console.WriteLine("Nome : ");
                var name = Console.ReadLine();

                Console.WriteLine("Prezzo : ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                {
                    throw new Exception("Prezzo non valido");
                }

                Console.WriteLine("Quantità : ");
                if (!int.TryParse(Console.ReadLine(), out int quantity))
                {
                    throw new Exception("Quantità non valida");
                }

                Console.WriteLine("Is imported : (Y/N) [any other key except y/Y is considered as N]");
                var isImported = Console.ReadLine().ToLower() == "y" ? true : false;

                Console.WriteLine("Seleziona uno dei seguenti:\n1. Book\n2. MusicCD\n3. ChocolateBar");

                if (!Enum.TryParse<TipoMerce>(Console.ReadLine(), out TipoMerce goodsType))
                {
                    throw new Exception("Invalid type");
                }

                Console.WriteLine("Do you want to add more items? (Y/N) [any other key except y/Y is considered as N]");
                var input = Console.ReadLine().ToLower();

                var product = productClass.GetProduct(name, Convert.ToDecimal(price), Convert.ToInt32(quantity), goodsType, isImported);
                cartItems.Add(product);

                if (input == "y")
                {
                    continue;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("\n");
            Console.WriteLine("Fatturazione");
           
            Console.WriteLine("Nome Articolo (Quantity)    Price       Is Imported       Tax");
           

            foreach (var item in cartItems)
            {
                Console.WriteLine(item.Name + "       "
                                            + item.Quantity + "                    "
                                            + item.Price + "                "
                                            + item.IsImported + "         "
                                            + item.CalculateTax());
            }

            Console.WriteLine("\n");

            Console.WriteLine($"----------------- Totale Articoli : {cartItems.Count()} -----------------\n");
            Console.WriteLine("Quantità : " + cartItems.Sum(item => item.Quantity));
            Console.WriteLine("Prezzo : " + cartItems.Sum(item => item.Price));
            Console.WriteLine("Service Tax (Imported Tax + Tassa di Servizio) : " + cartItems.Sum(item => item.CalculateTax()));

            Console.ReadLine();
        }
    }
}