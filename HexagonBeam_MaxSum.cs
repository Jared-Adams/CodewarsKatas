using System;
using System.Linq;

namespace HexagonBeam_MaxSum
{
	///<summary>
    ///https://www.codewars.com/kata/5ecc1d68c6029000017d8aaf/train/csharp
	///In this kata, your task is to find the maximum sum of any straight "beam" 
	///on a hexagonal grid, where its cell values are determined by a finite integer sequence seq.
	///In this context, a beam is a linear sequence of cells in any of the 3 pairs of opposing sides of a hexagon. 
    ///</summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SequentialHexegonAsString(5, new int[] { 1, 0, 4, -6 }));
            Console.WriteLine(GetSampleHexagonIndexedRowAsString());
            Console.WriteLine(GetGreatestBeamSum(2, new int[] {})); //18
            Console.ReadLine();
        }
        public static string SequentialHexegonAsString(int n, int[] sequence)
        {
            int sequenceIndex = 0;
            int lineLength = n;
            int maxLineLength = (n * 2) - 1;
            string hexegon = string.Empty;
            for (int j = 0; j < (maxLineLength - n); j++)
            {
                for (int i = 0; i < lineLength; i++)
                {
                    hexegon += sequence[sequenceIndex] + " ";
                    sequenceIndex += (sequenceIndex == sequence.Length - 1) ? (-sequence.Length + 1) : 1;
                }
                hexegon += "\n";
                lineLength += 1;
            }
            for (int g = n; g > 0; g--)
            {
                for (int i = lineLength; i > 0; i--)
                {
                    hexegon += sequence[sequenceIndex] + " ";
                    sequenceIndex += (sequenceIndex == sequence.Length - 1) ? (-sequence.Length + 1) : 1;
                }
                hexegon += "\n";
                lineLength -= 1;
            }

            return hexegon;
        }

        //used to create jagged array (hexagon shape)
        public static int[][] CreateSequentialHexagon(int n, int[] sequence)
        {
            int sequenceIndex = 0;
            int rowLength = n;
            int maxRowLength = (n * 2) - 1;
            int[][] hexagon = new int[maxRowLength][];
            //populates rows 1 through max row length
            for (int j = 0; j <= (maxRowLength - n); j++)
            {
                int[] row = new int[rowLength];
                for (int i = 0; i < rowLength; i++)
                {
                    row[i] = sequence[sequenceIndex];
                    //cycles sequence
                    sequenceIndex += (sequenceIndex == sequence.Length - 1) ? (-sequence.Length + 1) : 1;
                }
                hexagon[j] = row;
                rowLength += 1;
            }

            //inverse of first half. Begins populating row after max row length
            rowLength = maxRowLength - 1;
            for (int i = maxRowLength - (n - 1); i < maxRowLength; i++)
            {
                int[] row = new int[rowLength];
                for (int g = 0; g < rowLength; g++)
                {
                    row[g] = sequence[sequenceIndex];
                    sequenceIndex += (sequenceIndex == sequence.Length - 1) ? (-sequence.Length + 1) : 1;
                }
                hexagon[i] = row;
                rowLength -= 1;
            }

            return hexagon;
        }

        public static string GetSampleHexagonIndexedRowAsString()
        {
            string _output = string.Empty;
            int[][] sampleHexagon = CreateSequentialHexagon(4, new int[] { 2, 4, 6, 8 });

            for (int j = 0; j < sampleHexagon.Length; j++)
            {
                foreach (int i in sampleHexagon[j])
                {
                    _output += i + " ";
                }
                _output += "\n";
            }
            return _output;
        }

        public static int GetGreatestBeamSum(int n, int[] sequence)
        {
            int? _topSum = null;
            int _workingNum = 0;
            int _maxRowLength = (n * 2) - 1;
            int[][] sampleHexagon = CreateSequentialHexagon(n, sequence);
            //horizontal sums
            for (int i = 0; i < sampleHexagon.Length; i++)
            {
                if (!_topSum.HasValue)
                {
                    _topSum = sampleHexagon[i].Sum();
                }
                else
                {
                    if (sampleHexagon[i].Sum() > _topSum)
                    {
                        _topSum = sampleHexagon[i].Sum();
                    }
                }
            }

            //forward oblique sums
            for (int j = 0; j < sampleHexagon.Length; j++)
            {
                if (j < n)
                {
                    for (int k = 0; k < n + j; k++)
                    {
                        if (k >= n)
                        {
                            _workingNum += sampleHexagon[k][j - (k - (n - 1))];
                        }
                        else
                        {
                            _workingNum += sampleHexagon[k][j];
                        }

                    }
                }
                else
                {
                    //start k at 1
                    for (int k = (j - (n - 1)); k < _maxRowLength; k++)
                    {
                        if (k >= n)
                        {
                            _workingNum += sampleHexagon[k][j - (k - (n - 1))];
                        }
                        else
                        {
                            _workingNum += sampleHexagon[k][j];
                        }
                    }
                }
                if (_workingNum > _topSum)
                {
                    _topSum = _workingNum;
                }
                else
                {

                }
                _workingNum = 0;
            }
            _workingNum = 0;
            //backward oblique sums
            for (int j = 0; j < _maxRowLength; j++)
            {
                if (j < n)
                {
                    for (int i = 0; i < n + j; i++)
                    {
                        if (i < n)
                        {
                            _workingNum += sampleHexagon[i][sampleHexagon[i].Length - j - 1];
                        }
                        else
                        {
                            _workingNum += sampleHexagon[i][sampleHexagon[i].Length - j + (i - n)];
                        }
                    }
                }
                else
                {
                    for (int row = 1 + (j - n); row < _maxRowLength; row++)
                    {
                        if (row < n)
                        {
                            _workingNum += sampleHexagon[row][row - (j - n) - 1];
                        }
                        else
                        {
                            _workingNum += sampleHexagon[row][(_maxRowLength - j) - 1];
                        }
                    }
                }
                if (_workingNum > _topSum)
                {
                    _topSum = _workingNum;
                }
                _workingNum = 0;
            }
            return Convert.ToInt32(_topSum);
        }
    }
}
