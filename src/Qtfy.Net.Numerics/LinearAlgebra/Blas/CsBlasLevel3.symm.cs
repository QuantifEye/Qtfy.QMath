// <copyright file="CsBlasLevel3.symm.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra.Blas
{
    using System;
    using System.Numerics;

    internal static partial class CsBlasLevel3
    {
        public static unsafe void dsymm(
            BlasLayout layout,
            BlasSide side,
            BlasUpperLower upperLower,
            nint m,
            nint n,
            double alpha,
            double* a,
            nint lda,
            double* b,
            nint ldb,
            double beta,
            double* c,
            nint ldc)
        {
            throw new NotImplementedException();
        }

        public static unsafe void zsymm(
            BlasLayout layout,
            BlasSide side,
            BlasUpperLower upperLower,
            nint m,
            nint n,
            Complex alpha,
            Complex* a,
            nint lda,
            Complex* b,
            nint ldb,
            Complex beta,
            Complex* c,
            nint ldc)
        {
            throw new NotImplementedException();
        }
    }
}
