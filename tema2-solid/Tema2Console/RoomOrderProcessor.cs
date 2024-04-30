namespace Tema2Console;

public class RoomOrderProcessor : IOrderProcessor
{
    private readonly Order _order;

    public RoomOrderProcessor(Order order)
    {
        _order = order;
    }

    public decimal ProcessOrder()
    {
        Console.WriteLine("Processing Room order...");
        Console.WriteLine("Validating order parameters...");

        if (_order.Quantity == 0)
        {
            Console.WriteLine("-Room order must specify Quantity");
            return 0;
        }

        if (_order.Price == 0)
        {
            Console.WriteLine("-Room order must specify Price");
            return 0;
        }

        if (string.IsNullOrEmpty(_order.ReservationDate))
        {
            Console.WriteLine("-Room order must specify Reservation Date");
            return 0;
        }

        if (!DateTime.TryParseExact(_order.ReservationDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out var parsedReservationDate))
        {
            Console.WriteLine("-Reservation Date must be a valid date");
            return 0;
        }

        if (parsedReservationDate < DateTime.Now.AddMonths(1))
        {
            return (_order.Quantity * _order.Price) * 0.9m;
        }
        else if (parsedReservationDate < DateTime.Now.AddMonths(2))
        {
            return (_order.Quantity * _order.Price) * 0.8m;
        }
        else
        {
            return _order.Quantity * _order.Price;
        }
    }
}
