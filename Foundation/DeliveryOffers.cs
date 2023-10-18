using System;

namespace Swopblock;

public partial record DeliveryOffers
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

