using System;
using System.Text.RegularExpressions;

using System;

public class SelfOrder : AppProgram
{
    public new static void Main()
    {
        new SelfOrder().Run("Welcome to Swopblock Self Order!", "ORDER FORM:", Order.RenderAnOrderForm());
    }



    protected override string? ProcessMessage(string message)
    {
        var order = Order.ParseToNewOrder(message);

        if (order == null)
            return null;
        
        return order.RenderToEnglishMessage();
    }
}

public record Order
    (   
        string TypeOfOrder, 
        decimal MinOfferAmount, 
        decimal MaxOfferAmount, 
        string KindOfOffer, 
        string OfferAddress, 
        decimal MinOrderAmount, 
        decimal MaxOrderAmount, 
        string KindOfOrder, 
        string OrderAddress, 
        decimal MarketVolumeExpiration, 
        string KindOfMarketVolume
    )
{
    public static Order? ParseToNewOrder(string text)
    {
        string pattern =
            @"(Buy|Sell) with an offer between (\d+\.?\d*) " +
            @"and (\d+\.?\d*) (\w+) at my address (\d+) " +
            @"and an order between (\d+\.?\d*) " +
            @"and (\d+\.?\d*) (\w+) at my address (\d+) " +
            @"and set this offer to expire " +
            @"when the market volume reaches (\d+\.?\d*) (\w+).";

        var match = Regex.Match(text, pattern, RegexOptions.IgnoreCase);

        if (match.Success)
        {
            return new Order
                (
                    match.Groups[1].Value,//public record Order(string TypeOfOrder,
                    decimal.Parse(match.Groups[2].Value),//decimal MinOfferAmount,
                    decimal.Parse(match.Groups[3].Value),//decimal MaxOfferAmount,
                    match.Groups[4].Value,//string KindOfOffer,
                    match.Groups[5].Value,//string OfferAddress,
                    decimal.Parse(match.Groups[6].Value),//decimal MinOrderAmount,
                    decimal.Parse(match.Groups[7].Value),//decimal MaxOrderAmount,
                    match.Groups[8].Value,//string KindOfOrder,
                    match.Groups[9].Value,//string OrderAddress,
                    decimal.Parse(match.Groups[10].Value),//decimal MarketVolumeExpiration,
                    match.Groups[11].Value//string KindOfMarketVolume);
                );
        }
       
        return null;
    }

    public string? RenderToEnglishMessage()
    {
        return $"{TypeOfOrder} with an offer between {MinOfferAmount} and {MaxOfferAmount} {KindOfOffer} at my address {OfferAddress} " +
            $"and an order between {MinOrderAmount} and {MaxOrderAmount} {KindOfOrder} at my address {OrderAddress} and set " +
            $"this offer to expire when the market volume reaches {MarketVolumeExpiration} {KindOfMarketVolume}.";
    }

    public static string RenderAnOrderForm()
    {
        return "{(Buy|Sell)} with an offer between {MinOfferAmount} and {MaxOfferAmount} {KindOfOffer} at my address {OfferAddress} " +
                        "and an order between {MinOrderAmount} and {MaxOrderAmount} {KindOfOrder} at my address {OrderAddress} and set " +
                        "this offer to expire when the market volume reaches {MarketVolumeExpiration} {KindOfMarketVolume}.";
    }
}



