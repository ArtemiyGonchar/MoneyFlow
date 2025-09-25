using MediatR;
using MoneyFlow.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyFlow.Application.Commands.User
{
    public class RenameUserProfileCommandHandler : IRequestHandler<RenameUserProfileCommand, Guid>
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public RenameUserProfileCommandHandler(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<Guid> Handle(RenameUserProfileCommand request, CancellationToken cancellationToken)
        {
            var username = request.UserName;
            var userId = request.Id;

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            var userProfileFromRep = await _userProfileRepository.GetAsync(userId);
            if (userProfileFromRep == null)
            {
                return Guid.Empty;
            }

            userProfileFromRep.Rename(username);
            await _userProfileRepository.UpdateAsync(userProfileFromRep);
            return userId;
        }
    }
}
