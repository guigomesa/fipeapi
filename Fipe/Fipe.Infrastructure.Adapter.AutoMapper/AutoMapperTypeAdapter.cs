using AutoMapper;

namespace Fipe.Infrastructure.Adapter.AutoMapper
{
    public class AutoMapperTypeAdapter : ITypeAdapter
    {
        public TTarget Adapt<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class, new()
        {
            return Mapper.Map<TSource, TTarget>(source);
        }

        public TTarget Adapt<TTarget>(object source) where TTarget : class, new()
        {
            return (TTarget)Mapper.Map(source, source.GetType(), typeof(TTarget));
        }
    }
}