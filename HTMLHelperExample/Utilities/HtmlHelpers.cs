using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace HTMLHelperExample.Utilities
{
    public static class HtmlHelpers
    {
        //random palette from https://color.adobe.com/
        private static readonly List<string> ColourList = new List<string> { "#99ACDB", "#535B73", "#5D83C4", "#393E56", "#B9DEFF" };

        public static MvcHtmlString StackedGraph(this HtmlHelper htmlHelper, Dictionary<string, List<int>> data)
        {
            var html = new StringBuilder("<table class=\"table\">");

            foreach (var item in data)
            {
                html.Append("<tr>");
                html.Append("<td class=\"bargraph-key vert-align\">" + item.Key + "</td>");
                html.Append("<td class=\"bargraph\">");

                var index = 0;
                foreach (var graphItem in item.Value)
                {
                    //loops the colour palette once it runs out
                    if (index == ColourList.Count)
                        index = 0;

                    //actual stacking here. last item will have the rounded border effect.
                    html.Append(string.Format("<span class=\"bargraph-item {0}\" style=\"width: {1}%; background: {2}\"></span>",
                        graphItem == item.Value.Last() ? "last" : "", graphItem, ColourList[index++]));

                }

                //prints the totals
                html.Append("<span class=\"total-text\">" + item.Value.Sum(m => m) + "</span>");

                html.Append("</td>");
                html.Append("</tr>");
            }


            html.Append("</table>");

            return MvcHtmlString.Create(html.ToString());

        }
    }
}