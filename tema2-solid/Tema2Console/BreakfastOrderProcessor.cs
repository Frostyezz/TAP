namespace Tema2Console;

public class BreakfastOrderProcessor : IOrderProcessor
{
    private readonly Order _order;

    public BreakfastOrderProcessor(Order order)
    {
        _order = order;
    }

    public decimal ProcessOrder()
    {
        Console.WriteLine("Processing Breakfast order...");
        Console.WriteLine("Validating order parameters...");

        if (_order.Quantity == 0)
        {
            Console.WriteLine("-Breakfast order must specify Quantity");
            return 0;
        }

        if (_order.Price == 0)
        {
            Console.WriteLine("-Breakfast order must specify Price");
            return 0;
        }

        if (string.IsNullOrEmpty(_order.ServingDate))
        {
            Console.WriteLine("-Breakfast order must specify Serving Date");
            return 0;
        }

        if (!DateTime.TryParseExact(_order.ServingDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out var parsedServingDate))
        {
            Console.WriteLine("-Serving Date must be a valid date");
            return 0;
        }

        if (parsedServingDate < DateTime.Now.AddDays(7))
        {
            return _order.Quantity * _order.Price;
        }
        else
        {
            return (_order.Quantity * _order.Price) * 0.5m;
        }
    }
}
