using AutoMapper;
using Imi.Project.Api.Core.Dto.Category;
using Imi.Project.Api.Core.Dto;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dto.Unit;
using Imi.Project.Api.Core.Enums;

namespace Imi.Project.Api.Core.Services
{
    public class UnitService : IUnitService
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

        public UnitService(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponseDto<UnitResponseDto>> ListAllAsync()
        {
            var units = await _unitRepository.ListAllAsync();

            return new BaseResponseDto<UnitResponseDto>
            {
                Status = HttpStatusCode.OK,
                TotalResults = units.Count(),
                Results = _mapper.Map<IEnumerable<UnitResponseDto>>(units)
            };

        }
        public async Task<UnitResponseDto> GetByIdAsync(Guid id)
        {
            var unit = await _unitRepository.GetByIdAsync(id);
            return _mapper.Map<UnitResponseDto>(unit);
        }
        public async Task<bool> EntityExistsAsync(Guid id)
        {
            return await _unitRepository.EntityExistsAsync(id);
        }
    }

}
