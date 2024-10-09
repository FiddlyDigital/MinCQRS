using Xunit.Abstractions;

namespace YouTooCanKanban.Architecture.Tests
{
#pragma warning disable CS8601 // Possible null reference assignment.
    public sealed class WASMUIDependencyTests : BaseDependencyTest
    {
        public WASMUIDependencyTests(ITestOutputHelper outputHelper) : base(
            UIAssembly,
            shouldHaveDependencies: [
                ApiClientAssembly.GetName().Name,
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