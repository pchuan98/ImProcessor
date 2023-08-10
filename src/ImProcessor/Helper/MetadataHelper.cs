// 引用参考
// "https://github.com/drewnoakes/metadata-extractor/wiki/Getting-Started-(dotnet)"

using MetadataExtractor;
using MetadataExtractor.Util;

namespace ImProcessor.Helper;

/// <summary>
/// 数据元信息的辅助工具类
/// </summary>
public static class MetadataHelper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="stream"></param>
    /// <returns></returns>
    public static FileType DetectFileType(Stream stream)
        => FileTypeDetector.DetectFileType(stream);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static FileType DetectFileType(string path)
    {
        using var stream = File.OpenRead(path);
        return DetectFileType(stream);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="stream"></param>
    /// <returns></returns>
    public static IReadOnlyList<MetadataExtractor.Directory> ReadMetadata(Stream stream)
        => ImageMetadataReader.ReadMetadata(stream);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static IReadOnlyList<MetadataExtractor.Directory> ReadMetadata(string path)
        => ImageMetadataReader.ReadMetadata(path);

    /// <summary>
    /// 读取文件类型和元数据
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static (FileType, IReadOnlyList<MetadataExtractor.Directory>) ReadTypeAndMetadata(string path)
    {
        using var stream = File.OpenRead(path);

        var fileType = DetectFileType(stream);
        var metadata = ReadMetadata(stream);

        return (fileType, metadata);
    }
}