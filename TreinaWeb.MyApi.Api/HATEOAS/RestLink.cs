﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreinaWeb.MyApi.Api.HATEOAS
{
    public class RestLink
    {
        public string Rel { get; set; }
        public string Href { get; set; }
    }
}