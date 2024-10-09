using Xunit.Abstractions;

namespace YouTooCanKanban.Architecture.Tests
{
#pragma warning disable CS8601 // Possible null reference assignment.
    public sealed class ApiDependencyTests : BaseDependencyTest
    {
        public ApiDependencyTests(ITestOutputHelper outputHelper) : base(
            ApiAssembly,
            shouldHaveDependencies: [
                ApplicationAssembly.GetName().Name,
                BLLAssembly.GetName().Name,
                DALAssembly.GetName().Name,
                DomainAssembly.GetName().Name
            ],
            mustNotHaveDependencies: [
                ApiClientAssembly.GetName().Name,
            ],
            outputHelper
        )
        { }
    }
}
#pragma warning restore CS8601 // Possible null reference assignment.