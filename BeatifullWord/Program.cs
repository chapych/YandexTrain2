using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
public class Program
{
    public static void Main()
    {
        using (StreamReader sr = new StreamReader("input.txt"))
        {
            int k = int.Parse(sr.ReadLine());
            var input = sr.ReadLine();
            int max = k;
            if (k >= input.Length)
            {
                Console.WriteLine(k);
                return;
            }
            for(char c = 'a'; c <= 'z'; c++)
            {
                if (!input.Contains(c)) continue;
                var sc = new Scanner(k, c, input);
                int value = sc.FindLengthOfBeatifullWord();
                if (value > max) max = value;
            }
            Console.WriteLine(max);
        }
    }
}

public class Scanner
{
    int head;
    int tail;
    int length;
    char letter;
    string line;

    public Scanner(int k, char letter, string line)
    {
        this.head = line.IndexOf(letter);
        this.tail = head - k - 1;
        this.length = line.Length;
        this.letter = letter;
        this.line = line;
    }

    //public void Reset()
    //{
    //    head = 0;
    //    tail = -length - 1;
    //}

    public int FindLengthOfBeatifullWord()
    {
        int max = 0;
        while (true)
        {
            if (tail == length) break;//можно пораньше
            var tailShift = 1;
            var headShift = 1;
            if (IsShiftRequired(head))
                tailShift = 0;
            if (IsShiftRequired(tail))
                headShift = 0;
            if (headShift == 0 || tailShift == 0)
            {
                max = CurrentMax(max);
            }
            if (headShift == 0 && tailShift == 0)
            {
                headShift++;
                tailShift++;
            }
            head += headShift;
            tail += tailShift;
        }
        return max;
    }

    public bool IsShiftRequired(int pointer) //maybe rename
    {
        if(pointer < 0 || pointer >= line.Length) return false;
        var headChar = line[pointer];
        return headChar == letter;
    }

    public int CurrentMax(int max)
    {
        int value = head - tail - 1;
        if(value>max) max = value;
        return max;
    }
}