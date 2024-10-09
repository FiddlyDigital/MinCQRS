using System.Reflection;
using NetArchTest.Rules;
using Xunit.Abstractions;

namespace YouTooCanKanban.Architecture.Tests
{
#pragma warning disable CS8601 // Possible null reference assignment.
    public sealed class DomainDependencyTests : BaseDependencyTest
    {
        public DomainDependencyTests(ITestOutputHelper outputHelper) : base(
            DomainAssembly,
            shouldHaveDependencies: [
            
            ],
            mustNotHaveDependencies: [
                ApiAssembly.GetName().Name,
                ApiClientAssembly.GetName().Name,
                ApplicationAssembly.GetName().Name,
                BLLAssembly.GetName().Name,
                DALAssembly.GetName().Name,
                UIAssembly.GetName().Name
            ],
            outputHelper
        )
        { }
    }
}
#pragma warning restore CS8601 // Possible null reference assignment.