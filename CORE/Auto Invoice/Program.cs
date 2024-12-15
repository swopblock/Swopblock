using System;
using System.Text.RegularExpressions;

public class AutoInvoice : CoreProgram
{
    public new static void Main()
    {
        new AutoInvoice().Run("Welcome to Swopblock Auto Invoice!", "Invoice FORM:", Invoice.RenderInvoiceForm());
    }



    protected override string? ProcessMessage(string message)
    {
        var trade = Invoice.ParseToNewInvoice(message);

        if (trade == null)
            return null;

        return trade.RenderToEnglishMessage();
    }
}

public record Invoice
    (
        decimal PaymentAmount,
        string KindOfPayment,
        string PaymentSendingAddress,
        string PaymentReceivingAddress,
        decimal DeliveryAmount,
        string KindOfDelivery,
        string DeliverySendingAddress,
        string DeliveryReceivingAddress,
        decimal MarketVolumeCancelation,
        string KindOfMarketVolume
    )
{
    public static Invoice? ParseToNewInvoice(string text)
    {
        string pattern =
            @"An invoice for the payment of (\d+\.?\d*) (\w+) " +
            @"from the payment sending address (\d+) " +
            @"to the payment receiving address (\d+) " +
            @"is due upon the delivery of (\d+\.?\d*) (\w+) " +
            @"from the delivery sending address (\d+) " +
            @"to the delivery receiving address (\d+) " +
            @"and was made at the market volume (\d+\.?\d*) (\w+).";


        var match = Regex.Match(text, pattern, RegexOptions.IgnoreCase);

        if (match.Success)
        {
            return new Invoice
                (
                    decimal.Parse(match.Groups[1].Value), //PaymentAmount,
                    match.Groups[2].Value,                //KindOfPayment,
                    match.Groups[3].Value,                //PaymentSendingAddress,
                    match.Groups[4].Value,                //PaymentReceivingAddress,
                    decimal.Parse(match.Groups[5].Value), //DeliveryAmount,
                    match.Groups[6].Value,                //KindOfDelivery,
                    match.Groups[7].Value,                //DeliverySendingAddress,
                    match.Groups[8].Value,                 //DeliveryReceivingAddress,
                    decimal.Parse(match.Groups[9].Value),  //MarketVolumeCancelation,
                    match.Groups[10].Value                 //KindOfMarketVolume
                );
        }

        return null;
    }

    public string? RenderToEnglishMessage()
    {
        return $"An invoice for the payment of {PaymentAmount} {KindOfPayment} " +
            $"from the payment sending address {PaymentSendingAddress} " +
            $"to the payment receiving address {PaymentReceivingAddress} " +
            $"is due upon the delivery of {DeliveryAmount} {KindOfDelivery} " +
            $"from the delivery sending address {DeliverySendingAddress} " +
            $"to the delivery receiving address {DeliveryReceivingAddress} " +
            $"and was made at the market volume {MarketVolumeCancelation} {KindOfMarketVolume}.";
    }

    public static string RenderInvoiceForm()
    {
        return "An invoice for the payment of {PaymentAmount} {KindOfPayment} " +
            "from the payment sending address {PaymentSendingAddress} " +
            "to the payment receiving address {PaymentReceivingAddress} " +
            "is due upon the delivery of {DeliveryAmount} {KindOfDelivery} " +
            "from the delivery sending address {DeliverySendingAddress} " +
            "to the delivery receiving address {DeliveryReceivingAddress} " +
            "and was made at the market volume {MarketVolumeCancelation} {KindOfMarketVolume}.";
    }
}
