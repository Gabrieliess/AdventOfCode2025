namespace AdventOfCode2025.Advent;

static partial class MySolutions
{
    public static int SolveDayFour()
    {
        // for this solution to work you must first surround the input text block in dots,
        // so you don't read characters outside the input
        //   .........
        //   .@@.@.@@.
        //   .@@@@@@@.
        //   ...@.@...      example
        //   .@@.@.@..      hold scroll wheel for selecting 
        //   .........      multiple lines to write the dots

        int freeRows = 0;
        using StreamReader sr = new StreamReader("Src/DayFour.txt");
        char[]?[] jaggedRowArray =
        {
            String.Empty.ToCharArray(),
            sr.ReadLine()?.ToCharArray(),
            sr.ReadLine()?.ToCharArray(),
        };
        while (!sr.EndOfStream)
        {
            jaggedRowArray[0] = jaggedRowArray[1];
            jaggedRowArray[1] = jaggedRowArray[2]; // epic queue 
            jaggedRowArray[2] = sr.ReadLine()?.ToCharArray();

            for (int i = 0; i < jaggedRowArray[1]!.Length; i++)
            {
                var surrounding = new List<char>();
                if (jaggedRowArray[1]![i] == '@')
                {
                    surrounding.Add(jaggedRowArray[0]![i - 1]);
                    surrounding.Add(jaggedRowArray[0]![i]); // lamest solution this season
                    surrounding.Add(jaggedRowArray[0]![i + 1]);

                    surrounding.Add(jaggedRowArray[1]![i - 1]);
                    surrounding.Add(jaggedRowArray[1]![i + 1]);

                    surrounding.Add(jaggedRowArray[2]![i - 1]);
                    surrounding.Add(jaggedRowArray[2]![i]);
                    surrounding.Add(jaggedRowArray[2]![i + 1]);
                    int counter = 0;
                    foreach (var character in surrounding)
                    {
                        if (character == '@')
                        {
                            counter++;
                        }
                    }

                    if (counter < 4)
                    {
                        freeRows++;
                    }
                }
            }
        }


        return freeRows;
    }

    public static int SolveDayFourPlus()
    {
        return 1;
    }
}