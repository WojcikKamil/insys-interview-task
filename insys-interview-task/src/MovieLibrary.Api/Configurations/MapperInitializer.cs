using AutoMapper;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.Api.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Movie, MovieDTO>()
                 .ForMember(
                    dto => dto.Categories,
                    opt => opt.MapFrom(
                        x => x.MovieCategories
                            .Select(y => new Category
                            {
                                Id = y.Category.Id,
                                Name = y.Category.Name
                            })
                            .ToList()));
        }
    }
}
