using Xunit.Abstractions;

namespace YouTooCanKanban.Architecture.Tests
{
#pragma warning disable CS8601 // Possible null reference assignment.
    public sealed class ApplicationDependencyTests : BaseDependencyTest
    {
        public ApplicationDependencyTests(ITestOutputHelper outputHelper) : base(
            ApplicationAssembly,
            shouldHaveDependencies: [
                BLLAssembly.GetName().Name,
                DomainAssembly.GetName().Name
            ],
            mustNotHaveDependencies: [
                ApiAssembly.GetName().Name,
                ApiClientAssembly.GetName().Name,
                DALAssembly.GetName().Name,
            ],
            outputHelper
        )
        { }
    }
}
#pragma warning restore CS8601 // Possible null reference assignment.