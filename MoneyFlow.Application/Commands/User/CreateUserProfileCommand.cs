using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyFlow.Application.Commands.User
{
    public record CreateUserProfileCommand : IRequest<Guid>
    {
        public string UserName { get; set; }
    }
}
