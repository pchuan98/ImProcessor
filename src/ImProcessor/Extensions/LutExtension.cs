using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImProcessor.Models;
using OpenCvSharp;

namespace ImProcessor.Extensions;

public static class LutExtension
{
    /// <summary>
    /// 使用Lut来完成基础的映射关系处理
    /// </summary>
    /// <param name="image"></param>
    /// <param name="color"></param>
    /// <returns></returns>
    public static Image SetLut(this Image image, ColormapTypes color)
    {
        if (image.IsEmpty) throw new Exception("Image的Mats数据为空.");

        var mats = new List<Mat>();

        foreach (var mat in image.Mats!)
        {
            var newMat = new Mat();
            Cv2.ApplyColorMap(mat, newMat, color);
            mats.Add(newMat);
        }

        return new Image()
        {
            Mats = mats.ToArray(),
            FileType = image.FileType,
            Metadata = image.Metadata
        };
    }
}