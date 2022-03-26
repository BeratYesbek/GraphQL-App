using System.ComponentModel.DataAnnotations;

namespace CommanderGraphQL.Models
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        // [GraphQLDescription("Represents a purchase, valid license for the platform")]
        public string LicenseKey { get; set; }

        public ICollection<Command> Commands { get; set; } = new List<Command>();
    }
}