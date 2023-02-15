using Imi.Project.Api.Core.Dto.Category;
using Imi.Project.Api.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dto.Recipe;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IBaseService<T, TRequest>
    {
        Task<BaseResponseDto<T>> ListAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(TRequest requestDto);
        Task UpdateAsync(Guid id, TRequest requestDto);
        Task DeleteAsync(Guid id);
        Task<bool> EntityExistsAsync(Guid id);
    }
}
