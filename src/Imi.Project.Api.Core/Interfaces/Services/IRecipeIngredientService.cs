using Imi.Project.Api.Core.Dto.Instruction;
using Imi.Project.Api.Core.Dto.RecipeIngredient;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IRecipeIngredientService
    {
        Task<IEnumerable<RecipeIngredientResponseDto>> GetIngredientsAsync(Guid recipeId);
        Task<RecipeIngredientResponseDto> AddAsync(Guid recipeId, RecipeIngredientRequestDto requestDto);
        Task UpdateAsync(Guid recipeId, Guid ingredientId, RecipeIngredientUpdateRequestDto requestDto);
        Task DeleteAsync(Guid recipeId, Guid ingredientId);
        Task<bool> RecipeHasIngredientAsync(Guid recipeId, Guid ingredientId);


        //Task<InstructionResponseDto> AddInstructionToRecipeAsync(Guid recipeId, InstructionRequestDto requestDto);
        //Task UpdateInstructionAsync(Guid recipeId, Guid instructionId, InstructionRequestDto requestDto);
        //Task DeleteInstructionAsync(Guid recipeId, Guid instructionId);


    }
}

