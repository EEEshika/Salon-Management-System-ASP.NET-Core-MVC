using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class ServiceService
    {
        ServiceRepo repo;
        Mapper mapper;

        public ServiceService(ServiceRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }

        public bool Create(ServiceDTO data)
        {
            var service = mapper.Map<Service>(data);

            return repo.Create(service);
        }

        public List<ServiceDTO> Get()
        {
            var data = repo.Get();

            return mapper.Map<List<ServiceDTO>>(data);
        }

        public ServiceDTO Get(int id)
        {
            var data = repo.Get(id);

            return mapper.Map<ServiceDTO>(data);
        }

        public bool Update(ServiceDTO data)
        {
            var service = mapper.Map<Service>(data);

            return repo.Update(service);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
