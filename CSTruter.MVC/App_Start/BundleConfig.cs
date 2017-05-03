using System.Web.Optimization;

public class BundleConfig
{
    public static void RegisterBundles(BundleCollection bundles)
    {
        bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-{version}.js",
                    "~/Scripts/jquery.unobtrusive*",
                    "~/Scripts/jquery.validate*",
                    "~/Scripts/validation.js"));

        bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                    "~/Scripts/globalize/globalize.js",
                    "~/Scripts/globalize/cultures/globalize.culture." + System.Globalization.CultureInfo.CurrentCulture.ToString() + ".js",
                    "~/Scripts/bootstrap*",
                    "~/Scripts/filebutton.js",
                    "~/Scripts/globalize-datepicker.js"
                    ));

        bundles.Add(new StyleBundle("~/bundles/css").Include(
                    "~/Content/themes/bootstrap/bootstrap.css"));

        bundles.IgnoreList.Clear();
    }
}
