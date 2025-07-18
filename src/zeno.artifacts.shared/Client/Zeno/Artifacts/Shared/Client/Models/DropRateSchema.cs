// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace Zeno.Artifacts.Shared.Client.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class DropRateSchema : IAdditionalDataHolder, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Item code.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Code { get; set; }
#nullable restore
#else
        public string Code { get; set; }
#endif
        /// <summary>Maximum quantity.</summary>
        public int? MaxQuantity { get; set; }
        /// <summary>Minimum quantity.</summary>
        public int? MinQuantity { get; set; }
        /// <summary>Chance rate. (1/rate)</summary>
        public int? Rate { get; set; }
        /// <summary>
        /// Instantiates a new <see cref="global::Zeno.Artifacts.Shared.Client.Models.DropRateSchema"/> and sets the default values.
        /// </summary>
        public DropRateSchema()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::Zeno.Artifacts.Shared.Client.Models.DropRateSchema"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::Zeno.Artifacts.Shared.Client.Models.DropRateSchema CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::Zeno.Artifacts.Shared.Client.Models.DropRateSchema();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "code", n => { Code = n.GetStringValue(); } },
                { "max_quantity", n => { MaxQuantity = n.GetIntValue(); } },
                { "min_quantity", n => { MinQuantity = n.GetIntValue(); } },
                { "rate", n => { Rate = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("code", Code);
            writer.WriteIntValue("max_quantity", MaxQuantity);
            writer.WriteIntValue("min_quantity", MinQuantity);
            writer.WriteIntValue("rate", Rate);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
#pragma warning restore CS0618
