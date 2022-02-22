using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;


namespace App.Pages.Extensions
{
    public static class MyIndexerForHtml
    {
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
