using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AdminPortal.Models
{
    public static class ButtonExtensions
    {
        public static MvcHtmlString DisplayAddButton<TModel>(this HtmlHelper<TModel> html, string urlAction)
        {
            var addButton = new Button
            {
                Icon = Icon.plus,
                Style = ButtonStyle.Primary,
                Text = "Add",
                UrlAction = urlAction
            };
            return html.DisplayFor(_ => addButton);
        }

        public static MvcHtmlString DisplayBackButton<TModel>(this HtmlHelper<TModel> html, string urlAction)
        {
            var backButton = new Button
            {
                Icon = Icon.chevron_left,
                Style = ButtonStyle.Light,
                Text = "",
                UrlAction = urlAction
            };
            return html.DisplayFor(_ => backButton);
        }

        public static MvcHtmlString DisplayEditButton<TModel>(this HtmlHelper<TModel> html, string urlAction)
        {
            var backButton = new Button
            {
                Icon = Icon.pencil,
                Style = ButtonStyle.Primary,
                Text = "Edit",
                UrlAction = urlAction
            };
            return html.DisplayFor(_ => backButton);
        }

        public static MvcHtmlString DisplayDeleteButton<TModel>(this HtmlHelper<TModel> html, string urlAction)
        {
            var backButton = new Button
            {
                Icon = Icon.trash,
                Style = ButtonStyle.Danger,
                Text = "Delete",
                UrlAction = urlAction
            };
            return html.DisplayFor(_ => backButton);
        }
    }
}