using System.Web;
using System.Web.Optimization;

namespace SpringBlog
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            bundles.Add(new ScriptBundle("~/bundles/jquery", "https://code.jquery.com/jquery-3.4.1.min.js").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap", "https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.bundle.min.js").Include(
                      "~/Scripts/bootstrap.bundle.js"));

            bundles.Add(new ScriptBundle("~/bundles/croppie", "https://cdnjs.cloudflare.com/ajax/libs/croppie/2.6.4/croppie.min.js").Include(
                        "~/Scripts/croppie.js"));

            bundles.Add(new ScriptBundle("~/bundles/bs-custom-file-input", "https://cdn.jsdelivr.net/npm/bs-custom-file-input/dist/bs-custom-file-input.min.js").Include(
                        "~/Areas/Admin/plugins/bs-custom-file-input/bs-custom-file-input.js"));

            bundles.Add(new ScriptBundle("~/bundles/site")
                .Include("~/Scripts/Site.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap", "https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css").Include(
                      "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/croppie", "https://cdnjs.cloudflare.com/ajax/libs/croppie/2.6.4/croppie.min.css").Include(
          "~/Content/croppie.css"));

            bundles.Add(new StyleBundle("~/Content/fontawesome", "https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.13.0/css/all.min.css").Include(
          "~/Content/fontawesome-all.css"));



            // normalde bunu yazmaya gerek yok, release mod'da çalıştırırken farkı göstermek istedik
#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}
