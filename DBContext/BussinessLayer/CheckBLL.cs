using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCNDBContext.BussinessEntity;
using FCNDBContext.DataAccessLayer;

namespace FCNDBContext.BussinessLayer
{
    public class CheckBLL
    {
        public int Insert(Check check)
        {
            using (FCNDBContext.DataAccessLayer.FCNDBContext context = new FCNDBContext.DataAccessLayer.FCNDBContext("SQLServerDBString"))
            {
                return Insert(check, context);
            }

        }
        public int Insert(Check check, FCNDBContext.DataAccessLayer.FCNDBContext context)
        {
            if (context == null) { return -1; }
            context.PDFCheck.Add(check);
            try
            {
                int amount = context.SaveChanges();

                return amount;

            }
            catch (Exception ex)
            {
                return -1;
            }


        }
        public int Insert(string CheckDir,FCNDBContext.DataAccessLayer.FCNDBContext context)
        {
            if (context == null) { return -1; }
            Check check = new Check();
            check.CreateDate = System.DateTime.Now;
            check.CheckDirectory = CheckDir;
            check.Name = System.DateTime.Now.ToString("yyyyMMdd_HHmmdd.sss");
            return Insert(check,context);
            


        }
        public int GetSequence()
        {
            using (FCNDBContext.DataAccessLayer.FCNDBContext context = new FCNDBContext.DataAccessLayer.FCNDBContext("SQLServerDBString"))
            {
                return GetSequence( context);
            }
        }
        public int GetSequence(FCNDBContext.DataAccessLayer.FCNDBContext context)
        {
            try { 
                int maxId = context.Set<Check>().Max(p=>p.ID);
                return maxId;
            }
            catch
            {
                return -1;
            }

        }
        public Check GetCheckByID(int checkId, FCNDBContext.DataAccessLayer.FCNDBContext context)
        {
            return context.Set<Check>().First(item => (item.ID == checkId));
        }
        public Check GetCheckByName(string name, FCNDBContext.DataAccessLayer.FCNDBContext context)
        {
            return context.Set<Check>().First(item => (item.Name == name));
        }

        public bool Update(Check check, FCNDBContext.DataAccessLayer.FCNDBContext context)
        {
            if (context == null) { return false; }
            check.CreateDate = DateTime.Now;// no effect, but måste do it
            context.PDFCheck.Attach(check);

            context.Entry(check).Property(p => p.CheckDirectory).IsModified = true;
            context.Entry(check).Property(p => p.Total).IsModified = true;
            context.Entry(check).Property(p => p.Valid).IsModified = true;
            context.Entry(check).Property(p => p.Invalid).IsModified = true;
            return SaveChange(context);
        }
        public bool SaveChange(FCNDBContext.DataAccessLayer.FCNDBContext context)
        {
            if (context == null) { return false; }
            try
            {
                int amount = context.SaveChanges();
                if (amount >= 1)
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
            }

            return false;

        }
    }
}

    