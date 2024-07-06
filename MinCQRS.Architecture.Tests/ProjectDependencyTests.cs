using System.Reflection;
using NetArchTest.Rules;

namespace MinCQRS.Architecture.Tests
{
    public class ProjectDependencyTests
    {
        private const string ASSEMBLY_API = "MinCQRS.API";
        private const string ASSEMBLY_APPLICATION = "MinCQRS.Application";
        private const string ASSEMBLY_BLL = "MinCQRS.BLL";
        private const string ASSEMBLY_DAL = "MinCQRS.DAL";
        private const string ASSEMBLY_DOMAIN = "MinCQRS.Domain";

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
            return typeof(Domain.Extensions.MappingExtensions).Assembly;
        }
        
    }
}