﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterClass9pmBatch.UserDefinedControls
{
    public static class CustomControl
    {
        public static IHtmlString MyLabel2(string content)
        {
            string htmlstring = String.Format("<label>{0}</label>", content);
            return new HtmlString(htmlstring);
        }

        public static IHtmlString createUrControl2(this HtmlHelper helper, string content)
        {
            string htmlstring = "<input type=" + content + ">";
            return new HtmlString(htmlstring);
        }


        }
    }