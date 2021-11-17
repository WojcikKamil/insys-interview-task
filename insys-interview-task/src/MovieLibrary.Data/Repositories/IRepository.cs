using MovieLibrary.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace MovieLibrary.Data.Repositories
{
    public interface IRepository
    {
        Task<IPagedList> GetPagedListAsync(Paging paging = null, FilteringProperties filter = null);
    }
}
