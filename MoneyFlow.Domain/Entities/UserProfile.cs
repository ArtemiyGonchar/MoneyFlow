using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyFlow.Domain.Entities
{
    public class UserProfile : BaseEntity
    {
        private UserProfile() { }

        public UserProfile(string name)
        {
            Name = name;
            CreatedAt = DateTime.UtcNow;
            Categories = new List<Category>();
            Transactions = new List<Transaction>();
        }

        public string Name { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public virtual ICollection<Category> Categories { get; private set; }
        public virtual ICollection<Transaction> Transactions { get; private set; }

        public void Rename(string newName)
        {
            if (string.IsNullOrEmpty(newName))
            {
                throw new ArgumentNullException("Name cannot be empty.", nameof(newName));
            }

            Name = newName;
        }
    }
}
