using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;

namespace BLL.Services
{
    public class StaffService
    {
        StaffRepo repo;
        Mapper mapper;

        public StaffService(StaffRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }

        public bool Create(StaffDTO data)
        {
            var staff = mapper.Map<Staff>(data);
            return repo.Create(staff);
        }

        public List<StaffDTO> Get()
        {
            var data = repo.Get();
            return mapper.Map<List<StaffDTO>>(data);
        }

        public StaffDTO Get(int id)
        {
            var data = repo.Get(id);
            return mapper.Map<StaffDTO>(data);
        }

        public StaffDTO GetByUserId(int userId)
        {
            var data = repo.GetByUserId(userId);
            return mapper.Map<StaffDTO>(data);
        }

        public bool Update(StaffDTO data)
        {
            var staff = mapper.Map<Staff>(data);
            return repo.Update(staff);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }


        public List<StaffDTO> GetAllByUserId(int userId)
        {
            var data = repo.GetAllByUserId(userId);
            return mapper.Map<List<StaffDTO>>(data);
        }
    }
}