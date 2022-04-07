using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;


namespace App.Pages.Extensions
{
    public static class MyEditorForHtml
    {
        public static IHtmlContent MyEditorFor<TModel, TResult>(
            this IHtmlHelper<TModel> html, Expression<Func<TModel,TResult>> e)
        {
            var s = htmlStrings(html, e);
            return new HtmlContentBuilder(s);
        }

        private static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e)
        {
            var l = new List<object>(); 
            l.Add(new HtmlString("<div class =\"row\">"));
                l.Add(new HtmlString("<dd class =\"col-sm-2\">"));
                    l.Add(h.LabelFor(e, null, new {htmlAttributes= new { @class = "control-label" }}));
                l.Add(new HtmlString("</dd>"));
                l.Add(new HtmlString("<dd class =\"col-sm-10\">"));
                    l.Add(h.EditorFor(e, null, new { htmlAttributes = new { @class = "form-control" } }));
                    l.Add(new HtmlString("&nbsp;"));
                    l.Add(new HtmlString("&nbsp;"));
                    l.Add(h.ValidationMessageFor(e, null, new { @class = "text-danger" }));
                l.Add(new HtmlString("</dd>"));
            l.Add(new HtmlString("</div>"));
            return l;

        }

        public static IHtmlContent MyViewerFor<TModel, TResult>(
            this IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> expression, TResult value) {
            var h = htmlStrings(html, expression, value);
            return new HtmlContentBuilder(h);
        }

        private static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> expression, TResult value) {
            var list = new List<object> {
                new HtmlString("<dl class=\"row\">"),
                new HtmlString("<dt class=\"col-sm-2\">"),
                html.DisplayNameFor(expression),
                new HtmlString("</dt>"),
                new HtmlString("<dd class=\"col-sm-10\">"),
                html.Raw(value),
                new HtmlString("</dd>"),
                new HtmlString("</dl>")
            };
            return list;
        }

    }
}
