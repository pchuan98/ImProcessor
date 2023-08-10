using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImProcessor.Helper;
using MetadataExtractor.Util;
using OpenCvSharp;

namespace ImProcessor.Models;

public class Image : IDisposable
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="path"></param>
    /// <param name="detect">是否检测目标文件的属性</param>
    public Image(string path, bool detect = true)
    {
        if (detect) (FileType, Metadata) = MetadataHelper.ReadTypeAndMetadata(path);

        Cv2.ImReadMulti(path, out var mats, (ImreadModes)(-1));
        Mats = mats;
    }

    public Image() { }

    public Mat[]? Mats { get; set; }

    /// <summary>
    /// 相机元数据总和
    /// </summary>
    public IReadOnlyList<MetadataExtractor.Directory>? Metadata { get; set; }

    /// <summary>
    /// 数据对象
    /// </summary>
    public FileType FileType { get; set; }

    public void Dispose()
    {
        if (Mats == null) return;
        foreach (var mat in Mats)
        {
            mat.Dispose();
        }
    }

    public bool IsEmpty => Mats == null || Mats.Length == 0;

    ~Image() => Dispose();
}