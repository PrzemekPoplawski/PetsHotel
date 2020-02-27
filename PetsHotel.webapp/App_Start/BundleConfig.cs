using System.Web;
using System.Web.Optimization;

namespace PetsHotel.webapp
{
    public class BundleConfig
    {
        // Aby uzyskać więcej informacji o grupowaniu, odwiedź stronę https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Użyj wersji deweloperskiej biblioteki Modernizr do nauki i opracowywania rozwiązań. Następnie, kiedy wszystko będzie
            // gotowe do produkcji, użyj narzędzia do kompilowania ze strony https://modernizr.com, aby wybrać wyłącznie potrzebne testy.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*",
                        "~/Scripts/MyScripts/datatables.js",
                        "~/Scripts/MyScripts/DataTables-1.10.20/js/dataTables.*",
                        "~/Scripts/MyScripts/DataTables-1.10.20/js/jquery.dataTables.js",
                        "~/Scripts/TemplateJs/js/main.js",
                        "~/Scripts/TemplateJs/js/extension/choices.js",
                        "~/Scripts/TemplateJs/js/extension/custom-materialize.js",
                        "~/ Scripts/TemplateJs/js/extension/flatpickr.js"
                        //"~/Scripts/MyScripts/datatables.min.js",
                        ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/DataTables/datatables.css",
                      "~/Content/DataTables/css/dataTables*",
                      "~/Content/DataTables/css/jquery.dataTables.css",
                      "~/Content/carousel.css",
                      "~/Content/css/main.css"));

        }
    }
}
