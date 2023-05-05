using System;
namespace swop
{
    public class PayForms : DeliveryForms
    {
        public PayForms()
        {

        }

        public new static PayForms Parse(string text)
        {
            var txt = text.Split("in order to", 2)[0];

            if (txt.Contains("BTC"))
            {
                return BtcPayments.Parse(text);
            }

            if (txt.Contains("ETH"))
            {
                return EthPayments.Parse(text);
            }

            return new PayForms();
        }
    }



    public class BtcPayments : PayForms
    {
        public BtcPayments()
        {

        }

        public new static BtcPayments Parse(string text)
        {
            var txt = text.Split(' ', 1)[0];

            if (txt.Contains("I"))
            {
                return SignableBtcPayments.Parse(text);
            }

            if (txt.Contains("We"))
            {
                return ConfirmedBtcPayments.Parse(text);
            }
            return new BtcPayments();
        }
    }

    public class SignableBtcPayments : BtcPayments
    {
        public SignableBtcPayments()
        {

        }

        public new static SignableBtcPayments Parse(string text)
        {
            return new SignableBtcPayments();
        }
    }

    public class ConfirmedBtcPayments : BtcPayments
    {
        public ConfirmedBtcPayments()
        {

        }

        public new static ConfirmedBtcPayments Parse(string text)
        {
            return new ConfirmedBtcPayments();
        }
    }



    public class EthPayments : PayForms
    {
        public EthPayments()
        {

        }

        public new static EthPayments Parse(string text)
        {
            var txt = text.Split(' ', 1)[0];


            if (txt.Contains("I"))
            {
                return SignableEthPayments.Parse(text);
            }

            if (txt.Contains("We"))
            {
                return ConfirmedEthPayments.Parse(text);
            }

            return new EthPayments();
        }
    }

    public class SignableEthPayments : EthPayments
    {
        public SignableEthPayments()
        {

        }

        public new static SignableEthPayments Parse(string text)
        {
            return new SignableEthPayments();
        }
    }

    public class ConfirmedEthPayments : EthPayments
    {
        public ConfirmedEthPayments()
        {

        }

        public new static ConfirmedEthPayments Parse(string text)
        {
            return new ConfirmedEthPayments();
        }
    }

}


