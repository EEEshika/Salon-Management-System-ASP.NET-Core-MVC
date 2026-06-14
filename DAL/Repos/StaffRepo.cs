using DAL.EF;
using System.Linq;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class StaffRepo
    {
        SalonDbContext db;

        public StaffRepo(SalonDbContext db)
        {
            this.db = db;
        }

        public bool Create(Staff s)
        {
            db.Staffs.Add(s);
            return db.SaveChanges() > 0;
        }

        public List<Staff> Get()
        {
            return db.Staffs.ToList();
        }

        public Staff Get(int id)
        {
            return db.Staffs.Find(id)!;
        }

        public Staff GetByUserId(int userId)
        {
            return db.Staffs
                     .Where(s => s.UserId == userId)
                     .FirstOrDefault()!;
        }

        public bool Update(Staff s)
        {
            var exobj = Get(s.Id);
            db.Entry(exobj).CurrentValues.SetValues(s);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var appointments = db.Appointments
                                 .Where(a => a.StaffId == id)
                                 .ToList();

            foreach (var appointment in appointments)
            {
                var appointmentServices = db.AppointmentServices
                                            .Where(a => a.AppointmentId == appointment.Id)
                                            .ToList();

                foreach (var aps in appointmentServices)
                {
                    db.AppointmentServices.Remove(aps);
                }

                db.Appointments.Remove(appointment);
            }

            var exobj = Get(id);
            db.Staffs.Remove(exobj);

            return db.SaveChanges() > 0;
        }




        public List<Staff> GetAllByUserId(int userId)
        {
            return db.Staffs
                     .Where(s => s.UserId == userId)
                     .ToList();
        }


    }
}