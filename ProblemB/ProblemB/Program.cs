using System;
using System.Collections.Generic;
using System.Linq;
using Point = System.Tuple<int, int>;

public class Program
{
	const char Black = '#';

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
		var starCount = 0;
		for (var heightOffset = 0; heightOffset < testCase.Length; ++heightOffset)
		{
			for (var widthIndex = 0; widthIndex < testCase[0].Length; ++widthIndex)
			{
				var newStar = FindAdjecantStarPoints(testCase, heightOffset, widthIndex);
				if (newStar) starCount++;
			}
		}

		return starCount;
	}

	/**
	 * Recursion would probably be the most obvious choice here, and
	 * depending on optimization might even be faster, but this is
	 * more fun, good pratice, and I never get to use Queue otherwise :)
	 */
	private static bool FindAdjecantStarPoints(char[][] testCase, int x, int y)
	{
		var newStar = false;
		var toCheck = new Queue<Point>();
		toCheck.Enqueue(new Point(x, y));

		if (toCheck.Count > 0)
		while (toCheck.Count > 0)
		{
			var point = toCheck.Dequeue();
			if (testCase[point.Item1][point.Item2] == Black) continue;

			newStar = true;
			testCase[point.Item1][point.Item2] = Black;

			// Darken the sky. If we've found a new star, "blacken" all the adjoining points
			if (point.Item1 != 0) toCheck.Enqueue(new Point(point.Item1 - 1, point.Item2));
			if (point.Item1 + 1 < testCase.Length) toCheck.Enqueue(new Point(point.Item1 + 1, point.Item2));
			if (point.Item2 != 0) toCheck.Enqueue(new Point(point.Item1, point.Item2 - 1));
			if (point.Item2 + 1 < testCase[0].Length) toCheck.Enqueue(new Point(point.Item1, point.Item2 + 1));
		}

		return newStar;
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
