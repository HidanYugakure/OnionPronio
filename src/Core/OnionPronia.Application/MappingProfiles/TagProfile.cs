using AutoMapper;
using OnionPronia.Application.DTOS.Tags;
using OnionPronia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Application.MappingProfiles
{
    internal class TagProfile:Profile
    {
        public TagProfile() 
        {
            CreateMap<Tag, GetTagInProductDto>();
        }

    }
}
