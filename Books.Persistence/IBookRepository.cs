﻿using Books.Entities;
using System;
using System.Linq;

namespace Books.Persistence
{
    public interface IBookRepository
    {
        IQueryable<Book> GetAll();
        Book GetById(Guid id);
    }
}
