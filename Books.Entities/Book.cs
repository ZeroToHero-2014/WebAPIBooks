using System;
using System.Collections.Generic;

namespace Books.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }

        public Publisher Publisher { get; set; }

        public ICollection<string> Authors { get; set; }
    }
}
