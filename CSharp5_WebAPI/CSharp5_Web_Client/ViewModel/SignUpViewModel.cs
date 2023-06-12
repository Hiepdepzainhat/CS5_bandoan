namespace CSharp5_Web_Client.ViewModel
{
    public class SignUpViewModel
    {
        public Guid UserID { get; set; }
        public Guid? NationalID { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? PassWord { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Sex { get; set; }
        public string? ImgUser { get; set; }
    }
}
