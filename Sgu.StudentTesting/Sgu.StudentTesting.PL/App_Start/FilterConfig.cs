using System.Web;
using System.Web.Mvc;

namespace Sgu.StudentTesting.PL
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
