namespace CQRS_Service.Domain.Exceptions.Users
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(): base("User not found!")
        {
            
        }
    }
}
