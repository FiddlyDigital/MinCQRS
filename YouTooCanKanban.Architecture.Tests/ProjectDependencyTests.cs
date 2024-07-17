using System.Reflection;
using NetArchTest.Rules;

namespace YouTooCanKanban.Architecture.Tests
{
    public class ProjectDependencyTests
    {
        private const string ASSEMBLY_API = "YouTooCanKanban.API";
        private const string ASSEMBLY_APPLICATION = "YouTooCanKanban.Application";
        private const string ASSEMBLY_BLL = "YouTooCanKanban.BLL";
        private const string ASSEMBLY_DAL = "YouTooCanKanban.DAL";
        private const string ASSEMBLY_DOMAIN = "YouTooCanKanban.Domain";

        [Fact]
        public void DAL_Verify_ProjectDependencies()
        {
            Assembly DALAssembly = GetDALAssembly();

            TestResult testResult = Types.InAssembly(DALAssembly)
                .ShouldNot().HaveDependencyOnAll(
                    [ASSEMBLY_API, ASSEMBLY_APPLICATION, ASSEMBLY_BLL, ASSEMBLY_DOMAIN]
                ).GetResult();

            Assert.True(testResult.IsSuccessful);
        }

        private Assembly GetApplicationAssembly() 
        {
            return typeof(Application.Extensions.ServiceExtensions).Assembly;
        }

        private Assembly GetAPIAssembly() {
            return typeof(API.Extensions.ServiceExtensions).Assembly;
        }

        private Assembly GetBLLAssembly()
        {
            return typeof(BLL.Extensions.ServiceExtensions).Assembly;
        }

        private Assembly GetDALAssembly()
        {

            return typeof(DAL.Extensions.ServiceExtensions).Assembly;
        }

        private Assembly GetDomainAssembly() {
            return typeof(Domain.Models.Base.BaseModel).Assembly;
        }
        
    }
}