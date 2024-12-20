using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Великая теорема Ферма: нет решений для a^n + b^n = c^n, n > 2.");
        int a = 3, b = 4, c = 5, n = 3;
        bool isTrue = Math.Pow(a, n) + Math.Pow(b, n) != Math.Pow(c, n);
        Console.WriteLine($"Проверка для a={a}, b={b}, c={c}, n={n}: {isTrue}");
    }
}
