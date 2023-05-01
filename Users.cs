using System;

namespace swop
{
	public class Users: Applicators
	{
        Offers Offer = new Offers();

		public Users()
		{

		}

        public override void WriteLine(string line)
        {

        }

        public override string? ReadLine()
        {
            return base.ReadLine();
        }
    }
}

