using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using Price = BuberDinner.Domain.Common.Models.Price;

namespace BuberDinner.Domain.Bill;

public class Bill : AggregateRoot<BillId>
{
    public DinnerId DinnerId { get; set; }
    public GuestId GuestId { get; set; }
    public HostId HostId { get; set; }
    public Price Price { get; set; }
    
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
    
    public Bill(BillId id) : base(id)
    {
    }
}