using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImProcessor.Models;
using OpenCvSharp;
using OpenCvSharp.Flann;

namespace ImProcessor.Extensions;

public static class ChannelExtension
{
    /// <summary>
    /// 选择Image中某一个完成划分，其中每一排为一组，每一列为一帧
    /// </summary>
    /// <param name="image"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static Image SplitChannels(this Image image, int index)
    {
        if (image.Mats == null) throw new NoNullAllowedException();
        if (index >= image.Mats.Length) throw new IndexOutOfRangeException();

        var mat = image.Mats[index];

        var channels = mat.Split();

        return new Image()
        {
            Mats = channels
        };
    }

    public static Image MergeChannels(this Image image, int start = 0, int end = 0)
    {
        if (image.Mats == null) throw new NoNullAllowedException();
        if (end >= image.Mats.Length - 1 || start > end || start < 0) throw new IndexOutOfRangeException();

        var data = image.Mats[start..end];

        var mat = new Mat();
        Cv2.Merge(data, mat);

        return new Image()
        {
            Mats = new Mat[] { mat },
        };
    }
}