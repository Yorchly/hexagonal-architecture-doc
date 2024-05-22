namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases
{
    /// <summary>
    /// Interface for handler a CreateVehicle use case.
    /// </summary>
    /// <typeparam name="TUseCaseInput">input type.</typeparam>
    public interface ICreateVehicleUseCase<in TUseCaseInput>
        : IUseCase<TUseCaseInput>
        where TUseCaseInput : IUseCaseInput
    {
    }
}
