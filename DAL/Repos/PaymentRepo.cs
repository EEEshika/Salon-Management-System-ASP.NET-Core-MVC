using DAL.EF;
using DAL.EF.Tables;

namespace DAL.Repos
{
    public class PaymentRepo
    {
        SalonDbContext db;

        public PaymentRepo(SalonDbContext db)
        {
            this.db = db;
        }

        public bool Create(Payment p)
        {
            db.Payments.Add(p);
            return db.SaveChanges() > 0;
        }

        public List<Payment> Get()
        {
            return db.Payments.ToList();
        }

        public Payment Get(int id)
        {
            return db.Payments.Find(id)!;
        }

        public List<Payment> GetByAppointmentId(int appointmentId)
        {
            return db.Payments
                     .Where(p => p.AppointmentId == appointmentId)
                     .ToList();
        }
    }
}