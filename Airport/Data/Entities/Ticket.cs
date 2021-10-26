using Airport.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Data.Entities
{
    [Table("Ticket")]

    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.TicketNumberMaxLength)]
        public string Number { get; set; }

        [Required]
        [StringLength(ValidationConstants.PassengerFullNameMaxLength)]
        public string PassengerFullName { get; set; }

        [Required]
        [StringLength(ValidationConstants.PassengerPassportMaxLength)]
        public string PassengerPassport { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [StringLength(ValidationConstants.PlaceNumberMaxLength)]
        public string Place { get; set; }

        [Required]
        public DateTime BuyDate { get; set; }
        
        [Required]
        public bool IsActive { get; set; }

        public virtual FlightTicket FlightTicket { get; set; }

    }
}
