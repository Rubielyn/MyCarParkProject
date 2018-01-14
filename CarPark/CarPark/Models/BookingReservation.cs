using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CarPark.Models
{
    public class BookingReservation
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string AreaCode { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
    }

    public class CarParkDBContext : DbContext
    {
        public DbSet<BookingReservation> Bookings { get; set; }
    }



}