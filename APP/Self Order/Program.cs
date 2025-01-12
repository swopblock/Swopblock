using System;
using System.Text.RegularExpressions;
using Swopblock.Utilities;

using System;

public class SelfOrder : AppProgram, IProcessForm
{
    public static async Task Main()
    {
        WelcomeOrderHere();

        var order = Console.ReadLine();

        while (order != null && order != "exit")
        {
            Console.WriteLine();

            await foreach (var message in IProcessForm.ProcessForm((IForm)new OrderForm(order)))
            {
                Console.WriteLine(message);
            }

            WelcomeOrderHere();

            order = Console.ReadLine();
        }
    }

    public static void WelcomeOrderHere()
    {
        Console.WriteLine();
        Console.WriteLine("Welcome to Swopblock Self Order!");
        Console.WriteLine("Place your order here.");
        Console.WriteLine();
    }

    protected override string? ProcessMessage(string message)
    {
        var order = Order.ParseToNewOrder(message);

        if (order == null)
            return null;
        
        return order.RenderToEnglishMessage();
    }
}

public enum OrderStatus
{
    Void,
    Messageing,
    Messaged,
    MessagedFailed,
    Parsing,
    Parsed,
    ParsedFailed,
    Writting,
    Written,
    WrittenFailed,
    Signing,
    SigningSucceeded,
    SigningFailed,
    Broadcasting,
    BroadcastedFailed,
    BroadcastingSucceeded,
    Confirmed,
    ConfirmedFailed
}

//public interface IProcessForm 
//{
//    static async IAsyncEnumerable<string> ProcessForm(IForm Form)
//    {
//        await foreach (var Text in Form.NewForm())
//        {
//            await foreach (var Message in Text.Message())
//            {
//                await foreach (var Object in Message.Parse())
//                {
//                    await foreach (var Binary in Object.Write())
//                    {
//                        await foreach (var Signature in Binary.Sign())
//                        {
//                            await foreach (var Received in Signature.Broadcast())
//                            {
//                                await foreach (var Confirmation in Received.Confirm())
//                                {
//                                    await foreach (var Status in Confirmation.Status())
//                                    {
//                                        yield return Status;
//                                    }
//                                }
//                            }
//                        }
//                    }
//                }
//            }
//        }
//    }
//}

//public interface IForm { IAsyncEnumerable<IText> NewForm(); }
//public interface IText { IAsyncEnumerable<IParse> Message(); }
//public interface IParse { IAsyncEnumerable<IWrite> Parse(); }
//public interface IWrite { IAsyncEnumerable<ISign> Write(); }
//public interface ISign { IAsyncEnumerable<IBroadcast> Sign(); }
//public interface IBroadcast { IAsyncEnumerable<IConfirm> Broadcast(); }
//public interface IConfirm { IAsyncEnumerable<IStatus> Confirm(); }
//public interface IStatus { IAsyncEnumerable<string> Status(); }
public record OrderForm(string Text) : IProcessForm, IForm, IText, IParse, IWrite, ISign, IBroadcast, IConfirm, IStatus
{
    private string textMessage;

    private string[] statusMessages = 
    { 
        "Success: new order form created.",
        "Success: text to object parsed.",
        "Success: object to binary written.",
        "Success: binary signed.",
        "Success: signed binary broacasted.",
        "Success: broadcast confirmed."
    };

    public Order Object { get; set; }

    //public string Message { get; set; }

    public byte[] Binary { get; set; }

    public string Json { get; set; }
    public async IAsyncEnumerable<IText> NewForm()
    {
        Console.WriteLine("Created a text form.");

        yield return (IText)this;
    }

    public async IAsyncEnumerable<IParse> Message()
    {
        Console.WriteLine("Created a message form.");

        yield return (IParse)this;
    }

    public async IAsyncEnumerable<IWrite> Parse()
    {
        Console.WriteLine("Created an object form.");

        yield return (IWrite)this;
    }

    public async IAsyncEnumerable<ISign> Write()
    {
        Console.WriteLine("Created a binary form.");

        yield return (ISign)this;
    }

    public async IAsyncEnumerable<IBroadcast> Sign()
    {
        Console.WriteLine("Created a signed binary form.");

        yield return (IBroadcast)this;
    }

    public async IAsyncEnumerable<IConfirm> Broadcast()
    {
        Console.WriteLine("Broadcasted the signed binary form.");

        yield return (IConfirm)this;
    }

    public async IAsyncEnumerable<IStatus> Confirm()
    {
        Console.WriteLine("Confirmed the broadcasted signed binary form.");

        yield return (IStatus)this;
    }

    public async IAsyncEnumerable<string> Status()
    {
        yield return "Ready for another form.";
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



