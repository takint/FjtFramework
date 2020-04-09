namespace FjtFramework.Cores
{
    // Transportation services
    public enum PaymentType
    {
        Cash = 1,
        eTransfer
    }

    public enum OrderType
    {
        Go = 1,
        Airport,
        Home,
        Tour,
        Truck
    }

    public enum OrderStatus
    {
        Open = 1,
        Pending,
        Done,
        Paid,
        Closed
    }

    public enum TypeOfCar
    {
        Sedan = 1,
        Suv,
        Truck
    }

    public enum MessageType
    {
        BookOrder = 1,
        PaidOrder
    }

    // Another services

}
