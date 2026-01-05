


namespace Ordering.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        public static IEnumerable<Customer> Customers => new List<Customer>
        {
            Customer.Create(CustomerId.Of(new Guid("d290f1ee-6c54-4b01-90e6-d701748f0851")), "John Doe", "JohnDoe.gamil.com"),
            Customer.Create(CustomerId.Of(new Guid("d290f1ef-6c54-4b01-90e6-d701748f0852")), "Sam Dough", "Sam_Dough.gamil.com")
        };
    }
}
