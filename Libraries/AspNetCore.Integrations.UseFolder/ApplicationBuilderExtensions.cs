using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Extension methods for Folder Middleware.
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Enables static file serving for the given request path.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="requestPath">The relative request path.</param>
        /// <param name="contentRootPath">The content root path.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseFolder(this IApplicationBuilder app, string requestPath, string contentRootPath)
        {
            var fileProvider = new PhysicalFileProvider(Path.Combine(contentRootPath, requestPath));
            var options = new StaticFileOptions
            {
                RequestPath = string.Concat("/", requestPath),
                FileProvider = fileProvider
            };
            app.UseStaticFiles(options);
            return app;
        }
    }
}
