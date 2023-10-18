using System;
namespace Swopblock;

public partial record Dues
	(
		decimal BaseValue,

		decimal FaceValue

	):InvoiceItems
	(
		BaseValue,

		FaceValue
	)
{
}

