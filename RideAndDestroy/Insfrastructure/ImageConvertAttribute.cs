using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace RideAndDestroy.Insfrastructure
{
    public class ImageConvertAttribute : Attribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            
        }
        
        public void OnResultExecuting(ResultExecutingContext context)
        {
            
        }
    }
}
