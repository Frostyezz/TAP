namespace Tema2Console;

public class HotelReception
{
    private readonly IOrderProcessor _orderProcessor;

    public HotelReception(IOrderProcessor orderProcessor)
    {
        _orderProcessor = orderProcessor;
    }

    public decimal FinalPrice { get; private set; }

    public void ProcessOrder()
    {
        FinalPrice = _orderProcessor.ProcessOrder();
    }
}
