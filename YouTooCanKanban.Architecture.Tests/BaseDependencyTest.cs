using System.Reflection;
using NetArchTest.Rules;
using Xunit.Abstractions;

namespace YouTooCanKanban.Architecture.Tests
{
    public abstract class BaseDependencyTest
    {
        private readonly ITestOutputHelper OutputHelper;

        protected static readonly Assembly ApiAssembly = typeof(API.Extensions.ServiceExtensions).Assembly;
        protected static readonly Assembly ApiClientAssembly = typeof(API.Client.Extensions.ServiceExtensions).Assembly;
        protected static readonly Assembly ApplicationAssembly = typeof(Application.Extensions.ServiceExtensions).Assembly;
        protected static readonly Assembly BLLAssembly = typeof(BLL.Extensions.ServiceExtensions).Assembly;
        protected static readonly Assembly DALAssembly = typeof(DAL.Extensions.ServiceExtensions).Assembly;
        protected static readonly Assembly DomainAssembly = typeof(Domain.Models.Base.BaseModel).Assembly;
        protected static readonly Assembly UIAssembly = typeof(WASMUI.Program).Assembly;

        protected readonly Assembly assemblyUnderTest;
        protected readonly string[] ShouldHaveDependencies;
        protected readonly string[] MustNotHaveDependencies;

        protected BaseDependencyTest(
            Assembly testingAssembly,
            string[]? shouldHaveDependencies,
            string[]? mustNotHaveDependencies,
            ITestOutputHelper outputHelper)
        {
            assemblyUnderTest = testingAssembly;
            ShouldHaveDependencies = shouldHaveDependencies ?? Array.Empty<string>();
            MustNotHaveDependencies = mustNotHaveDependencies ?? Array.Empty<string>();
            OutputHelper = outputHelper;
        }

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        [Fact]
        public void ShouldHaveRequiredAssemblies()
        {
            bool importsAllRequiredAssembles = true;
            string assemblyUnderTestName = assemblyUnderTest.GetName().Name;
            Types assemblyTypes = Types.InAssembly(assemblyUnderTest);

            foreach (var asmblyName in ShouldHaveDependencies)
            {
                var hasDependencyResult = assemblyTypes.Should().HaveDependencyOn(asmblyName).GetResult();
                if (!hasDependencyResult.IsSuccessful)
                {
                    importsAllRequiredAssembles = false;
                    OutputHelper.WriteLine($"{assemblyUnderTestName} doesn't have required dependency {asmblyName}.");
                }
            }

            Assert.True(importsAllRequiredAssembles, $"{assemblyUnderTestName} does not import all required assemblies.");
        }
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        [Fact]
        public void ShouldNotHaveProhibitedAssemblies()
        {

        }
    }
}
