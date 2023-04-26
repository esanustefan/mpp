using System;
using baschet.domain;

namespace baschet.repo;

public interface IUserRepository : IRepository<int, User>
{ 
    Boolean CheckifUserExists(string username, string password);

}