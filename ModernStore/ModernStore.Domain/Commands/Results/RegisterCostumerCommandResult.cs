using System;
using MordenStore.Share.Commands;

namespace ModernStore.Domain.Commands.Results
{
    public class RegisterCostumerCommandResult : ICommandResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
