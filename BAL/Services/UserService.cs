using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class UserService
    {
        UserRepo repo;
        CustomerRepo customerRepo;

        Mapper mapper;

        public UserService(UserRepo repo, CustomerRepo customerRepo)
        {
            this.repo = repo;

            this.customerRepo = customerRepo;

            mapper = MapperConfig.GetMapper();
        }

        public UserDTO Login(LoginDTO data)  //
        {
            var res = repo.Login(data.Username, data.Password);

            var user = mapper.Map<UserDTO>(res);

            return user;
        }

        public void Register(RegisterDTO data)
        {
            var user = mapper.Map<User>(data);

            user.Type = 3;

            var savedUser = repo.Register(user);

            var customer = new Customer()
            {
                Name = data.Name,
                Phone = data.Phone,
                Email = data.Email,
                UserId = savedUser.Id
            };

            customerRepo.Create(customer);
        }
    }
}
