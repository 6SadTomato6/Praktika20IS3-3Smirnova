namespace SmirnovaPR5._1.Contracts.User
{
    public class GetUserResponse
    {
        public int CustomerId { get; set; }
        public string CustomerFname { get; set; }
        public string CustomerLname { get; set; }
        public string CustomerEmail { get; set; }
        public string Role { get; set; }
    }
}
