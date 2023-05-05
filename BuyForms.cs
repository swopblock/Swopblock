using System;

namespace swop
{
    public class BuyForms: InvoiceForms
    {
        public BuyForms()
        {

        }

        public new static BuyForms Parse(string text)
        {
            var txt = text.Split("in order to", 2)[0];

            if (txt.Contains("BTC"))
            {
                return BtcBuys.Parse(text);
            }

            if (txt.Contains("ETH"))
            {
                return EthBuys.Parse(text);
            }

            return new BuyForms();
        }
    }



    public class BtcBuys : BuyForms
    {
        public BtcBuys()
        {

        }

        public new static BtcBuys Parse(string text)
        {
            var txt = text.Split(' ', 1)[0];

            if (txt.Contains("I"))
            {
                return SignableBtcBuys.Parse(text);
            }

            if (txt.Contains("We"))
            {
                return ConfirmedBtcBuys.Parse(text);
            }
            return new BtcBuys();
        }
    }

    public class SignableBtcBuys : BtcBuys
    {
        public SignableBtcBuys()
        {

        }

        public new static SignableBtcBuys Parse(string text)
        {
            return new SignableBtcBuys();
        }
    }

    public class ConfirmedBtcBuys : BtcBuys
    {
        public ConfirmedBtcBuys()
        {

        }

        public new static ConfirmedBtcBuys Parse(string text)
        {
            return new ConfirmedBtcBuys();
        }
    }



    public class EthBuys : BuyForms
    {
        public EthBuys()
        {

        }

        public new static EthBuys Parse(string text)
        {
            var txt = text.Split(' ', 1)[0];


            if (txt.Contains("I"))
            {
                return SignableEthBuys.Parse(text);
            }

            if (txt.Contains("We"))
            {
                return ConfirmedEthBuys.Parse(text);
            }

            return new EthBuys();
        }
    }

    public class SignableEthBuys : EthBuys
    {
        public SignableEthBuys()
        {

        }

        public new static SignableEthBuys Parse(string text)
        {
            return new SignableEthBuys();
        }
    }

    public class ConfirmedEthBuys : EthBuys
    {
        public ConfirmedEthBuys()
        {

        }

        public new static ConfirmedEthBuys Parse(string text)
        {
            return new ConfirmedEthBuys();
        }
    }

}

