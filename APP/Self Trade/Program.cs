using System;
using System.Text.RegularExpressions;

using System;

public class SelfTrade : AppProgram
{
    public new static void Main()
    {
        new SelfTrade().Run("Welcome to Swopblock Self Trade!", "Trade FORM:", Trade.RenderTradeForm());
    }



    protected override string? ProcessMessage(string message)
    {
        var trade = Trade.ParseToNewTrade(message);

        if (trade == null)
            return null;

        return trade.RenderToEnglishMessage();
    }
}

public record Trade
    (
        decimal PaymentAmount,
        string KindOfPayment,
        string PaymentSendingAddress, 
        string PaymentReceivingAddress,
        decimal DeliveryAmount,
        string KindOfDelivery,
        string DeliverySendingAddress,
        string DeliveryReceivingAddress,
        decimal InvoiceMarketVolume,
        string KindOfInvoiceMarketVolume
    )
{
    public static Trade? ParseToNewTrade(string text)
    {
        string pattern =
            @"Trade the payment of (\d+\.?\d*) (\w+) " +
            @"from the payment sending address (\d+) " +
            @"to the payment receiving address (\d+) " +
            @"with the delivery of (\d+\.?\d*) (\w+) " +
            @"from the delivery sending address (\d+) " +
            @"to the delivery receiving address (\d+) " +
            @"by the invoice made when the market volume reached (\d+\.?\d*) (\w+).";


        var match = Regex.Match(text, pattern, RegexOptions.IgnoreCase);

        if (match.Success)
        {
            return new Trade
                (
                    decimal.Parse(match.Groups[1].Value), //PaymentAmount,
                    match.Groups[2].Value,                //KindOfPayment,
                    match.Groups[3].Value,                //PaymentSendingAddress,
                    match.Groups[4].Value,                //PaymentReceivingAddress,
                    decimal.Parse(match.Groups[5].Value), //DeliveryAmount,
                    match.Groups[6].Value,                //KindOfDelivery,
                    match.Groups[7].Value,                //DeliverySendingAddress,
                    match.Groups[8].Value,                 //DeliveryReceivingAddress,
                    decimal.Parse(match.Groups[9].Value), //InvoiceMarketVolume,
                    match.Groups[10].Value                //KindOfInvoiceMarketVolume,
                );
        }

        return null;
    }

    public string? RenderToEnglishMessage()
    {
        return $"Trade the payment of {PaymentAmount} {KindOfPayment} " +
            $"from the payment sending address {PaymentSendingAddress} " +
            $"to the payment receiving address {PaymentReceivingAddress} " +
            $"with the delivery of {DeliveryAmount} {KindOfDelivery} " +
            $"from the delivery sending address {DeliverySendingAddress} " +
            $"to the delivery receiving address {DeliveryReceivingAddress} " +
            $"by the invoice made when the market volume reached {InvoiceMarketVolume} {KindOfInvoiceMarketVolume}.";
    }

    public static string RenderTradeForm()
    {
        return "Trade the payment of {PaymentAmount} {KindOfPayment} " +
            "from the payment sending address {PaymentSendingAddress} " +
            "to the payment receiving address {PaymentReceivingAddress} " +
            "with the delivery of {DeliveryAmount} {KindOfDelivery} " +
            "from the delivery sending address {DeliverySendingAddress} " +
            "to the delivery receiving address {DeliveryReceivingAddress} " +
            "by the invoice made when the market volume reached {InvoiceMarketVolume} {KindOfInvoiceMarketVolume}.";
    }
}
