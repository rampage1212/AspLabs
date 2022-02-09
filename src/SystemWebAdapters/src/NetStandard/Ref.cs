namespace System.Web
{
    public partial class HttpBrowserCapabilities
    {
        public HttpBrowserCapabilities() { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
    }
    public partial class HttpContext
    {
        internal HttpContext() { }
        public static System.Web.HttpContext Current { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public System.Web.HttpRequest Request { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
    }
    public partial class HttpContextBase : System.IServiceProvider
    {
        protected HttpContextBase() { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
        public virtual System.Web.HttpRequestBase Request { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual System.Web.HttpResponseBase Response { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual object GetService(System.Type serviceType) { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
    }
    public partial class HttpCookie
    {
        public HttpCookie() { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
        public string Domain { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} set { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public System.DateTime Expires { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} set { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public bool HttpOnly { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} set { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public string Name { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} set { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public System.Web.SameSiteMode SameSite { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} set { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public bool Secure { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} set { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public string Value { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} set { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public System.Collections.Specialized.NameValueCollection Values { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
    }
    public sealed partial class HttpCookieCollection : System.Collections.Specialized.NameObjectCollectionBase
    {
        public HttpCookieCollection() { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
        public string[] AllKeys { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public System.Web.HttpCookie this[int index] { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public System.Web.HttpCookie this[string name] { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public void Add(System.Web.HttpCookie cookie) { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
        public void Clear() { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
        public System.Web.HttpCookie Get(int index) { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
        public System.Web.HttpCookie Get(string name) { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
        public string GetKey(int index) { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
        public void Remove(string name) { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
        public void Set(System.Web.HttpCookie cookie) { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
    }
    public partial class HttpRequest
    {
        public HttpRequest() { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
        public string UserAgent { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
    }
    public abstract partial class HttpRequestBase
    {
        protected HttpRequestBase() { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
        public string ApplicationPath { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public string AppRelativeCurrentExecutionFilePath { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public System.Web.HttpBrowserCapabilities Browser { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual System.Text.Encoding ContentEncoding { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual int ContentLength { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual string ContentType { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} set { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual System.Web.HttpCookieCollection Cookies { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual System.Collections.Specialized.NameValueCollection Headers { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual string HttpMethod { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual System.IO.Stream InputStream { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual bool IsAuthenticated { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual bool IsLocal { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public bool IsSecureConnection { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual System.Security.Principal.IIdentity LogonUserIdentity { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual string Path { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual System.Collections.Specialized.NameValueCollection QueryString { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual string RawUrl { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual string RequestType { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public System.Collections.Specialized.NameValueCollection ServerVariables { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual int TotalBytes { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual System.Uri Url { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual System.Uri UrlReferrer { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual string UserAgent { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual string UserHostAddress { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual string UserHostName { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual string[] UserLanguages { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual void Abort() { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
        public virtual byte[] BinaryRead(int count) { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
    }
    public partial class HttpResponseBase
    {
        public HttpResponseBase() { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
        public string Charset { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} set { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual string ContentType { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} set { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual System.Web.HttpCookieCollection Cookies { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} set { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual System.Collections.Specialized.NameValueCollection Headers { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual bool IsClientConnected { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual System.IO.TextWriter Output { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} set { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual System.IO.Stream OutputStream { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual int StatusCode { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} set { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual string StatusDescription { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} set { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual bool SuppressContent { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} set { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual bool TrySkipIisCustomErrors { get { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} set { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");} }
        public virtual void Abort() { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
        public virtual void AddHeader(string name, string value) { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
        public void AppendHeader(string name, string value) { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
        public void Clear() { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
        public void ClearContent() { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
        public void End() { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
        public virtual void SetCookie(System.Web.HttpCookie cookie) { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
        public virtual void Write(char ch) { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
        public virtual void Write(object obj) { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
        public virtual void Write(string s) { throw new System.PlatformNotSupportedException("Only support when running on ASP.NET Core or System.Web");}
    }
    public enum SameSiteMode
    {
    }
}
