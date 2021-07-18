namespace API.DTOs
{
    public class UserDto
    {
        //object that we're returning when user logs in (or registered)
        public string Username { get; set; }
        public string Token { get; set; }
    }
}