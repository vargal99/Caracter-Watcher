// See https://aka.ms/new-console-template for more information
class Karakterfigyelő
{
    private char _Char;

    public void Ellenőriz(char c)
    {
        if (c == _Char) RosszKarakter(EventArgs.Empty);
        _Char = c;
    }

    private void RosszKarakter(EventArgs e)
    {
        EventHandler kezelő = RosszKarakterHandler;
        if (kezelő != null) kezelő(this, e);
    }

    public event EventHandler RosszKarakterHandler;
}

internal static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Várom a szöveget...");
        Karakterfigyelő figyelo = new Karakterfigyelő();
        char c;
        figyelo.RosszKarakterHandler += RosszKarakterr;
        do
        {
            c = Console.ReadKey().KeyChar;
            figyelo.Ellenőriz(c);
        } while (c != (int)ConsoleKey.Enter);
    }

    private static void RosszKarakterr(object sender, EventArgs e)
    {
        Console.WriteLine("\nRossz karakter!");
    }
}
