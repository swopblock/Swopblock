using System;
using System.Text.RegularExpressions;

using System;

public class SelfQuery : AppProgram
{
    public new static void Main()
    {
        new SelfQuery().Run("Welcome to Swopblock Self Query!", "Query FORM:", Query.RenderQueryForm());
    }



    protected override string? ProcessMessage(string message)
    {
        var query = Query.ParseToNewQuery(message);

        if (query == null)
            return null;

        return query.RenderToEnglishMessage();
    }
}

public record Query
    (
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
    public static Query? ParseToNewQuery(string text)
    {
        string pattern =
            @"Estimate the price of an offer between (\d+\.?\d*) " +
            @"and (\d+\.?\d*) (\w+) of the amount at my address (\d+) " +
            @"in exchange for an order between (\d+\.?\d*) " +
            @"and (\d+\.?\d*) (\w+) of the amount at my address (\d+) " +
            @"before the market volume reaches (\d+\.?\d*) (\w+).";


        var match = Regex.Match(text, pattern, RegexOptions.IgnoreCase);

        if (match.Success)
        {
            return new Query
                (
                    decimal.Parse(match.Groups[1].Value), 
                    decimal.Parse(match.Groups[2].Value), 
                    match.Groups[3].Value,                
                    match.Groups[4].Value,                
                    decimal.Parse(match.Groups[5].Value), 
                    decimal.Parse(match.Groups[6].Value), 
                    match.Groups[7].Value,                
                    match.Groups[8].Value,                
                    decimal.Parse(match.Groups[9].Value),
                    match.Groups[10].Value
                );
        }

        return null;
    }

    public string? RenderToEnglishMessage()
    {
        return
            $"Estimate the price of an offer between {MinOfferAmount} " +
            $"and {MaxOfferAmount} {KindOfOffer} of the amount at my address {OfferAddress} " +
            $"in exchange for an order between {MinOrderAmount} " +
            $"and {MaxOrderAmount} {KindOfOrder} of the amount at my address {OrderAddress} " +
            $"before the market volume reaches {MarketVolumeExpiration} {KindOfMarketVolume}.";


    }

    public static string RenderQueryForm()
    {
        return
            "Estimate the price of an offer between {MinOfferAmount} " +
            "and {MaxOfferAmount} {KindOfOffer} of the amount at my address {OfferAddress} " +
            "in exchange for an order between {MinOrderAmount} " +
            "and {MaxOrderAmount} {KindOfOrder} of the amount at my address {OrderAddress} " +
            "before the market volume reaches {MarketVolumeExpiration} {KindOfMarketVolume}.";
    }
}

