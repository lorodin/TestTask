using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TestTask.Models;

namespace TestTask.Helpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PageInfoViewModel pageInfo, Func<int, string> pageUrl)
        {
            if (pageInfo.TotalPages <= 1)
            {
                return MvcHtmlString.Empty;
            }

            StringBuilder result = new StringBuilder();


            if(pageInfo.PageNumber > 1)
            {
                var tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(pageInfo.PageNumber - 1));
                tag.InnerHtml = "<";
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }

            for(int i = 1; i <= pageInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if(i == pageInfo.PageNumber)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }

            if (pageInfo.PageNumber != pageInfo.TotalPages)
            {
                var tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(pageInfo.PageNumber + 1));
                tag.InnerHtml = ">";
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }

            return MvcHtmlString.Create(result.ToString());
        }
    }
}