using System.Threading.Tasks;

namespace Bitbone3d.Command;

public interface ICommandHandler<in TDomainCommand>
    where TDomainCommand : IDomainCommand
{
    Task HandleAsync(TDomainCommand command);
}