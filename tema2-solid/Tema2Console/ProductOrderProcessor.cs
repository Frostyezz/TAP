namespace Tema2Console;

public class ProductOrderProcessor : IOrderProcessor
{
    private readonly Order _order;

    public ProductOrderProcessor(Order order)
    {
        _order = order;
    }

    public decimal ProcessOrder()
    {
        Console.WriteLine("Processing Product order...");
        Console.WriteLine("Validating order parameters...");

        if (string.IsNullOrEmpty(_order.Name))
        {
            Console.WriteLine("-Product order must specify Name");
            return 0;
        }

        if (_order.Quantity == 0)
        {
            Console.WriteLine("-Product order must specify Quantity");
            return 0;
        }

        if (_order.Price == 0)
        {
            Console.WriteLine("-Product order must specify Price");
            return 0;
        }

        decimal price = _order.Quantity * _order.Price;
        if (_order.Name == "Fanta")
        {
            price *= 0.75m;
        }

        return price;
    }
}
