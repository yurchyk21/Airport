using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Data.Entities
{
    [Table("FlightTicket")]
    public class FlightTicket
    {
        [Key]
        public int Id { get; set; }

        public int TicketId { get; set; }
        [ForeignKey("TicketId")]
        public virtual Ticket Ticket { get; set; }

        public int FlightId { get; set; }
        [ForeignKey("FlightId")]
        public virtual Flight Flight{ get; set; }

    }
}
