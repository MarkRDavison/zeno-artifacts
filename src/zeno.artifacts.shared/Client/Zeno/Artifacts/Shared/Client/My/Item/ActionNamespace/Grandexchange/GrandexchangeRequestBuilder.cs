// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
using Zeno.Artifacts.Shared.Client.My.Item.ActionNamespace.Grandexchange.Buy;
using Zeno.Artifacts.Shared.Client.My.Item.ActionNamespace.Grandexchange.Cancel;
using Zeno.Artifacts.Shared.Client.My.Item.ActionNamespace.Grandexchange.Sell;
namespace Zeno.Artifacts.Shared.Client.My.Item.ActionNamespace.Grandexchange
{
    /// <summary>
    /// Builds and executes requests for operations under \my\{name}\action\grandexchange
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class GrandexchangeRequestBuilder : BaseRequestBuilder
    {
        /// <summary>The buy property</summary>
        public global::Zeno.Artifacts.Shared.Client.My.Item.ActionNamespace.Grandexchange.Buy.BuyRequestBuilder Buy
        {
            get => new global::Zeno.Artifacts.Shared.Client.My.Item.ActionNamespace.Grandexchange.Buy.BuyRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The cancel property</summary>
        public global::Zeno.Artifacts.Shared.Client.My.Item.ActionNamespace.Grandexchange.Cancel.CancelRequestBuilder Cancel
        {
            get => new global::Zeno.Artifacts.Shared.Client.My.Item.ActionNamespace.Grandexchange.Cancel.CancelRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The sell property</summary>
        public global::Zeno.Artifacts.Shared.Client.My.Item.ActionNamespace.Grandexchange.Sell.SellRequestBuilder Sell
        {
            get => new global::Zeno.Artifacts.Shared.Client.My.Item.ActionNamespace.Grandexchange.Sell.SellRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Zeno.Artifacts.Shared.Client.My.Item.ActionNamespace.Grandexchange.GrandexchangeRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public GrandexchangeRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/my/{name}/action/grandexchange", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Zeno.Artifacts.Shared.Client.My.Item.ActionNamespace.Grandexchange.GrandexchangeRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public GrandexchangeRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/my/{name}/action/grandexchange", rawUrl)
        {
        }
    }
}
#pragma warning restore CS0618
