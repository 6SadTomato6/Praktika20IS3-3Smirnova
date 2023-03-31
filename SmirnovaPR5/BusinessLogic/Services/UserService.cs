using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public Task<List<Customer>> GetAll()
        {
            return _repositoryWrapper.User.FindAll().ToListAsync();
        }
        public Task<Customer> GetById(int id)
        {
            var user = _repositoryWrapper.User
            .FindByCondition(x => x.CustomerId == id).First();
            return Task.FromResult(user);
        }
        public Task Create(Customer model)
        {
            _repositoryWrapper.User.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
        public Task Update(Customer model)
        {
            _repositoryWrapper.User.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
        public Task Delete(int id)
        {
            var user = _repositoryWrapper.User
            .FindByCondition(x => x.CustomerId == id).First();
            _repositoryWrapper.User.Delete(user);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}

