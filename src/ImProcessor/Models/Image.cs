using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace ImProcessor.Models;

public class Image
{
    public Image(string path)
        => _data = Cv2.ImRead(path, (ImreadModes)(-1));

    internal Image(Mat mat)
        => mat.CopyTo(_data);

    /// <summary>
    /// 处理数据，不暴露
    /// </summary>
    private readonly Mat _data = new();

    /// <summary>
    /// 相机元数据总和
    /// </summary>
    public Dictionary<string, Dictionary<string, string>>? Metadata { get; set; }
}