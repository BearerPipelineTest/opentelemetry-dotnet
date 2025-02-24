// <copyright file="PrometheusHttpListenerOptions.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using System;
using System.Collections.Generic;
using OpenTelemetry.Internal;

namespace OpenTelemetry.Exporter
{
    /// <summary>
    /// <see cref="PrometheusHttpListener"/> options.
    /// </summary>
    public class PrometheusHttpListenerOptions
    {
        private IReadOnlyCollection<string> uriPrefixes = new string[] { "http://localhost:9464/" };

        /// <summary>
        /// Gets or sets the path to use for the scraping endpoint. Default value: "/metrics".
        /// </summary>
        public string ScrapeEndpointPath { get; set; } = "/metrics";

        /// <summary>
        /// Gets or sets the URI (Uniform Resource Identifier) prefixes to use for the http listener.
        /// Default value: <c>["http://localhost:9464/"]</c>.
        /// </summary>
        public IReadOnlyCollection<string> UriPrefixes
        {
            get => this.uriPrefixes;
            set
            {
                Guard.ThrowIfNull(value);

                if (value.Count == 0)
                {
                    throw new ArgumentException("Empty list provided.", nameof(this.UriPrefixes));
                }

                this.uriPrefixes = value;
            }
        }
    }
}
