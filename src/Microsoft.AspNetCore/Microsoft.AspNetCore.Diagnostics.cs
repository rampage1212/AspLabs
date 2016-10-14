namespace Microsoft.AspNetCore.Builder
{
    public static partial class DeveloperExceptionPageExtensions
    {
        public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseDeveloperExceptionPage(this Microsoft.AspNetCore.Builder.IApplicationBuilder app) { throw null; }
        public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseDeveloperExceptionPage(this Microsoft.AspNetCore.Builder.IApplicationBuilder app, Microsoft.AspNetCore.Builder.DeveloperExceptionPageOptions options) { throw null; }
    }
    public partial class DeveloperExceptionPageOptions
    {
        public DeveloperExceptionPageOptions() { }
        public Microsoft.Extensions.FileProviders.IFileProvider FileProvider { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public int SourceCodeLineCount { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public static partial class ExceptionHandlerExtensions
    {
        public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseExceptionHandler(this Microsoft.AspNetCore.Builder.IApplicationBuilder app) { throw null; }
        public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseExceptionHandler(this Microsoft.AspNetCore.Builder.IApplicationBuilder app, Microsoft.AspNetCore.Builder.ExceptionHandlerOptions options) { throw null; }
        public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseExceptionHandler(this Microsoft.AspNetCore.Builder.IApplicationBuilder app, System.Action<Microsoft.AspNetCore.Builder.IApplicationBuilder> configure) { throw null; }
        public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseExceptionHandler(this Microsoft.AspNetCore.Builder.IApplicationBuilder app, string errorHandlingPath) { throw null; }
    }
    public partial class ExceptionHandlerOptions
    {
        public ExceptionHandlerOptions() { }
        public Microsoft.AspNetCore.Http.RequestDelegate ExceptionHandler { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public Microsoft.AspNetCore.Http.PathString ExceptionHandlingPath { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public static partial class StatusCodePagesExtensions
    {
        public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseStatusCodePages(this Microsoft.AspNetCore.Builder.IApplicationBuilder app) { throw null; }
        public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseStatusCodePages(this Microsoft.AspNetCore.Builder.IApplicationBuilder app, Microsoft.AspNetCore.Builder.StatusCodePagesOptions options) { throw null; }
        public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseStatusCodePages(this Microsoft.AspNetCore.Builder.IApplicationBuilder app, System.Action<Microsoft.AspNetCore.Builder.IApplicationBuilder> configuration) { throw null; }
        public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseStatusCodePages(this Microsoft.AspNetCore.Builder.IApplicationBuilder app, System.Func<Microsoft.AspNetCore.Diagnostics.StatusCodeContext, System.Threading.Tasks.Task> handler) { throw null; }
        public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseStatusCodePages(this Microsoft.AspNetCore.Builder.IApplicationBuilder app, string contentType, string bodyFormat) { throw null; }
        public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseStatusCodePagesWithRedirects(this Microsoft.AspNetCore.Builder.IApplicationBuilder app, string locationFormat) { throw null; }
        public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseStatusCodePagesWithReExecute(this Microsoft.AspNetCore.Builder.IApplicationBuilder app, string pathFormat, string queryFormat=null) { throw null; }
    }
    public partial class StatusCodePagesOptions
    {
        public StatusCodePagesOptions() { }
        public System.Func<Microsoft.AspNetCore.Diagnostics.StatusCodeContext, System.Threading.Tasks.Task> HandleAsync { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public static partial class WelcomePageExtensions
    {
        public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseWelcomePage(this Microsoft.AspNetCore.Builder.IApplicationBuilder app) { throw null; }
        public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseWelcomePage(this Microsoft.AspNetCore.Builder.IApplicationBuilder app, Microsoft.AspNetCore.Builder.WelcomePageOptions options) { throw null; }
        public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseWelcomePage(this Microsoft.AspNetCore.Builder.IApplicationBuilder app, Microsoft.AspNetCore.Http.PathString path) { throw null; }
        public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseWelcomePage(this Microsoft.AspNetCore.Builder.IApplicationBuilder app, string path) { throw null; }
    }
    public partial class WelcomePageOptions
    {
        public WelcomePageOptions() { }
        public Microsoft.AspNetCore.Http.PathString Path { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
}
namespace Microsoft.AspNetCore.Diagnostics
{
    public partial class DeveloperExceptionPageMiddleware
    {
        public DeveloperExceptionPageMiddleware(Microsoft.AspNetCore.Http.RequestDelegate next, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.DeveloperExceptionPageOptions> options, Microsoft.Extensions.Logging.ILoggerFactory loggerFactory, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment, System.Diagnostics.DiagnosticSource diagnosticSource) { }
        public System.Threading.Tasks.Task Invoke(Microsoft.AspNetCore.Http.HttpContext context) { throw null; }
    }
    public partial class ExceptionHandlerFeature : Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature
    {
        public ExceptionHandlerFeature() { }
        public System.Exception Error { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public partial class ExceptionHandlerMiddleware
    {
        public ExceptionHandlerMiddleware(Microsoft.AspNetCore.Http.RequestDelegate next, Microsoft.Extensions.Logging.ILoggerFactory loggerFactory, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.ExceptionHandlerOptions> options, System.Diagnostics.DiagnosticSource diagnosticSource) { }
        public System.Threading.Tasks.Task Invoke(Microsoft.AspNetCore.Http.HttpContext context) { throw null; }
    }
    public partial class StatusCodeContext
    {
        public StatusCodeContext(Microsoft.AspNetCore.Http.HttpContext context, Microsoft.AspNetCore.Builder.StatusCodePagesOptions options, Microsoft.AspNetCore.Http.RequestDelegate next) { }
        public Microsoft.AspNetCore.Http.HttpContext HttpContext { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public Microsoft.AspNetCore.Http.RequestDelegate Next { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public Microsoft.AspNetCore.Builder.StatusCodePagesOptions Options { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public partial class StatusCodePagesFeature : Microsoft.AspNetCore.Diagnostics.IStatusCodePagesFeature
    {
        public StatusCodePagesFeature() { }
        public bool Enabled { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public partial class StatusCodePagesMiddleware
    {
        public StatusCodePagesMiddleware(Microsoft.AspNetCore.Http.RequestDelegate next, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.StatusCodePagesOptions> options) { }
        public System.Threading.Tasks.Task Invoke(Microsoft.AspNetCore.Http.HttpContext context) { throw null; }
    }
    public partial class StatusCodeReExecuteFeature : Microsoft.AspNetCore.Diagnostics.IStatusCodeReExecuteFeature
    {
        public StatusCodeReExecuteFeature() { }
        public string OriginalPath { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string OriginalPathBase { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string OriginalQueryString { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public partial class WelcomePageMiddleware
    {
        public WelcomePageMiddleware(Microsoft.AspNetCore.Http.RequestDelegate next, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.WelcomePageOptions> options) { }
        public System.Threading.Tasks.Task Invoke(Microsoft.AspNetCore.Http.HttpContext context) { throw null; }
    }
}
namespace Microsoft.AspNetCore.Diagnostics.Views
{
    public partial class CompilationErrorPage : Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView
    {
        public CompilationErrorPage() { }
        public Microsoft.AspNetCore.Diagnostics.Views.CompilationErrorPageModel Model { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public override System.Threading.Tasks.Task ExecuteAsync() { throw null; }
    }
    public partial class CompilationErrorPageModel
    {
        public CompilationErrorPageModel() { }
        public System.Collections.Generic.IList<Microsoft.AspNetCore.Diagnostics.Views.ErrorDetails> ErrorDetails { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public Microsoft.AspNetCore.Builder.DeveloperExceptionPageOptions Options { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public partial class ErrorDetails
    {
        public ErrorDetails() { }
        public System.Exception Error { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Diagnostics.Views.StackFrame> StackFrames { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public partial class ErrorPage : Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView
    {
        public ErrorPage() { }
        public ErrorPage(Microsoft.AspNetCore.Diagnostics.Views.ErrorPageModel model) { }
        public Microsoft.AspNetCore.Diagnostics.Views.ErrorPageModel Model { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public override System.Threading.Tasks.Task ExecuteAsync() { throw null; }
    }
    public partial class ErrorPageModel
    {
        public ErrorPageModel() { }
        public Microsoft.AspNetCore.Http.IRequestCookieCollection Cookies { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Diagnostics.Views.ErrorDetails> ErrorDetails { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IDictionary<string, Microsoft.Extensions.Primitives.StringValues> Headers { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public Microsoft.AspNetCore.Builder.DeveloperExceptionPageOptions Options { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public Microsoft.AspNetCore.Http.IQueryCollection Query { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public partial class StackFrame
    {
        public StackFrame() { }
        public System.Collections.Generic.IEnumerable<string> ContextCode { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string ErrorDetails { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string File { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Function { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public int Line { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IEnumerable<string> PostContextCode { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IEnumerable<string> PreContextCode { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public int PreContextLine { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public partial class StackFrameInfo
    {
        public StackFrameInfo() { }
        public System.Collections.Generic.IEnumerable<string> ContextCode { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string ErrorDetails { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string File { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Function { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public int Line { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IEnumerable<string> PostContextCode { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IEnumerable<string> PreContextCode { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public int PreContextLine { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public partial class WelcomePage : Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView
    {
        public WelcomePage() { }
        public override System.Threading.Tasks.Task ExecuteAsync() { throw null; }
    }
}
namespace Microsoft.AspNetCore.DiagnosticsViewPage.Views
{
    public partial class AttributeValue
    {
        public AttributeValue(string prefix, object value, bool literal) { }
        public bool Literal { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Prefix { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public object Value { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue FromTuple(System.Tuple<string, object, bool> value) { throw null; }
        public static Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue FromTuple(System.Tuple<string, string, bool> value) { throw null; }
        public static implicit operator Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue (System.Tuple<string, object, bool> value) { throw null; }
    }
    public abstract partial class BaseView
    {
        protected BaseView() { }
        protected Microsoft.AspNetCore.Http.HttpContext Context { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        protected System.Text.Encodings.Web.HtmlEncoder HtmlEncoder { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        protected System.Text.Encodings.Web.JavaScriptEncoder JavaScriptEncoder { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        protected System.IO.StreamWriter Output { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        protected Microsoft.AspNetCore.Http.HttpRequest Request { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        protected Microsoft.AspNetCore.Http.HttpResponse Response { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        protected System.Text.Encodings.Web.UrlEncoder UrlEncoder { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        protected void BeginWriteAttribute(string name, string begining, int startPosition, string ending, int endPosition, int thingy) { }
        protected void EndWriteAttribute() { }
        public abstract System.Threading.Tasks.Task ExecuteAsync();
        public System.Threading.Tasks.Task ExecuteAsync(Microsoft.AspNetCore.Http.HttpContext context) { throw null; }
        protected string HtmlEncodeAndReplaceLineBreaks(string input) { throw null; }
        protected void Write(Microsoft.AspNetCore.DiagnosticsViewPage.Views.HelperResult result) { }
        protected void Write(object value) { }
        protected void Write(string value) { }
        protected void WriteAttributeTo(System.IO.TextWriter writer, string name, string leader, string trailer, params Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue[] values) { }
        protected void WriteAttributeValue(string thingy, int startPostion, object value, int endValue, int dealyo, bool yesno) { }
        protected void WriteLiteral(object value) { }
        protected void WriteLiteral(string value) { }
        protected void WriteLiteralTo(System.IO.TextWriter writer, object value) { }
        protected void WriteLiteralTo(System.IO.TextWriter writer, string value) { }
        protected void WriteTo(System.IO.TextWriter writer, object value) { }
        protected void WriteTo(System.IO.TextWriter writer, string value) { }
    }
    public partial class HelperResult
    {
        public HelperResult(System.Action<System.IO.TextWriter> action) { }
        public System.Action<System.IO.TextWriter> WriteAction { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public void WriteTo(System.IO.TextWriter writer) { }
    }
}
