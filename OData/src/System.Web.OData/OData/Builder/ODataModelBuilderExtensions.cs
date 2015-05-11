// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System.ComponentModel;

namespace System.Web.OData.Builder
{
    /// <summary>
    /// Provides extension methods for the <see cref="ODataModelBuilder"/> class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ODataModelBuilderExtensions
    {
        /// <summary>
        /// Enable lower camel case with given <see cref="NameResolverOptions"/>,
        /// if left out defaults to:
        /// NameResolverOptions.ProcessReflectedPropertyNames |
        /// NameResolverOptions.ProcessDataMemberAttributePropertyNames |
        /// NameResolverOptions.ProcessExplicitPropertyNames.
        /// </summary>
        /// <param name="builder">The <see cref="ODataModelBuilder"/> to be enabled with lower camel case.</param>
        /// <param name="options">The <see cref="NameResolverOptions"/> for the lower camel case.</param>
        /// <returns>Returns itself so that multiple calls can be chained.</returns>
        public static T EnableLowerCamelCase<T>(
            this T builder,
            NameResolverOptions options = NameResolverOptions.ProcessReflectedPropertyNames |
                NameResolverOptions.ProcessDataMemberAttributePropertyNames |
                NameResolverOptions.ProcessExplicitPropertyNames)
            where T : ODataModelBuilder
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }
            
            builder.OnModelCreating += new LowerCamelCaser(options).ApplyLowerCamelCase;
            return builder;
        }
    }
}
