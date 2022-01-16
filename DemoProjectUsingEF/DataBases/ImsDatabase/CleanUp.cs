using Microsoft.EntityFrameworkCore;

namespace DemoProjectUsingEF.DataBases.ImsDatabase
{
    public static class CleanUp
    {
        public static void Clean(ImsContext _dbContext)
        {
            _dbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Roles] WHERE Predefined = 0;");
            _dbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Users] WHERE UserName != 'admin';");
            _dbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[LdapSettings]");
            _dbContext.SaveChanges();
        }

    }
}
