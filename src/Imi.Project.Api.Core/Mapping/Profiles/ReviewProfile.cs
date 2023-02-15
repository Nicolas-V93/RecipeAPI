using AutoMapper;
using Imi.Project.Api.Core.Dto.Instruction;
using Imi.Project.Api.Core.Dto.Review;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Mapping.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<ReviewRequestDto, Review>()
                .BeforeMap((src, dest) => dest.UpdateTimeStamp = DateTime.Now)
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment.Trim()));
            CreateMap<Review, ReviewResponseDto>();
        }
    }
}
