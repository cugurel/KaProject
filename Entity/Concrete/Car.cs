using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Car:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Announcement { get; set; }
        public DateTime AnnouncementDate { get; set; }
        public string Brand { get; set; }
        public string? Serial { get; set; }
        public string Model { get; set; }
        public string? Year { get; set; }
        public string? Fuel { get; set; }
        public string? Gear { get; set; }
        public string? Km { get; set; }
        public string? Price { get; set; }
        public int CategoryId { get; set; }
    }
}
