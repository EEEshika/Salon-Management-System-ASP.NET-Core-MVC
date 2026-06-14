using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class MapperConfig

    {
        public static MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Customer, CustomerDTO>().ReverseMap();
            cfg.CreateMap<User, UserDTO>().ReverseMap();
            cfg.CreateMap<User, RegisterDTO>().ReverseMap();
            cfg.CreateMap<Service, ServiceDTO>().ReverseMap();
            cfg.CreateMap<Staff, StaffDTO>().ReverseMap();
            cfg.CreateMap<Appointment, AppointmentDTO>().ReverseMap();
            cfg.CreateMap<Payment, PaymentDTO>().ReverseMap();
        });


        public static Mapper GetMapper()
        {
            return new Mapper(config);

        }
    }
}
