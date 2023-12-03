namespace DI_Services_Lifetime.Services
{
    public class SingletonGuidService : ISingletonGuidService
    {
        public readonly Guid Id;
        public SingletonGuidService()
        {
            Id = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return Id.ToString();
        }
    }
}
