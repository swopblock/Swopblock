using APP;

Task whenAllDone = Task.CompletedTask;

var SelfOrder = new SelfOrder(args, out whenAllDone);

await whenAllDone;

class SelfOrder : App
{
    public SelfOrder(string[] args, out Task whenAll) : base("SelfOrder", args, out whenAll)
    {
    }
}

public record Order(string orderType, MinMaxOffer offer, MinMaxOrder order);

public record MinMaxOffer(decimal MinOfferAmount, decimal MaxOfferAmount, string KindOfOffer);
public record MinMaxOrder(decimal MinOrderAmount, decimal MaxOrderAmount, string KindOfOrder);

public record BidBuyOrder(MinMaxOffer bidOffer, MinMaxOrder buyOrder) : Order("BidBuyOrder", bidOffer, buyOrder);

public record AskSellOrder(MinMaxOffer askOffer, MinMaxOrder sellOrder) : Order("BidBuyOrder", askOffer, sellOrder);



