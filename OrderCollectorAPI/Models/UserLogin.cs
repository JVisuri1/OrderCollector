using System.ComponentModel.DataAnnotations.Schema;

namespace OrderCollectorAPI.Models
{
    public class UserLogin
    {
        public int Id { get; set; }
        public string EncryptedPassword { get; set; }
        public string Salt { get; set; }
        [ForeignKey("users")]
        public int UserId { get; set; }
    }
}