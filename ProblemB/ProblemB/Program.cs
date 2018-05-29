using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    const char Black = '#';
    const char White = '-';
    const char Encountered = '@';

    enum Direction
    {
        Up = -1,
        Down = 1
    }

    public static void Main(string[] args)
    {
        var cases = ReadMap();
        for (int c = 0; c < cases.Count; c++)
        {
            var stars = CountStarsInMap(cases[c]);
            Console.WriteLine($"Case {c + 1}: {stars}");
        }
    }

    public static int CountStarsInMap(char[][] testCase)
    {
        var width = testCase[0].Length;
        var starCount = 0;
        for (var heightOffset = 0; heightOffset < testCase.Length; ++heightOffset)
        {
            for (var widthIndex = 0; widthIndex < width; widthIndex++)
            {
                if (testCase[heightOffset][widthIndex] == Black/* || testCase[heightOffset][widthIndex] == Encountered*/) continue;

                var starLineWidth = testCase[heightOffset].Skip(widthIndex).TakeWhile(c => !c.Equals(Black)).Count();

                var onLineEncountered = SpanContainsEncountered(testCase[heightOffset], widthIndex, starLineWidth);
                EncounterAdjacent(testCase[heightOffset], widthIndex);

                var previousLineEncountered = CheckAdjacentLine(testCase, heightOffset, widthIndex, starLineWidth, Direction.Up);
                var nextLineEncountered = CheckAdjacentLine(testCase, heightOffset, widthIndex, starLineWidth, Direction.Down);

                if (!onLineEncountered && !previousLineEncountered && !nextLineEncountered) starCount++;
            }
        }

        return starCount;
    }

    private static int GetLineWidth(char[][] testCase, int heightOffset, int widthOffset) => testCase[heightOffset].Skip(widthOffset).TakeWhile(c => !c.Equals(Black)).Count();

    private static bool CheckAdjacentLine(char[][] testCase, int heightOffset, int widthOffset, int width, Direction direction)
    {
        heightOffset += (int)direction;
        if (heightOffset < 0 || heightOffset == testCase.Length) return false;

        if (testCase[heightOffset].Skip(widthOffset).Take(width).All(Black.Equals)) return false;
        if (testCase[heightOffset].Skip(widthOffset).Take(width).All(c => Encountered.Equals(c) || Black.Equals(c))) return true;
        //if (SpanContainsEncountered(testCase[heightOffset], widthOffset, width)) return true;

        // Need to find the start of this starline
        int lineStart = FindLineStart(testCase[heightOffset], widthOffset, width);
        int lineWidth = GetLineWidth(testCase, heightOffset, lineStart);
        var containsEncountered = SpanContainsEncountered(testCase[heightOffset], lineStart, lineWidth);
        EncounterAdjacent(testCase[heightOffset], lineStart);
        var recursiveCheckWidth = 0;
        var recursiveLineStart = lineStart;
        bool shouldDoRecursive = true;
        if (lineStart < widthOffset)
        {
            recursiveCheckWidth = widthOffset - lineStart;
        }
        else
        {
            recursiveLineStart = widthOffset + width;
            recursiveCheckWidth = lineWidth - (recursiveLineStart - widthOffset);
            shouldDoRecursive = recursiveLineStart < (lineStart + lineWidth);
        }
        if (shouldDoRecursive && (recursiveCheckWidth != 0)) containsEncountered = CheckAdjacentLine(testCase, heightOffset, recursiveLineStart, recursiveCheckWidth, OppositeDirection(direction)) || containsEncountered;
        return CheckAdjacentLine(testCase, heightOffset, lineStart, lineWidth, direction) || containsEncountered;
    }

    private static Direction OppositeDirection(Direction direction) => direction == Direction.Down ? Direction.Up : Direction.Down;

    public static int FindLineStart(char[] line, int widthOffset, int width)
    {
        int lineStart = widthOffset;
        while (lineStart > 0 && !line[lineStart].Equals(Black))
        {
            if (line[lineStart - 1].Equals(Black))
            {
                break;
            }
            lineStart--;
        }
        if (lineStart != widthOffset) return lineStart;

        // If we didn't move, we need to look forward instead
        for (; lineStart < widthOffset + width; lineStart++)
        {
            if (!line[lineStart].Equals(Black)) return lineStart;
        }
        //return lineStart;
        return widthOffset;
    }

    public static bool SpanContainsEncountered(char[] line, int offset, int width) => line.Skip(offset).Take(width).Any(c => c.Equals(Encountered));

    public static void EncounterAdjacent(char[] line, int pos)
    {
        for (int i = pos; i < line.Length && line[i] != Black; ++i)
        {
            line[i] = Encountered;
        }
        for (int i = pos - 1; i >= 0 && line[i] != Black; --i)
        {
            line[i] = Encountered;
        }
    }


    private static List<char[][]> ReadMap()
    {
        var cases = new List<char[][]>();
        var file = new List<string>();
        string line;
        while ((line = Console.ReadLine()) != null)
        {
            file.Add(line);
        }

        for (int lineIndex = 0; lineIndex < file.Count; ++lineIndex)
        {
            var pair = file[lineIndex].Split(' ').Select(int.Parse).ToArray();

            cases.Add(file.Skip(lineIndex + 1).Take(pair[0]).Select(l => l.ToCharArray()).ToArray());

            lineIndex += pair[0];
        }

        return cases;
    }
}
