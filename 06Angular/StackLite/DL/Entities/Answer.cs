using System;
using System.Collections.Generic;

namespace DL.Entities
{
    public partial class Answer
    {
        public int Id { get; set; }
        public int? Score { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? AuthorId { get; set; }
        public string Content { get; set; } = null!;
        public bool? IsBestAnswer { get; set; }
        public int? IssueId { get; set; }

        public virtual User? Author { get; set; }
        public virtual Issue? Issue { get; set; }
    }
}
