using System.Web;
using System.Web.Mvc;

namespace KutseeApp_Grigorjev
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
