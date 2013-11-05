using StructureMap;

namespace Framework
{
    public static class ApplicationEnvironment
    {
        public static T Resolve<T>()
        {
            return ObjectFactory.GetInstance<T>();
        }
    }
}
