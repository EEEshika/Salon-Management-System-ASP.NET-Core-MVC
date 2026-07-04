using DAL.EF;
using System.Linq;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class AppointmentRepo
    {
        SalonDbContext db;

        public AppointmentRepo(SalonDbContext db)
        {
            this.db = db;
        }

        public Appointment Create(Appointment a)
        {
            db.Appointments.Add(a);
            db.SaveChanges();

            return a;
        }

        public List<Appointment> Get()
        {
            return db.Appointments.ToList();
        }

        public Appointment Get(int id)
        {
            return db.Appointments.Find(id)!;
        }

        public bool Update(Appointment a)
        {
            var exobj = Get(a.Id);
            db.Entry(exobj).CurrentValues.SetValues(a);
            return db.SaveChanges() > 0;
        }




        public bool Delete(int id)
        {
            var exobj = Get(id);

            // Delete Payment first
            var payments = db.Payments
                             .Where(p => p.AppointmentId == id)
                             .ToList();

            foreach (var payment in payments)
            {
                db.Payments.Remove(payment);
            }

            // Delete Appointment Services
            var aps = db.AppointmentServices
                        .Where(a => a.AppointmentId == id)
                        .ToList();

            foreach (var item in aps)
            {
                db.AppointmentServices.Remove(item);
            }

            // Delete Appointment
            db.Appointments.Remove(exobj);

            return db.SaveChanges() > 0;
        }

        public bool AddService(AppointmentService aps)
        {
            db.AppointmentServices.Add(aps);
            return db.SaveChanges() > 0;
        }

        public List<Appointment> GetByCustomerId(int customerId)
        {
            return db.Appointments
                     .Where(a => a.CustomerId == customerId)
                     .ToList();
        }

        public List<Appointment> GetByStaffId(int staffId)
        {
            return db.Appointments
                     .Where(a => a.StaffId == staffId)
                     .ToList();
        }

        public bool UpdateStatus(int id, string status)
        {
            var exobj = db.Appointments.Find(id)!;
            exobj.Status = status;
            return db.SaveChanges() > 0;
        }

        public List<Appointment> GetByStaffIds(List<int> staffIds)
        {
            return db.Appointments
                     .Where(a => staffIds.Contains(a.StaffId))
                     .ToList();
        }

        public List<DAL.EF.Tables.AppointmentService> GetAppointmentServices(int appointmentId)
        {
            return db.AppointmentServices
                     .Where(a => a.AppointmentId == appointmentId)
                     .ToList();
        }
    }
}