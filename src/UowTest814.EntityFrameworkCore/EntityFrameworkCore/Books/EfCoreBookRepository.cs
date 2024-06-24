using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UowTest814.Books;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace UowTest814.EntityFrameworkCore.Books
{
    public class EfCoreBookRepository : EfCoreRepository<UowTest814DbContext, Book, Guid>, IBookRepository
    {
        public EfCoreBookRepository(IDbContextProvider<UowTest814DbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Book> GetBookByIdAsync(Guid id)
        {
            return await (await GetDbSetAsync()).Where(l => l.Id == id).FirstOrDefaultAsync();
        }
    }
}
