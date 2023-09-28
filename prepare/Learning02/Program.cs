using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;
        job1.DisplayJobDetails();

        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;
        job2.DisplayJobDetails();

        Resume res1 = new Resume();
        res1._name = "Allison Rose";

        res1._jobs.Add(job1);
        res1._jobs.Add(job2);
        res1.DisplayResume();

    }
}