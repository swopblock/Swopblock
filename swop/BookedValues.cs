using System;
namespace Swopblock
{
    public abstract record Values

            (decimal Value);


    public record BaseValues

        (decimal BaseValue)

        : Values

            (BaseValue);


    public record FaceValues

        (decimal FaceValue, decimal BaseValue)

        : BaseValues

            (BaseValue);


    public record BookedValues

        (decimal BaseValue, decimal FaceValue, decimal BookedBaseValue, decimal BookedFaceValue, decimal BookedBaseVolume, decimal BookedFaceVolume)

        : FaceValues

            (BaseValue, FaceValue);


    public record MarketBooks

        (decimal MarketBaseValue, decimal MarketFaceValue, decimal MarketBookedBaseValue, decimal MarketBookedFaceValue, decimal MarketBaseVolume, decimal MarketFaceVolume, BookedValues[] MarketBook)

        : BookedValues

            (MarketBaseValue, MarketFaceValue, MarketBookedBaseValue, MarketBookedFaceValue, MarketBaseVolume, MarketFaceValue);

    public record ExchangeBooks

        (decimal ExchangeBaseValue, decimal ExchangeFaceValue, decimal ExchangeBookedBaseValue, decimal ExchangeBookedFaceValue, decimal ExchangeBaseVolume, decimal ExchangeFaceVolume, MarketBooks[] ExchangeBook)

        : BookedValues

            (ExchangeBaseValue, ExchangeFaceValue, ExchangeBookedBaseValue, ExchangeBookedFaceValue, ExchangeBaseVolume, ExchangeFaceVolume);

}

