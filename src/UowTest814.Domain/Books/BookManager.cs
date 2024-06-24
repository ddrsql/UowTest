using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Uow;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UowTest814.Books
{
    public class BookManager : DomainService
    {
        protected IUnitOfWorkManager UnitOfWorkManager => base.LazyServiceProvider.LazyGetRequiredService<IUnitOfWorkManager>();
        private readonly IRepository<Book, Guid> _repository;
        private readonly IBookRepository _bookRepository;

        public BookManager(IRepository<Book, Guid> repository, IBookRepository bookRepository)
        {
            _repository = repository;
            _bookRepository = bookRepository;
        }

        public virtual async Task<Book> AddBookBeginAsync()
        {
            var book = new Book(Guid.NewGuid(), "book" + DateTime.Now);
            using (var uow = UnitOfWorkManager.Begin(true, true))
            {
                book = await _repository.InsertAsync(book);
                await uow.SaveChangesAsync();
                var bookBegin1 = await _bookRepository.GetBookByIdAsync(book.Id);
                if (bookBegin1 != null)
                    Logger.LogInformation("bookBegin1 查询√√√");
                else
                    Logger.LogInformation("bookBegin1 查询×××");

                await uow.CompleteAsync();

                var bookBegin2 = await _bookRepository.GetBookByIdAsync(book.Id);
                if (bookBegin2 != null)
                    Logger.LogInformation("bookBegin2 查询√√√");
                else
                    Logger.LogInformation("bookBegin2 查询×××");
            }
            try
            {
                var bookBegin3 = await _repository.GetAsync(book.Id);
                if (bookBegin3 != null)
                    Logger.LogInformation("bookBegin3 查询√√√");
                else
                    Logger.LogInformation("bookBegin3 查询×××");
            }
            catch (Exception ex)
            {
                Logger.LogInformation("bookBegin3 查询××× " + ex.Message);
            }
            var bookBegin4 = await _bookRepository.GetBookByIdAsync(book.Id);
            if (bookBegin4 != null)
                Logger.LogInformation("bookBegin4 查询√√√");
            else
                Logger.LogInformation("bookBegin4 查询×××");
            return book;
        }

        public virtual async Task<Book> AddBookSaveChangeAsync()
        {
            var book = new Book(Guid.NewGuid(), "book" + DateTime.Now);
            book = await _repository.InsertAsync(book);
            if (UnitOfWorkManager != null && UnitOfWorkManager.Current != null)
                await UnitOfWorkManager.Current.SaveChangesAsync();
            try
            {
                var bookSaveChange1 = await _repository.GetAsync(book.Id);
                if (bookSaveChange1 != null)
                    Logger.LogInformation("bookSaveChange1 查询√√√");
                else
                    Logger.LogInformation("bookSaveChange1 查询×××");
            }
            catch (Exception ex)
            {
                Logger.LogInformation("bookSaveChange1 查询××× " + ex.Message);
            }
            var bookSaveChange2 = await _bookRepository.GetBookByIdAsync(book.Id);
            if (bookSaveChange2 != null)
                Logger.LogInformation("bookSaveChange2 查询√√√");
            else
                Logger.LogInformation("bookSaveChange2 查询×××");
            return book;
        }
    }
}
