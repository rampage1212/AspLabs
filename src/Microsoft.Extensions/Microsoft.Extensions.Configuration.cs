namespace Microsoft.Extensions.Configuration
{
    public partial class ConfigurationBuilder : Microsoft.Extensions.Configuration.IConfigurationBuilder
    {
        public ConfigurationBuilder() { }
        public System.Collections.Generic.Dictionary<string, object> Properties { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.IEnumerable<Microsoft.Extensions.Configuration.IConfigurationSource> Sources { get { throw null; } }
        public Microsoft.Extensions.Configuration.IConfigurationBuilder Add(Microsoft.Extensions.Configuration.IConfigurationSource source) { throw null; }
        public Microsoft.Extensions.Configuration.IConfigurationRoot Build() { throw null; }
    }
    public partial class ConfigurationKeyComparer : System.Collections.Generic.IComparer<string>
    {
        public ConfigurationKeyComparer() { }
        public static Microsoft.Extensions.Configuration.ConfigurationKeyComparer Instance { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public int Compare(string x, string y) { throw null; }
    }
    public abstract partial class ConfigurationProvider : Microsoft.Extensions.Configuration.IConfigurationProvider
    {
        protected ConfigurationProvider() { }
        protected System.Collections.Generic.IDictionary<string, string> Data { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public virtual System.Collections.Generic.IEnumerable<string> GetChildKeys(System.Collections.Generic.IEnumerable<string> earlierKeys, string parentPath) { throw null; }
        public Microsoft.Extensions.Primitives.IChangeToken GetReloadToken() { throw null; }
        public virtual void Load() { }
        protected void OnReload() { }
        public virtual void Set(string key, string value) { }
        public virtual bool TryGet(string key, out string value) { value = default(string); throw null; }
    }
    public partial class ConfigurationReloadToken : Microsoft.Extensions.Primitives.IChangeToken
    {
        public ConfigurationReloadToken() { }
        public bool ActiveChangeCallbacks { get { throw null; } }
        public bool HasChanged { get { throw null; } }
        public void OnReload() { }
        public System.IDisposable RegisterChangeCallback(System.Action<object> callback, object state) { throw null; }
    }
    public partial class ConfigurationRoot : Microsoft.Extensions.Configuration.IConfiguration, Microsoft.Extensions.Configuration.IConfigurationRoot
    {
        public ConfigurationRoot(System.Collections.Generic.IList<Microsoft.Extensions.Configuration.IConfigurationProvider> providers) { }
        public string this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<Microsoft.Extensions.Configuration.IConfigurationSection> GetChildren() { throw null; }
        public Microsoft.Extensions.Primitives.IChangeToken GetReloadToken() { throw null; }
        public Microsoft.Extensions.Configuration.IConfigurationSection GetSection(string key) { throw null; }
        public void Reload() { }
    }
    public partial class ConfigurationSection : Microsoft.Extensions.Configuration.IConfiguration, Microsoft.Extensions.Configuration.IConfigurationSection
    {
        public ConfigurationSection(Microsoft.Extensions.Configuration.ConfigurationRoot root, string path) { }
        public string this[string key] { get { throw null; } set { } }
        public string Key { get { throw null; } }
        public string Path { get { throw null; } }
        public string Value { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<Microsoft.Extensions.Configuration.IConfigurationSection> GetChildren() { throw null; }
        public Microsoft.Extensions.Primitives.IChangeToken GetReloadToken() { throw null; }
        public Microsoft.Extensions.Configuration.IConfigurationSection GetSection(string key) { throw null; }
    }
    public static partial class MemoryConfigurationBuilderExtensions
    {
        public static Microsoft.Extensions.Configuration.IConfigurationBuilder AddInMemoryCollection(this Microsoft.Extensions.Configuration.IConfigurationBuilder configurationBuilder) { throw null; }
        public static Microsoft.Extensions.Configuration.IConfigurationBuilder AddInMemoryCollection(this Microsoft.Extensions.Configuration.IConfigurationBuilder configurationBuilder, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, string>> initialData) { throw null; }
    }
}
namespace Microsoft.Extensions.Configuration.Memory
{
    public partial class MemoryConfigurationProvider : Microsoft.Extensions.Configuration.ConfigurationProvider, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, string>>, System.Collections.IEnumerable
    {
        public MemoryConfigurationProvider(Microsoft.Extensions.Configuration.Memory.MemoryConfigurationSource source) { }
        public void Add(string key, string value) { }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, string>> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MemoryConfigurationSource : Microsoft.Extensions.Configuration.IConfigurationSource
    {
        public MemoryConfigurationSource() { }
        public System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, string>> InitialData { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public Microsoft.Extensions.Configuration.IConfigurationProvider Build(Microsoft.Extensions.Configuration.IConfigurationBuilder builder) { throw null; }
    }
}
