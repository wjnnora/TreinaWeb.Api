﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreinaWeb.MyApi.Api.HATEOAS
{
    public abstract class RestResource
    {
        public List<RestLink> Links { get; set; } = new List<RestLink>(); 
    }
}