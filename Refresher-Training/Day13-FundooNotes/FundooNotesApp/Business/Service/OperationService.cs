using Business.Interface;

namespace Business.Service
{
    public class OperationService : IOperationTransient, IOperationScoped, IOperationSingleton
    {
        public Guid OperationId { get; }

        public OperationService()
        {
            OperationId = Guid.NewGuid();
        }
    }

    // Depends on all three lifetimes itself, so we can compare the GUID
    // resolved here against the GUID resolved directly in the controller,
    // within the SAME HTTP request.
    public class OperationLogger
    {
        public IOperationTransient TransientOperation { get; }
        public IOperationScoped ScopedOperation { get; }
        public IOperationSingleton SingletonOperation { get; }

        public OperationLogger(
            IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation)
        {
            TransientOperation = transientOperation;
            ScopedOperation = scopedOperation;
            SingletonOperation = singletonOperation;
        }
    }
}
