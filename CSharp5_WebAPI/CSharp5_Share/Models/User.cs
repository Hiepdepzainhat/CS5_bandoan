namespace CSharp5_Share.Models
{
    public class User
    {
        public Guid UserID { get; set; }
        public Guid RoleID { get; set; }
        public Guid NationalID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Sex { get; set; }
        public string ImgUser { get; set; }
        public virtual Role Role { get; set; }
        public virtual National National { get; set; }
        public virtual IEnumerable<Bill> Bills { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
