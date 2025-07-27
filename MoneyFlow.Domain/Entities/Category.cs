using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyFlow.Domain.Entities
{
    public class Category : BaseEntity
    {
        private Category() { }

        public Category(string title, Guid userProfileId)
        {
            SetTitle(title);
            UserProfileId = userProfileId;
        }

        public string Title { get; private set; }
        
        public Guid UserProfileId { get; private set; }
        public virtual UserProfile UserProfile { get; private set; }
        
        public void Rename(string newTitle)
        {
            SetTitle(newTitle);
        }

        private void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be null or whitespace.", nameof(title));
            }
            
            Title = title;
        }
    }
}
