using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RepositoryBase
{
    public class UserRepository : RepositoryBase<Customer>, IUserRepository
    {
        public UserRepository(SHOPContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
