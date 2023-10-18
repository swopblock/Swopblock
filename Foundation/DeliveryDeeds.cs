using System;
namespace Swopblock;

public partial record DeliveryDeeds
    (
        decimal BaseValue,

        decimal FaceValue
    )
: Deeds
    (
        BaseValue,

        FaceValue
    )
{
}

