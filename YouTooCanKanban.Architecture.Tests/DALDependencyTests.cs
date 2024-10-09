using Xunit.Abstractions;

namespace YouTooCanKanban.Architecture.Tests
{
#pragma warning disable CS8601 // Possible null reference assignment.
    public sealed class DALDependencyTests : BaseDependencyTest
    {
        public DALDependencyTests(ITestOutputHelper outputHelper) : base(
            DALAssembly,
            shouldHaveDependencies: [

            ],
            mustNotHaveDependencies: [
                ApiAssembly.GetName().Name,
                ApiClientAssembly.GetName().Name,
                ApplicationAssembly.GetName().Name,
                BLLAssembly.GetName().Name,
                DomainAssembly.GetName().Name
            ],
            outputHelper
        )
        { }
    }
}
#pragma warning restore CS8601 // Possible null reference assignment.