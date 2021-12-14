using System.Linq;
using DomainModel;
using Infrastructure.Exceptions;

namespace Repository.Verifications
{
    public class AccountVerification
    {
        public User User { get; set; }
        public AccountVerification(User user)
        {
            User = user;
        }
        public bool UserVerification()
        {
            var repository = new GetOnlyRepository();
            var users = repository.DatabaseTable.UsersList;
            if (!users.Any(i => i.Username == User.Username && i.Password == User.Password))
                throw new InvalidUserDbException();
            return true;
        }
    }
}
