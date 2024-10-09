using Xunit.Abstractions;

namespace YouTooCanKanban.Architecture.Tests
{
#pragma warning disable CS8601 // Possible null reference assignment.
    public sealed class ApiClientDependencyTests : BaseDependencyTest
    {
        public ApiClientDependencyTests(ITestOutputHelper outputHelper) : base(
            ApiClientAssembly,
            shouldHaveDependencies: [
                DomainAssembly.GetName().Name
            ],
            mustNotHaveDependencies: [
                ApiAssembly.GetName().Name,
                ApplicationAssembly.GetName().Name,
                BLLAssembly.GetName().Name,
                DALAssembly.GetName().Name,
            ],
            outputHelper
        )
        { }
    }
}
#pragma warning restore CS8601 // Possible null reference assignment.