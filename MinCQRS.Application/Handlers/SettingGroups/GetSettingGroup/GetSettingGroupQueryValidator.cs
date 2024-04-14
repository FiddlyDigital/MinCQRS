namespace MinCQRS.Application.Handlers.SettingGroups.GetSettingGroup
{
    using FluentValidation;

    // Candidate for extraction
    public sealed class GetSettingGroupQueryValidator : AbstractValidator<GetSettingGroupQuery>
    {
        public GetSettingGroupQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
