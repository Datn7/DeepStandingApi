namespace DeepStandingApi.Services.DI
{
    public class ScopedService : IDemoLifetime
    {
        private readonly Guid _id = Guid.NewGuid();
        public Guid GetOperationId() => _id;
    }
}
