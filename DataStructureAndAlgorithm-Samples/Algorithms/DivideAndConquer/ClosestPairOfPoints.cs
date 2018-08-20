/****************************** Module Header ******************************\
Module Name:  DivideAndConquer Closest Pair of points.cs
Project:      Data structure and Algorithm
Copyright (c) Nandakumar Nagarajan.

Created At: 10-Aug-2018

-------------------------------Description-----------------------------------
                                Closest pair of points 
------------------------------------------------------------------------------

We are given an array of n points in the plane, and the problem is to find out the closest pair of points in the array. This problem arises in a number of applications.
For example, in air-traffic control, you may want to monitor planes that come too close together, since this may indicate a possible collision. Recall the following formula
for distance between two points p and q.

||pq|| = Math.Sqrt( ((px-qx)x(px-qx)) + ((py-qy)x(py-qy)) ) 
-----------------------------------------------------------------------------------------------
Steps 
-----------------------------------------------------------------------------------------------
1) Find the middle point in the sorted array, we can take P[n/2] as middle point.

2) Divide the given array in two halves. The first subarray contains points from P[0] to P[n/2]. The second subarray contains points from P[n/2+1] to P[n-1].

3) Recursively find the smallest distances in both subarrays. Let the distances be dl and dr. Find the minimum of dl and dr. Let the minimum be d.

4) From above 3 steps, we have an upper bound d of minimum distance. Now we need to consider the pairs such that one point in pair is from left half and other is from right half.
Consider the vertical line passing through passing through P[n/2] and find all points whose x coordinate is closer than d to the middle vertical line. Build an array strip[] of all such points.

5) Sort the array strip[] according to y coordinates. This step is O(nLogn). It can be optimized to O(n) by recursively sorting and merging.

6) Find the smallest distance in strip[]. This is tricky. From first look, it seems to be a O(n^2) step, but it is actually O(n). It can be proved geometrically that for every point in strip, 
we only need to check at most 7 points after it (note that strip is sorted according to Y coordinate). See this for more analysis.

7) Finally return the minimum of d and distance calculated in above step (step 6)
 
\***************************************************************************/

using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System;

namespace DataStructureAndAlgorithm_Samples.Algorithms.DivideAndConquer
{
    public partial class DivideAndConquer
    {

        public class Segment
        {
            public readonly PointF P1;
            public readonly PointF P2;

            public Segment(PointF p1, PointF p2)
            {
                P1 = p1;
                P2 = p2;
            }

            public float LengthSquared()
            {
                return ((((P1.X) - (P2.X)) * ((P1.X) - (P2.X))) + (((P1.Y) - (P2.Y)) * ((P1.Y) - (P2.Y))));
            }

            public float Length()
            {
                return (float)Math.Sqrt(LengthSquared());
            }
        }

        public static Segment ClosestBruteForce(List<PointF> points)
        {
            Trace.Assert(points.Count >= 2);

            int count = points.Count;

            var result =new Segment(points[0], points[1]);
            var bestResult = result.Length();

            for (int i = 0; i < count; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    var currentResult = new Segment(points[i], points[j]);
                    var currentLength = currentResult.Length();

                    if (currentLength < bestResult)
                    {
                        result = currentResult;
                        bestResult = currentLength;
                    }
                }
            }
            return result;
        }

        private static Segment ClosestRecord(List<PointF> pointsByX)
        {
            pointsByX.OrderBy(p => p.X).ToList();

            int count = pointsByX.Count;

            if (count <= 4)
                return ClosestBruteForce(pointsByX);

            var leftByX = pointsByX.Take(count / 2).ToList();
            var leftResult = ClosestRecord(leftByX);

            var rightByX = pointsByX.Skip(count / 2).ToList();
            var rightResult = ClosestRecord(rightByX);

            var bestResult = rightResult.Length() <= leftResult.Length() ? rightResult : leftResult;

            var midx = leftByX.Last().X;
            var bandWidth = bestResult.Length();
            var inBandByX = pointsByX.Where(p => Math.Abs(midx - p.X) <= bandWidth);

            var inBandByY = inBandByX.OrderBy(p => p.Y).ToList();

            int iCount = inBandByY.Count;
            for (int i = 0; i < iCount; i++)
            {
                var pLower = inBandByY[i];

                for (int j = i + 1; j < iCount; i++)
                {
                    var pUpper = inBandByY[j];

                    if ((pUpper.Y - pLower.Y) >= bestResult.Length())
                        break;

                    if (new Segment(pLower, pUpper).Length()< bestResult.Length())
                    {
                        bestResult = new Segment(pLower, pUpper);
                    }
                }
            }

            return bestResult;
        }

        static public void ClosestPairOfPoint()
        {
            start:
            Console.WriteLine("********** Closest pair of point  ********");
            Console.WriteLine("Please enter the size of array");

            short maxSize;
            var validInt = Int16.TryParse(Console.ReadLine(), out maxSize);

            if (validInt)
            {
                int[] points = new int[maxSize];

                ///Read the array elements from user 
                for (int i = 0; i < maxSize; i++)
                {
                    Console.WriteLine("please enter index {0} number", i);
                    points[i] = Convert.ToInt32(Console.ReadLine());
                }

                Console.WriteLine("The array elements are...\n");
                ///show the array elements 
                foreach (int j in points)
                {
                    Console.WriteLine(j + "\n");
                }

                var coordinats = points.Select((v, i) => new { v, i }).GroupBy(x => x.i / 2).Select(x => new PointF(x.FirstOrDefault().v, x.Last().v)).ToList();

                //sort the array 
                var segment = ClosestRecord(coordinats);

                Console.WriteLine("closest Pair of points are \n");
                Console.WriteLine($"[{segment.P1.X},{segment.P1.Y}] and [{segment.P2.X},{segment.P2.Y}]");

                System.Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Please enter valid number");
                goto start;
            }
        }
    }
}
