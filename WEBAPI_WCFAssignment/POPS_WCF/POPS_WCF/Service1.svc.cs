using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace POPS_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public IEnumerable<SUPPLIER> GetAllSuppliers()
        {
            using (PODbEntities1 context = new PODbEntities1())
            {
                return context.SUPPLIERs.ToList();
            }
        }
        public SUPPLIER GetSupplier(string id)
        {
            using (PODbEntities1 context = new PODbEntities1())
            {
                var ProductSupplier = (from s
                                   in context.SUPPLIERs
                                       where s.SUPLNO.Equals(id)
                                       select s).FirstOrDefault();
                if (ProductSupplier != null)
                    return ProductSupplier;
                else
                    throw new Exception("Invalid Supplier Number");
            }

        }
        public void AddSupplier(SUPPLIER item)
        {
            try
            {
                using (PODbEntities1 context = new PODbEntities1())
                {
                    context.SUPPLIERs.Add(item);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }
        public void UpdateSupplier(SUPPLIER item)
        {
            using (PODbEntities1 context = new PODbEntities1())
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void DeleteSupplier(string id)
        {
            using (PODbEntities1 context = new PODbEntities1())
            {
                context.SUPPLIERs.Remove(
                    context.SUPPLIERs.Where(e => e.SUPLNO == id).FirstOrDefault());
                context.SaveChanges();
            }
        }
    }
}
