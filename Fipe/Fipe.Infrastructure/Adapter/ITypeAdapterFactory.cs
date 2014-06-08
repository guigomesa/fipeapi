namespace Fipe.Infrastructure.Adapter
{
    public interface ITypeAdapterFactory
    {
        ITypeAdapter Build();
    }
}