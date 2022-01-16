using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DemoProjectUsingEF.DataBases.HubDatabase
{
    public static class CleanUp
    {
        public static void Clean(HubContext _dbContext)
        {
            foreach (var dbEntityEntry in _dbContext.ChangeTracker.Entries().ToArray())
            {
                if (dbEntityEntry.Entity != null) dbEntityEntry.State = EntityState.Detached;
            }

            _dbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[StepAction]");
            _dbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[StepEmail]");
            _dbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[StepDecision]");
            _dbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[DecisionChoice]");
            _dbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[ObjectBasedStep]");
            _dbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Applications]");
            _dbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Roles] WHERE Predefined = 0;");

            
            _dbContext.Database.ExecuteSqlRaw("DELETE FROM [layouts].[Table] WHERE Name = 'Audit';");
            _dbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Wireframes]");
            _dbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[WireframeObjects]");

            _dbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Users] WHERE UserName != 'admin';");
            _dbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[ProcessDefinition]");
            _dbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[BusinessProcessForm]");
            _dbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[BusinessProcesses]");
            _dbContext.SaveChanges();
        }

    }
}
