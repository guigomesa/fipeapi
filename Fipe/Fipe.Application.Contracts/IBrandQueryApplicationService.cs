using System.Collections.Generic;
using Fipe.Application.ViewModels;

namespace Fipe.Application.Contracts
{
    public interface IBrandQueryApplicationService
    {
        IEnumerable<BrandViewModel> GetAllBrands();
    }
}
