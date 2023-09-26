using System;
using Swopblock.OrdersOldNS;

namespace Swopblock.TestOrders
{
    #region Entry Test Items

    public class TestIMarketItem : IMarketItem { }

    public class TestIEntryItem// : IFirstEntryItem
    {
        public TestIEntryItem()
        {
            PersuedMarket = new TestIMarketItem();
        }

        public IMarketItem PersuedMarket { get; init; }

        [Fact]
        public void GetPersuedMarket()
        {
            Assert.NotNull(PersuedMarket);

            Assert.IsAssignableFrom<IMarketItem>(PersuedMarket);
        }

        [Fact]
        public void TestAssignableFromIEntryItem()
        {
            //Assert.IsAssignableFrom<IFirstEntryItem>(this);
        }
    }

    public class TestIBuyEntryItem// : IBuyEntryItem
    {
        public TestIBuyEntryItem()
        {
            PersuedMarket = new TestIMarketItem();
        }

        public IMarketItem PersuedMarket { get; init; }

        public IMarketItem BuyMarket { get; init; }

        //public IMarketItem BuyMarket { get; init; }


        [Fact]
        public void TestGetPersuedMarket()
        {
            Assert.NotNull(PersuedMarket);

            Assert.IsAssignableFrom<IMarketItem>(PersuedMarket);
        }

        [Fact]
        public void TestGetBuyMarket()
        {
            //((IBuyEntryItem)this).testA(1, 2);

            //this.testA(1, 2);
        }

        [Fact]
        public void TestAssignableFromIEntryItem()
        {
            //Assert.IsAssignableFrom<IFirstEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIBuyEntryItem()
        {
            //Assert.IsAssignableFrom<IBuyEntryItem>(this);
        }
    }

    public class TestISellEntryItem// : ISellEntryItem
    {
        public TestISellEntryItem()
        {
            PersuedMarket = new TestIMarketItem();
        }

        public IMarketItem PersuedMarket { get; init; }

        [Fact]
        public void GetPersuedMarket()
        {
            Assert.NotNull(PersuedMarket);

            Assert.IsAssignableFrom<IMarketItem>(PersuedMarket);
        }


        [Fact]
        public void TestAssignableFromIEntryItem()
        {
            //Assert.IsAssignableFrom<IFirstEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromISellEntryItem()
        {
            //Assert.IsAssignableFrom<ISellEntryItem>(this);
        }
    }

    #endregion

    #region Charge Test Items

    public class TestIChargeItem : IChargeItem
    {
        public IMarketItem PersuedMarket { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

        [Fact]
        public void TestAssignableFromIEntryItem()
        {
            //Assert.IsAssignableFrom<IFirstEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIChargeItem()
        {
            //Assert.IsAssignableFrom<IChargeItem>(this);
        }
    }

    public class TestIBuyChargeItem// : IBuyChargeItem
    {
        public IMarketItem PersuedMarket { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

        [Fact]
        public void TestAssignableFromIEntryItem()
        {
            //Assert.IsAssignableFrom<IFirstEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIBuyEntryItem()
        {
            //Assert.IsAssignableFrom<IBuyEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIChargeItem()
        {
            Assert.IsAssignableFrom<IChargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIBuyChargeItem()
        {
            //Assert.IsAssignableFrom<IBuyChargeItem>(this);
        }
    }

    public class TestISellChargeItem// : ISellChargeItem
    {
        public IMarketItem PersuedMarket { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

        [Fact]
        public void TestAssignableFromIEntryItem()
        {
            //Assert.IsAssignableFrom<IFirstEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromISellEntryItem()
        {
            //Assert.IsAssignableFrom<ISellEntryItem>(this);
        }
        [Fact]
        public void TestAssignableFromIChargeItem()
        {
            Assert.IsAssignableFrom<IChargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromISellChargeItem()
        {
            //Assert.IsAssignableFrom<ISellChargeItem>(this);
        }
    }

    #endregion

    #region Discharge Test Items

    public class TestIDischargeItem : IDischargeItem
    {
        public IMarketItem PersuedMarket { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

        [Fact]
        public void TestAssignableFromIEntryItem()
        {
            //Assert.IsAssignableFrom<IFirstEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIChargeItem()
        {
            Assert.IsAssignableFrom<IChargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIDischargeItem()
        {
            Assert.IsAssignableFrom<IDischargeItem>(this);
        }
    }

    public class TestIBuyDischargeItem// : IBuyDischargeItem
    {
        public IMarketItem PersuedMarket { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
        public IMarketItem BuyMarket { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

        [Fact]
        public void TestAssignableFromIDisChargeItem()
        {
            Assert.IsAssignableFrom<IDischargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIEntryItem()
        {
            //Assert.IsAssignableFrom<IFirstEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIChargeItem()
        {
            Assert.IsAssignableFrom<IChargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIBuyEntryItem()
        {
            //Assert.IsAssignableFrom<IBuyEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIBuyChargeItem()
        {
            //Assert.IsAssignableFrom<IBuyChargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIBuyDischareItem()
        {
            //Assert.IsAssignableFrom<IBuyDischargeItem>(this);
        }
    }

    public class TestISellDischargeItem// : ISellDischargeItem
    {
        public IMarketItem PersuedMarket { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

        [Fact]
        public void TestAssignableFromIDisChargeItem()
        {
            Assert.IsAssignableFrom<IDischargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIEntryItem()
        {
            //Assert.IsAssignableFrom<IFirstEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIChargeItem()
        {
            Assert.IsAssignableFrom<IChargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromISellEntryItem()
        {
            //Assert.IsAssignableFrom<ISellEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromISellChargeItem()
        {
            //Assert.IsAssignableFrom<ISellChargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromISellDischareItem()
        {
            //Assert.IsAssignableFrom<ISellDischargeItem>(this);
        }
    }



    #endregion

    #region Offer Test Items

    public class TestIOfferItem// : IOfferItem
    {
        public IMarketItem PersuedMarket { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [Fact]
        public void TestAssignableFromIEntryItem()
        {
            //Assert.IsAssignableFrom<IFirstEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIChargeItem()
        {
            Assert.IsAssignableFrom<IChargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIOfferItem()
        {
            Assert.IsAssignableFrom<IOfferItem>(this);
        }
    }

    public class TestIBidItem// : IBidItem
    {
        public IMarketItem PersuedMarket { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [Fact]
        public void TestAssignableFromIOfferItem()
        {
            Assert.IsAssignableFrom<IOfferItem>(this);
        }

        [Fact]
        public void TestAssignableFromIBuyChargeItem()
        {
            //Assert.IsAssignableFrom<IBuyChargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIBuyEntryItem()
        {
            //Assert.IsAssignableFrom<IBuyEntryItem>(this);
        }
    }

    public class TestIAskItem// : IAskItem
    {
        public IMarketItem PersuedMarket { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [Fact]
        public void TestAssignableFromIOfferItem()
        {
            Assert.IsAssignableFrom<IOfferItem>(this);
        }

        [Fact]
        public void TestAssignableFromISellChargeItem()
        {
            //Assert.IsAssignableFrom<ISellChargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromISellEntryItem()
        {
            //Assert.IsAssignableFrom<ISellEntryItem>(this);
        }
    }


    #endregion

    #region Invoice Test Items

    public class TestIInvoiceItem// : IInvoiceItem
    {
        public IMarketItem PersuedMarket { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [Fact]
        public void TestAssignableFromIInvoiceItem()
        {
            Assert.IsAssignableFrom<IInvoiceItem>(this);
        }

        [Fact]
        public void TestAssignableFromIOfferItem()
        {
            Assert.IsAssignableFrom<IOfferItem>(this);
        }

        [Fact]
        public void TestAssignableFromIChargeItem()
        {
            Assert.IsAssignableFrom<IChargeItem>(this);
        }

    }

    public class TestIBuyItem : TestIBuyEntryItem//, IBuyItem
    {
        public IMarketItem PersuedMarket { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IMarketItem BuyMarket { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

        [Fact]
        public void TestAssignableFromIBuyItem()
        {
            //Assert.IsAssignableFrom<IBuyItem>(this);
        }

        [Fact]
        public void TestAssignableFromIInvoiceItem()
        {
            Assert.IsAssignableFrom<IInvoiceItem>(this);
        }

        [Fact]
        public void TestAssignableFromIBidItem()
        {
            //Assert.IsAssignableFrom<IBidItem>(this);
        }
    }

    public class TestISellItem// : ISellItem
    {
        public IMarketItem PersuedMarket { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [Fact]
        public void TestAssignableFromISellItem()
        {
            //Assert.IsAssignableFrom<ISellItem>(this);
        }

        [Fact]
        public void TestAssignableFromIInvoiceItem()
        {
            Assert.IsAssignableFrom<IInvoiceItem>(this);
        }

        [Fact]
        public void TestAssignableFromIAskItem()
        {
            //Assert.IsAssignableFrom<IAskItem>(this);
        }
    }


    #endregion

    #region Delivery Test Items

    public class TestIDeliveryItem// : IDeliveryItem
    {
        public IMarketItem PersuedMarket { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [Fact]
        public void TestAssignableFromIEntryItem()
        {
            //Assert.IsAssignableFrom<IFirstEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIChargeItem()
        {
            Assert.IsAssignableFrom<IChargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIOfferItem()
        {
            Assert.IsAssignableFrom<IOfferItem>(this);
        }

        [Fact]
        public void TestAssignableFromIInvoiceItem()
        {
            Assert.IsAssignableFrom<IDischargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIDeliveryItem()
        {
            Assert.IsAssignableFrom<IDeliveryItem>(this);
        }
    }

    public class TestIPaymentItem// : IPaymentItem
    {
        public IMarketItem PersuedMarket { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [Fact]
        public void TestAssignableFromIPaymentItem()
        {
            Assert.IsAssignableFrom<IPaymentItem>(this);
        }

        [Fact]
        public void TestAssignableFromIDeliveryItem()
        {
            Assert.IsAssignableFrom<IDeliveryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIBuyItem()
        {
            //Assert.IsAssignableFrom<IBuyItem>(this);
        }
    }

    public class TestICashingItem// : ICashingItem
    {
        public IMarketItem PersuedMarket { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [Fact]
        public void TestAssignableFromICashingItem()
        {
            Assert.IsAssignableFrom<ICashingItem>(this);
        }

        [Fact]
        public void TestAssignableFromIDeliveryItem()
        {
            Assert.IsAssignableFrom<IDeliveryItem>(this);
        }

        [Fact]
        public void TestAssignableFromISellItem()
        {
            //Assert.IsAssignableFrom<ISellItem>(this);
        }
    }


    #endregion

    #region Receipt Test Items

    public class TestIReceiptItem// : IReceiptItem
    {
        public IMarketItem PersuedMarket { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

        [Fact]
        public void TestAssignableFromIEntryItem()
        {
            //Assert.IsAssignableFrom<IFirstEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIChargeItem()
        {
            Assert.IsAssignableFrom<IChargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIOfferItem()
        {
            Assert.IsAssignableFrom<IOfferItem>(this);
        }

        [Fact]
        public void TestAssignableFromIInvoiceItem()
        {
            Assert.IsAssignableFrom<IDischargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIDeliveryItem()
        {
            Assert.IsAssignableFrom<IDeliveryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIReceiptItem()
        {
            Assert.IsAssignableFrom<IReceiptItem>(this);
        }
    }

    public class TestIExpenseItem// : IExpenseItem
    {
        public IMarketItem PersuedMarket { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

        [Fact]
        public void TestAssignableFromIExpenseItem()
        {
            Assert.IsAssignableFrom<IExpenseItem>(this);
        }

        [Fact]
        public void TestAssignableFromIRecieptItem()
        {
            Assert.IsAssignableFrom<IReceiptItem>(this);
        }

        [Fact]
        public void TestAssignableFromIPaymentItem()
        {
            Assert.IsAssignableFrom<IPaymentItem>(this);
        }
    }

    public class TestIIncomeItem //: IIncomeItem
    {
        public IMarketItem PersuedMarket { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

        [Fact]
        public void TestAssingableFromIIncomeItem()
        {
            Assert.IsAssignableFrom<IIncomeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIDischareItem()
        {
            Assert.IsAssignableFrom<IReceiptItem>(this);
        }

        [Fact]
        public void TestAssignableFromICashingItem()
        {
            Assert.IsAssignableFrom<ICashingItem>(this);
        }
    }

    #endregion

    #region Order Test Items

    public class TestIOrderItem// : IOrderItem
    {
        public IMarketItem PersuedMarket { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

        [Fact]
        public void TestAssignableFromIEntryItem()
        {
            //Assert.IsAssignableFrom<IFirstEntryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIChargeItem()
        {
            Assert.IsAssignableFrom<IChargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIOfferItem()
        {
            Assert.IsAssignableFrom<IOfferItem>(this);
        }

        [Fact]
        public void TestAssignableFromIInvoiceItem()
        {
            Assert.IsAssignableFrom<IInvoiceItem>(this);
        }

        [Fact]
        public void TestAssignableFromIDischareItem()
        {
            Assert.IsAssignableFrom<IDischargeItem>(this);
        }

        [Fact]
        public void TestAssignableFromIDeliveryItem()
        {
            Assert.IsAssignableFrom<IDeliveryItem>(this);
        }

        [Fact]
        public void TestAssignableFromIReceiptItem()
        {
            Assert.IsAssignableFrom<IReceiptItem>(this);
        }

        [Fact]
        public void TestAssignableFromIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(this);
        }
    }

    public class TestIBuyOrderItem //: IBuyOrderItem
    {
        public IMarketItem PersuedMarket { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

        [Fact]
        public void TestAssignableFromIBuyOrderItem()
        {
            Assert.IsAssignableFrom<IBuyOrderItem>(this);
        }

        [Fact]
        public void TestAssignableFromIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(this);
        }

        [Fact]
        public void TestAssignableFromIExpenseItem()
        {
            Assert.IsAssignableFrom<IExpenseItem>(this);
        }
    }

    public class TestISellOrderItem// : ISellOrderItem
    {
        public IMarketItem PersuedMarket { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

        [Fact]
        public void TestAssignableFromISellOrderItem()
        {
            Assert.IsAssignableFrom<ISellOrderItem>(this);
        }

        [Fact]
        public void TestAssignableFromIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(this);
        }

        [Fact]
        public void TestAssignableFromIIncomeItem()
        {
            Assert.IsAssignableFrom<IIncomeItem>(this);
        }
    }

    #endregion
}

