using System;

namespace Books.Entities
{
    public class Publisher : Entity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
