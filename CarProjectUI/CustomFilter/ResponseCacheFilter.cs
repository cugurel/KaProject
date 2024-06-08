﻿using Microsoft.AspNetCore.Mvc;

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
