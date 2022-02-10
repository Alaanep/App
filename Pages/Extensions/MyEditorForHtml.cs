using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;


namespace App.Pages.Extensions
{
    public static class MyEditorForHtml
    {
        public static IHtmlContent MyEditorForCreateAndEdit<TModel, TResult>(
            this IHtmlHelper<TModel> h, Expression<Func<TModel,TResult>> e)
        {
            var s = htmlStringsForCreateAndEdit(h, e);
            return new HtmlContentBuilder(s);
        }

        private static List<object> htmlStringsForCreateAndEdit<TModel, TResult>(IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e)
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

        public static IHtmlContent MyEditorForDeleteAndDetails<TModel, TResult>(
            this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e)
        {
            var s = htmlStringsForDeleteAndDetails(h, e);
            return new HtmlContentBuilder(s);
        }

        private static List<object> htmlStringsForDeleteAndDetails<TModel, TResult>(IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e)
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

        public static IHtmlContent MyEditorForIndexTableHead<TModel, TResult>(
            this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e)
        {
            var s = htmlStringsForIndexTableHead(h, e);
            return new HtmlContentBuilder(s);
        }

        private static List<object> htmlStringsForIndexTableHead<TModel, TResult>(IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e)
        {
            var l = new List<object>();
                l.Add(new HtmlString("<th>"));
                l.Add(h.DisplayNameFor(e));
                l.Add(new HtmlString("</th>"));
                return l;
        }

        public static IHtmlContent MyEditorForIndexTableBody<TModel, TResult>(
            this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e)
        {
            var s = htmlStringsForIndexTableBody(h, e);
            return new HtmlContentBuilder(s);
        }

        private static List<object> htmlStringsForIndexTableBody<TModel, TResult>(IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e)
        {
            var l = new List<object>();
            l.Add(new HtmlString("<td>"));
            l.Add(h.DisplayFor(e));
            l.Add(new HtmlString("</td>"));
            return l;
        }


    }
}
