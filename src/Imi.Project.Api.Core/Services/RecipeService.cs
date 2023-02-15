using AutoMapper;
using Imi.Project.Api.Core.Dto;
using Imi.Project.Api.Core.Dto.Category;
using Imi.Project.Api.Core.Dto.Diet;
using Imi.Project.Api.Core.Dto.Instruction;
using Imi.Project.Api.Core.Dto.Recipe;
using Imi.Project.Api.Core.Dto.RecipeIngredient;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Helpers.CustomClaimTypes;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class RecipeService : IRecipeService
    {

        private readonly IRecipeRepository _recipeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDietRepository _dietRepository;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public RecipeService(IRecipeRepository recipeRepository, 
            ICategoryRepository categoryRepository, 
            IDietRepository dietRepository, 
            IIngredientRepository ingredientRepository,
            IMapper mapper, 
            IUserService userService)
            
        {
            _recipeRepository = recipeRepository;
            _categoryRepository = categoryRepository;
            _dietRepository = dietRepository;
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<BaseResponseDto<RecipeResponseDto>> ListAllAsync(string? title, int? totalTime)
        {
            var collectionQuery = _recipeRepository.GetAll();

            if (!string.IsNullOrWhiteSpace(title))
            {
                collectionQuery = collectionQuery.Where(r => r.Title.Trim().ToUpper().Contains(title.Trim().ToUpper()));
            }

            if (totalTime.HasValue)
            {
                collectionQuery = collectionQuery.Where(r => r.PrepTime + r.CookTime <= totalTime);
            }

            var recipes = await _recipeRepository.ExecuteQueryAsync(collectionQuery);

            return new BaseResponseDto<RecipeResponseDto>
            {
                Status = HttpStatusCode.OK,
                TotalResults = recipes.Count(),
                Results = _mapper.Map<IEnumerable<RecipeResponseDto>>(recipes)

            };
        }
        public async Task<RecipeResponseDto> GetByIdAsync(Guid id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            return _mapper.Map<RecipeResponseDto>(recipe);
        }
        public async Task<RecipeResponseDto> AddAsync(RecipeRequestDto requestDto, ClaimsPrincipal User)
        {    
            var category = await _categoryRepository.GetByNameAsync(requestDto.CategoryName)
                ?? throw new ArgumentException($"Unable to add recipe because category '{requestDto.CategoryName}' does not exist");
            var diet = await _dietRepository.GetByNameAsync(requestDto.DietName)
                ?? throw new ArgumentException($"Unable to add recipe because diet '{requestDto.DietName}' does not exist");

            var recipe = _mapper.Map<Recipe>(requestDto);

            recipe.CategoryId = category.Id;
            recipe.DietId = diet.Id;
            recipe.ApplicationUserId = _userService.GetUserId(User);  

            var result = await _recipeRepository.AddAsync(recipe);
            return _mapper.Map<RecipeResponseDto>(result);
        }
        public async Task UpdateAsync(Guid id, RecipeRequestDto requestDto)
        {
            var category = await _categoryRepository.GetByNameAsync(requestDto.CategoryName)
                ?? throw new ArgumentException($"Unable to update recipe because category '{requestDto.CategoryName}' does not exist");
            var diet = await _dietRepository.GetByNameAsync(requestDto.DietName)
                ?? throw new ArgumentException($"Unable to update recipe because diet '{requestDto.DietName}' does not exist");

            var recipe = await _recipeRepository.GetByIdAsync(id);

            _mapper.Map(requestDto, recipe);
            recipe.CategoryId = category.Id;
            recipe.DietId = diet.Id;

            await _recipeRepository.UpdateAsync(recipe);
        }
        public async Task DeleteAsync(Guid id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            await _recipeRepository.DeleteAsync(recipe);
        }       
        public async Task<BaseResponseDto<RecipeResponseDto>> GetByCategoryIdAsync(Guid id)
        {
            var recipes = await _recipeRepository.GetByCategoryIdAsync(id);

            return new BaseResponseDto<RecipeResponseDto>
            {
                Status = HttpStatusCode.OK,
                TotalResults = recipes.Count(),
                Results = _mapper.Map<IEnumerable<RecipeResponseDto>>(recipes)
            };

        }
        public async Task<BaseResponseDto<RecipeResponseDto>> GetByDietIdAsync(Guid id)
        {
            IEnumerable<Recipe> recipes;
            var diet = await _dietRepository.GetByIdAsync(id);
            if (diet.Name.Trim().ToLower().Equals("anything"))
            {
                recipes = await _recipeRepository.ListAllAsync();
            }
            else
            {
                recipes = await _recipeRepository.GetByDietIdAsync(id);
            }
            return new BaseResponseDto<RecipeResponseDto>
            {
                Status = HttpStatusCode.OK,
                TotalResults = recipes.Count(),
                Results = _mapper.Map<IEnumerable<RecipeResponseDto>>(recipes)
            };
        }
        public async Task<bool> EntityExistsAsync(Guid id)
        {
            return await _recipeRepository.EntityExistsAsync(id);
        }
        public async Task<BaseResponseDto<RecipeResponseDto>> GetByIngredientAsync(string name)
        {
            var ingredient = await _ingredientRepository.GetByNameAsync(name);
            var ingredientId = ingredient == null ? Guid.Empty : ingredient.Id;

            var recipes = await _recipeRepository.GetByIngredientIdAsync(ingredientId);

            return new BaseResponseDto<RecipeResponseDto>
            {
                Status = HttpStatusCode.OK,
                TotalResults = recipes.Count(),
                Results = _mapper.Map<IEnumerable<RecipeResponseDto>>(recipes)

            };
        }
        public async Task<RecipeDetailsResponseDto> GetRecipeInformation(Guid id)
        {
            var recipe = await _recipeRepository.GetByIdDetailsAsync(id);
            return _mapper.Map<RecipeDetailsResponseDto>(recipe);
        }
        public async Task<bool> AuthorizeAsync(Guid id, ClaimsPrincipal user, IAuthorizationRequirement requirement)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            return await _userService.AuthorizeAsync(user, recipe, requirement);
        }
    }
}
