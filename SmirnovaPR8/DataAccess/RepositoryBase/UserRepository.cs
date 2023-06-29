using Domain.Models;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RepositoryBase
{
    public class UserRepository : RepositoryBase<Customer>, Domain.Interfaces.IUserRepository
    {
        public UserRepository(SHOPContext repositoryContext): base(repositoryContext)
        {
        }
    }
}
