using System.ComponentModel.DataAnnotations;

namespace CSharp5_Share.Models
{
    public class Producer
    {
        [Key]
        public Guid ProducerID { get; set; }
        public string? ProducerName { get; set; }
        public string? Description { get; set; }
    }
}
