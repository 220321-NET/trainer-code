using System;
using System.Collections.Generic;

namespace DL.Entities
{
    public partial class User
    {
        public User()
        {
            Answers = new HashSet<Answer>();
            Issues = new HashSet<Issue>();
        }

        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? NickName { get; set; }
        public string? Password { get; set; }
        public string? Bio { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
    }
}
