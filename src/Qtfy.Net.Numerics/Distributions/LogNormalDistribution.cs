// <copyright file="LogNormalDistribution.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Distributions
{
    using System;

    /// <summary>
    /// A Log-Normal statistical distribution object.
    /// </summary>
    public class LogNormalDistribution : IContinuousDistribution
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogNormalDistribution"/> class.
        /// </summary>
        /// <param name="mu">
        /// The mean parameter of the related normal distribution.
        /// </param>
        /// <param name="sigma">
        /// The standard deviation of the related normal distribution.
        /// </param>
        public LogNormalDistribution(double mu, double sigma)
        {
            if (!double.IsFinite(mu))
            {
                throw new ArgumentException(
                    $"{nameof(mu)} must not be infinite or NaN",
                    nameof(mu));
            }

            if (!double.IsFinite(sigma) || sigma <= 0d)
            {
                throw new ArgumentException(
                    $"{nameof(sigma)} must not be greater than zero and not or NaN",
                    nameof(sigma));
            }

            this.Mu = mu;
            this.Sigma = sigma;
        }

        /// <summary>
        /// Gets the mean parameter of the related normal distribution.
        /// </summary>
        public double Mu { get; }

        /// <summary>
        /// Gets the standard deviation parameter of the related normal distribution.
        /// </summary>
        public double Sigma { get; }

        /// <inheritdoc />
        public double Mean
        {
            get => Math.Exp(this.Mu + this.Sigma * this.Sigma / 2d);
        }

        /// <inheritdoc />
        public double Variance
        {
            get
            {
                var v = this.Sigma * this.Sigma;
                return (Math.Exp(v) - 1d) * Math.Exp(2d * this.Mu + v);
            }
        }

        /// <inheritdoc />
        public double StandardDeviation
        {
            get => Math.Sqrt(this.Variance);
        }

        /// <inheritdoc />
        public double Quantile(double probability)
        {
            if (probability >= 0d && probability <= 1d)
            {
                var erfInv = SpecialFunctions.ErfInv(Math.FusedMultiplyAdd(2d, probability, -1d));
                return Math.Exp(this.Mu + Constants.SqrtTwo * this.Sigma * erfInv);
            }

            throw new ArgumentException("invalid probability", nameof(probability));
        }

        /// <inheritdoc />
        public double Density(double x)
        {
            var z = Math.Log(x) - this.Mu;
            return Math.Exp(z * z / (-2d * this.Sigma * this.Sigma)) / (x * this.Sigma * Constants.SqrtTwoPi);
        }

        /// <inheritdoc />
        public double DensityLn(double x)
        {
            var z = (Math.Log(x) - this.Mu) / this.Sigma;
            return -0.5 * z * z - Math.Log(x * this.Sigma * Constants.SqrtTwoPi);
        }

        /// <inheritdoc />
        public double CumulativeDistribution(double x)
        {
            var z = (Math.Log(x) - this.Mu) / (Constants.SqrtTwo * this.Sigma);
            return Math.FusedMultiplyAdd(SpecialFunctions.Erf(z), 0.5d, 0.5d);
        }
    }
}
