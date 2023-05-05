using System;

namespace swop
{
	public class Users: Applicators
	{
        OfferForms Offer = new OfferForms();

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

