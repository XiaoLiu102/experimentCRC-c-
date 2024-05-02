using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace trit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "Char";
            dataGridView1.Columns[1].Name = "3";
            dataGridView1.Columns[2].Name = "9";
            dataGridView1.Columns[3].Name = "27";
            dataGridView1.Columns[4].Name = "crc4";
            dataGridView1.Columns[5].Name = "crcerror";
            dataGridView1.Columns[6].Name = "crctest";
            // 添加标题行
            string[] titleRow = new string[] { "char", "3", "9", "27", "crc4", "crcerror", "crctest" };
        }

        private void Random_Click(object sender, EventArgs e)
        {
            // 获取用户输入的数字
            int count;
            if (int.TryParse(tritCount.Text, out count) && count > 0)
            {
                HashSet<char> uniqueChars = new HashSet<char>();
                StringBuilder sb = new StringBuilder();
                while (uniqueChars.Count < count)
                {
                    char randomChar = GenerateRandomChar();
                    if (uniqueChars.Add(randomChar)) // 如果字符是唯一的，则添加成功
                    {
                        sb.Append(randomChar);
                    }
                }
                // 显示到文本框
                trit.Text = sb.ToString();

                // 清空DataGridView的数据，除了列标题
                dataGridView1.Rows.Clear();
                List<int> L2 = new List<int>();
                GetCoef(crctrit.Text, L2);

                // 将字符添加到DataGridView并计算进制
                foreach (char c in sb.ToString())
                {

                    List<int> L1 = new List<int>();
                    int asciiValue = (int)c;
                    L1 = SaveL(ToSymmetricBase(asciiValue, 3));
                    ReverseList(L1);
                    AddZeros(L1, L2);
                    dataGridView1.Rows.Add(c.ToString(),
                                            ToSymmetricBase(asciiValue, 3),
                                            ToSymmetricBase(asciiValue, 9),
                                            ToSymmetricBase27(asciiValue),
                                            GetCRC(L1, L2)
                                            );
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid positive number.");
            }
        }

        public List<int> SaveL(string input)
        {
            List<int> resultList = new List<int>();
            bool negative = false; // 标记下一个数字是否应该是负数

            foreach (char c in input)
            {
                if (c == '-')
                {
                    // 遇到'-'，设置标记以使下一个数字为负数
                    negative = true;
                }
                else if (char.IsDigit(c))
                {
                    // 如果当前字符是数字，将其添加到结果列表
                    int number = (int)char.GetNumericValue(c);
                    if (negative)
                    {
                        // 如果之前的字符是'-'，将数字转换为负数
                        number *= -1;
                        negative = false; // 重置标记
                    }
                    resultList.Add(number);
                }
                else
                {
                    // 如果字符既不是'-'也不是数字，抛出异常
                    throw new ArgumentException("Input string contains invalid characters.");
                }
            }

            return resultList;
        }

        private string ToSymmetricBase(int value, int baseNum)
        {
            if (value == 0) return "0";

            StringBuilder result = new StringBuilder();
            int tempValue = Math.Abs(value);

            while (tempValue > 0)
            {
                int remainder = tempValue % baseNum;
                // 对称基数的调整
                if (baseNum == 3)
                {
                    remainder = remainder == 2 ? -1 : remainder;
                }
                else if (baseNum == 9)
                {
                    remainder = remainder > 4 ? remainder - 9 : remainder;
                }
                else if (baseNum == 27)
                {
                    remainder = remainder > 13 ? remainder - 27 : remainder;
                }

                // 构造结果字符串，不使用"+"符号，数字间添加空格
                result.Insert(0, remainder.ToString("#;-#;0"));
                tempValue = (tempValue - Math.Abs(remainder)) / baseNum;
            }

            if (value < 0) // 如果原始数值为负
            {
                // 翻转所有符号
                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i] == '+') result[i] = '-';
                    else if (result[i] == '-') result[i] = '+';
                }
            }

            // 移除最后一个空格并返回结果
            return result.ToString().Trim();
        }
        private string ToSymmetricBase27(int value)
        {
            if (value == 0) return "0";

            StringBuilder result = new StringBuilder();
            int tempValue = Math.Abs(value);
            string[] symbols = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D" };

            while (tempValue > 0)
            {
                int remainder = tempValue % 27;
                if (remainder > 13) // 如果余数超过13，使用对称负数
                {
                    remainder -= 27;
                }
                string symbol = remainder >= 0 ? symbols[remainder] : "-" + symbols[-remainder];
                result.Insert(0, symbol);
                tempValue = (tempValue - Math.Abs(remainder)) / 27;
            }

            if (value < 0) // 如果原值是负数，则翻转符号
            {
                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i] == '-') result[i] = '+';
                    else if (result[i] == '+') result[i] = '-';
                }
            }

            return result.ToString().TrimEnd();
        }

        static string ListToString(List<int> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int num in list)
            {
                sb.Append(num);
            }
            return sb.ToString();
        }

        private char GenerateRandomChar()
        {
            Random random = new Random();
            // 随机生成ASCII字符范围内的字母或数字
            int num = random.Next(48, 122); // ASCII码 0-9, A-Z, a-z
            while ((num > 57 && num < 65) || (num > 90 && num < 97))
            {
                num = random.Next(48, 122);
            }
            return (char)num;

        }


        private void GetCoef(string textBoxValue, List<int> L)
        {
            char[] charList = textBoxValue.ToCharArray();
            char sign = '+';
            int index = 0;
            int maxIndex = 0;
            foreach (char c in charList)
            {
                if (c == '-')
                {
                    sign = '-';
                    if (index + 1 < charList.Length && charList[index + 1] != 'x')
                    {
                        L[0] = -1;
                        return;
                    }
                }
                else if (c == '+')
                {
                    sign = '+';
                    if (index + 1 < charList.Length && charList[index + 1] != 'x')
                    {
                        L[0] = 1;
                        return;
                    }
                }
                else if (c == 'x')
                {
                    if (index + 1 < charList.Length && charList[index + 1] != '^')
                    {
                        L[1] = (sign == '-') ? -1 : 1;
                    }
                }

                else if (char.IsDigit(c))
                {
                    int num = c - '0';
                    while (index + 1 < charList.Length && char.IsDigit(charList[index + 1]))
                    {
                        num = num * 10 + (charList[index + 1] - '0');
                        index++;
                    }
                    maxIndex = Math.Max(maxIndex, num);
                    if (maxIndex >= L.Count)
                    {
                        L.AddRange(new int[maxIndex - L.Count + 1]);
                    }
                    L[num] = (sign == '-') ? -1 : 1;
                }
                index++;
            }
        }

        static void ReverseList(List<int> L)
        {
            int left = 0;
            int right = L.Count - 1;
            while (left < right)
            {
                int temp = L[left];
                L[left] = L[right];
                L[right] = temp;
                left++;
                right--;
            }
        }

        private void AddZeros(List<int> L1, List<int> L2)
        {
            int size = L1.Count;
            int zeros = L2.Count - 1;
            L1.AddRange(new int[zeros]);
            for (int i = size - 1; i >= 0; --i)
            {
                L1[i + zeros] = L1[i];
            }
            for (int i = 0; i < zeros; i++)
            {
                L1[i] = 0;
            }
        }

        static int IsSameSign(int I1, int I2)
        {
            return (I1 * I2 == 1) ? 1 : 0;
        }

        static void ListNegate(List<int> L)
        {
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i] == 1)
                {
                    L[i] = -1;
                }
                else if (L[i] == -1)
                {
                    L[i] = 1;
                }
            }
        }

        static int Operations(int a, int b)
        {
            if (a == 1 && b == 1)
            {
                return 0;
            }
            else if (a == 1 && b == 0)
            {
                return 1;
            }
            else if (a == 1 && b == -1)
            {
                return -1;
            }
            else if (a == 0 && b == 1)
            {
                return -1;
            }
            else if (a == 0 && b == 0)
            {
                return 0;
            }
            else if (a == 0 && b == -1)
            {
                return 1;
            }
            else if (a == -1 && b == 1)
            {
                return 1;
            }
            else if (a == -1 && b == 0)
            {
                return -1;
            }
            else // if (a == -1 && b == -1)
            {
                return 0;
            }
        }
        void changeSign(List<int> L, int zeros)
        {
            for (int i = 0; i < zeros; ++i)
            {
                if (L[i] != 0)
                {
                    L[i] = -L[i];
                }
            }
        }

        public bool isAllZeros(List<int> L)
        {
            return L.All(x => x == 0);
        }

        private string GetCRC(List<int> L1, List<int> L2)
        {
            if (isAllZeros(L1))
            {
                return ListToString(L1);
            }
            List<int> L3 = new List<int>(L1);
            int index1 = L1.Count - 1;
            while (L1[index1] == 0)
                index1--;
            int index2 = L2.Count - 1;
            int manyZeros = 0;
            int difference = index1 - index2;
            for (int a = 1; a <= difference + 1; a++)
            {
                if (L1[index1] == 0)
                {
                    if (manyZeros == 0)
                        a--;
                    index1--;
                    manyZeros = 1;
                }
                else if (IsSameSign(L1[index1], L2[index2]) == 1)
                {
                    for (int i = 0; i <= index2; i++)
                    {
                        L1[index1 - i] = Operations(L1[index1 - i], L2[index2 - i]);
                    }
                    manyZeros = 0;
                }
                else
                {
                    ListNegate(L2);
                    for (int i = 0; i <= index2; i++)
                    {
                        L1[index1 - i] = Operations(L1[index1 - i], L2[index2 - i]);
                    }
                    manyZeros = 0;
                }
            }

            int zeros = L2.Count - 1;
            for (int i = 0; i < zeros; i++)
            {
                L3[i] = L1[i];
            }
            changeSign(L3, difference);
            return ListToString(L3);
        }

        private void RandomError_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow && row.Cells[4].Value != null)
                {
                    string originalStr = row.Cells[4].Value.ToString();
                    StringBuilder newStrBuilder = new StringBuilder();
                    List<int> changedIndices = new List<int>();  // 记录改变的位置
                    int i = 0;

                    while (i < originalStr.Length)
                    {
                        string currentNumStr = originalStr[i].ToString();

                        if (currentNumStr == "-" && i + 1 < originalStr.Length && originalStr[i + 1] == '1')
                        {
                            currentNumStr += "1";
                            i++;
                        }

                        string newNumStr = currentNumStr;
                        if (random.NextDouble() < 0.3)  // 30%的概率进行更改
                        {
                            List<string> replacements = new List<string> { "-1", "0", "1" };
                            replacements.Remove(currentNumStr);
                            newNumStr = replacements[random.Next(replacements.Count)];
                            if (newNumStr != currentNumStr)  // 如果发生了改变
                            {
                                changedIndices.Add(newStrBuilder.Length);  // 记录改变的位置
                            }
                        }
                        newStrBuilder.Append(newNumStr);
                        i++;
                    }

                    string newStr = newStrBuilder.ToString();
                    row.Cells["crcerror"].Value = newStr;
                    row.Cells["crcerror"].Tag = changedIndices;  // 将改变的索引存储在 Tag 属性中
                }
            }
        }


        private void crctest_Click(object sender, EventArgs e)
        {
            List<int> L1 = new List<int>();
            List<int> L2 = new List<int>();
            GetCoef(crctrit.Text, L2);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow && row.Cells["crcerror"].Value != null)
                {
                    string errorData = row.Cells["crcerror"].Value.ToString();
                    //textBox1.Text = errorData;
                    L1 = StringToList(errorData);
                    row.Cells["crctest"].Value = CheckCRC(L1, L2) ? "True" : "False";
                }
            }
        }

        private bool CheckCRC(List<int> L1, List<int> L2)
        {
            string Zeros = "";
            for (int i = 0; i < L1.Count; i++)
            {
                if (L1[i] != '-')
                    Zeros = Zeros + "0";
            }
            if (GetCRC(L1, L2) != Zeros)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<int> StringToList(string input)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                // 检查是否是负号
                if (input[i] == '-')
                {
                    // 确保负号后面有数字
                    if (i + 1 < input.Length && (input[i + 1] == '0' || input[i + 1] == '1'))
                    {
                        // 将负号和数字一起作为一个整体添加到列表中
                        result.Add(-1 * (input[i + 1] - '0')); // 将 '0' 或 '1' 转换为 -1 或 -0
                        i++; // 跳过下一个数字，因为我们已经处理了它
                    }
                }
                else if (input[i] == '0' || input[i] == '1')
                {
                    // 直接将 '0' 或 '1' 添加到列表中
                    result.Add(input[i] - '0'); // 将 '0' 或 '1' 转换为 0 或 1
                }
                else
                {
                    // 如果字符不是 '0'、'1' 或 '-'，抛出异常
                    throw new ArgumentException("Invalid character in input string.");
                }
            }

            return result;
        }

        private (int trueCount, int falseCount) CountTrueFalse()
        {
            int trueCount = 0;
            int falseCount = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    string value = row.Cells["crctest"].Value?.ToString();
                    if (value == "True")
                    {
                        trueCount++;
                    }
                    else if (value == "False")
                    {
                        falseCount++;
                    }
                }
            }
            return (trueCount, falseCount);
        }

        private void run_Click(object sender, EventArgs e)
        {
            int totalTrue = 0;
            int totalFalse = 0;
            for (int i = 0; i < 50; i++)
            {
                // 模拟点击Random, Randomerror, crctest按钮
                Random.PerformClick();
                RandomError.PerformClick();
                crctest.PerformClick();

                // 计数并累加
                var counts = CountTrueFalse();
                totalTrue += counts.trueCount;
                totalFalse += counts.falseCount;
            }

            // 更新 TextBox 控件
            tbtrue.Text = totalTrue.ToString();
            tbfalse.Text = totalFalse.ToString();

            // 更新图表
            UpdateChart(totalTrue, totalTrue + totalFalse);
        }

        private void UpdateChart(int valueForSeries1, int valueForSeries2)
        {
            // 清除之前的点
            chart.Series["Series1"].Points.Clear();
            chart.Series["Series2"].Points.Clear();

            // 添加新的点到系列
            chart.Series["Series1"].Points.AddY(valueForSeries1);
            chart.Series["Series2"].Points.AddY(valueForSeries2);
        }
    }
}
