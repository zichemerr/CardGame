namespace CMS.EntryPoint
{
    public interface IServiceLocator<T>
    {
        TP Register<TP>(TP service, int id = -1) where TP : T;
        void UnRegister<TP>(TP service) where TP : T;
        TP Get<TP>(int id = -1) where TP : T;
    }
}
