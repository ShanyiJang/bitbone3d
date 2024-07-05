using System;

namespace Bitbone3d.Command;

public interface IDomainEvent
{
    public DateTime HappenTime { get; set; }
}