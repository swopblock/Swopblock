using System;
namespace Swopblock;

public partial record PaymentDeeds
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
