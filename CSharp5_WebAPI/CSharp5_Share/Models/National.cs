namespace CSharp5_Share.Models
{
    public class National
    {
        public Guid NationalID { get; set; }
        public string NationalName { get; set; }
        public virtual IEnumerable<User> Users { get; set; }
    }
}
