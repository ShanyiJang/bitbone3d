using System;

namespace Bitbone3d.Command;

public interface IDomainCommand
{
    public DateTime OperationTime { get; }
}