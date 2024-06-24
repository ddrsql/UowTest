using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace UowTest814.Books
{
    public class Book : AuditedAggregateRoot<Guid>
    {
        public Book(Guid id, string name)
        {
            Id = id;
            Name = name;
            PublishDate = DateTime.Now;
        }
        public string Name { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }
    }
}
