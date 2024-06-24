﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace UowTest814.Books
{
    public interface IBookRepository : IBasicRepository<Book, Guid>
    {
        Task<Book> GetBookByIdAsync(Guid id);
    }
}
