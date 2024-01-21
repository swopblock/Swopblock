using System;
namespace Swopblock;

public partial record DuesY
	(
		decimal BaseValue,

		decimal FaceValue

	):OrderItems
	(
		BaseValue,

		FaceValue
	)
{
}

