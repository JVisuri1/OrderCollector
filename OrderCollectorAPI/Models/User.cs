using System.Runtime.Serialization;

namespace OrderCollectorAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [IgnoreDataMember]
        public UserLogin Login { get; set; }
    }
}
