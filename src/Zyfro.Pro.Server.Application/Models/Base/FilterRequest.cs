﻿namespace Zyfro.Pro.Server.Application.Models.Base
{
    public class FilterRequest
    {
        public string Search { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; } = 1;
    }
}
