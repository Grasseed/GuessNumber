# 猜數字
- 題目 :
    輸入使用者猜的數字，與電腦給出的隨機數字比較，並列出幾A幾B。    
- 範例 : 
```
    輸入:1234
    輸出:2A2B
    輸入:4231
    輸出:4A0B
         恭喜你答對了!!
```    
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
                        number[q] = Rnd.Next(0, 9);
                    }
                }
            }
            //每次取一個陣列值,依序比對值是否相同,若相同則再給一隨機數值,直到不相同便跳出
            //重複做這項動作3次(for(int q = 0; q <= 3; q++) {...} )
            int A = 0, B = 0;
            Console.WriteLine("猜數字遊戲,請輸入你要猜的數字:");
            int[] Guess = new int[4];
            while (number != Guess)
            {                
                if(count == 0)
                {
                    count++;
                    continue;
                }//第一次執行時count為0,不需要執行else的部分
                else
                {
                    n = int.Parse(Console.ReadLine());
                    a = n / 1000;
                    b = (n % 1000) / 100;
                    c = (n % 100) / 10;
                    d = (n % 10) / 1;
                    Guess = new int[4] { a, b, c, d };
                    for (int j = 0; j <= 3; j++ )
                    {
                        if(number[j] == Guess[j])
                        {
                            A++;
                        }//數字、位置皆對,顯示為A
                        else
                        {
                            for(int p = 0; p<=3 ; p++)
                            {
                                if(number[j] == Guess[p])
                                {
                                    B++;
                                }//若有猜中其中的數字但位置錯誤,則顯示為B
                            }                            
                        }
                    }//未猜中數字則不計
                    Console.WriteLine("{0}A{1}B", A, B);
                    if(A == 4)
                    {
                        Console.WriteLine("恭喜你答對了!!");
                        break;
                    }
                    Console.WriteLine("請再試一次");
                    A = B = 0;//A、B歸零                                      
                }                                
            }            
            Console.ReadKey();
        }
    }
}
```
# 注意事項
小草籽保留最終所有權利
