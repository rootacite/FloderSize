// See https://aka.ms/new-console-template for more information

long GetSize(string p)
{
    long r = 0;
    
    foreach (var i in Directory.EnumerateFiles(p))
    {
        r += new FileInfo(i).Length;
    }

    foreach (var i in Directory.EnumerateDirectories(p))
    {
        r += GetSize(i);
    }
    return r;
}

string cd = Environment.CurrentDirectory;

string FFt40(string i)
{
    if(i.Length>40)
    {
        return i.Substring(0, 35) + "..." + "  ";
    }
    else
    {
        return i.PadRight(40);
    }
}

string FFt12l(string i) => i.PadLeft(12);

foreach (var i in Directory.EnumerateFiles(cd))
{
    try
    {
        var fft = new FileInfo(i);
        var l = fft.Length;
        double dl = l / 1024d / 1024d;

        string lf = FFt12l($"{dl:F2} MB");


        Console.WriteLine($"{FFt40(fft.Name)} {lf}");
    }
    catch (Exception)
    {
        continue;
        
    }

}

foreach (var i in Directory.EnumerateDirectories(cd))
{
    try
    {
        var fft = new FileInfo(i);
        var l = GetSize(i);
        double dl = l / 1024d / 1024d;
        string lf = FFt12l($"{dl:F2} MB");

        Console.WriteLine($"{FFt40(fft.Name)} {lf}");
    }
    catch (Exception)
    {
        continue;

    }
}