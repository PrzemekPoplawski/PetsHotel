using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetsHotel.webapp.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static WindowFactory WindowFactory(this HtmlHelper helper)
        {
            return new WindowFactory(helper);
        }
    }

    public class WindowFactory
    {
        public WindowFactory(HtmlHelper helper)
        {
            HtmlHelper = helper;
        }

        private ViewContext ViewContext 
        {
            get { return this.HtmlHelper.ViewContext; }
        }

        public HtmlHelper HtmlHelper { get; set; }

        public Window Window()
        {
            return new Window();
        }

    }

    public class WindowBuilder
    {
        // szerokosc, wysokosc, viewcontext
    }

    public class Window
    {
        private string title;

        public Window()
        {
            var html = Render();
            
        }

        public int Height { get; set; }

        public int Width { get; set; }

        public IDictionary<string,object> ContentHtmlAttribiutes { get; set; }

        public ViewContext ViewContext { get; set; }

        public ViewDataDictionary ViewDataDictionary { get; set; }

        public Window Title(string title)
        {
            this.title= title;  // bo tu pisze  ze przypsujemy zmienną do samej siebie 
            return this;
        }

        public string Render()
        {
            var outerDiv1 = new TagBuilder("div");
            outerDiv1.AddCssClass("modal fade bootstrapmodal");
            
            var outerDiv2 = new TagBuilder("div");
            outerDiv2.AddCssClass("modal-dialog");
            
            var outerDiv3 = new TagBuilder("div");
            outerDiv3.AddCssClass("modal-content");

            var outerDiv4 = new TagBuilder("div");
            outerDiv4.AddCssClass("modal-header");

            var button = new TagBuilder("button");
            button.AddCssClass("close");
            button.Attributes.Add("data-dismiss", "modal");

            var span = new TagBuilder("span");
            span.InnerHtml = "&times;";

            var outerDiv5 = new TagBuilder("div");
            outerDiv5.AddCssClass("modal - title");

            //jeste,

            // na gore

            // to powinno być git bo wrzucasz tekst title, które przychodzi z widoku// aaadbra juz nie no i on ci wrzuci tytuł jaki wpiszesz w widoku
            //wejdz w layout

            outerDiv5.InnerHtml = title.ToString();
            outerDiv4.InnerHtml = outerDiv5.ToString();
            button.InnerHtml = span.ToString();
            outerDiv4.InnerHtml = button.ToString();
            outerDiv4.InnerHtml = button.ToString();
            outerDiv3.InnerHtml = outerDiv4.ToString();
            outerDiv2.InnerHtml = outerDiv3.ToString();
            outerDiv1.InnerHtml = outerDiv2.ToString();

            // < div class="modal fade bootstrapmodal">
            //    <div class="modal-dialog">
            //        <div class="modal-content">
            //            <div class="modal-header">
            //                <button data-dismiss="modal" class="close"><span>&times;</span></button>
            //                <div class="modal-title">Dodaj ogłosznie</div>

            //            </div>
            //            <div class="modal-body">
            //                <p>@Html.Partial(body.ToString())</p>
            //            </div>
            //            <div class="modal-footer">
            //                <button type = "button" class="btn btn-secondary" data-dismiss="modal">Close</button>
            //                <button type = "button" class="btn btn-success">Save changes</button>
            //            </div>
            //        </div>
            //    </div>
            //</div>
            return outerDiv1.ToString();
        }

        public string ToHtmlString()
        {
            return "true";
        }
    }
}