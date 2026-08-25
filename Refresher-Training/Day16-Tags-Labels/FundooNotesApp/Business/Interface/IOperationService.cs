namespace Business.Interface
{
    public interface IOperation
    {
        Guid OperationId { get; }
    }

    // Marker interfaces so the SAME class can be registered
    // with three different DI lifetimes and compared side by side.
    public interface IOperationTransient : IOperation { }
    public interface IOperationScoped : IOperation { }
    public interface IOperationSingleton : IOperation { }
}
