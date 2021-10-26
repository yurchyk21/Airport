using Airport.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Data.Entities
{
    [Table("Flight")]
    public class Flight
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.FlightNumberMaxLength)]
        public string Number { get; set; }

        [Required]
        [StringLength(ValidationConstants.CityNameMaxLength)]
        public string DepartureFrom { get; set; }

        [Required]
        [StringLength(ValidationConstants.CityNameMaxLength)]
        public string ArrivalTo { get; set; }

        [Required]
        public DateTime DepartureDate { get; set; }

        [Required]
        public DateTime ArrivalDate { get; set; }

        public virtual ICollection<FlightTicket> FlightTickets { get; set; }

    }
}
