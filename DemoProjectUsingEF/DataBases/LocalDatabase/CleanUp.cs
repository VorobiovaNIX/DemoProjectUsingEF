using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProjectUsingEF.DataBases.LocalDatabase
{
    public static class CleanUp
    {
        public static void Clean(LocalDbContext _dbContext)
        {
            _dbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Users] WHERE UserName != 'admin';");
            _dbContext.SaveChanges();
        }
    }
}
