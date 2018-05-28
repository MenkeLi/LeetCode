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
        /// 主要是一个时间的重叠问题,根据数组相邻两项的差与持续时间做对比，一次来判断是否重合。注意输入数组为空的情况。
        /// </summary>
        /// <param name="timeSeries"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public int FindPoisonedDuration(int[] timeSeries, int duration)
        {
            if (timeSeries.Length==0)
            {
                return 0;
            }
            int count = 0;

            for (int i = 0; i < timeSeries.Length-1; i++)
            {
                if (timeSeries[i]+duration-1<timeSeries[i+1])
                {
                    count += duration;
                }
                else
                {
                    count += timeSeries[i + 1] - timeSeries[i];
                }
            }

            count += duration;
            return count;
        }

        /// <summary>
        /// 667. Beautiful Arrangement II
        /// Given two integers n and k, you need to construct a list which contains n different positive integers ranging from 1 to n and obeys 
        /// the following requirement: 
        /// Suppose this list is [a1, a2, a3, ... , an], then the list [|a1 - a2|, |a2 - a3|, |a3 - a4|, ... , |an-1 - an|] has exactly k distinct integers. 
        ///
        ///  If there are multiple answers, print any of them. 
        /// 
        /// Note:
        /// 1.The n and k are in the range 1 <= k < n <= 10^4.
        /// 考虑排列顺序，要符合以上要求，那么N个数最多有N-1种不同，则K必然要小于N
        /// 考虑最大的差距来自于最大数和最小数，那么就在最开始的K个数当中，根据最小最大的顺序依次放入前面K-1个数，然后从K个数视情况为递加1或者递减1即可
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] ConstructArray(int n, int k)
        {
            if (k>=n||k==0)
            {
                return null;
            }
            int[] nums = new int[n];
            for (int i = 0; i < k; i++)
            {
                if (i%2==0)
                {
                    nums[i] = i / 2 + 1;
                }
                else
                {
                    nums[i] = n - i / 2;
                }
            }
            
            for (int i = k; i < n; i++)
            {
                if (k%2==0)
                {
                    nums[i] = nums[i-1]-1;
                }
                else
                {
                    nums[i] = nums[i-1]+1;
                }
            }
            return nums;
        }


        /// <summary>
        /// 448. Find All Numbers Disappeared in an Array
        /// Given an array of integers where 1 ≤ a[i] ≤ n (n = size of array), some elements appear twice and others appear once.
        /// Find all the elements of [1, n] inclusive that do not appear in this array.
        /// Could you do it without extra space and in O(n) runtime? You may assume the returned list does not count as extra space.
        /// 这道题目跟之前的442寻找在一个数组中出现两次的数字是一样的思路。
        /// 同样是利用索引来达到目的。之前把数字标负，然后当第二次指向的时候，就可以判定为是第二次指向，然后就直接把此数字加入输出的List中。
        /// 对于现在这个题目来说，如果我们指向的位置已经为负，则不用管，否则的话，把指向的那个索引的值置为负数，然后对数组再进行一次遍历，
        /// 那么如果值不为负，说明此索引未被指向过，则说明这就是我们要寻找的缺失的数字。顺便把为负的数值变回正数，就达到了不破坏原有数组的目的。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            List<int> listArray = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[Math.Abs(nums[i])-1] > 0)
                {
                    nums[Math.Abs(nums[i])-1] = -nums[Math.Abs(nums[i])-1];
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i]>0)
                {
                    listArray.Add(i + 1);
                }
                else
                {
                    nums[i] = -nums[i];
                }
            }
            return listArray;
        }


        /// <summary>
        /// 238. Product of Array Except Self
        /// Given an array nums of n integers where n > 1,  return an array output such that output[i] is equal to the product of all the elements
        /// of nums except nums[i].
        /// 
        /// Note: Please solve it without division and in O(n).
        /// 
        /// Follow up:
        /// Could you solve it with constant space complexity? (The output array does not count as extra space for the purpose of space complexity analysis.)
        /// 除法的思路直接被遏制还真是。。。
        /// 对于这个解法，只能说叹为观止
        /// 先从左边开始，每一项等于前面所有项的乘积。然后再从右边开始，每一项等于本身与后面所有项的乘积。这样经过两次遍历，每一项就得到了除了自己以外的所有数的乘积。
        /// 并且此解法的空间复杂度的确为常数1
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] ProductExceptSelf(int[] nums)
        {
            int[] outPut = new int[nums.Length];
            outPut[0] = 1;
            for (int i = 1; i < outPut.Length; i++)
            {
                outPut[i] = outPut[i - 1] * nums[i - 1];
            }

            int right = 1;
            for (int i = outPut.Length - 1; i >= 0; i--)
            {
                outPut[i] *= right;
                right *= nums[i];
            }
            return outPut;
        }


        /// <summary>
        /// 565. Array Nesting
        /// A zero-indexed array A of length N contains all integers from 0 to N-1. Find and return the longest length of set S, where S[i] = {A[i], A[A
        /// [i]], A[A[A[i]]], ... } subjected to the rule below.
        /// 
        /// Suppose the first element in S starts with the selection of element A[i] of index = i, the next element in S should be A[A[i]], and then A[A
        /// [A[i]]]… By that analogy, we stop adding right before a duplicate element occurs in S.
        /// Note:
        /// 1.N is an integer within the range [1, 20,000].
        /// 2.The elements of A are all distinct.
        /// 3.Each element of A is an integer within the range [0, N-1].
        /// 第一次尝试时，使用暴力破解，不停的指向，然后导致超时。
        /// 改变思路，如果已经访问过的我做一次标记，然后增加一个数组用来存储已经访问过的点到最后的长度，那么就可以解决重复访问的问题了
        /// 所以说，在解决问题中，要善于利用取反来达到标记的目的。不仅可以用于标记，也方便后续的恢复原来数组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int ArrayNesting(int[] nums)
        {
            int maxCount = 0;
            int count = 0;
            int[] countNums = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                int tempIndex = i;
                count = 1;
                while (nums[tempIndex]!=i&&nums[tempIndex]>=0)
                {
                    tempIndex = nums[tempIndex];
                    count += 1;
                }

                count = count + countNums[tempIndex];
                maxCount = Math.Max(count, maxCount);

                tempIndex = i;
                while (nums[tempIndex]!=i && nums[tempIndex] >= 0)
                {
                    count -= 1;
                    countNums[nums[tempIndex]] = count;
                    nums[tempIndex] = -nums[tempIndex];
                    tempIndex = Math.Abs(nums[tempIndex]);
                }
                
            }

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = Math.Abs(nums[i]);
            }
            return maxCount;
        }


        /// <summary>
        /// 717. 1-bit and 2-bit Characters
        /// We have two special characters. The first character can be represented by one bit 0. The second character can be represented by two
        /// bits (10 or 11). 
        /// Now given a string represented by several bits. Return whether the last character must be a one-bit character or not. The given string 
        /// will always end with a zero.
        /// 
        /// Note: 
        /// 1 &lt;= len(bits) &lt;= 1000.
        /// bits[i] is always 0 or 1.
        /// 
        /// 经过观察可以知道，如果一旦遇到了一个1，那么这一位与接下来那一位一定是第2种编码，所以就直接跳到下一位的下一位，直到遍历整个数组。
        /// 如果在倒数第二位遇到了1，那么我们就可以判定最后两位一定是第2中编码，因此返回False,否则返回True
        /// </summary>
        /// <param name="bits"></param>
        /// <returns></returns>
        public bool IsOneBitCharacter(int[] bits)
        {
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i]==1)
                {
                    i += 1;
                    if (i == bits.Length-1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        /// <summary>
        /// 830. Positions of Large Groups
        /// In a string S of lowercase letters, these letters form consecutive groups of the same character.
        /// For example, a string like S = "abbxxxxzyy" has the groups "a", "bb", "xxxx", "z" and "yy".
        /// Call a group large if it has 3 or more characters.  We would like the starting and ending positions of every large group.
        /// The final answer should be in lexicographic order.
        /// 
        /// Note:  1 <= S.length <= 1000
        /// 
        /// 题目最开始主要是遇到了数据结构转换的问题List<list<int>>是不被认可的，无奈之下，只能最后认为转一次数组
        /// 其次是界限的判断问题，主要思路是判断下一个值是否跟当前值一样，但是很容易忽略是否有下一个值
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public IList<IList<int>> LargeGroupPositions(string S)
        {
            List<int[]> ssss = new List<int[]>();
            int endIndex = 1;
            int count = 1;
            char[] chars = S.ToArray();
            for (int i = 0; i < chars.Length - 1; i++)
            {
                if (chars[i + 1] == chars[i])
                {
                    count += 1;
                    if (i==chars.Length-2&&count>=3)
                    {
                        endIndex = i+1;
                        ssss.Add(new int[] { endIndex - count + 1, endIndex });
                    }
                }
                else
                {
                    if (count >= 3)
                    {
                        endIndex = i;
                        ssss.Add(new int[] { endIndex - count + 1, endIndex });
                    }

                    count = 1;
                }

            }
            int[][] oders = new int[ssss.Count][];
            for (int i = 0; i < ssss.Count; i++)
            {
                oders[i] = ssss[i].ToArray();
            }
            return oders;

        }


        /// <summary>
        /// 169. Majority Element
        /// Given an array of size n, find the majority element. The majority element is the element that appears more than ⌊ n/2 ⌋ times.
        /// You may assume that the array is non-empty and the majority element always exist in the array.
        /// 刚开始没想到什么太好的办法，只能采用暴力解题。然而第一次尝试还是忘记了边界的问题，当长度只有一个的时候的情况没能考虑进去。以后一定要对这些边界多考虑一下。
        /// 其次加了一种标记办法，即创建一个跟它同样的数组，然后用bool值来进行标记，时间复杂度同样太高。注意到了n/2这个提示，但是没想到怎么利用。
        /// 现在的解题办法，充分利用了N/2的这个提示，
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MajorityElement(int[] nums)
        {
            int major = nums[0], count = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (count == 0)
                {
                    count++;
                    major = nums[i];
                }
                else if (major == nums[i])
                {
                    count++;
                }
                else count--;

            }
            return major;


            //这是一个时间复杂度很高的解决办法，不采用
            //int temp = 0;
            //int count = 1;
            //int maxCount = 1;
            //int maxOutput = 0;
            //if (nums.Length==1)
            //{
            //    return nums[0];
            //}
            //for (int i = 0; i < (nums.Length+1)/2; i++)
            //{
            //    count = 1;
            //    temp = nums[i];
            //    for (int j = i+1; j < nums.Length; j++)
            //    {
            //        if (nums[j]==temp)
            //        {
            //            count += 1;
            //        }
            //    }

            //    if (count>maxCount)
            //    {
            //        maxCount = count;
            //        maxOutput = temp;
            //    }

            //    if (maxCount>nums.Length/2)
            //    {
            //        break;
            //    }
            //}
            //return maxOutput;


            //此方法避免了重复访问的问题，但是时间复杂度依然太高
            //int temp = 0;
            //int count = 1;
            //int maxCount = 1;
            //int maxOutput = 0;
            //if (nums.Length == 1)
            //{
            //    return nums[0];
            //}

            //bool[] isVisited = new bool[nums.Length];
            //for (int i = 0; i < (nums.Length + 1) / 2; i++)
            //{
            //    if (!isVisited[i])
            //    {
            //        count = 1;
            //        temp = nums[i];
            //        for (int j = i + 1; j < nums.Length; j++)
            //        {
            //            if (!isVisited[j]&&nums[j] == temp)
            //            {
            //                count += 1;
            //            }
            //        }

            //        if (count > maxCount)
            //        {
            //            maxCount = count;
            //            maxOutput = temp;
            //        }

            //        if (maxCount > nums.Length / 2)
            //        {
            //            break;
            //        }
            //    }

            //}
            //return maxOutput;


        }



        /// <summary>
        /// 769. Max Chunks To Make Sorted
        /// Given an array arr that is a permutation of [0, 1, ..., arr.length - 1], we split the array into some number of "chunks" (partitions),
        /// and individually sort each chunk.  After concatenating them, the result equals the sorted array.
        /// What is the most number of chunks we could have made?
        /// 
        /// Note:
        /// 1.arr will have length in range [1, 10].
        /// 2.arr[i] will be a permutation of [0, 1, ..., arr.length - 1].
        /// 
        /// 首先还是要利用到数组本身的序号来解决问题。
        /// 我们增加一个数组再每个位置的最大数，然后最大数存储的结果是上一个最大数与当前数字相比较的最大值。
        /// 那么当最大数与索引相同时，这个区间内的数组可以拆分。
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int MaxChunksToSorted(int[] arr)
        {
            if (arr==null||arr.Length==0)
            {
                return 0;
            }

            int count = 0;
            int[] max = new int[arr.Length];
            max[0] = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                max[i] = Math.Max(max[i - 1], arr[i]);
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (max[i]==i)
                {
                    count += 1;
                }
            }

            return count;
        }
    }
}
