using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace App.Pages.Extensions
{
    public static class MyViewerForHtml
    {
        public static IHtmlContent MyViewerFor<TModel, TResult>(
            this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e)
        {
            var s = htmlStrings(h, e);
            return new HtmlContentBuilder(s);
        }
        private static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e)
        {
            var l = new List<object>();
            l.Add(new HtmlString("<dt class =\"col-sm-2\">"));
            l.Add(h.DisplayNameFor(e));
            l.Add(new HtmlString("</dt>"));
            l.Add(new HtmlString("<dd class =\"col-sm-10\">"));
            l.Add(h.DisplayFor(e));
            l.Add(new HtmlString("</dd>"));
            return l;
        }

        public static IHtmlContent MyViewerFor<TModel, TResult>(
            this IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> expression, dynamic value) {
            var h = htmlStrings(html, expression, value);
            return new HtmlContentBuilder(h);
        }

        private static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> expression, dynamic value) {
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
