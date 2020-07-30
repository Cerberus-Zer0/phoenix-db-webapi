using System.ComponentModel.DataAnnotations;

namespace WebAPI.Dtos
{
    public class InstitutionUpdateDto
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public string Logo { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public string Postcode { get; set; }
        public string Country { get; set; }

        public string Website { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        [MaxLength(11)]
        public string ABN { get; set; }
        [MaxLength(5)]
        public string RTOProvider { get; set; }
        [MaxLength(6)]
        public string CRICOSCode { get; set; }

        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }
        public string Instagram { get; set; }
        public string LinkedIn { get; set; }
    }
}