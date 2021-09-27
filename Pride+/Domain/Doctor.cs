using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pride_.Domain
{
    public class Doctor
    {
        [Key]
        public string CRM { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Speciality { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string SocialMedia { get; set; }
        public string HealthInsurance { get; set; }
    }
}
