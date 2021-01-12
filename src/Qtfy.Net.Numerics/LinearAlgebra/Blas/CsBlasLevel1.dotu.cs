// <copyright file="CsBlasLevel1.dotu.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra.Blas
{
    using System.Numerics;

    internal static partial class CsBlasLevel1
    {
        public static unsafe void zdotu_sub(
            nint n,
            Complex* x,
            nint incx,
            Complex* y,
            nint incy,
            Complex* output)
        {
            AssertValid(n);
            Complex result = default;
            while (true)
            {
                result += *y * *x;
                if (--n == 0)
                {
                    *output = result;
                    return;
                }

                x += incx;
                y += incy;
            }
        }
    }
}
