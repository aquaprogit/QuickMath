using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

using QuickMath.Resources;
using QuickMath.UserData;

namespace QuickMath.SkillWorker
{
    class MathSkillWorker : SkillWorkerBase, ISkillWorker
    {
        public List<char> EnableOperations
        {
            get {
                List<char> enableAct = new List<char>() { '+', '-' };
                if (Level > 2)
                    enableAct.Add('*');
                if (Level > 5)
                    enableAct.Add('/');
                if (Level > 7)
                    enableAct.Add('²');
                if (Level > 8)
                    enableAct.Add('√');
                if (Level == 10)
                    enableAct.Add('³');
                return enableAct;
            }
        }
        public void CheckAnswer(string question, string userAnswer)
        {
            string realAns = new DataTable().Compute(SimplifiedQuestion(question), null).ToString();

            if (userAnswer == realAns)
                Right++;
            else
                Wrong++;

            string SimplifiedQuestion(string input)
            {
                if (input.Any(c => c.IsOneOf('²', '³', '√')))
                {
                    char powCharValue = ' ';
                    if (input.IndexOf('²', '³', '√') != -1)
                        powCharValue = input[input.IndexOf('²', '³', '√')];
                    double powFloatValue = 0.0;
                    switch (powCharValue)
                    {
                        case '²':
                            powFloatValue = 2.0;
                            break;
                        case '³':
                            powFloatValue = 3.0;
                            break;
                        case '√':
                            powFloatValue = 0.5;
                            break;
                    }
                    string pattern = powCharValue.IsOneOf('²', '³') ? "(?<DigitValue>[^\\D]+)" + powCharValue : "√(?<DigitValue>[^\\D]+)";
                    Regex regex = new Regex(pattern, RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);

                    int reseivedNum = regex.Match(input).Groups["DigitValue"].Value.ToInt32();

                    string specNumSimplified = powCharValue == '√' ? $"√{reseivedNum}" : $"{reseivedNum}" + powCharValue;
                    return input.Replace(specNumSimplified, $"{Math.Pow(reseivedNum, powFloatValue)}");
                }
                return input;
            }
        }

        public string GetQuestion()
        {
            Regex isNormalDouble = new Regex(@"^\d+\,\d5*$");
            Random m = new Random();

            double num1, num2 = 0;
            char operation = EnableOperations[m.Next(0, EnableOperations.Count)];
            void SetRandomValue(out double x, out double y, int minValue, int maxValue, bool floatingDot = false)
            {
                Random rand = new Random();
                if (floatingDot == false)
                {
                    x = rand.Next(minValue, maxValue);
                    y = rand.Next(minValue, maxValue);
                }
                else
                {
                    x = RandomNumberBetween(minValue, maxValue);
                    y = RandomNumberBetween(minValue, maxValue);
                }
            }
            double RandomNumberBetween(int max, int min)
            {
                return m.NextDouble() * (max - min) + min;
            }
            if (operation == '+' || operation == '-')
            {
                if (Level == 2)
                {
                    if (m.Next(0, 3) == 2)
                        SetRandomValue(out num1, out num2, 1, 61);
                    else
                    {
                        do
                        {
                            SetRandomValue(out num1, out num2, 1, 51, true);
                            num1 = Math.Round(num1, 2);
                            num2 = Math.Round(num2, 2);
                        } while (!isNormalDouble.IsMatch(num1.ToString()) || !isNormalDouble.IsMatch(num2.ToString()));
                    }
                }
                else
                    SetRandomValue(out num1, out num2, 1, 51);
            }
            else if (operation == '/')
            {
                do
                {
                    SetRandomValue(out num1, out num2, 2, (Level < 9) ? 81 : 225);
                } while (num1 % num2 != 0 || num1 / num2 == 1);
            }
            else if (operation == '*')
                SetRandomValue(out num1, out num2, 2, (Level < 7) ? 9 : 15);
            else if (operation == '√')
            {
                if (Level == 9)
                {
                    do
                    {
                        num1 = m.Next(1, 225);
                    } while (Math.Sqrt(num1) % 1 != 0);
                    return $"√{num1}";
                }
                else
                {
                    bool firsNumToSqrt = m.Next(0, 2) == 0;
                    bool forFirstLevelCond, forSecondLevelCond;

                    do
                    {
                        SetRandomValue(out num1, out num2, 1, firsNumToSqrt ? 225 : 21);

                        forFirstLevelCond = Math.Sqrt(num1) % 1 != 0 || Math.Sqrt(num1) < num2;
                        forSecondLevelCond = Math.Sqrt(num2) % 1 != 0;
                    } while (firsNumToSqrt ? forFirstLevelCond : forSecondLevelCond);

                    char localOp = ' ';
                    switch (m.Next(0, 3))
                    {
                        case 0:
                            localOp = '+';
                            break;
                        case 1:
                            localOp = '-';
                            break;
                        case 2:
                            localOp = '*';
                            break;
                    }
                    return firsNumToSqrt ? $"√{num1}{localOp}{num2}" : $"{num1}{localOp}√{num2}";
                }
            }
            else if (operation == '²')
            {
                if (Level == 8 || Level == 9)
                    return $"{m.Next(1, 16)}²";
                else
                {
                    num1 = m.Next(1, 16);
                    char localOp = ' ';
                    switch (m.Next(0, 3))
                    {
                        case 0:
                            localOp = '+';
                            num2 = m.Next(1, 51);
                            break;
                        case 1:
                            localOp = '-';
                            num2 = m.Next(1, 51);
                            break;
                        case 2:
                            localOp = '*';
                            num2 = m.Next(1, 10);
                            break;
                    }
                    return Math.Pow(num1, 2) < num2 ? $"{num2}{localOp}{num1}²" : $"{num1}²{localOp}{num2}";
                }
            }
            else
                return $"{m.Next(1, 10)}³";

            if (num1 < num2)
            {
                double temp = num1;
                num1 = num2;
                num2 = temp;
            }
            return $"{num1}{operation}{num2}";
        }

        public MathSkillWorker(SkillHolder skillHolder) : base(skillHolder) { }
    }
}
