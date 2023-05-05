using System;
namespace swop
{
    public class CashForms : DeliveryForms
    {
        public CashForms()
        {

        }

        public new static CashForms Parse(string text)
        {
            var txt = text.Split("in order to", 2)[0];

            if (txt.Contains("BTC"))
            {
                return BtcCashments.Parse(text);
            }

            if (txt.Contains("ETH"))
            {
                return EthCashments.Parse(text);
            }

            return new CashForms();
        }
    }



    public class BtcCashments : CashForms
    {
        public BtcCashments()
        {

        }

        public new static BtcCashments Parse(string text)
        {
            var txt = text.Split(' ', 1)[0];

            if (txt.Contains("I"))
            {
                return SignableBtcCashments.Parse(text);
            }

            if (txt.Contains("We"))
            {
                return ConfirmedBtcCashments.Parse(text);
            }

            return new BtcCashments();
        }
    }

    public class SignableBtcCashments : BtcCashments
    {
        public SignableBtcCashments()
        {

        }

        public new static SignableBtcCashments Parse(string text)
        {
            return new SignableBtcCashments();
        }
    }

    public class ConfirmedBtcCashments : BtcCashments
    {
        public ConfirmedBtcCashments()
        {

        }

        public new static ConfirmedBtcCashments Parse(string text)
        {
            return new ConfirmedBtcCashments();
        }
    }



    public class EthCashments : CashForms
    {
        public EthCashments()
        {

        }

        public new static EthCashments Parse(string text)
        {
            var txt = text.Split(' ', 1)[0];


            if (txt.Contains("I"))
            {
                return SignableEthCashments.Parse(text);
            }

            if (txt.Contains("We"))
            {
                return ConfirmedEthCashments.Parse(text);
            }

            return new EthCashments();
        }
    }

    public class SignableEthCashments : EthCashments
    {
        public SignableEthCashments()
        {

        }

        public new static SignableEthCashments Parse(string text)
        {
            return new SignableEthCashments();
        }
    }

    public class ConfirmedEthCashments : EthCashments
    {
        public ConfirmedEthCashments()
        {

        }

        public new static ConfirmedEthCashments Parse(string text)
        {
            return new ConfirmedEthCashments();
        }
    }

}

