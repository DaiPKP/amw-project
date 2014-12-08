using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Text;
using System.Globalization;

namespace multilang
{
    public class BasePage:System.Web.UI.Page
    {
        protected override void InitializeCulture()
        {
            if (!string.IsNullOrEmpty(Request["lang"]))
            {
                Session["lang"] = Request["lang"];
            }
            string lang = Session["lang"].ToString(); 
            string culture = string.Empty;
            //if (lang.CompareTo("vi-VN") == 0)
            //{
            //    culture = "vi-VN";
            //}
            if (lang.CompareTo("en-US") == 0)
            {
                culture = "en-US";
            }
            else
            {
                culture = "vi-VN";
            }
            
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            base.InitializeCulture();

        }
    }
}
