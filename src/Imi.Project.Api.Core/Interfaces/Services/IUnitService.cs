using Imi.Project.Api.Core.Dto;
using Imi.Project.Api.Core.Dto.Unit;
using Imi.Project.Api.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IUnitService
    {
        Task<BaseResponseDto<UnitResponseDto>> ListAllAsync();
        Task<UnitResponseDto> GetByIdAsync(Guid id);
        Task<bool> EntityExistsAsync(Guid id);
    }
}
