using System;
using System.Text.RegularExpressions;

using System;

public class AutoEstimate : CoreProgram
{
    public new static void Main()
    {
        new AutoEstimate().Run("Welcome to Swopblock Auto Estimate!", "Estimate FORM:", Estimate.RenderEstimateForm());
    }



    protected override string? ProcessMessage(string message)
    {
        var query = Estimate.ParseToNewEstimate(message);

        if (query == null)
            return null;

        return query.RenderToEnglishMessage();
    }
}

public record Estimate
    (
        decimal EstimatedOfferAmount,
        string KindOfEstimatedOffer,
        string EstimatedOfferAddress,
        decimal EstimatedOrderAmount,
        string KindOfEstimatedOrder,
        string EstimatedOrderAddress,
        decimal MarketVolumeExpiration,
        string KindOfMarketVolume
    )
{
    public static Estimate? ParseToNewEstimate(string text)
    {
        string pattern =
            @"The values of an offer for (\d+\.?\d*) (\w+) " +
            @"at your address (\d+) " +
            @"and of an order for (\d+\.?\d*) (\w+)" +
            @"at your address (\d+) " +
            @"are estimated equivalent for any time before the market volume reaches (\d+\.?\d*) (\w+).";


        var match = Regex.Match(text, pattern, RegexOptions.IgnoreCase);

        if (match.Success)
        {
            return new Estimate
                (
                    decimal.Parse(match.Groups[1].Value),
                    match.Groups[2].Value,
                    match.Groups[3].Value,
                    decimal.Parse(match.Groups[4].Value),
                    match.Groups[5].Value,
                    match.Groups[6].Value,
                    decimal.Parse(match.Groups[7].Value),
                    match.Groups[8].Value
                );
        }

        return null;
    }

    public string? RenderToEnglishMessage()
    {
        return
            $"The values of an offer for {EstimatedOfferAmount} {KindOfEstimatedOffer} " +
            $"at your address {EstimatedOfferAddress} " +
            $"and of an order for {EstimatedOrderAmount} {KindOfEstimatedOrder}" +
            $"at your address {EstimatedOrderAddress} " +
            $"are estimated equivalent for any time before the market volume reaches {MarketVolumeExpiration} {KindOfMarketVolume}.";


    }

    public static string RenderEstimateForm()
    {
        return
            "The values of an offer for {EstimatedOfferAmount} {KindOfEstimatedOffer} " +
            "at your address {EstimatedOfferAddress} " +
            "and of an order for {EstimatedOrderAmount} {KindOfEstimatedOrderAmount}" +
            "at your address {EstimatedOrderAddress} " +
            "are estimated equivalent for any time before the market volume reaches {MarketVolumeExpiration} {KindOfMarketVolume}.";
    }
}

