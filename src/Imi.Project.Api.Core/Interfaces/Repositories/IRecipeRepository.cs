using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repositories
{
    public interface IRecipeRepository : IBaseRepository<Recipe>
    {
        Task<IEnumerable<Recipe>> GetByCategoryIdAsync(Guid id);
        Task<IEnumerable<Recipe>> GetByDietIdAsync(Guid id);
        Task<Recipe> GetByIdDetailsAsync(Guid id);
        Task<IEnumerable<Recipe>> GetByIngredientIdAsync(Guid id);
        Task<IEnumerable<Recipe>> ExecuteQueryAsync(IQueryable<Recipe> query);
    }
}
