using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace firstAPI_2023_04_19.Filter
{
    public class SampleExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _hostEnvironment;

        public SampleExceptionFilter(IHostEnvironment hostEnvironment) =>
            _hostEnvironment = hostEnvironment;

        public void OnException(ExceptionContext context)
        {
            if (!_hostEnvironment.IsDevelopment())
            {
                // Don't display exception details unless running in Development.
                return ;
            }

            context.Result = new ContentResult
            {
                //Content = context.Exception.ToString()
                Content = "出現不明錯誤"
            };
        }
    }
}
