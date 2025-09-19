using MediatR;
using MoneyFlow.Domain.Entities;
using MoneyFlow.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyFlow.Application.Commands.User
{
    public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, Guid>
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public CreateUserProfileCommandHandler(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<Guid> Handle(CreateUserProfileCommand command, CancellationToken cancellationToken)
        {
            var userName = command.UserName;

            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }

            var userProfile = new UserProfile(userName);

            var userProfileId = await _userProfileRepository.CreateAsync(userProfile);
            return userProfileId;
        }
    }
}
