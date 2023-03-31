﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<List<Customer>> GetAll();
        Task<Customer> GetById(int Id);
        Task Create(Customer model);
        Task Update(Customer model);
        Task Delete(int id);
    }
}
