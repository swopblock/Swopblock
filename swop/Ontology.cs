using System;
using swop;
using Swopblock;
using System.Net;
using OrdersNS;

namespace Ontology
{
    public record OrderReservations;
    public record OrderConfirmations;   // (Orders[] Orders);
    public record OrderExpirations;

    //public record OfferReservations

    
    public record Offers(Addresses Addresses);//: Orders;
    //public record Buys: Offers;
    //public record Sells: Offers;

    public record Deals(Offers Offer);

    //public record Invoices(Deals[] Deals);

    public record Executions(Deals Deal);//: Orders;
    //public record Payments: Executions;
    //public record Deliveries: Executions;

    //public record Receipts(Executions Execution);
     


    //public record Orders(Offers Offer);
    //public record Confirmations;// (Orders[] Orders);

    public record Receipts(Executions Execution);

    //public record Transactions(Offers Offer, Deals Deal, Executions Execution, Receipts Receipt);

    public record Addresses(Receipts[] Receipts);
    public record Accounts(Addresses[] Addresses);
    public record Nodes(Accounts[] Accounts);
    public record Markets(Nodes[] Nodes);
    public record Parties(Markets[] Nodes);
    public record Neighborhoods(Parties[] Parties);
    public record CORE(Neighborhoods[] Neighborhoods, Markets[] Markets): Parties(Markets);
    public record LIVE(CORE[] SimulationParties);
}

namespace Swopblock
{

    namespace X
    {
        public abstract record Values

            (decimal Value);


        public record BaseValues

            (decimal BaseValue)

            : Values

                (BaseValue);


        public record FaceValues

            (decimal FaceValue, decimal BaseValue)

            : BaseValues

                (BaseValue);


        public record BookedValues

            (decimal BaseValue, decimal FaceValue, decimal BookedBaseValue, decimal BookedFaceValue, decimal BookedBaseVolume, decimal BookedFaceVolume)

            : FaceValues

                (BaseValue, FaceValue);


        public record MarketBooks

            (decimal MarketBaseValue, decimal MarketFaceValue, decimal MarketBookedBaseValue, decimal MarketBookedFaceValue, decimal MarketBaseVolume, decimal MarketFaceVolume, BookedValues[] MarketBook)

            : BookedValues

                (MarketBaseValue, MarketFaceValue, MarketBookedBaseValue, MarketBookedFaceValue, MarketBaseVolume, MarketFaceValue);

        public record ExchangeBooks

            (decimal ExchangeBaseValue, decimal ExchangeFaceValue, decimal ExchangeBookedBaseValue, decimal ExchangeBookedFaceValue, decimal ExchangeBaseVolume, decimal ExchangeFaceVolume, MarketBooks[] ExchangeBook)

            : BookedValues

                (ExchangeBaseValue, ExchangeFaceValue, ExchangeBookedBaseValue, ExchangeBookedFaceValue, ExchangeBaseVolume, ExchangeFaceVolume);



        public record SwopblockValues

            (decimal BaseValue, decimal FaceValue)

            : FaceValues

                (BaseValue, FaceValue);

        public record BookedSwopblockValues

            (decimal BaseValue, decimal FaceValue)

            : SwopblockValues

                (BaseValue, FaceValue);



        public record SpendingValues

            (decimal BaseValue, decimal FaceValue)

            : FaceValues

                (BaseValue, FaceValue);

        //public record OrderAddresses

            //(decimal BaseValue, decimal FaceValue, decimal BookedBaseValue, decimal BookedFaceValue)

            //: BookedAddressValues

                //(BaseValue, FaceValue, BookedBaseValue, BookedFaceValue);

        public record MoneyOrderAddresses

            (decimal BaseValue, decimal FaceValue, decimal BookedBaseValue, decimal BookedFaceValue)

            : OrderAddresses

                (BaseValue, FaceValue, BookedBaseValue, BookedFaceValue);

        public record MarketOrderAddresses

            (decimal BaseValue, decimal FaceValue, decimal BookedBaseValue, decimal BookedFaceValue)

            : OrderAddresses

                (BaseValue, FaceValue, BookedBaseValue, BookedFaceValue);

        public record InvoicingAddresses

            (decimal BaseValue, decimal FaceValue, decimal BookedBaseValue, decimal BookedFaceValue)

            : OrderAddresses

                (BaseValue, FaceValue, BookedBaseValue, BookedFaceValue);

        public record InvoicingBlocks

            (decimal BaseValue, decimal FaceValue, decimal BookedBaseValue, decimal BookedFaceValue,

            InvoicingAddresses[] Inputs, DeliveringAddresses[] Outputs)

            : InvoicingAddresses

                (BaseValue, FaceValue, BookedBaseValue, BookedFaceValue);

        public record DeliveringAddresses

            (decimal BaseValue, decimal FaceValue, decimal BookedBaseValue, decimal BookedFaceValue)

            : InvoicingAddresses(BaseValue, FaceValue, BookedBaseValue, BookedFaceValue);

        public record ReceiptingAddresses

            (decimal BaseValue, decimal FaceValue, decimal BookedBaseValue, decimal BookedFaceValue)

            : DeliveringAddresses(BaseValue, FaceValue, BookedBaseValue, BookedFaceValue);



        /*

        public record BaseTransfers(decimal BaseTransfer);

        public record FaceTransfers(decimal FaceTransfer);

        public record BlockTransfers(decimal BaseTransfer, decimal FaceTransfer);

        public record OpenSpendingCommand(decimal BaseTransfer, decimal FaceTransfer): Transfers(BaseTransfer);

        public record CloseSpendingCommand(decimal BaseTransfer): Transfers(BaseTransfer);

        //public record OpenSpendingTransfers(decimal BaseTransfer, decimal FaceTransfer): Transfers(BaseTransfer);

        //public record OrderingTransfers(decimal BaseTransfer, decimal FaceTransfer): SpendingTransfers(BaseTransfer, FaceTransfer);


        public record Transactions(Addresses Subject, Transfers Command, Addresses Result);

        public record OpenSpendingAccount(Addresses AddressSource, OpenSpendingCommand OpenSpending, SpendingAddresses SpendingResult): Transactions(AddressSource, Transfer, SpendingResult);

        public record CloseSpendingAccount(SpendingAddresses SpendingSubject, Transfers Command, Addresses AddressResult): Transactions(SpendingSubject, Command, AddressResult);

        public record OpenMoneyMarketAccount();

        public record CloseMoneyMarketAccount();

        public record OpenExchangeMarketAccount(SpendingAddresses Source, Transfers Transfer, OrderingAddresses OrderingAdress);

        public record CloseExchangeMarketAccount(InvoiceOrderingAddress(OrderingAddresses Source, Transfers Invoice, InvoicingAddresses InvoicingA)

        public record CloseOrderingAddress();




        public record BaseValues(decimal BaseValue): Address;

        public record CirculatedValues(decimal BaseValue, decimal FaceValue): BaseValues(BaseValue);

        public record UncirculatingValues(decimal BaseValue, decimal FaceValue, decimal MarketBaseSupply, decimal MarketFaceDemand):

            FaceValues(BaseValue, FaceValue);

        record MarketOrderValues (

            decimal BaseValue, decimal FaceValue,

            decimal MarketBaseSupply, decimal MarketFaceDemand,

            decimal SupplyVolume, decimal DemandVolume ) 

            : MoneyMarketValues(BaseValue, FaceValue, MarketBaseSupply, MarketFaceDemand);
        */

    }

    #region Swopblock Ontology of Addresses, Transactions, Blockchains and Nodes

    #region Addresses Copyright September 19, 2023 Swopblock LLC


    abstract record PublicAddressesNew(decimal BaseValue);

    record PrivateAddressAccessorsNew(decimal BaseValue) : PublicAddressesNew(BaseValue);


    abstract record PublicTransfersNew(decimal BaseValue);

    record PrivateTransferAccessorsNew(decimal BaseValue) : PublicTransfersNew(BaseValue);


    abstract record PublicMoneyOrdersNew(decimal BaseValue, decimal FaceValue, decimal BaseCapital, decimal FaceCapital) : PublicAddressesNew(BaseValue);

    //record PrivateMoneyOrderAccessors(decimal BaseValue, decimal FaceValue) : PublicMoneyOrdersNew(BaseValue, FaceValue);


    abstract record PublicMarketOrdersNew(decimal BaseValue, decimal FaceValue, decimal BaseCapital, decimal FaceCapital, decimal BaseVolume, decimal FaceVolume); //: PublicMoneyOrdersNew();

    //record PrivateMarketOrderAccessors : PublicMarketOrdersNew;



    record OrdersNew;

    //record MoneyOrdersNew(PrivateAddressAccessorsNew Source, TransfersNew Transfer, Addresses Sink);

    //record MarketOrdersNew(PrivateAddressAccessorsNew Source, TransfersNew Supply, TransfersNew Demand);

    record TransactionsNew();

    record MoneyOrderTransactionsNew();

// Addresses are locations of Base Value that was, is, or may yet be available
// for Transactions to transfer to another location.
public abstract partial record Addresses(decimal BaseValue);

    // Native Addresses are Addresses that are unique to a particular blockchain.
    public abstract partial record NativeAddresses(decimal BaseValue)
        : Addresses(BaseValue);

    // Btc Addresses are Native Addresses unique to the Bitcoin blockchain.
    public partial record BtcAddresses(decimal BaseValue)
        : NativeAddresses(BaseValue);

    // Eth Addresses are Native Addresses unique to the Ethereum blockchain.
    public partial record EthAddresses(decimal BaseValue)
        : NativeAddresses(BaseValue);

    // Order Addresses are Native Addresses that are locations of Base Value and
    // Face Value that is unique to and available for Order Transactions only, and
    // they also keep the running balance of Face Capital and of Base Capital. 
    public abstract partial record OrderAddresses
        (decimal BaseValue, decimal FaceValue,
        decimal BaseCapital, decimal FaceCapital)
        : NativeAddresses(BaseValue);

    // Money Orders are Order Addresses which are available for
    // Money Order Transactions only.
    public partial record MoneyOrderAddresses
        (decimal BaseValue, decimal FaceValue,
        decimal BaseCapital, decimal FaceCapital)
        : OrderAddresses(BaseValue, FaceValue, BaseCapital, FaceCapital);

    // Market Orders are Order Addresses which are available for
    // Market Order Transactions only, and they also keep running balances of
    // Base Volume and of Face Volume.
    public partial record MarketOrderAddresses
        (decimal BaseValue, decimal FaceValue,
        decimal BaseCapital, decimal FaceCapital,
        decimal BaseVolume, decimal FaceVolume)
        : MoneyOrderAddresses(BaseValue, FaceValue, BaseCapital, FaceCapital);

    public partial record BtcMarketOrderAddresses;

    public partial record EthMarketOrderAddresses;

    #endregion

    #region Transactions


    // Transactions are transfers from an Input location of values to an Output location for the values.
    public abstract record Transactions();

    // Native Transactions are Transactions that denote native value that is transfered on its native blockchain.
    public abstract record NativeTransactions(NativeAddresses Input, NativeAddresses Output) : Transactions;

    // Native Transactions are transactions that denote native value that is transfered on its native blockchain.
    public abstract record BtcNativeTransactions(BtcAddresses Input, BtcAddresses Output) : Transactions();

    // Native Transactions are transactions that denote native value that is transfered on its native blockchain.
    //public abstract record EthNativeTransactions(Addresses Source, Addresses Sink) : Transactions(Source, Sink);


    public record OrderTransactions(OrderAddresses OrderSource, OrderAddresses OrderSink) : NativeTransactions(OrderSource, OrderSink);

    public record OpeningTransactions(NativeAddresses Before, NativeAddresses Opened) : NativeTransactions(Before, Opened);

    public record ClosingTransactons(NativeAddresses Before, NativeAddresses Closed) : NativeTransactions(Before, Closed);

    // Money Transactions are Native Transactions that additionally denote Face Value that is transfered in Money spending transactions only.
    //public record MoneyOrderTransactions(OAddresses Source, Addresses Sink) : OrderTransactions;

    // Market Transactions are Native Transactions that additionally denote Face Value that is transfered in Market trading transactions only. 
    //public record MarketOrderTransactions(OrderAddresses OrderSource, OrderAddresses Sink) : OrderTransactions(Source, Sink);





    // Native Blocks are containers that contain NativeTransactions to be verified and confirmed.
    public abstract record NativeBlocks;


    // Money Addresses and Transactions


    // Market Addresses and Transactions





    //IAMHERE

    // Availings are Market Transactions that are either a Beginning Transaction or a Closing Transacton that denote an address is available to open for trading.
    //public abstract record Availings : MarketTransactions;

    // Openings are Trading Transactions that open an address for trading.
    //public record Openings(Availings Availing) : MarketTransactions;

    // Closings are Trading Transactions that close an address for trading and denotes it available to open for trading.
    //public record Closings(Openings Opening) : Availings;

    // Beginnings are Trading Transactions that make an address available to open for trading.
    //public record Beginnings(NativeAddresses Address) : Availings;

    // Orders are a kind of order, the order being a set of native blockshain transactions that comprises either a money transaction or a market transaction. 
    //public abstract record Orders(decimal FaceValue, decimal MarketValue, NativeAddresses Address) : NativeTransactions;

    //public record MoneyOrders(decimal FaceValue, decimal MarketValue) : MoneyTransactions;

    public record MarketOrdersOld// : Orders;
    (
        //Openings Opening,

        Nodes Node,

        MarketsOlder Market,

        decimal FaceValue,

        decimal MarketValue
    )
    {

    }

    public record Deposit
        (
            //Orders Order,

            decimal FaceValue,

            decimal MarketValue
        )
    {

    }

    public record Withdrawals
        (
            Deposit Deposit,

            MarketsOlder Market,

            decimal FaceValue,

            decimal MarketValue

        )
    {

    }

    public record TradingOffers
        (
            Deposit Deposit,

            Withdrawals Withdrawal,

            decimal OpeningBid,

            decimal OpeningAsk,

            decimal Opening)

    { }
    public record Invoices(Nodes Node, MarketsOlder Market);// : TradingOffers(Node, Market);

    public record Deliveries(Nodes Node, MarketsOlder Market) : Invoices(Node, Market);

    public record Receipts(Nodes Node, MarketsOlder Market) : Deliveries(Node, Market);

    //}
    #endregion


    #region Blockchains

    public abstract record Blockchains;

    public abstract record NativeBlockchains(

        Nodes[] ServerParties, Nodes[] ClientParties,

        Addresses[] Addresses, Transactions[] Transactions) :

        Blockchains;

    public record BtcBlockchain(

        Nodes[] ServerParties, Nodes[] ClientParties,

        Addresses[] Addresses, Transactions[] Transactions) :

        NativeBlockchains(ServerParties, ClientParties, Addresses, Transactions);

    public record EthBlockchain(

        Nodes[] ServerParties, Nodes[] ClientParties,

        Addresses[] Addresses, Transactions[] Transactions) :

        NativeBlockchains(ServerParties, ClientParties, Addresses, Transactions);

    public abstract record OrderBlockchains(

        Nodes[] ServerParties, Nodes[] ClientParties,

        Addresses[] Addresses, Transactions[] Transactions) :

        Blockchains();

    public record OrderBlockchain(NativeBlockchains NativeBlock);

    #endregion

    #region

    public record Nodes(EndPoint Location, Nodes[] Servers, Nodes[] Clients);

    public record NativeNodes(EndPoint Location, Nodes[] Servers, Nodes[] Client);

    //public record BtcNodes(EndPoint Location, NativeNodes[] Servers, NativeNodes[] Clients) : NativeNodes(Location, Servers, Clients);

    //public record EthNodes(EndPoint Location, NativeNodes[] Servers, NativeNodes[] Clients) : NativeNodes(Location, Servers, Clients);

    //public record OrderNodes(EndPoint Location, BtcNodes BtcNode, EthNodes EthNode) : Nodes(Location);


    public record Swopblock(Nodes[] AllParties, Blockchains[] AllMarkets, Addresses[] AllAddresses, Transactions[] AllTransactions);

    //public record Nodes(Nodes[] MyServers, Nodes[] MyClients, Blockchains[] MyMarkets, Addresses[] MyAddresses, Transactions[] MyTransactions);



    #endregion

    #endregion

}