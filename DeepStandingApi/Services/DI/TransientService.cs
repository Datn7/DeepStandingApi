namespace DeepStandingApi.Services.DI
{
    public class TransientService : IDemoLifetime
    {
        private readonly Guid _id = Guid.NewGuid();
        public Guid GetOperationId() => _id;
    }
}
