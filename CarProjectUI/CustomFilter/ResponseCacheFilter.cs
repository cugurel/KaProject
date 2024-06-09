using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Shared;

namespace CarProjectUI.CustomFilter
{
    public class ResponseCacheFilter : ResponseCacheAttribute
    {
        public ResponseCacheFilter():base()
        {
            Location = ResponseCacheLocation.None;
            NoStore = true;
        }

    }
}
