namespace WebAPI.Dtos
{
    public class InstitutionReadDto
    {
        public int Id { get; set; }

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

        public string ABN { get; set; }
        public string RTOProvider { get; set; }
        public string CRICOSCode { get; set; }

        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }
        public string Instagram { get; set; }
        public string LinkedIn { get; set; }
    }
}