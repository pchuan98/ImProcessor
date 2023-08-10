using OpenCvSharp;

namespace ImProcessor.Helper;

public static class LutHelper
{
    public static void Generate(ref Mat mat, bool red, bool green, bool blue)
    {


        for (var i = 0; i < 256; i++)
        {
            var b = (byte)(blue ? i : 0);
            var r = (byte)(red ? i : 0);
            var g = (byte)(green ? i : 0);

            mat.Set(i, new Vec3b(b, g, r));
        }

    }

    private static Mat? _green = null;
    public static Mat Green
    {
        get
        {
            if (_green != null) return _green!;

            _green = new Mat(256, 1, MatType.CV_8UC3);
            Generate(ref _green, false, true, false);
            return _green!;
        }
    }

    private static Mat? _red = null;
    public static Mat Red
    {
        get
        {
            if (_red != null) return _red!;

            _red = new Mat(256, 1, MatType.CV_8UC3);
            Generate(ref _red, true, false, false);

            return _red!;
        }
    }

    private static Mat? _blue = null;
    public static Mat Blue
    {
        get
        {
            if (_blue != null) return _blue!;
            _blue = new Mat(256, 1, MatType.CV_8UC3);
            Generate(ref _blue, false, false, true);
            return _blue!;
        }
    }

    private static Mat? _yellow = null;
    public static Mat Yellow
    {
        get
        {
            if (_yellow != null) return _yellow!;
            _yellow = new Mat(256, 1, MatType.CV_8UC3);
            Generate(ref _yellow, true, true, false);
            return _yellow!;
        }
    }

    private static Mat? _cyan = null;
    public static Mat Cyan
    {
        get
        {
            if (_cyan != null) return _cyan!;
            _cyan = new Mat(256, 1, MatType.CV_8UC3);
            Generate(ref _cyan, false, true, true);
            return _cyan!;
        }
    }

    private static Mat? _magenta = null;
    public static Mat Magenta
    {
        get
        {
            if (_magenta != null) return _magenta!;
            _magenta = new Mat(256, 1, MatType.CV_8UC3);
            Generate(ref _magenta, true, false, true);
            return _magenta!;
        }
    }


    private static Mat? _gray = null;
    public static Mat Gray
    {
        get
        {
            if (_gray != null) return _gray!;
            _gray = new Mat(256, 1, MatType.CV_8UC3);
            Generate(ref _gray, true, true, true);
            return _gray!;
        }
    }

    public static Mat Generate(MatType type)
    {
        if (type == MatType.CV_8U)
            Console.WriteLine("ok");
        if (type == MatType.CV_16U)
            Console.WriteLine("ok");

        if (type == MatType.CV_8UC1 || type == MatType.CV_8UC3)
            throw new NotImplementedException();
        else if (type == MatType.CV_16SC1)
            throw new NotImplementedException();

        return new Mat();
    }
}