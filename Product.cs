﻿using System;

namespace SalesTaxProblem
{
    public enum TipoMerce
    {
        Book = 1,
        MusicCD = 2,
        ChocolateBar = 3
    }

    public abstract class Product
    {
        public string Name { get; set; }

        public bool IsImported { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int Type { get; }

        public Product(string name, bool isImported, decimal price, int quantity)
        {
            Name = name;
            IsImported = isImported;
            Price = price;
            Quantity = quantity;
        }

        public virtual decimal CalculateTax()
        {
            decimal tax = 0;

            if (IsImported == true)
            {
                tax = Convert.ToDecimal(Convert.ToDouble(Price * Quantity) * 0.05);
            }

            return Math.Round(tax, 2);
        }
    }

    public class Book : Product
    {
        public Book(string name, bool isImported, decimal price, int quantity)
            : base(name, isImported, price, quantity)
        {
        }

        public override decimal CalculateTax()
        {
            decimal importedTax = 0;

            if (IsImported == true)
            {
                importedTax = Convert.ToDecimal(Convert.ToDouble(Price * Quantity) * 0.05);
            }

            var salesTax = Convert.ToDecimal(Convert.ToDouble(Price * Quantity) * 0.1);

            return Math.Round(importedTax + salesTax, 2);
        }
    }

    public class ChocolateBar : Product
    {
        public ChocolateBar(string name, bool isImported, decimal price, int quantity)
            : base(name, isImported, price, quantity)
        {
        }
    }

    public class MusicCD : Product
    {
        public MusicCD(string name, bool isImported, decimal price, int quantity)
            : base(name, isImported, price, quantity)
        {
        }
    }
}
