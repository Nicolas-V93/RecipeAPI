using Imi.Project.Api.Core.Dto;
using Imi.Project.Api.Core.Dto.Diet;
using Imi.Project.Api.Core.Dto.Recipe;
using Imi.Project.Api.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IRecipeService
    {
        Task<BaseResponseDto<RecipeResponseDto>> ListAllAsync(string? title, int? totalTime);
        Task<RecipeResponseDto> GetByIdAsync(Guid id);
        Task<RecipeResponseDto> AddAsync(RecipeRequestDto requestDto, ClaimsPrincipal user);
        Task UpdateAsync(Guid id, RecipeRequestDto requestDto);
        Task DeleteAsync(Guid id);
        Task<bool> EntityExistsAsync(Guid id);
        Task<BaseResponseDto<RecipeResponseDto>> GetByCategoryIdAsync(Guid id);
        Task<BaseResponseDto<RecipeResponseDto>> GetByDietIdAsync(Guid id);
        Task<BaseResponseDto<RecipeResponseDto>> GetByIngredientAsync(string name);
        Task<RecipeDetailsResponseDto> GetRecipeInformation(Guid id);
        Task<bool> AuthorizeAsync(Guid id, ClaimsPrincipal user, IAuthorizationRequirement requirement);
    }
}
