using StructureMap;

namespace Web.Bootstrap
{
    public static class Bootstraper
    {
        public static void Initialize()
        {
            // Initialize the static ObjectFactory container
            ObjectFactory.Configure(x => x.Scan( s=>
            {
                s.TheCallingAssembly();
                s.Assembly("Web");
                s.Assembly("Business");
                s.Assembly("DAL");
                s.WithDefaultConventions();
            }));
        }
    }
}