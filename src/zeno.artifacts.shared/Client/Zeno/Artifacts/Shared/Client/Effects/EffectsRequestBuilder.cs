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
using Zeno.Artifacts.Shared.Client.Effects.Item;
using Zeno.Artifacts.Shared.Client.Models;
namespace Zeno.Artifacts.Shared.Client.Effects
{
    /// <summary>
    /// Builds and executes requests for operations under \effects
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class EffectsRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Gets an item from the zeno.artifacts.shared.client.effects.item collection</summary>
        /// <param name="position">The code of the achievement.</param>
        /// <returns>A <see cref="global::Zeno.Artifacts.Shared.Client.Effects.Item.WithCodeItemRequestBuilder"/></returns>
        public global::Zeno.Artifacts.Shared.Client.Effects.Item.WithCodeItemRequestBuilder this[string position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                urlTplParams.Add("code", position);
                return new global::Zeno.Artifacts.Shared.Client.Effects.Item.WithCodeItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Zeno.Artifacts.Shared.Client.Effects.EffectsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public EffectsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/effects{?page*,size*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Zeno.Artifacts.Shared.Client.Effects.EffectsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public EffectsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/effects{?page*,size*}", rawUrl)
        {
        }
        /// <summary>
        /// List of all effects. Effects are used by equipment, tools, runes, consumables and monsters. An effect is an action that produces an effect on the game.
        /// </summary>
        /// <returns>A <see cref="global::Zeno.Artifacts.Shared.Client.Models.DataPage_EffectSchema_"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::Zeno.Artifacts.Shared.Client.Models.DataPage_EffectSchema_?> GetAsync(Action<RequestConfiguration<global::Zeno.Artifacts.Shared.Client.Effects.EffectsRequestBuilder.EffectsRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::Zeno.Artifacts.Shared.Client.Models.DataPage_EffectSchema_> GetAsync(Action<RequestConfiguration<global::Zeno.Artifacts.Shared.Client.Effects.EffectsRequestBuilder.EffectsRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            return await RequestAdapter.SendAsync<global::Zeno.Artifacts.Shared.Client.Models.DataPage_EffectSchema_>(requestInfo, global::Zeno.Artifacts.Shared.Client.Models.DataPage_EffectSchema_.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// List of all effects. Effects are used by equipment, tools, runes, consumables and monsters. An effect is an action that produces an effect on the game.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Zeno.Artifacts.Shared.Client.Effects.EffectsRequestBuilder.EffectsRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Zeno.Artifacts.Shared.Client.Effects.EffectsRequestBuilder.EffectsRequestBuilderGetQueryParameters>> requestConfiguration = default)
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
        /// <returns>A <see cref="global::Zeno.Artifacts.Shared.Client.Effects.EffectsRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::Zeno.Artifacts.Shared.Client.Effects.EffectsRequestBuilder WithUrl(string rawUrl)
        {
            return new global::Zeno.Artifacts.Shared.Client.Effects.EffectsRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// List of all effects. Effects are used by equipment, tools, runes, consumables and monsters. An effect is an action that produces an effect on the game.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class EffectsRequestBuilderGetQueryParameters 
        {
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
        public partial class EffectsRequestBuilderGetRequestConfiguration : RequestConfiguration<global::Zeno.Artifacts.Shared.Client.Effects.EffectsRequestBuilder.EffectsRequestBuilderGetQueryParameters>
        {
        }
    }
}
#pragma warning restore CS0618
