using System;
namespace swop
{
	public class AskForms: Offers
	{
		public AskForms()
		{

		}

        public new static AskForms Parse(string text)
        {
            var ask = text.Split("in order to", 2)[0];

            if (ask.Contains("BTC"))
            {
                return BtcAsks.Parse(text);
            }

            if (ask.Contains("ETH"))
            {
                return EthAsks.Parse(text);
            }
            return new AskForms();
        }
    }



    public class BtcAsks: AskForms
    {
        public BtcAsks()
        {

        }

        public new static BtcAsks Parse(string text)
        {
            var btcAsk = text.Split(' ', 1)[0];

            if (btcAsk.Contains("I"))
            {
                return SignableBtcAsks.Parse(text);
            }

            if (btcAsk.Contains("We"))
            {
                return ConfirmedBtcAsks.Parse(text);
            }
            
            return new BtcAsks();
        }
    }

    public class SignableBtcAsks: BtcAsks
    {
        public SignableBtcAsks()
        {

        }

        public new static SignableBtcAsks Parse(string text)
        {
            return new SignableBtcAsks();
        }
    }

    public class ConfirmedBtcAsks: BtcAsks
    {
        public new static ConfirmedBtcAsks Parse(string text)
        {
            return new ConfirmedBtcAsks();
        }
    }



    public class EthAsks: AskForms
    {
        public EthAsks()
        {

        }

        public new static EthAsks Parse(string text)
        {
            var ethAsk = text.Split(' ', 1)[0];

            if (ethAsk.Contains("I"))
            {
                return SignableEthAsks.Parse(text);
            }

            if (ethAsk.Contains("We"))
            {
                return ConfirmedEthAsks.Parse(text);
            }

            return new EthAsks();
        }
    }

    public class SignableEthAsks : EthAsks
    {
        public SignableEthAsks()
        {

        }

        public new static SignableEthAsks Parse(string text)
        {
            return new SignableEthAsks();
        }
    }

    public class ConfirmedEthAsks : EthAsks
    {
        public ConfirmedEthAsks()
        {

        }

        public new static ConfirmedEthAsks Parse(string text)
        {
            return new ConfirmedEthAsks();
        }
    }
}

