using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyFlow.Domain.Entities
{
    /// <summary>
    /// User can create custom categories for managing their finances.
    /// </summary>
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

        /// <summary>
        /// Renames the title of the category, validates for null or whitespace using SetTitle.
        /// </summary>
        /// <param name="newTitle">New title to set.</param>
        public void Rename(string newTitle)
        {
            SetTitle(newTitle);
        }

        /// <summary>
        /// Sets the title of the category after validating that it is not null or whitespace.
        /// </summary>
        /// <param name="title">Title to set.</param>
        /// <exception cref="ArgumentException">Thrown if the title is null, empty or consists only whitespace.</exception>
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
