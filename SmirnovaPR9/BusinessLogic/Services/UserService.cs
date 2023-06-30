using Domain.Models;
using Domain.Interfaces;
using Domain.Wrapper;
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
        public async Task<List<Customer>> GetAll()
        {
            return await _repositoryWrapper.User.FindAll();
        }
        public async Task<Customer> GetById(int id)
        {
            var user = await _repositoryWrapper.User
            .FindByCondition(x => x.CustomerId == id);
            return user.First();
        }
        public async Task Create(Customer model)
        {
            if(model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.CustomerFname))
            {
                throw new ArgumentException(nameof(model.CustomerFname));
            }
            await _repositoryWrapper.User.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Customer model)
        {
           await  _repositoryWrapper.User.Update(model);
           await  _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.User
            .FindByCondition(x => x.CustomerId == id);

            await _repositoryWrapper.User.Delete(user.First());
            await _repositoryWrapper.Save();
        }
    }
}

