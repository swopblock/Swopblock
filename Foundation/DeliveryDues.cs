using System;
namespace Swopblock;

public partial record DeliveryDues
    (
        decimal BaseValue,

        decimal FaceValue
    )
: Dues
    (
        BaseValue,

        FaceValue
    )
{
}

