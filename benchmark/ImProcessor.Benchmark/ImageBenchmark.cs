using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using ImProcessor.Models;

namespace ImProcessor.Benchmark;

public class ImageBenchmark
{
    private const int N = 10000;

    private const string Pic = @"C:\Users\haeer\Pictures\organ-of-corti.tif";

    [Benchmark]
    public void B_ReadImageFile1()
    {
        var img = new Image(Pic);

        var s = img.FileType;
        var m = img.Metadata;
    }

    [Benchmark]
    public void B_ReadImageFile2()
    {
        var img = new Image(Pic, false);

        var s = img.FileType;
        var m = img.Metadata;
    }

}