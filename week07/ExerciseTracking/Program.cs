using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Running running1 = new Running("25 Oct 2026", 30, 20);
        Cycling cycling1 = new Cycling("10 Now 2023", 40, 45);
        Swimming swimming1 = new Swimming("03 Sep 2021", 20, 8);

        foreach (Activity a in Activity.GetList())
        {
            a.GetSummary();
        }
    }
}