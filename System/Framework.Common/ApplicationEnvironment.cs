using StructureMap;

namespace Framework.Common
{
    public static class ApplicationEnvironment
    {
        public static T Resolve<T>()
        {
            return ObjectFactory.GetInstance<T>();
        }
    }
}
