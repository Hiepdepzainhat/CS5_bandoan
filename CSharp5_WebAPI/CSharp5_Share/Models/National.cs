using System.ComponentModel.DataAnnotations;

namespace CSharp5_Share.Models
{
    public class National
    {
        [Key]
        public Guid NationalID { get; set; }
        public string NationalName { get; set; }
    }
}
