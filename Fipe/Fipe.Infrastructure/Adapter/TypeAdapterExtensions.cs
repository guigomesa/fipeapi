namespace Fipe.Infrastructure.Adapter
{
    public static class TypeAdapterExtensions
    {
        public static TProjection ProjectedAs<TProjection>(this object item, ITypeAdapterFactory factory)
            where TProjection : class, new()
        {
            var adapter = factory.Build();
            return adapter.Adapt<TProjection>(item);
        }
    }
}
