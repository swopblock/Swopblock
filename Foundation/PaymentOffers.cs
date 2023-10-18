using System;
namespace Swopblock;

public partial record PaymentOffers
    (
        decimal BaseValue,

        decimal FaceValue
    )
: Offers
    (
        BaseValue,

        FaceValue
    )
{
}
