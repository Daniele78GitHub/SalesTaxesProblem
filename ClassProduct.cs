using System;

namespace SalesTaxProblem
{
    public interface Interface
    {
        Product GetProduct(string Name, decimal price, int quantity, TipoMerce tipoMerce, bool isImported);
    }

    public class ClassProduct : Interface
    {
        public Product GetProduct(string name, decimal price, int quantity, TipoMerce tipoMerce, bool isImported)
        {
            switch (tipoMerce)
            {
                case TipoMerce.Book:
                    return new Book(name, isImported, price, quantity);

                case TipoMerce.MusicCD:
                    return new MusicCD(name, isImported, price, quantity);

                case TipoMerce.ChocolateBar:
                    return new ChocolateBar(name, isImported, price, quantity);

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
