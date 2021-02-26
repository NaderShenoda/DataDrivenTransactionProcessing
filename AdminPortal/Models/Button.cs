using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPortal.Models
{
    public sealed class Button
    {
        public ButtonStyle Style { get; set; }

        public Icon Icon { get; set; }

        public string UrlAction { get; set; }

        public string Text { get; set; }
    }
}