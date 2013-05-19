namespace Simple.Web
{
    using System;
    using System.Collections.Generic;
    using Authentication;
    using DependencyInjection;
    using MediaTypeHandling;

    /// <summary>
    /// Default implementation of <see cref="IConfiguration"/>.
    /// </summary>
    public sealed class Configuration : IConfiguration
    {
        private readonly DefaultAuthenticationProvider _defaultAuthenticationProvider = new DefaultAuthenticationProvider();
        private readonly IDictionary<string, string> _publicFileMappings =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private readonly IDictionary<string, string> _authenticatedFileMappings =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Gets a dictionary representing URLs which map to files but are only for authenticated users.
        /// </summary>
        public IDictionary<string, string> AuthenticatedFileMappings
        {
            get { return _authenticatedFileMappings; }
        }

        private readonly HashSet<string> _publicFolders = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private ISimpleContainer _container = new DefaultSimpleContainer();

        /// <summary>
        /// Gets a dictionary representing URLs which should be mapped directly to files.
        /// </summary>
        public IDictionary<string, string> PublicFileMappings
        {
            get { return _publicFileMappings; }
        }

        /// <summary>
        /// Gets the list of public folders.
        /// </summary>
        public ISet<string> PublicFolders
        {
            get { return _publicFolders; }
        }

        /// <summary>
        /// Gets or sets the IoC container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        public ISimpleContainer Container
        {
            get { return _container; }
            set { _container = value ?? new DefaultSimpleContainer(); }
        }

        /// <summary>
        /// Gets or sets the type of the handler which provides the login page for Forms-based Authentication.
        /// </summary>
        /// <value>
        /// The login page.
        /// </value>
        public Type LoginPage { get; set; }

        private IAuthenticationProvider _authenticationProvider;

        /// <summary>
        /// Gets or sets the authentication provider.
        /// </summary>
        /// <value>
        /// The authentication provider.
        /// </value>
        public IAuthenticationProvider AuthenticationProvider
        {
            get { return _authenticationProvider ?? _defaultAuthenticationProvider; }
            set { _authenticationProvider = value; }
        }

        public IMediaTypeHandler DefaultMediaTypeHandler { get; set; }
    }
}