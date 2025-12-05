namespace AdventOfCode2025.Advent;

partial class MySolutions
{
    public static long SolveDayThree()
    {
        long outputPower = 0;

        using (StreamReader sr = new StreamReader("Src/DayThree.txt"))
        {
            string? bank;
            while ((bank = sr.ReadLine()) != null)
            {
                int first = 0;
                int second = 0;
                int index = 0;

                for (int i = 0; i < bank.Length - 1; i++)
                {
                    int.TryParse(bank[i].ToString(), out int batteryValue);
                    if (!(batteryValue > first)) continue;
                    first = batteryValue;
                    index = i;
                }

                for (int i = bank.Length - 1; i > index; i--)
                {
                    int.TryParse(bank[i].ToString(), out int batteryValue);
                    if (batteryValue > second) second = batteryValue;
                }

                outputPower += first * 10 + second;
            }
        }

        return outputPower;
    }

    public static long SolveDayThreePlus()
    {
        string massiveOutputPower = "";

        using (StreamReader sr = new StreamReader("Src/DayThree.txt"))
        {
            string? bank;

            while ((bank = sr.ReadLine()) != null)
            {
                char[] bankArr = bank.ToCharArray();
                int indexFromRear = 12;
                int index = -1;
                while (indexFromRear > 0)
                {
                    int largest = 0;
                    for (int i = 0; i < bankArr.Length - indexFromRear; i++)
                    {
                        int.TryParse(bankArr[i].ToString(), out int current);
                        if (current > largest)
                        {
                            largest = current;
                            index = i;
                        }
                    }
                    massiveOutputPower += largest.ToString();
                    indexFromRear--;
                    bankArr[index] = '0';
                }
            }
        }

        long.TryParse(massiveOutputPower, out long massiveOutputPowerNum);
        return massiveOutputPowerNum;
    }
}