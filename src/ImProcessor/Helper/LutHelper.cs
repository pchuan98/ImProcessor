using OpenCvSharp;
using System;

namespace ImProcessor.Helper;

public static class LutHelper
{
    /// <summary>
    /// 0 - CV_8U 
    /// 1 - CV_8S 
    /// 2 - CV_16U 
    /// 3 - CV_16S 
    /// 4 - CV_32S 
    /// 5 - CV_32F 
    /// 6 - CV_64F 
    /// 7 - CV_USRTYPE1 
    /// </summary>
    /// <param name="mode"></param>
    /// <param name="red"></param>
    /// <param name="green"></param>
    /// <param name="blue"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static Mat Generate(int mode, bool red, bool green, bool blue)
        => mode switch
        {
            0 => GetByteMat(red, green, blue),
            2 => GetIntMat(red, green, blue),
            _ => throw new Exception("The data type is not supported."),
        };

    private static Mat GetByteMat(bool red, bool green, bool blue)
    {
        var mat = new Mat(256, 1, MatType.CV_8UC1);
        for (var i = 0; i < 256; i++)
        {
            var b = (byte)(blue ? i : 0);
            var r = (byte)(red ? i : 0);
            var g = (byte)(green ? i : 0);

            mat.Set(i, new Vec3b(b, g, r));
        }
        return mat;
    }

    private static Mat GetIntMat(bool red, bool green, bool blue)
    {
        var mat = new Mat(256, 1, MatType.CV_16UC1);
        for (var i = 0; i < 65535; i++)
        {
            var b = (int)(blue ? i : 0);
            var r = (int)(red ? i : 0);
            var g = (int)(green ? i : 0);

            mat.Set(i, new Vec3i(b, g, r));
        }

        return mat;
    }

    #region 单色

    public static Mat Green(int mode)
        => Generate(mode, false, true, false);

    public static Mat Red(int mode)
        => Generate(mode, true, false, false);

    public static Mat Blue(int mode)
        => Generate(mode, false, false, true);

    public static Mat Gray(int mode)
        => Generate(mode, true, true, true);

    public static Mat Yellow(int mode)
        => Generate(mode, true, true, false);

    public static Mat Cyan(int mode)
        => Generate(mode, false, true, true);

    public static Mat Magenta(int mode)
        => Generate(mode, true, false, true);

    /// <summary>
    /// 1 - Green
    /// 2 - Red
    /// 3 - Blue
    /// 4 - Gray
    /// 5 - Yellow
    /// 6 - Cyan
    /// 7 - Magenta
    /// </summary>
    /// <param name="mode"></param>
    /// <param name="color"></param>
    /// <returns></returns>
    public static Mat Monochrome(int mode, int color)
        => color switch
        {
            1 => Green(mode),
            2 => Red(mode),
            3 => Blue(mode),
            4 => Gray(mode),
            5 => Yellow(mode),
            6 => Cyan(mode),
            7 => Magenta(mode),
            _ => throw new Exception("The color is not supported."),
        };

    #endregion
}