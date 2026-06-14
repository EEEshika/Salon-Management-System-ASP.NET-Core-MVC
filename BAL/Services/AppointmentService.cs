using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class AppointmentService
    {
        AppointmentRepo repo;
        ServiceRepo serviceRepo;
        CustomerRepo customerRepo;
        StaffRepo staffRepo;
        Mapper mapper;

        public AppointmentService(AppointmentRepo repo, ServiceRepo serviceRepo, CustomerRepo customerRepo, StaffRepo staffRepo)
        {
            this.repo = repo;
            this.serviceRepo = serviceRepo;
            this.customerRepo = customerRepo;
            this.staffRepo = staffRepo;

            mapper = MapperConfig.GetMapper();
        }

        public bool Create(AppointmentDTO data)
        {
            Appointment appointment = new Appointment();

            appointment.CustomerId = data.CustomerId;
            appointment.StaffId = data.StaffId;
            appointment.AppointmentDate = data.AppointmentDate;
            appointment.Status = data.Status;
            appointment.Notes = data.Notes;

            var savedAppointment = repo.Create(appointment);

            var service = serviceRepo.Get(data.ServiceId);

            var aps = new DAL.EF.Tables.AppointmentService()
            {
                AppointmentId = savedAppointment.Id,
                ServiceId = data.ServiceId,
                Price = service.Price
            };

            return repo.AddService(aps);
        }



        public AppointmentDTO Get(int id)
        {
            var data = repo.Get(id);

            return mapper.Map<AppointmentDTO>(data);
        }

        public bool Update(AppointmentDTO data)
        {
            var appointment = mapper.Map<Appointment>(data);

            return repo.Update(appointment);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }


        public List<AppointmentDTO> GetByCustomerId(int customerId)
        {
            var data = repo.GetByCustomerId(customerId);

            var appointments = mapper.Map<List<AppointmentDTO>>(data);

            foreach (var item in appointments)
            {
                var staff = staffRepo.Get(item.StaffId);

                item.StaffName = staff.Name;

                var aps = repo.GetAppointmentServices(item.Id).FirstOrDefault();

                if (aps != null)
                {
                    var service = serviceRepo.Get(aps.ServiceId);
                    item.ServiceName = service.Name;
                }
            }

            return appointments;
        }


      

        public bool UpdateStatus(int id, string status)
        {
            return repo.UpdateStatus(id, status);
        }


        public List<AppointmentDTO> GetByStaffIds(List<int> staffIds)
        {
            var data = repo.GetByStaffIds(staffIds);
            var appointments = mapper.Map<List<AppointmentDTO>>(data);

            foreach (var item in appointments)
            {
                var customer = customerRepo.Get(item.CustomerId);
                var staff = staffRepo.Get(item.StaffId);
                var aps = repo.GetAppointmentServices(item.Id).FirstOrDefault();

                item.CustomerName = customer.Name;
                item.StaffName = staff.Name;

                if (aps != null)
                {
                    var service = serviceRepo.Get(aps.ServiceId);
                    item.ServiceName = service.Name;
                }
            }

            return appointments;
        }


        public List<AppointmentDTO> Get()
        {
            var data = repo.Get();
            var appointments = mapper.Map<List<AppointmentDTO>>(data);

            foreach (var item in appointments)
            {
                var customer = customerRepo.Get(item.CustomerId);
                var staff = staffRepo.Get(item.StaffId);
                var aps = repo.GetAppointmentServices(item.Id).FirstOrDefault();

                item.CustomerName = customer.Name;
                item.StaffName = staff.Name;

                if (aps != null)
                {
                    var service = serviceRepo.Get(aps.ServiceId);
                    item.ServiceName = service.Name;
                }
            }

            return appointments;
        }



    }
}