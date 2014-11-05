using System;

namespace Books.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}