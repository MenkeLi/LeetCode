using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// LeetCode中所有Array问题的解答与思考
    /// </summary>
    public class Code
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxIncreaseKeepingSkyline(int[][] grid)
        {
            int num = 0;
            int[] row = new int[grid.GetLength(0)];
            int[] colum = new int[grid[0].Length];

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                int temp = 0;
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] > temp)
                    {
                        temp = grid[i][j];
                    }
                }

                row[i] = temp;
            }

            for (int i = 0; i < grid[0].Length; i++)
            {
                int temp = 0;
                for (int j = 0; j < grid.GetLength(0); j++)
                {
                    if (grid[j][i] > temp)
                    {
                        temp = grid[j][i];
                    }
                }

                colum[i] = temp;
            }

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                int temp;
                for (int j = 0; j < grid[0].Length; j++)
                {
                    temp = row[i];
                    if (colum[j] < temp)
                    {
                        temp = colum[j];
                    }

                    if (grid[i][j] < temp)
                    {
                        num += temp - grid[i][j];
                    }
                }
            }


            return num;
        }

        /// <summary>
        /// 832 先做一次调换，然后反转。主要注意最中间的那一次反转
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int[][] FlipAndInvertImage(int[][] A)
        {
            for (int i = 0; i < A.GetLength(0); i++)
            {
                int length = A[i].Length;
                for (int j = 0; j < (length + 1) / 2; j++)
                {
                    if (j == length - 1 - j)
                    {
                        A[i][j] = 1 - A[i][j];
                    }
                    else
                    {
                        int temp = A[i][j];
                        A[i][j] = 1 - A[i][length - 1 - j];
                        A[i][length - 1 - j] = 1 - temp;
                    }

                }
            }

            return A;
        }

        /// <summary>
        /// 561 先对数组进行排序，然后将1,3,5等相加
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int ArrayPairSum(int[] nums)
        {

            int flag = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                flag = i;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] < nums[flag])
                    {
                        flag = j;
                    }
                }

                int temp = nums[i];
                nums[i] = nums[flag];
                nums[flag] = temp;
            }



            int num = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                num += nums[i];
                i++;
            }

            return num;
        }

        /// <summary>
        /// 766 从最中间开始  按照行和列分别扩散
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>egu
        public bool IsToeplitzMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int row = i;
                int column = 0;
                while (row < matrix.GetLength(0) - 1 && column < matrix.GetLength(1) - 1)
                {
                    if (matrix[row, column] != matrix[row + 1, column + 1])
                    {
                        return false;
                    }

                    row++;
                    column++;
                }
            }

            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                int row = 0;
                int column = j;
                while (row < matrix.GetLength(0) - 1 && column < matrix.GetLength(1) - 1)
                {
                    if (matrix[row, column] != matrix[row + 1, column + 1])
                    {
                        return false;
                    }

                    row++;
                    column++;
                }
            }

            return true;
        }

        /// <summary>
        /// 566 先判断元素数量是否符合规则。 其次遍历整个原始数组，想办法加到新数组中去
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int[,] MatrixReshape(int[,] nums, int r, int c)
        {
            if (nums.GetLength(0) * nums.GetLength(1) != r * c)
            {
                return nums;
            }

            int[,] temp = new int[r, c];
            int numsR = 0;
            int numsC = 0;
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    temp[i, j] = nums[numsR, numsC];
                    numsC++;
                    if (numsC == nums.GetLength(1))
                    {
                        numsC = 0;
                        numsR++;
                    }
                }
            }

            return temp;
        }

        /// <summary>
        /// 442 找出所有重复的元素  要求没有额外空间，时间复杂度为O(N)    把（当前索引的数值的绝对值）指向的位置如果是负数，那么把（当前索引的数值的绝对值）添加进需要寻找的list里面，否则，把那个位置的数字置为负数
        /// 如果使用交换的办法，那么就是每一轮都会找到一个重复值，但是时间复杂度会超过0(N)，可能会达到N2
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> FindDuplicates(int[] nums)
        {
            List<int> tempList = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[Math.Abs(nums[i]) - 1] < 0)
                {
                    tempList.Add(Math.Abs(nums[i]));
                }
                else
                {
                    nums[Math.Abs(nums[i]) - 1] = -nums[Math.Abs(nums[i]) - 1];
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = Math.Abs(nums[i]);
            }

            return tempList;
        }

        /// <summary>
        /// 485 在比较计数和最大计数那里，如果用IF语句，会很慢，   然而用Math函数就超快，不得不感慨，API大法好（所以，以后能用API的地方就用API）
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int count = 0;
            int maxCount = 0;
            for (int i = 0; i < nums.Length; i++)
            {

                if (nums[i] == 1)
                {
                    count++;
                    maxCount = Math.Max(maxCount, count);

                }
                else
                {
                    count = 0;
                }
            }
            return maxCount;
        }

        /// <summary>
        /// 695  Max Area of Island
        /// Given a non-empty 2D array grid of 0's and 1's, an island is a group of 1's (representing land) connected 4-directionally (horizontal or
        /// vertical.) You may assume all four edges of the grid are surrounded by water.
        /// Find the maximum area of an island in the given 2D array. (If there is no island, the maximum area is 0.) 
        /// 利用一个递归函数GetAreaOfOnePoint来计算每个点是否有联通，以及如果有联通的话额外增加的面积是多少
        /// 把已经访问过的点进行-1的处理，不仅为GetAreaOfOnePoint函数做了访问标记，同时为数组的遍历做了标记，防止无用功的发生
        /// ！！！这种类型的问题，要额外注意对于“正负标注”的灵活使用，既可以简化问题，有不会对原数据造成破坏，与“442”相关联
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxAreaOfIsland(int[,] grid)
        {
            int maxArea = 0;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    maxArea = Math.Max(maxArea, GetAreaOfOnePoint(i, j, grid));
                }
            }
            return maxArea;
        }
        /// <summary>
        /// 作为MaxAreaOfIsland函数的辅助函数来使用
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="grid"></param>
        /// <returns></returns>
        private int GetAreaOfOnePoint(int row, int column, int[,] grid)
        {
            if (row<0||row>=grid.GetLength(0)|column<0||column>=grid.GetLength(1))
            {
                return 0;
            }
            else
            {
                if (grid[row,column]!=1)
                {
                    return 0;
                }

                grid[row, column] = -1;
                int down = GetAreaOfOnePoint(row + 1, column, grid);
                int up = GetAreaOfOnePoint(row - 1, column, grid);
                int left = GetAreaOfOnePoint(row, column - 1, grid);
                int right = GetAreaOfOnePoint(row, column + 1, grid);
                return 1 + down + up + left + right;
            }
        }

        /// <summary>
        /// 283. Move Zeroes
        /// Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.
        /// Note:
        /// 1.You must do this in-place without making a copy of the array.
        /// 2.Minimize the total number of operations.
        /// 这个问题乍一看很简单，采用冒泡啊，把0放到最后面啊都可以实现，但是由于有最小化操作次数的要求，所以要有其他考虑。
        /// 于是考虑插入操作的排序，即为如果目前索引的数字不为零，并且此索引之前的索引有为0的地方，那么把这两个数字对换(这是一个比较蠢的做法)
        /// 只需要加入一个计数，直接把索引为计数位置的数值，与当前索引位置的数值进行交换即可。注意如果直接把当前所谓数值设置为零,如果前面的元素都不为零，则都会被置为零
        /// 时间复杂度为O(N)
        /// </summary>
        /// <param name="nums"></param>
        public void MoveZeroes(int[] nums)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i]!=0)
                {
                    int temp = nums[count];
                    nums[count] = nums[i];
                    nums[i] = temp;

                    count++;
                }
            }
        }

        /// <summary>
        /// 495. Teemo Attacking
        /// https://leetcode.com/problems/teemo-attacking/description/
        /// In LOL world, there is a hero called Teemo and his attacking can make his enemy Ashe be in poisoned condition. Now, given the 
        /// Teemo's attacking ascending time series towards Ashe and the poisoning time duration per Teemo's attacking, you need to output the 
        /// total time that Ashe is in poisoned condition. 
        /// 
        /// You may assume that Teemo attacks at the very beginning of a specific time point, and makes Ashe be in poisoned condition 
        /// immediately.
        /// 
        /// Note:
        /// 1.You may assume the length of given time series array won't exceed 10000.
        /// 2.You may assume the numbers in the Teemo's attacking time series and his poisoning time duration per attacking are non-
        /// negative integers, which won't exceed 10,000,000.
        /// </summary>
        /// <param name="timeSeries"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public int FindPoisonedDuration(int[] timeSeries, int duration)
        {
            return 0;
        }
    }
}
