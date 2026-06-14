using DAL.EF;
using DAL.EF.Tables;

namespace DAL.Repos
{
    public class CustomerRepo
    {
        SalonDbContext db;

        public CustomerRepo(SalonDbContext db)
        {
            this.db = db;
        }

        public List<Customer> Get()
        {
            return db.Customers.ToList();
        }

        public Customer Get(int id)
        {
            return db.Customers.Find(id)!;
        }

        public Customer GetByUserId(int userId)
        {
            return db.Customers
                     .Where(c => c.UserId == userId)
                     .FirstOrDefault()!;
        }

        public bool Create(Customer c)
        {
            db.Customers.Add(c);
            return db.SaveChanges() > 0;
        }

        public bool Update(Customer c)
        {
            var exobj = Get(c.Id);
            db.Entry(exobj).CurrentValues.SetValues(c);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Customers.Remove(exobj);
            return db.SaveChanges() > 0;
        }
    }
}