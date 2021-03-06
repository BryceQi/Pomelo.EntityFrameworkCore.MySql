// Copyright (c) Pomelo Foundation. All rights reserved.
// Licensed under the MIT. See LICENSE in the project root for license information.

using System.ComponentModel;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Json.Microsoft.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Utilities;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore
{
    /// <summary>
    ///     Json specific extension methods for <see cref="MySqlDbContextOptionsBuilder" />.
    /// </summary>
    public static class MySqlJsonMicrosoftDbContextOptionsBuilderExtensions
    {
        /// <summary>
        ///     Use System.Text.Json to access MySQL JSON data.
        /// </summary>
        /// <param name="optionsBuilder"> The builder being used to configure MySQL. </param>
        /// <param name="options">
        ///     Configures the context to use the specified change tracking option as the default for all JSON column
        ///     mapped properties.
        /// </param>
        /// <returns> The options builder so that further configuration can be chained. </returns>
        public static MySqlDbContextOptionsBuilder UseMicrosoftJson(
            [NotNull] this MySqlDbContextOptionsBuilder optionsBuilder,
            MySqlCommonJsonChangeTrackingOptions options = MySqlCommonJsonChangeTrackingOptions.RootPropertyOnly)
        {
            Check.NotNull(optionsBuilder, nameof(optionsBuilder));

            var coreOptionsBuilder = ((IRelationalDbContextOptionsBuilderInfrastructure)optionsBuilder).OptionsBuilder;

            var extension = (coreOptionsBuilder.Options.FindExtension<MySqlJsonMicrosoftOptionsExtension>() ??
                            new MySqlJsonMicrosoftOptionsExtension())
                .WithJsonChangeTrackingOptions(options);

            ((IDbContextOptionsBuilderInfrastructure)coreOptionsBuilder).AddOrUpdateExtension(extension);

            return optionsBuilder;
        }

        /// <summary>
        ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
        ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
        ///     any release. You should only use it directly in your code with extreme caution and knowing that
        ///     doing so can result in application failures when updating to a new Entity Framework Core release.
        /// </summary>
        [EditorBrowsable]
        public static MySqlDbContextOptionsBuilder UseMicrosoftJson(
            [NotNull] this MySqlDbContextOptionsBuilder optionsBuilder, MySqlJsonChangeTrackingOptions options)
        {
            Check.NotNull(optionsBuilder, nameof(optionsBuilder));

            var coreOptionsBuilder = ((IRelationalDbContextOptionsBuilderInfrastructure)optionsBuilder).OptionsBuilder;

            var extension = (coreOptionsBuilder.Options.FindExtension<MySqlJsonMicrosoftOptionsExtension>() ??
                             new MySqlJsonMicrosoftOptionsExtension())
                .WithJsonChangeTrackingOptions(options);

            ((IDbContextOptionsBuilderInfrastructure)coreOptionsBuilder).AddOrUpdateExtension(extension);

            return optionsBuilder;
        }
    }
}
