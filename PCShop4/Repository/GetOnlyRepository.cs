using System.Collections.Generic;
using DomainModel;
using Repository.Database;

namespace Repository
{
    public class GetOnlyRepository
    {
        public DatabaseTable DatabaseTable { get; } = DatabaseTable.GetInstance();
        public List<User> UsersList()
        {
            return DatabaseTable.UsersList;
        }
    }
}