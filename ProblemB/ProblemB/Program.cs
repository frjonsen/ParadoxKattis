using System;
using System.Collections.Generic;
using System.Linq;

/**
 * Specifically wanted to make a non-destructive algorithm.
 * Modifying the incoming array would probably be faster,
 * and use less memory. Since it's read from stdin it doesn't 
 * really matter, but I simply prefer non-destructive when possible
 */
public class Program
{
	const char Black = '#';
	const char White = '-';

	private struct Point
	{
		public int x;
		public int y;
	}
	private class PointComparer : IEqualityComparer<Point>
	{
		public bool Equals(Point x, Point y) => x.x == y.x && x.y == y.y;
		public int GetHashCode(Point obj) => obj.x ^ obj.y;
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

	private static readonly IEqualityComparer<Point> comparer = new PointComparer();

	public static int CountStarsInMap(char[][] testCase)
	{
		var width = testCase[0].Length;
		var visitedStars = new List<HashSet<Point>>();
		for (var heightOffset = 0; heightOffset < testCase.Length; ++heightOffset)
		{
			for (var widthIndex = 0; widthIndex < width; widthIndex++)
			{
				var thisPoint = new Point { x = heightOffset, y = widthIndex };
				var star = new HashSet<Point>();
				FindAdjecantStarPoints(visitedStars, star, testCase, heightOffset, widthIndex);
				if (star.Count != 0) visitedStars.Add(star);
			}
		}

		return visitedStars.Count;
	}

	private static void FindAdjecantStarPoints(List<HashSet<Point>> visited, HashSet<Point> currentStar, char[][] testCase, int x, int y)
	{
		if (x < 0 || x >= testCase.Length) return;
		if (y < 0 || y >= testCase[0].Length) return;
		var thisPoint = new Point { x = x, y = y };
		if (testCase[x][y] == Black || currentStar.Contains(thisPoint, comparer) || PartOfVisitedStart(visited, thisPoint)) return;

		currentStar.Add(thisPoint);
		FindAdjecantStarPoints(visited, currentStar, testCase, x + 1, y);
		FindAdjecantStarPoints(visited, currentStar, testCase, x - 1, y);
		FindAdjecantStarPoints(visited, currentStar, testCase, x, y - 1);
		FindAdjecantStarPoints(visited, currentStar, testCase, x, y + 1);
	}

	private static bool PartOfVisitedStart(List<HashSet<Point>> visitedStars, Point p) => visitedStars.SelectMany(s => s).Contains(p, comparer);

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
