using System;
using System.Security.Principal;
using System.IO;
using database;

Man[] dbase = new Man[100];
int n = 0;
string name;
int n_man = 0;
double mean_pay = 0;
try
{
    StreamReader f = new StreamReader("dbase.txt");
    string s;
    int i =0;

    while ((s = f.ReadLine()) != null)
    {
        dbase[i] = new Man(s);
        Console.WriteLine(dbase[i]);
        ++i;
    }
    n = i - 1;
    f.Close();
    //while (!f.EndOfStream)
    //{
    //    s = f.ReadLine();
    //    string[] items = s.Split(';');
    //    Man manes= new Man();
    //    {
    //        name= items[0];
    //        n_man= int.Parse(items[1]);
    //        mean_pay= int.Parse(items[2]);
    //    }
    //}
}
catch (FileNotFoundException e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine("Проверьте правильность имени файла!");
    return;
}
catch (IndexOutOfRangeException)
{
   
    Console.WriteLine("Слишком большой файл!");
    return;
}
catch (FormatException)
{

    Console.WriteLine("Недопустимая дата рождения или оклад");
    return;
}
catch (Exception e)
{

    Console.WriteLine("Ошибка: " + e.Message);
    return;
}

Console.WriteLine("Введите фамилию сотрудника");

while ((name = Console.ReadLine())!="")
{
    bool not_found = true;
    for (int k =0; k<=0; ++k)
    {
        Man man = dbase[k];
        if (man.Compare(name)==0)
        {
            Console.WriteLine(man);
            ++n_man;
            mean_pay += man.Pay;
            not_found= false;
        }
    }
    if (not_found) Console.WriteLine("Такого сотрудника нет");
    Console.WriteLine("Введите фамилию сотрудника или Enter для окончания");
}
if (n_man>0)
{
    mean_pay = mean_pay/n_man;
    Console.WriteLine("Средний оклад: {0:F2}", mean_pay);
}