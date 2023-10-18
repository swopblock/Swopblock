using System;
namespace Swopblock;

public partial record PaymentDues
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
