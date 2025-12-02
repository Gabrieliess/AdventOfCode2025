namespace AdventOfCode2025.Advent;

partial class MyProgram
{
    public static int SolveDayOne()
    {
        int number = 50;
        int pointingZero = 0;
        using (StreamReader sr = new StreamReader("Src/DayOne.txt"))
        {
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                int.TryParse(line.Remove(0, 1), out int shift);
                shift %= 100;
                switch (line[0])
                {
                    case 'R': // +
                        number = (number + shift) % 100;
                        break;
                    case 'L':
                        if (number - shift < 0)
                        {
                            number = 100 + ((number - shift) % 100);
                        }
                        else
                        {
                            number -= shift;
                        }

                        break;
                }

                if (number == 0)
                {
                    pointingZero++;
                }
            }
        }

        return pointingZero;
    }

    public static string DayOnePlus()
    {
        return "Nothing to see here.";
    }
}