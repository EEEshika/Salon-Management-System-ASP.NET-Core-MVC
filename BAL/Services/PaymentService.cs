using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;

namespace BLL.Services
{
    public class PaymentService
    {
        PaymentRepo repo;
        AppointmentRepo appointmentRepo;
        Mapper mapper;

        public PaymentService(PaymentRepo repo, AppointmentRepo appointmentRepo)
        {
            this.repo = repo;
            this.appointmentRepo = appointmentRepo;

            mapper = MapperConfig.GetMapper();
        }

        public bool Create(PaymentDTO data)
        {
            var payment = mapper.Map<Payment>(data);

            payment.PaymentDate = DateTime.Now;

            return repo.Create(payment);
        }

        public List<PaymentDTO> Get()
        {
            var data = repo.Get();

            return mapper.Map<List<PaymentDTO>>(data);
        }

        public List<PaymentDTO> GetByAppointmentId(int appointmentId)
        {
            var data = repo.GetByAppointmentId(appointmentId);

            return mapper.Map<List<PaymentDTO>>(data);
        }
    }
}