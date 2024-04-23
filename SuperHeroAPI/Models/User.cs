using System.ComponentModel.DataAnnotations;

namespace SuperheroAPI.Models
{
    public class User
    {
        [Key]
        public string UserId { get; set; }
        public string Username { get; set; }

        // Add other user related properties as needed in the Future
    }
}
