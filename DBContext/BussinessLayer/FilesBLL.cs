using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCNDBContext.BussinessEntity;
using FCNDBContext.DataAccessLayer;

namespace FCNDBContext.BussinessLayer
{
    public class FilesBLL
    {
        public bool Insert(Files file)
        {
            using (FCNDBContext.DataAccessLayer.FCNDBContext context = new FCNDBContext.DataAccessLayer.FCNDBContext("SQLServerDBString"))
            {
                return Insert(file, context);
            }

        }
        public  bool Insert(Files file, FCNDBContext.DataAccessLayer.FCNDBContext context)
        {
            if (context == null) { return false; }
            context.PDFFiles.Add(file);
            try
            {
                int amount = context.SaveChanges();
                if (amount == 1)
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
        public bool InsertWithoutCommit(Files file, FCNDBContext.DataAccessLayer.FCNDBContext context)
        {
            try
            {
                if (context == null) { return false; }
                context.PDFFiles.Add(file);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> SaveChangeAsync(FCNDBContext.DataAccessLayer.FCNDBContext context)
        {
            if (context == null) { return false; }
            try
            {
                int amount = await context.SaveChangesAsync();
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
        public bool Update(Files file)
        {
            using (FCNDBContext.DataAccessLayer.FCNDBContext context = new FCNDBContext.DataAccessLayer.FCNDBContext("SQLServerDBString"))
            {
                return Update(file, context);
            }

        }
        public bool Update(Files file, FCNDBContext.DataAccessLayer.FCNDBContext context)
        {
            if (context == null) { return false; }
            context.PDFFiles.Attach(file);
            context.Entry(file).Property(p => p.ModifyDate).IsModified = true;
            context.Entry(file).Property(p => p.Size).IsModified = true;
            context.Entry(file).Property(p => p.Size_Abbreviation).IsModified = true;
            context.Entry(file).Property(p => p.IsValid).IsModified = true;
            try
            {
                int amount = context.SaveChanges();
                if (amount == 1)
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
        public bool UpdateWithoutCommit(Files file, FCNDBContext.DataAccessLayer.FCNDBContext context)
        {
            if (context == null) { return false; }
            context.PDFFiles.Attach(file);
            context.Entry(file).Property(p => p.ModifyDate).IsModified = true;
            context.Entry(file).Property(p => p.Size).IsModified = true;
            context.Entry(file).Property(p => p.Size_Abbreviation).IsModified = true;
            context.Entry(file).Property(p => p.IsValid).IsModified = true;
            return true;
        }
        public async Task<bool> UpdateAsync(Files file)
        {
            using (FCNDBContext.DataAccessLayer.FCNDBContext context = new FCNDBContext.DataAccessLayer.FCNDBContext("SQLServerDBString"))
            {
                return await UpdateAsync(file, context);
            }

        }
        public async Task<bool> UpdateAsync(Files file, FCNDBContext.DataAccessLayer.FCNDBContext context)
        {
            if (context == null) { return false; }
            context.PDFFiles.Attach(file);
            try
            {
                int amount = await context.SaveChangesAsync();
                if (amount == 1)
                {
                    return true;
                }

            }
            catch
            {
                return false;
            }

            return false;
        }

        public Files GetFileByFullName(int CheckID,string FullName, FCNDBContext.DataAccessLayer.FCNDBContext context)
        {
            return context.Set<Files>().First(item => item.FileFullName == FullName && item.CheckID == CheckID);
        }
        //public Files GetFilebByOriginal(string mainFolder, string filename, string extenison, int size)
        //{
        //    using (FCNDBContext.DataAccessLayer.FCNDBContext context = new FCNDBContext.DataAccessLayer.FCNDBContext("SQLServerDBString"))
        //    {
        //        return GetFilebByOriginal(mainFolder, filename, extenison, size, context);
        //    }
        //}

        //public Files GetFilebByOriginal(string mainFolder, string filename, string extenison, int size, FCNDBContext.DataAccessLayer.FCNDBContext context)
        //{
        //    List<Files> result = context.Set<Files>().Where(item => (item.OriginalFileName.ToLower().Trim() == filename.ToLower().Trim())
        //    && (item.OrigianlSize == size)
        //    && (item.MainFolder == mainFolder)
        //    && (item.OriginalExtension.ToLower().Trim() == extenison.ToLower().Trim())
        //    ).ToList();
        //    if (result.Count() >= 1)
        //    {
        //        return result[0];
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}


        //public Files GetFilebByOutput(string mainFolder, string filename, string extenison, int size)
        //{
        //    using (FCNDBContext.DataAccessLayer.FCNDBContext context = new FCNDBContext.DataAccessLayer.FCNDBContext("SQLServerDBString"))
        //    {
        //        return GetFilebByOutput(mainFolder, filename, extenison, size, context);
        //    }
        //}

        //public Files GetFilebByOutput(string mainFolder, string filename, string extenison, int size, FCNDBContext.DataAccessLayer.FCNDBContext context)
        //{
        //    List<Files> result = context.Set<Files>().Where(item => (item.OutputFileName.ToLower().Trim() == filename.ToLower().Trim())
        //    && (item.OutputSize == size)
        //    && (item.MainFolder == mainFolder)
        //    && (item.OutputExtension.ToLower().Trim() == extenison.ToLower().Trim())
        //    ).ToList();
        //    if (result.Count() >= 1)
        //    {
        //        return result[0];
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public System.Linq.IQueryable<Files> GetInvalidFilesBySequenceId(int[] Ids, FCNDBContext.DataAccessLayer.FCNDBContext context)
        //{
        //    if (context == null) { return null; }
        //    if (Ids == null) { return null; }
        //    if (Ids.Length == 0) { return null; }
        //    try
        //    {
        //        System.Linq.IQueryable<Files> result = context.Set<Files>().Where(item => ((Ids.Contains(item.SequenceID)) && (item.IsValid == false) ));
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }


        //}
    }
}
