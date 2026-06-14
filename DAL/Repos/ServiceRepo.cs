using DAL.EF;
using DAL.EF.Tables;

namespace DAL.Repos
{
    public class ServiceRepo
    {
        SalonDbContext db;

        public ServiceRepo(SalonDbContext db)
        {
            this.db = db;
        }

        public List<Service> Get()
        {
            return db.Services.ToList();
        }

        public Service Get(int id)
        {
            return db.Services.Find(id)!;
        }

        public bool Create(Service s)
        {
            db.Services.Add(s);
            return db.SaveChanges() > 0;
        }

        public bool Update(Service s)
        {
            var exobj = Get(s.Id);
            db.Entry(exobj).CurrentValues.SetValues(s);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);

            var appointmentServices = db.AppointmentServices
                                        .Where(a => a.ServiceId == id)
                                        .ToList();

            foreach (var aps in appointmentServices)
            {
                db.AppointmentServices.Remove(aps);
            }

            db.Services.Remove(exobj);

            return db.SaveChanges() > 0;
        }
    }
}