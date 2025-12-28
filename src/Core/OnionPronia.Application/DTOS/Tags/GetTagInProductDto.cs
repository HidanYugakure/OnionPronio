using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Application.DTOS.Tags
{
    public record GetTagInProductDto
        (
        long id,
        string Name
        );
}
