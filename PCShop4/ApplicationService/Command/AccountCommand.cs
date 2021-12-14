using Infrastructure.Exceptions;

namespace ApplicationService.Command
{
    public class AccountCommand : CommandBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public override void Validate()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                throw new InvalidUserException();
        }
    }
}