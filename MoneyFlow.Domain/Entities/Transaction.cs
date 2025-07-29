using MoneyFlow.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyFlow.Domain.Entities
{
    /// <summary>
    /// User can create transactions for save/manage them.
    /// </summary>
    public class Transaction : BaseEntity
    {
        private Transaction() { }

        public Transaction(string title, string description, Guid userProfileId, Money amount)
        {
            SetTitle(title);
            SetDescription(description);
            UserProfileId = userProfileId;
            Amount = amount;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }

        public Guid UserProfileId { get; private set; }
        public virtual UserProfile UserProfile { get; private set; }

        public Money Amount { get; private set; }

        /// <summary>
        /// Sets the title of the transaction after validating that it is not null or whitespace.
        /// </summary>
        /// <param name="title">Title to set.</param>
        /// <exception cref="ArgumentException">Thrown if the title is null, empty or consists only whitespace.</exception>
        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentNullException(nameof(title));
            Title = title;
        }

        /// <summary>
        /// Sets the description of the transaction after validating that it is not null or whitespace.
        /// </summary>
        /// <param name="description">Description to set.</param>
        /// <exception cref="ArgumentException">Thrown if the title is null, empty or consists only whitespace.</exception>
        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentNullException(nameof(description));
            Description = description;
        }
    }
}
