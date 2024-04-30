using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Tema2Console;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Client...");

        Console.WriteLine("Loading order from file...");
        var dataJson = File.ReadAllText("orders.json");

        Console.WriteLine("Deserializing Order object from json data...");
        var order = JsonConvert.DeserializeObject<Order>(dataJson, new StringEnumConverter());

        if (order == null)
        {
            Console.WriteLine("Order type not parsed successfully.");
            return;
        }

        IOrderProcessor orderProcessor;
        switch (order.Type)
        {
            case OrderType.Room:
                orderProcessor = new RoomOrderProcessor(order);
                break;
            case OrderType.Product:
                orderProcessor = new ProductOrderProcessor(order);
                break;
            case OrderType.Breakfast:
                orderProcessor = new BreakfastOrderProcessor(order);
                break;
            default:
                throw new InvalidOperationException("Unknown order type.");
        }

        var hotelReception = new HotelReception(orderProcessor);
        hotelReception.ProcessOrder();

        if (hotelReception.FinalPrice == 0)
        {
            Console.WriteLine("No order was processed.");
        }
        else
        {
            Console.WriteLine($"Final price for your order: {hotelReception.FinalPrice} RON");
        }
    }
}
