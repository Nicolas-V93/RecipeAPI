using Imi.Project.Api.Core.Dto.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Dto
{
    public class BaseResponseDto<T>
    {
        public HttpStatusCode Status { get; set; }
        public int TotalResults { get; set; }
        public IEnumerable<T> Results { get; set; }

    }

}
