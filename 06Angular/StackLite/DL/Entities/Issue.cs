using System;
using System.Collections.Generic;

namespace DL.Entities
{
    public partial class Issue
    {
        public Issue()
        {
            Answers = new HashSet<Answer>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime? DateCreated { get; set; }
        public string? Content { get; set; }
        public bool? IsClosed { get; set; }
        public int? Score { get; set; }
        public int? AuthorId { get; set; }

        public virtual User? Author { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
