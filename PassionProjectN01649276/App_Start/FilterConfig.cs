using System.Web;
using System.Web.Mvc;

namespace PassionProjectN01649276
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
