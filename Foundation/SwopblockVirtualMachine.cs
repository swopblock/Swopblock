using System;

namespace Swopblock;

public record SwopblockVirtualMachine(HashSet<VirtualMachine> VirtualMachines);

public record VirtualMachine;