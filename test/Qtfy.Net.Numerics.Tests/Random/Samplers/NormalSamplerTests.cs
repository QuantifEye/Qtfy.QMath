// <copyright file="NormalSamplerTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests.Random.Samplers
{
    using System;
    using NUnit.Framework;
    using Qtfy.Net.Numerics.Distributions;
    using Qtfy.Net.Numerics.Random;
    using Qtfy.Net.Numerics.Random.RandomNumberEngines;
    using Qtfy.Net.Numerics.Random.Samplers;

    public class NormalSamplerTests : DoubleSamplerTester
    {
        private const double Mu = 12d;

        private const double Sigma = 1d;

        public override NormalSampler GetSampler()
        {
            var engine = MersenneTwister32Bit19937.InitGenRand(1);
            return new NormalSampler(engine, Mu, Sigma);
        }

        public override IDistribution GetReferenceDistribution()
        {
            return new NormalDistribution(Mu, Sigma);
        }

        [Test]
        public void TestGetNext()
        {
            Assert.Warn("test me");
        }

        [Test]
        public void TestProperties()
        {
            var sampler = this.GetSampler();
            Assert.AreEqual(Mu, sampler.Mu);
            Assert.AreEqual(Sigma, sampler.Sigma);
        }

        private static void TestInvalidThrows<TException>(IRandomNumberEngine engine, double mu, double sigma)
            where TException : Exception
        {
            Assert.Throws<TException>(
                () => _ = new NormalSampler(engine, mu: mu, sigma: sigma));
        }

        [Test]
        public void TestNanParameter()
        {
            var engine = MersenneTwister32Bit19937.InitGenRand(1);
            TestInvalidThrows<ArgumentException>(engine, mu: double.NaN, sigma: 1d);
            TestInvalidThrows<ArgumentException>(engine, mu: 1d, sigma: double.NaN);
        }

        [Test]
        public void TestConstructInvalidGenerator()
        {
            TestInvalidThrows<ArgumentNullException>(null, mu: 1d, sigma: 1d);
        }
    }
}
