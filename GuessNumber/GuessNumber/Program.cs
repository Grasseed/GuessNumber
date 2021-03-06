﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Random Rnd = new Random();//加入Random,產生隨機的數字
            int[] number = new int[4];
            int a, b, c, d, count = 0, n;
            string sx;
            for(int k = 0; k <= 3; k++)
            {
                number[k] = Rnd.Next(0,9);           
            }
            //先賦予陣列隨機4個數值
            for(int q = 0; q <= 3;q++)
            {
                for (int s = 0; s <= 3; s++)
                {
                    while (number[q] == number[s] && q != s)
                    {
                        s = 0; //如有重複，將變數s設為0，再次檢查 (因為還是有重複的可能)
                        number[q] = Rnd.Next(0, 9);
                    }
                }
            }
            //每次取一個陣列值,依序比對值是否相同,若相同則再給一隨機數值,直到不相同便跳出
            //重複做這項動作3次(for(int q = 0; q <= 3; q++) {...} )
            int A = 0, B = 0;
            Console.WriteLine("猜數字遊戲,不猜了的話可以按輸入exit離開~~~~");
            Console.WriteLine("請輸入你要猜的數字:");
            int[] Guess = new int[4];
            while (number != Guess)
            {
                if (count == 0)
                {
                    count++;
                    continue;
                }//第一次執行時count為0,不需要執行else的部分
                else
                {
                    sx = Console.ReadLine();
                    if (sx == "exit")
                    {
                        Console.WriteLine("離開遊戲,正確答案為:");
                        for (int k = 0; k <= 3; k++)
                        {
                            Console.Write(number[k]);
                        }
                        break;  //直接跳至程式結束的區域
                    }
                    else
                    {
                        bool result = int.TryParse(sx, out n);
                        //如果字串包含非數值字元，或所指定之特定類型的數值太大或太小，則 TryParse 會傳回 false，並將 out 參數設定為零。 否則會傳回 true，並將 out 參數設定為字串的數值。
                        if (result != false)
                        {
                            n = int.Parse(sx);
                            a = n / 1000;
                            b = (n % 1000) / 100;
                            c = (n % 100) / 10;
                            d = (n % 10) / 1;
                            if (sx.Length > 4) //sx.Lengh為取sx字串長度
                            {
                                Console.WriteLine("輸入時請勿超過4位數");
                            }
                            else if (sx.Length < 4)
                            {
                                Console.WriteLine("輸入時請勿小於4位數");
                            }
                            else
                            {

                                Guess = new int[4] { a, b, c, d };
                                for (int j = 0; j <= 3; j++)
                                {
                                    if (number[j] == Guess[j])
                                    {
                                        A++;
                                    }//數字、位置皆對,顯示為A
                                    else
                                    {
                                        for (int p = 0; p <= 3; p++)
                                        {
                                            if (number[j] == Guess[p])
                                            {
                                                B++;
                                            }//若有猜中其中的數字但位置錯誤,則顯示為B
                                        }
                                    }
                                }//未猜中數字則不計
                                Console.WriteLine("{0}A{1}B", A, B);
                                if (A == 4)
                                {
                                    Console.WriteLine("恭喜你答對了!!");
                                    break;
                                }
                                Console.WriteLine("請再試一次");
                                A = B = 0;//A、B歸零  
                            }
                        }
                        else
                        {
                            Console.WriteLine("請勿輸入非數字之文字及符號。");
                        }
                    }
                }
            }
            //程式結束區       
            Console.Read();
        }
    }
}
