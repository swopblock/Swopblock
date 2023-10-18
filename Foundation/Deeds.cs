using System;
namespace Swopblock;

public partial record Deeds
	(
		decimal BaseValue,

		decimal FaceValue
	)
:InvoiceItems
	(
		BaseValue,

		FaceValue
	)
{
}

