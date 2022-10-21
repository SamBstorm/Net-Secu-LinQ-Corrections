using LINQDataContext;

namespace ExerciceDeLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataContext dc = new DataContext();

            #region Faites vos exos ici

            /** 1.1
            var result_1_1 = dc.Students.Select(s => new { s.Last_Name, s.Login, s.BirthDate, s.Year_Result });

            var result_exp_1_1 = from s in dc.Students
                                 select new { s.Last_Name, s.Login, s.BirthDate, s.Year_Result };

            foreach (var student in result_exp_1_1)
            {
                Console.WriteLine($"{student.Last_Name} {student.Login} {student.BirthDate} {student.Year_Result}");
            }
             */

            /** 1.3 
            IEnumerable<string> result_1_3 = dc.Students.Select(s => s.Student_ID + "|" + s.First_Name + "|" + s.Last_Name + "|" + s.BirthDate + "|" + s.Login + "|" + s.Section_ID + "|" + s.Year_Result + "|" + s.Course_ID);

            IEnumerable<string> result_exp_1_3 = from s in dc.Students
                                                 select s.Student_ID + "|" + s.First_Name + "|" + s.Last_Name + "|" + s.BirthDate + "|" + s.Login + "|" + s.Section_ID + "|" + s.Year_Result + "|" + s.Course_ID;

            foreach (string info in result_exp_1_3)
            {
                Console.WriteLine(info);
            }
             */

            /** 2.1

            var result_2_1 = dc.Students
                                .Where(s => s.BirthDate.Year < 1955)
                                .Select(s => new { s.Last_Name, s.BirthDate, Status = (s.Year_Result >= 12) ? "OK" : "KO" });

            var result_exp_2_1 = from s in dc.Students
                                 where s.BirthDate.Year < 1955
                                 select new { s.Last_Name, s.BirthDate, Status = (s.Year_Result >= 12) ? "OK" : "KO" };

            foreach (var student in result_exp_2_1)
            {
                Console.WriteLine($"{student.Last_Name}, {student.BirthDate} , {student.Status}");
            }
             */

            /** 2.5

            var result_2_5 = dc.Students
                                .Where(s => s.Section_ID == 1110)
                                .OrderBy(s => s.Last_Name)
                                .Select(s => new { Full_Name = s.Last_Name + " " + s.First_Name, s.Year_Result });

            var result_exp_2_5 = from s in dc.Students
                                 where s.Section_ID == 1110
                                 orderby s.Last_Name
                                 select new { Full_Name = s.Last_Name + " " + s.First_Name, s.Year_Result };

            foreach (var student in result_2_5)
            {
                Console.WriteLine($"{student.Full_Name} : {student.Year_Result}");
            }
             */

            #endregion

            #region Console.ReadLine()
            Console.ReadLine();
            #endregion
        }
    }
}