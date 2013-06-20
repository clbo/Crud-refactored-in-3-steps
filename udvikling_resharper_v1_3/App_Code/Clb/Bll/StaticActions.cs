using System.Web;
using System.Web.UI;

namespace Clb.Bll
{
    /// <summary>
    ///     Static action (redirect, requests etc.)
    /// </summary>
    public static class StaticActions
    {
        public static void RedirectToDefault()
        {
            HttpContext.Current.Response.Redirect("Default.aspx");
        }
        public static void RedirectToCustom(string page)
        {
            HttpContext.Current.Response.Redirect(page);
        }
        
    }
}