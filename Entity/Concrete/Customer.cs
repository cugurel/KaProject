﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public int CityId { get; set; }
        public int TownId { get; set; }
        public string Gender { get; set; }
        public string? FileUrl { get; set; }

        [NotMapped]
        public List<IFormFile> File { get; set; }
    }
}