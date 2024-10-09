using Xunit.Abstractions;

namespace YouTooCanKanban.Architecture.Tests
{
#pragma warning disable CS8601 // Possible null reference assignment.
    public sealed class BLLDependencyTests : BaseDependencyTest
    {
        public BLLDependencyTests(ITestOutputHelper outputHelper) : base(
            BLLAssembly,
            shouldHaveDependencies: [
                DALAssembly.GetName().Name,
                DomainAssembly.GetName().Name
            ],
            mustNotHaveDependencies: [
                ApiAssembly.GetName().Name,
                ApiClientAssembly.GetName().Name,
                ApplicationAssembly.GetName().Name,
            ],
            outputHelper
        )
        { }
    }
}
#pragma warning restore CS8601 // Possible null reference assignment.