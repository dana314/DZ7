// 8.1 В класс банковский счет, созданный в упражнениях 7.1- 7.3 добавить метод,
// который переводит деньги с одного счета на другой.
using System;
using Lab8.AccountType;
using Lab8.BankAccount;
class Program
{
    static void Main(string[] args)
    {
        BankAccount Account1 = new BankAccount(AccountT.savings);
        Account1.Info();
        Account1.Replenishment(50000);
        Account1.Take0ff(5000);
        Account1.Info();

        BankAccount Account2 = new BankAccount(AccountT.actual);
        Account2.Info();
        Account1.Transaction(Account2, 300);
        Account1.Info();
        Account2.Info();



        // 8.2 Реализовать метод, который в качестве входного параметра принимает
        // строку string, возвращает строку типа string, буквы в которой идут в обратном порядке.
        string stroka = "Меладзе";
        string newStroka = Reversed(stroka);
        Console.WriteLine(newStroka);

        static string Reversed(string stroka)
        {
            char[] newStroka = stroka.ToCharArray();
            Array.Reverse(newStroka);
            return new string(newStroka);
        }


        // 8.3 Написать программу, которая спрашивает у пользователя имя файла.
        Console.Write("введите полное имя файла ");
        string file1 = Console.ReadLine();
        if (!File.Exists(file1))
        {
            Console.WriteLine("файла не существует");
            return;
        }
        string file2 = "file2.pdf"; 

        try
        {
            string inside = File.ReadAllText(file1);
            string insideUp = inside.ToUpper();
            File.WriteAllText(file2, insideUp);
            Console.WriteLine("файл перезаписан заглавными буквами");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ошибка ввода");
        }


        // 8.4 
        object variant1 = 55;
        object variant2 = 55.55;
        object variant3 = "5555";

        TryFormat(variant1);
        TryFormat(variant2);
        TryFormat(variant3);
        static void TryFormat(object variant)
        {
            IFormattable format = variant as IFormattable;
            if (format!=null)
            {
                Console.WriteLine("интерфейс IFormattable реализуется");
            }
            else
            {
                Console.WriteLine("интерфейс IFormattable не реализуется ");
            }
        }


        // дз1 Работа со строками
        string file_1 = "555.txt"; 
        string file_2 = "666.txt";

        try
        {
            using (StreamReader reader = new StreamReader(file_1))
            using (StreamWriter writer = new StreamWriter(file_2))
            {
                string strokaN;
                while ((strokaN = reader.ReadLine()) != null)
                {
                    SearchMail(ref stroka);
                    if (!string.IsNullOrEmpty(strokaN))
                    {
                        writer.WriteLine(strokaN);
                    }
                }
            }

            Console.WriteLine($"адреса электронной почты в '{file_1}'");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ошибка ввода");
        }
        static void SearchMail(ref string s)
        {
            string[] parts = s.Split('#');
            if (parts.Length > 1)
            {
                s = parts[1].Trim();
            }
            else
            {
                s = string.Empty;
            }
        }
    
    }


}
