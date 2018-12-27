# 猜數字
- 題目 :
    輸入使用者猜的數字，與電腦給出的隨機數字比較，並列出幾A幾B，若玩家不玩了，可以輸入exit離開遊戲並顯示其正確答案。    
- 範例 : 
```
    輸入:1234
    輸出:2A2B
    輸入:4231
    輸出:4A0B
         恭喜你答對了!!
```
- 輸入exit，執行結果如下:
```
    輸入:1234
    輸出:2A2B
    輸入:exit
    輸出:離開遊戲,正確答案為:
         4231
``` 

# 亂數的使用
- 功用 :加入Random,產生隨機的數字
```cs
Random Rnd = new Random();
int[] number = new int[4];
```
但是Random()函式有極高的重複率(尤其在數字範圍愈小的情形)  
為此,我們需要自行創造一個演算法使得電腦給出的數值盡可能地隨機。
# 方法
我們先隨機給電腦一組數值(不管是否重複),並設定在0~9的範圍,並放入自訂的陣列中。
如:
```cs
Random Rnd = new Random();
int[] number = new int[4];
for(int k = 0; k <= 3; k++)
{
    number[k] = Rnd.Next(0,9);                             
}//先賦予陣列隨機4個數值
```
接下來我們需要讓4位數中的各數值不重複,這樣才能盡量達到不重複的隨機亂數。
- 想法 :
  - step1:
    每次從陣列中取一元素與其他元素比較,相同者重新賦值，並重頭取出數值再做比較(因其仍舊可能有所重複)，
    直到不重複為止。
  - step2:
    重複step1四次,即可得出四位數不重複之數值。
```cs
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
```
- 判斷是否有非數字之整數或文字符號:
為了能有效防止使用者輸入非數字之型別，這裡使用MSDN所介紹之一套用法。
引自MSDN說明:
```
基本數值類型也會實作 Parse 靜態方法，但如果字串不是有效數字，則會擲回例外狀況。 TryParse 通常更具效率，因為它在數字不正確時就會傳回 false。
```
-用法:
```
bool result = int.TryParse(sx, out n);
//如果字串包含非數值字元，或所指定之特定類型的數值太大或太小，則 TryParse 會傳回 false，並將 out 參數設定為零。 否則會傳回 true，並將 out 參數設定為字串的數值。
```

上述都能理解後,就開始自己試試看吧!    
# 作法
```cs
using System;
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
```
# 注意事項
小草籽保留最終所有權利
