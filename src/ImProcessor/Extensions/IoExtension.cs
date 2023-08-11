using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImProcessor.Models;

namespace ImProcessor.Extensions;

public static class IoExtension
{
    public static void Save(this Image image, string path, int index = 0)
    {
        if (image.Mats == null) throw new NoNullAllowedException();
        if (index >= image.Mats.Length) throw new IndexOutOfRangeException();

        var mat = image.Mats[index];

        mat.SaveImage(path);
    }
}