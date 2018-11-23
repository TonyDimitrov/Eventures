namespace Models.Web
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Event : BaseEntity<string>
    {
        public string Name { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Place { get; set; }

        public int TotalTickets { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerTicket { get; set; }

        public string OrderId { get; set; }

        public Order Order { get; set; }

        public string UserId { get; set; }

        public EventureUser User { get; set; }
    }
}
