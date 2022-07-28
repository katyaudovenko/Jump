namespace Model.Services.ServiceLocator
{
    public interface IServiceLocator<TService>
    {
        T Register<T>(T newService) where T : TService;
        T GetService<T>() where T : TService;
    }
}