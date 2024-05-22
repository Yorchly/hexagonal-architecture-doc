namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases
{
    /// <summary>
    /// Interface for handler a ReturnVehicle use case.
    /// </summary>
    /// <typeparam name="TUseCaseInput">input type.</typeparam>
    public interface IReturnVehicleUseCase<in TUseCaseInput>
        : IUseCase<TUseCaseInput>
        where TUseCaseInput : IUseCaseInput
    {
    }
}
