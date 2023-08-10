﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImProcessor.Models;
using OpenCvSharp;

namespace ImProcessor.Helper;

/// <summary>
/// 图像所有的IO操作的辅助工具类
/// </summary>
public static class IoHelper
{
    public static Mat ReadImage(string path)
    {
        return Cv2.ImRead(path);
    }
}