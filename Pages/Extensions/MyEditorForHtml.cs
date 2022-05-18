using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;


namespace App.Pages.Extensions
{
    public static class MyEditorForHtml {
        public static IHtmlContent MyEditorFor<TModel, TResult>(
            this IHtmlHelper<TModel> html, Expression<Func<TModel,TResult>> e) {
            var s = htmlStrings(html, e);
            return new HtmlContentBuilder(s);
        }

        private static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e)
        {
            var l = new List<object> {
                new HtmlString("<div class =\"row\">"),
                new HtmlString("<dd class =\"col-sm-2\">"),
                h.LabelFor(e, null, new { htmlAttributes = new { @class = "control-label" } }),
                new HtmlString("</dd>"),
                new HtmlString("<dd class =\"col-sm-10\">"),
                h.EditorFor(e, null, new { htmlAttributes = new { @class = "form-control" } }),
                new HtmlString("&nbsp;"),
                new HtmlString("&nbsp;"),
                h.ValidationMessageFor(e, null, new { @class = "text-danger" }),
                new HtmlString("</dd>"),
                new HtmlString("</div>")
            };
            return l;
        }
    }
}
