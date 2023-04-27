using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Task
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var a = new Program();
            a.RunProgram();
        }

        public string CheckNumber(string str, out int num)
        {
            while (!int.TryParse(str, out num))
            {
                Console.WriteLine("You write not a number");
                Console.Write("Try again: ");
                str = Console.ReadLine();
            }

            return str;
        }

        public void RunProgram()
        {
            string contin;
            string strNum;
            var str1 = "K K  KBJHAHBAHBJA! ccajcha KjabCJSB, LMDCDSCS! DNVADSDNAA K";
            int intNum;
            var M = 1;
            var N = 10;
            var mas = new int[] { 1, -6, 5, -10, -8, 3 };
            var mas1 = new int[,] { { 1, 6, 3, 4 }, { 5, 6, 12, 8 }, { 9, 10, 11, 12 } };            

            while (true)
            {
                Console.Clear();
                Console.Write("Please write Number of task: ");
                strNum = Console.ReadLine();
                CheckNumber(strNum, out intNum);
                Console.Clear();

                switch (intNum)
                {
                    case 1:
                        var task1 = new Task1();
                        break;
                    case 2:
                        var task2 = new Task2();                        
                        break;
                    case 3:
                        var task3 = new Task3();
                        break;
                    case 4:
                        var task4 = new Task4();
                        break;
                    case 5:
                        var task5 = new Task5(10);
                        break;
                    case 6:
                        var task6 = new Task6(30);
                        break;
                    case 7:
                        var task7 = new Task7(mas);
                        break;
                    case 8:
                        var task8 = new Task8(mas);
                        break;
                    case 9:
                        var task9 = new Task9(mas);
                        break;
                    case 10:
                        var task10 = new Task10(mas, M, N);
                        break;
                    case 11:
                        var task11 = new Task11(mas1);
                        break;
                    case 12:
                        var task12 = new Task12(mas1);
                        break;
                    case 13:
                        var task13 = new Task13(mas1);
                        break;
                    case 14:
                        var task14 = new Task14(str1);
                        break;
                    case 15:
                        var task15 = new Task15(str1);
                        break;
                    case 16:
                        var task16 = new Task16(str1);
                        break;
                    case 17:
                        var task17 = new Task17(str1);
                        break;
                    case 18:
                        var task18 = new Task18(str1);
                        break;
                    default:
                        Console.WriteLine("So number is not exhist");
                        break;
                }

                Console.WriteLine("Do you want to continue? ( Write 1 if YES ): ");
                contin = Console.ReadLine();

                if (contin != "1")
                    break;
            }
        }
    }
}
