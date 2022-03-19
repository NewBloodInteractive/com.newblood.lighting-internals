using System;
using UnityEngine;

namespace NewBlood
{
    [Serializable]
    public struct Matrix3x4f
    {
        public float e00;
        public float e01;
        public float e02;
        public float e03;
        public float e10;
        public float e11;
        public float e12;
        public float e13;
        public float e20;
        public float e21;
        public float e22;
        public float e23;

        public static implicit operator Matrix4x4(Matrix3x4f matrix)
        {
            return new Matrix4x4
            {
                m00 = matrix.e00, m01 = matrix.e01, m02 = matrix.e02, m03 = matrix.e03,
                m10 = matrix.e10, m11 = matrix.e11, m12 = matrix.e12, m13 = matrix.e13,
                m20 = matrix.e20, m21 = matrix.e21, m22 = matrix.e22, m23 = matrix.e23
            };
        }

        public static explicit operator Matrix3x4f(Matrix4x4 matrix)
        {
            return new Matrix3x4f
            {
                e00 = matrix.m00, e01 = matrix.m01, e02 = matrix.m02, e03 = matrix.m03,
                e10 = matrix.m10, e11 = matrix.m11, e12 = matrix.m12, e13 = matrix.m13,
                e20 = matrix.m20, e21 = matrix.m21, e22 = matrix.m22, e23 = matrix.m23
            };
        }
    }
}
