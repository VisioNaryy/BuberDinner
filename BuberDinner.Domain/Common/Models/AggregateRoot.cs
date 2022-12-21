namespace BuberDinner.Domain.Common.Models;

public class AggregateRoot<Tid> : Entity<Tid> where Tid: notnull
{
    public AggregateRoot(Tid id) : base(id)
    {
    }
}