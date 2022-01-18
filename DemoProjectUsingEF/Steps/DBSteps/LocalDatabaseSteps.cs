using BoDi;
using DemoProjectUsingEF.DataBases.LocalDatabase;
using TechTalk.SpecFlow;

namespace DemoProjectUsingEF.Steps.DBSteps
{
    [Binding]
    public sealed class LocalDatabaseSteps
    {

        private IObjectContainer _objectContainer;
        private readonly LocalDbContext _dbContext;

        public LocalDatabaseSteps(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            // var imsServiceProvider = objectContainer.Resolve<IServiceProvider>("imsServiceProvider");
            //  _dbContext = imsServiceProvider.GetService<ImsDbContext>();

        }

        [Given(@"I add '(.*)' user where '(.*)' is age and '(.*)' is Id")]
        public void GivenIAddUserWhereIsAgeAndIsId(string Username, int age, int Id)
        {
            _dbContext.Users.AddRange(new Models.User { Name = Username, Age = age, Id = Id });
            _dbContext.SaveChanges();
        }

    }
}
