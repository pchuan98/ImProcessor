using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImProcessor.Models;
using OpenCvSharp;

namespace ImProcessor.Extensions;

public static class MatExtension
{
    /// <summary>
    /// Mat数据对象
    /// </summary>
    /// <param name="image"></param>
    /// <returns></returns>
    public static int MatType(this Image image)
        => image.Mats![0].Depth();
}