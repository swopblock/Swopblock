using System;
namespace Swopblock;

public partial record DeedsY
	(
		decimal BaseValue,

		decimal FaceValue
	)
:OrderItems
	(
		BaseValue,

		FaceValue
	)
{
}

