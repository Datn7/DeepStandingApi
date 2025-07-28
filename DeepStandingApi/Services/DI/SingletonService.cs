namespace DeepStandingApi.Services.DI
{
    public class SingletonService : IDemoLifetime
    {
        private readonly Guid _id = Guid.NewGuid();
        public Guid GetOperationId() => _id;
    }
}
