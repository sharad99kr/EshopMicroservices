

namespace Ordering.Domain.ValueObjects
{
    public record OrderItemID
    {
        public Guid Value { get; }
        private OrderItemID(Guid value) => Value = value;
        public static OrderItemID Of(Guid value) {
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            if(value == Guid.Empty) {
                throw new DomainException("OrderItemID cannot be empty");
            }
            return new OrderItemID(value);
        }
    }
}
