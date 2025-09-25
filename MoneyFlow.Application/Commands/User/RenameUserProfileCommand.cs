using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyFlow.Application.Commands.User
{
    public record RenameUserProfileCommand : IRequest<Guid>
    {
        public string UserName { get; set; }
        public Guid Id { get; set; }
    }
}
