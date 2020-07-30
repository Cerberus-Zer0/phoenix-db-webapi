using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public byte[] Password { get; set; }
        [Required]
        public byte[] Salt { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string ProfileImage { get; set; }
    }
}