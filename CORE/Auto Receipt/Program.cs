
using System;
using System.Text.RegularExpressions;

using System;

public class AutoReceipt : CoreProgram
{
    public new static void Main()
    {
        new AutoReceipt().Run("Welcome to Swopblock Auto Receipt!", "Receipt FORM:", Receipt.RenderInvoiceForm());
    }



    protected override string? ProcessMessage(string message)
    {
        var trade = Receipt.ParseToNewTrade(message);

        if (trade == null)
            return null;

        return trade.RenderToEnglishMessage();
    }
}

public record Receipt
    (
        decimal PaymentAmount,
        string KindOfPayment,
        string PaymentSendingAddress,
        string PaymentReceivingAddress,
        decimal DeliveryAmount,
        string KindOfDelivery,
        string DeliverySendingAddress,
        string DeliveryReceivingAddress,
        decimal TradeMarketVolume,
        string KindOfTradeMarketVolume
    )
{
    public static Receipt? ParseToNewTrade(string text)
    {
        string pattern =
            @"Receipt for the payment of (\d+\.?\d*) (\w+) " +
            @"from the payment sending address (\d+) " +
            @"to the payment receiving address (\d+) " +
            @"and for the delivery of (\d+\.?\d*) (\w+) " +
            @"from the delivery sending address (\d+) " +
            @"to the delivery receiving address (\d+) " +
            @"for the trade made when the market volume reached (\d+\.?\d*) (\w+).";


        var match = Regex.Match(text, pattern, RegexOptions.IgnoreCase);

        if (match.Success)
        {
            return new Receipt
                (
                    decimal.Parse(match.Groups[1].Value), //PaymentAmount,
                    match.Groups[2].Value,                //KindOfPayment,
                    match.Groups[3].Value,                //PaymentSendingAddress,
                    match.Groups[4].Value,                //PaymentReceivingAddress,
                    decimal.Parse(match.Groups[5].Value), //DeliveryAmount,
                    match.Groups[6].Value,                //KindOfDelivery,
                    match.Groups[7].Value,                //DeliverySendingAddress,
                    match.Groups[8].Value,                 //DeliveryReceivingAddress,
                    decimal.Parse(match.Groups[9].Value), //TradeMarketVolume,
                    match.Groups[10].Value                //KindOftradeMarketVolume,
                );
        }

        return null;
    }

    public string? RenderToEnglishMessage()
    {
        return $"Receipt for the payment of {PaymentAmount} {KindOfPayment} " +
            $"from the payment sending address {PaymentSendingAddress} " +
            $"to the payment receiving address {PaymentReceivingAddress} " +
            $"and for the delivery of {DeliveryAmount} {KindOfDelivery} " +
            $"from the delivery sending address {DeliverySendingAddress} " +
            $"to the delivery receiving address {DeliveryReceivingAddress} " +
            $"for the trade made when the market volume reached {TradeMarketVolume} {KindOfTradeMarketVolume}.";
    }

    public static string RenderInvoiceForm()
    {
        return "Receipt for the payment of {PaymentAmount} {KindOfPayment} " +
            "from the payment sending address {PaymentSendingAddress} " +
            "to the payment receiving address {PaymentReceivingAddress} " +
            "and for the delivery of {DeliveryAmount} {KindOfDelivery} " +
            "from the delivery sending address {DeliverySendingAddress} " +
            "to the delivery receiving address {DeliveryReceivingAddress} " +
            "for the trade made when the market volume reached {TradeMarketVolume} {KindOfTradeMarketVolume}.";
    }
}
