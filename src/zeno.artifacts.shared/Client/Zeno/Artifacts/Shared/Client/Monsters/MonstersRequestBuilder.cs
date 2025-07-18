// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
using Zeno.Artifacts.Shared.Client.Models;
using Zeno.Artifacts.Shared.Client.Monsters.Item;
namespace Zeno.Artifacts.Shared.Client.Monsters
{
    /// <summary>
    /// Builds and executes requests for operations under \monsters
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class MonstersRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Gets an item from the zeno.artifacts.shared.client.monsters.item collection</summary>
        /// <param name="position">The code of the monster.</param>
        /// <returns>A <see cref="global::Zeno.Artifacts.Shared.Client.Monsters.Item.WithCodeItemRequestBuilder"/></returns>
        public global::Zeno.Artifacts.Shared.Client.Monsters.Item.WithCodeItemRequestBuilder this[string position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                urlTplParams.Add("code", position);
                return new global::Zeno.Artifacts.Shared.Client.Monsters.Item.WithCodeItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Zeno.Artifacts.Shared.Client.Monsters.MonstersRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public MonstersRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/monsters{?drop*,max_level*,min_level*,name*,page*,size*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Zeno.Artifacts.Shared.Client.Monsters.MonstersRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public MonstersRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/monsters{?drop*,max_level*,min_level*,name*,page*,size*}", rawUrl)
        {
        }
        /// <summary>
        /// Fetch monsters details.
        /// </summary>
        /// <returns>A <see cref="global::Zeno.Artifacts.Shared.Client.Models.DataPage_MonsterSchema_"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::Zeno.Artifacts.Shared.Client.Models.DataPage_MonsterSchema_?> GetAsync(Action<RequestConfiguration<global::Zeno.Artifacts.Shared.Client.Monsters.MonstersRequestBuilder.MonstersRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::Zeno.Artifacts.Shared.Client.Models.DataPage_MonsterSchema_> GetAsync(Action<RequestConfiguration<global::Zeno.Artifacts.Shared.Client.Monsters.MonstersRequestBuilder.MonstersRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            return await RequestAdapter.SendAsync<global::Zeno.Artifacts.Shared.Client.Models.DataPage_MonsterSchema_>(requestInfo, global::Zeno.Artifacts.Shared.Client.Models.DataPage_MonsterSchema_.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Fetch monsters details.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Zeno.Artifacts.Shared.Client.Monsters.MonstersRequestBuilder.MonstersRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Zeno.Artifacts.Shared.Client.Monsters.MonstersRequestBuilder.MonstersRequestBuilderGetQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="global::Zeno.Artifacts.Shared.Client.Monsters.MonstersRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::Zeno.Artifacts.Shared.Client.Monsters.MonstersRequestBuilder WithUrl(string rawUrl)
        {
            return new global::Zeno.Artifacts.Shared.Client.Monsters.MonstersRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Fetch monsters details.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class MonstersRequestBuilderGetQueryParameters 
        {
            /// <summary>Item code of the drop.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("drop")]
            public string? Drop { get; set; }
#nullable restore
#else
            [QueryParameter("drop")]
            public string Drop { get; set; }
#endif
            /// <summary>Monster maximum level.</summary>
            [QueryParameter("max_level")]
            public int? MaxLevel { get; set; }
            /// <summary>Monster minimum level.</summary>
            [QueryParameter("min_level")]
            public int? MinLevel { get; set; }
            /// <summary>Name of the monster.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("name")]
            public string? Name { get; set; }
#nullable restore
#else
            [QueryParameter("name")]
            public string Name { get; set; }
#endif
            /// <summary>Page number</summary>
            [QueryParameter("page")]
            public int? Page { get; set; }
            /// <summary>Page size</summary>
            [QueryParameter("size")]
            public int? Size { get; set; }
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class MonstersRequestBuilderGetRequestConfiguration : RequestConfiguration<global::Zeno.Artifacts.Shared.Client.Monsters.MonstersRequestBuilder.MonstersRequestBuilderGetQueryParameters>
        {
        }
    }
}
#pragma warning restore CS0618
