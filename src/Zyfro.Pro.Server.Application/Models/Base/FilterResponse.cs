using System.Collections.Generic;

namespace Zyfro.Pro.Server.Application.Models.Base
{
    public class FilterResponse<TModel> where TModel : class
    {
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public IList<TModel> Data { get; set; } = new List<TModel>();
    }
}
