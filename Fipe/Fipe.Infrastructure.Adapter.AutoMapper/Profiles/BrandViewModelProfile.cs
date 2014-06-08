using AutoMapper;
using Fipe.Application.ViewModels;
using Fipe.Domain;

namespace Fipe.Infrastructure.Adapter.AutoMapper.Profiles
{
    public class BrandViewModelProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Brand, BrandViewModel>();
        }
    }
}
