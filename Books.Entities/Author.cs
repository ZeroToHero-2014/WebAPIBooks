using System;

namespace Books.Entities
{
    public class Author
    {
        private string sortableName;

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string SortableName
        {
            get
            {
                if (string.IsNullOrEmpty(sortableName))
                {
                    return Name;
                }

                return sortableName;
            }
            set
            {
                sortableName = value;
            }
        }
    }
}
