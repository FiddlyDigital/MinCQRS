using AutoMapper;

namespace MinCQRS.Domain.Extensions
{

    public static class MappingExtensions
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static IMapper _mapper;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public static void InitializeMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public static DestinationT MapTo<DestinationT>(this object source)
        {
            return _mapper.Map<DestinationT>(source);
        }

        public static TDestination MapTo<TDestination>(this object source, TDestination destination)
        {
            return _mapper.Map(source, destination);
        }
    }
}
