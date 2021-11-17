using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace MovieLibrary.Data.Repositories
{
    public class MovieRepository : IRepository
    {
        private readonly MovieLibraryContext _context;
        private readonly IMapper _mapper;

        public MovieRepository(MovieLibraryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IPagedList> GetPagedListAsync(Paging paging = null, FilteringProperties filter = null)
        {
            List<MovieDTO> dtos = _context.Movies
                .Include(m => m.MovieCategories)
                .ThenInclude(m => m.Category)
                .Select(m => _mapper.Map<MovieDTO>(m))
                .ToList();

            if (filter != null)
            {
                dtos = dtos.Where(m =>
                       m.Title.Contains(filter.ByText) || m.Description.Contains(filter.ByText)
                    && m.Year >= filter.YearMin && m.Year <= filter.YearMax
                    && m.ImdbRating >= filter.RatingMin && m.ImdbRating <= filter.RatingMin)
                    .ToList();
            }

            return await dtos
                .ToPagedListAsync(paging.PageNumber, paging.PageSize);
        }
    }
}
