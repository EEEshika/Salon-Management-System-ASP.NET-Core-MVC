using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class CustomerService
    {
        CustomerRepo repo;
        Mapper mapper;
        
        public CustomerService(CustomerRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }

        public List<CustomerDTO> Get()
        {
            var data = repo.Get();
            var res = mapper.Map<List<CustomerDTO>>(data);
            return res;
        }

        public bool Create(CustomerDTO c)
        {
            var data = mapper.Map<Customer>(c);
            var res = repo.Create(data);
            return res;
        }

        public bool Update(CustomerDTO c)
        {
            var data = mapper.Map<Customer>(c);
            var res = repo.Update(data);
            return res;
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }

        public CustomerDTO GetByUserId(int userId)
        {
            var data = repo.GetByUserId(userId);

            var res = mapper.Map<CustomerDTO>(data);

            return res;
        }

    }
}
