using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Enums;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Domain.Dinner.Entities;

public class DinnerReservation : Entity<DinnerReservationId>
{
    public int GuestCount { get; set; }
    public ReservationStatus ReservationStatus { get; set; }
    public GuestId GuestId { get; set; }
    public BillId BillId { get; set; }
    public DateTime ArrivalDateTime { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }

    private DinnerReservation(DinnerReservationId id, int guestCount, ReservationStatus reservationStatus, GuestId guestId, BillId billId, DateTime arrivalDateTime, DateTime createdDateTime, DateTime updatedDateTime) : base(id)
    {
        GuestCount = guestCount;
        ReservationStatus = reservationStatus;
        GuestId = guestId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public DinnerReservation Create(int guestCount, ReservationStatus reservationStatus, GuestId guestId, BillId billId,
        DateTime arrivalDateTime, DateTime createdDateTime, DateTime updatedDateTime) => 
        new(DinnerReservationId.CreateUniqie(), guestCount,reservationStatus,guestId,billId,arrivalDateTime,DateTime.UtcNow,DateTime.UtcNow);
}