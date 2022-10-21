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

            /** 3.1

            double result_3_1 = dc.Students.Average(s => s.Year_Result);

            double result_exp_3_1 = (from s in dc.Students
                                    select s.Year_Result).Average();

            Console.WriteLine($"La moyenne est de {result_3_1}");
             */

            /** 3.5

            int result_3_5 = dc.Students.Count(s => s.Year_Result%2 == 1);

            int result_exp_3_5 = (from s in dc.Students
                                 where s.Year_Result % 2 == 1
                                 select s).Count();

            Console.WriteLine($"Seul {result_3_5} ont un résultat impair...");
             */

            /** 4.1
            //var result_4_1 = dc.Students
            //                    .GroupBy(s => s.Section_ID)
            //                    .Select(g => new { SectionId = g.Key , MaxResult = g.Max(s=>s.Year_Result)});

            IEnumerable<IGrouping<int, Student>> temp_groups = dc.Students
                                                                .GroupBy(s => s.Section_ID);
            var result_4_1 = temp_groups.Select(g => new { SectionId = g.Key, MaxResult = g.Max(s => s.Year_Result) });

            foreach (var group in result_4_1)
            {
                Console.WriteLine($"Pour la section { group.SectionId } le maximum est {group.MaxResult}");
            }
             */

            #endregion

            #region Correctifs officiels



            #region EX 1.1
            {
                //var Result11 = from s in dc.Students
                //               select new
                //               {
                //                   Nom = s.Last_Name,
                //                   DateNaiss = s.BirthDate,
                //                   Login = s.Login,
                //                   Resultat = s.Year_Result
                //               };

                //var Result11Bis = dc.Students.Select(s => new { Nom = s.Last_Name, DateNaiss = s.BirthDate, Login = s.Login, Resultat = s.Year_Result });

                //Console.WriteLine("Exercice 1.1 : {0} résultat(s)", Result11.Count());
                //foreach (var s in Result11)
                //{
                //    Console.WriteLine("{0} - {1} - {2} - {3}", s.Nom, s.DateNaiss.ToShortDateString(), s.Login, s.Resultat);
                //}

                //Console.WriteLine();
                //foreach (var s in Result11Bis)
                //{
                //    Console.WriteLine("{0} - {1} - {2} - {3}", s.Nom, s.DateNaiss.ToShortDateString(), s.Login, s.Resultat);
                //}
            }
            #endregion

            #region EX 1.2
            {
                //var Result12 = from s in dc.Students
                //               select new
                //               {
                //                   NomComplet = string.Format("{0} {1}", s.Last_Name, s.First_Name),
                //                   ID = s.Student_ID,
                //                   DateNaiss = s.BirthDate
                //               };

                //var Result12Bis = dc.Students.Select(s => new { NomComplet = string.Format("{0} {1}", s.Last_Name, s.First_Name), ID = s.Student_ID, DateNaiss = s.BirthDate });

                //Console.WriteLine("Exercice 1.2 : {0} résultat(s)", Result12.Count());
                //foreach (var s in Result12)
                //{
                //    Console.WriteLine("{0} - {1} - {2}", s.NomComplet, s.ID, s.DateNaiss.ToShortDateString());
                //}

                //Console.WriteLine();
                //foreach (var s in Result12Bis)
                //{
                //    Console.WriteLine("{0} - {1} - {2}", s.NomComplet, s.ID, s.DateNaiss.ToShortDateString());
                //}
            }
            #endregion

            #region EX 1.3
            {
                //IEnumerable<string> Result13 = from s in dc.Students
                //                               select string.Format("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7}", s.Student_ID, s.First_Name, s.Last_Name, s.BirthDate.ToShortDateString(), s.Login, s.Section_ID, s.Year_Result, s.Course_ID);

                //IEnumerable<string> Result13Bis = dc.Students.Select(s => string.Format("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7}", s.Student_ID, s.First_Name, s.Last_Name, s.BirthDate.ToShortDateString(), s.Login, s.Section_ID, s.Year_Result, s.Course_ID));

                //Console.WriteLine("Exercice 1.3 : {0} résultat(s)", Result13.Count());
                //foreach (string s in Result13)
                //{
                //    Console.WriteLine(s);
                //}

                //Console.WriteLine();
                //foreach (string s in Result13Bis)
                //{
                //    Console.WriteLine(s);
                //}
            }
            #endregion

            #region EX 2.1
            {
                //var Result21 = from s in dc.Students
                //               where s.BirthDate.Year < 1955
                //               select new { Nom = s.Last_Name, Resultat = s.Year_Result, Statut = (s.Year_Result < 12) ? "KO" : "OK" };

                //var Result21Bis = dc.Students.Where(s => s.BirthDate.Year < 1955)
                //                             .Select(s => new { Nom = s.Last_Name, Resultat = s.Year_Result, Statut = (s.Year_Result < 12) ? "KO" : "OK" });

                //Console.WriteLine("Exercice 2.1 : {0} résultat(s)", Result21.Count());
                //foreach (var s in Result21)
                //{
                //    Console.WriteLine(string.Format("{0} - {1} - {2}", s.Nom, s.Resultat, s.Statut));
                //}

                //Console.WriteLine();
                //foreach (var s in Result21Bis)
                //{
                //    Console.WriteLine(string.Format("{0} - {1} - {2}", s.Nom, s.Resultat, s.Statut));
                //}
            }
            #endregion

            #region EX 2.2
            {
                //var Result22 = from s in dc.Students
                //               where s.BirthDate.Year >= 1955 && s.BirthDate.Year <= 1965
                //               select new { Nom = s.Last_Name, Resultat = s.Year_Result, Categorie = (s.Year_Result < 10) ? "Inférieur" : (s.Year_Result > 10) ? "Supérieur" : "Neutre" };

                //var Result22Bis = dc.Students.Where(s => s.BirthDate.Year >= 1955 && s.BirthDate.Year <= 1965)
                //                             .Select(s => new { Nom = s.Last_Name, Resultat = s.Year_Result, Categorie = (s.Year_Result < 10) ? "Inférieur" : (s.Year_Result > 10) ? "Supérieur" : "Neutre" });
                //Console.WriteLine("Exercice 2.2 : {0} résultat(s)", Result22.Count());
                //foreach (var s in Result22)
                //{
                //    Console.WriteLine(string.Format("{0} - {1} - {2}", s.Nom, s.Resultat, s.Categorie));
                //}

                //Console.WriteLine();
                //foreach (var s in Result22Bis)
                //{
                //    Console.WriteLine(string.Format("{0} - {1} - {2}", s.Nom, s.Resultat, s.Categorie));
                //}
            }
            #endregion

            #region EX 2.3
            {
                //var Result23 = from s in dc.Students
                //               where s.Last_Name.ToLower().EndsWith("r")
                //               select new { s.Last_Name, s.Section_ID };

                //var Result23Bis = dc.Students.Where(s => s.Last_Name.ToLower().EndsWith("r")).Select(s => new { s.Last_Name, s.Section_ID });

                //Console.WriteLine("Exercice 2.3 : {0} résultat(s)", Result23.Count());
                //foreach (var s in Result23)
                //{
                //    Console.WriteLine("{0} - {1}", s.Last_Name, s.Section_ID);
                //}

                //Console.WriteLine();
                //foreach (var s in Result23Bis)
                //{
                //    Console.WriteLine("{0} - {1}", s.Last_Name, s.Section_ID);
                //}
            }
            #endregion

            #region EX 2.4
            {
                //var Result24 = from s in dc.Students
                //               where s.Year_Result <= 3
                //               orderby s.Year_Result descending
                //               select new { s.Last_Name, s.Year_Result };

                //var Result24Bis = dc.Students.Where(s => s.Year_Result <= 3)
                //                             .OrderByDescending(s => s.Year_Result)
                //                             .Select(s => new { s.Last_Name, s.Year_Result });

                //Console.WriteLine("Exercice 2.4 : {0} résultat(s)", Result24.Count());
                //foreach (var s in Result24)
                //{
                //    Console.WriteLine("{0} - {1}", s.Last_Name, s.Year_Result);
                //}

                //Console.WriteLine();
                //foreach (var s in Result24Bis)
                //{
                //    Console.WriteLine("{0} - {1}", s.Last_Name, s.Year_Result);
                //}
            }
            #endregion

            #region EX 2.5
            {
                //var Result25 = from s in dc.Students
                //               where s.Section_ID == 1110
                //               orderby s.Last_Name
                //               select new { NomComplet = string.Format("{0} {1}", s.Last_Name, s.First_Name), s.Year_Result };

                //var Result25Bis = dc.Students.Where(s => s.Section_ID == 1110)
                //                             .OrderBy(s => s.Last_Name)
                //                             .Select(s => new { NomComplet = string.Format("{0} {1}", s.Last_Name, s.First_Name), s.Year_Result });

                //Console.WriteLine("Exercice 2.5 : {0} résultat(s)", Result25.Count());
                //foreach (var s in Result25)
                //{
                //    Console.WriteLine("{0} - {1}", s.NomComplet, s.Year_Result);
                //}

                //Console.WriteLine();
                //foreach (var s in Result25Bis)
                //{
                //    Console.WriteLine("{0} - {1}", s.NomComplet, s.Year_Result);
                //}
            }

            #endregion

            #region EX 2.6
            {
                //var Result26 = from s in dc.Students
                //               where !(s.Year_Result >= 12 && s.Year_Result <= 18) && (s.Section_ID == 1010 || s.Section_ID == 1020)
                //               orderby s.Section_ID
                //               select new { s.Last_Name, s.Section_ID, s.Year_Result };

                //var Result26Bis = dc.Students.Where(s => !(s.Year_Result >= 12 && s.Year_Result <= 18) && (s.Section_ID == 1010 || s.Section_ID == 1020))
                //                             .OrderBy(s => s.Section_ID)
                //                             .Select(s => new { s.Last_Name, s.Section_ID, s.Year_Result });

                //Console.WriteLine("Exercice 2.6 : {0} résultat(s)", Result26.Count());
                //foreach (var s in Result26)
                //{
                //    Console.WriteLine("{0} - {1} - {2}", s.Last_Name, s.Section_ID, s.Year_Result);
                //}

                //Console.WriteLine();
                //foreach (var s in Result26Bis)
                //{
                //    Console.WriteLine("{0} - {1} - {2}", s.Last_Name, s.Section_ID, s.Year_Result);
                //}
            }
            #endregion

            #region EX 2.7
            {
                //var Result27 = from s in dc.Students
                //               where s.Section_ID.ToString().StartsWith("13") && s.Year_Result * 5 < 60
                //               orderby s.Year_Result descending
                //               select new { s.Last_Name, s.Section_ID, Result100 = s.Year_Result * 5 };

                //var Result27Bis = dc.Students.Where(s => s.Section_ID.ToString().StartsWith("13") && s.Year_Result * 5 < 60)
                //                             .OrderByDescending(s => s.Year_Result)
                //                             .Select(s => new { s.Last_Name, s.Section_ID, Result100 = s.Year_Result * 5 });

                //var Result27Tiers = dc.Students.Where(s => s.Section_ID.ToString().StartsWith("13") && s.Year_Result * 5 < 60)
                //                               .Select(s => new { s.Last_Name, s.Section_ID, Result100 = s.Year_Result * 5 })                                               
                //                               .OrderByDescending(s => s.Result100);

                //Console.WriteLine("Exercice 2.7 : {0} résultat(s)", Result27.Count());
                //foreach (var s in Result27)
                //{
                //    Console.WriteLine("{0} - {1} - {2}", s.Last_Name, s.Section_ID, s.Result100);
                //}

                //Console.WriteLine();
                //foreach (var s in Result27Bis)
                //{
                //    Console.WriteLine("{0} - {1} - {2}", s.Last_Name, s.Section_ID, s.Result100);
                //}

                //Console.WriteLine();
                //foreach (var s in Result27Tiers)
                //{
                //    Console.WriteLine("{0} - {1} - {2}", s.Last_Name, s.Section_ID, s.Result100);
                //}
            }
            #endregion

            #region EX 3.1
            {
                //double Result31 = (from s in dc.Students
                //                   select s.Year_Result).Average();

                //double Result31Bis = dc.Students.Average(s => s.Year_Result);

                //Console.WriteLine("Exercice 3.1 : ");
                //Console.WriteLine(Result31);
                //Console.WriteLine(Result31Bis);
            }
            #endregion

            #region EX 3.2
            {
                //int Result32 = (from s in dc.Students
                //                select s.Year_Result).Max();

                //int Result32Bis = dc.Students.Max(s => s.Year_Result);

                //Console.WriteLine("Exercice 3.2 :");
                //Console.WriteLine(Result32);
                //Console.WriteLine(Result32Bis);
            }
            #endregion

            #region EX 3.3
            {
                //int Result33 = (from s in dc.Students
                //                select s.Year_Result).Sum();

                //int Result33Bis = dc.Students.Sum(s => s.Year_Result);

                //Console.WriteLine("Exercice 3.3 : ");
                //Console.WriteLine(Result33);
                //Console.WriteLine(Result33Bis);
            }
            #endregion

            #region EX 3.4
            {
                //int Result34 = (from s in dc.Students
                //                select s.Year_Result).Min();

                //int Result34Bis = dc.Students.Min(s => s.Year_Result);

                //Console.WriteLine("Exercice 3.4 : ");
                //Console.WriteLine(Result34);
                //Console.WriteLine(Result34Bis);
            }
            #endregion

            #region EX 3.5
            {
                //int Result35 = (from s in dc.Students
                //                select s).Count(s => s.Year_Result % 2 == 1);

                //int Result35Bis = dc.Students.Count(s => s.Year_Result % 2 == 1);

                //Console.WriteLine("Exercice 3.5 : ");
                //Console.WriteLine(Result35);
                //Console.WriteLine(Result35Bis);
            }
            #endregion

            #region EX 4.1
            {
                //var Result41 = from s in dc.Students
                //               group s by s.Section_ID into SubStudents
                //               select new { SectionID = SubStudents.Key, MaxResult = SubStudents.Max(st => st.Year_Result) };

                //var Result41Bis = dc.Students.GroupBy(s => s.Section_ID)
                //                    .Select(g => new { SectionID = g.Key, MaxResult = g.Max(s => s.Year_Result) });

                //Console.WriteLine("Exercice 4.1 : {0} résultat(s)", Result41.Count());
                //foreach (var s in Result41)
                //{
                //    Console.WriteLine("{0} - {1}", s.SectionID, s.MaxResult);
                //}

                //Console.WriteLine();
                //foreach (var s in Result41Bis)
                //{
                //    Console.WriteLine("{0} - {1}", s.SectionID, s.MaxResult);
                //}
            }
            #endregion

            #region EX 4.2
            {
                //var Result42 = from s in dc.Students
                //               where s.Section_ID.ToString().StartsWith("10")
                //               group s by s.Section_ID into IGroupStudents
                //               select new { SectionID = IGroupStudents.Key, AvgResult = IGroupStudents.Average(st => st.Year_Result) };

                //var Result42Bis = dc.Students.Where(se => se.Section_ID.ToString().StartsWith("10"))
                //                             .GroupBy(st => st.Section_ID)
                //                             .Select(IGroupStudents => new { SectionID = IGroupStudents.Key, AvgResult = IGroupStudents.Average(st => st.Year_Result) });

                //Console.WriteLine("Exercice 4.2 : {0} résultat(s)", Result42.Count());
                //foreach (var s in Result42)
                //{
                //    Console.WriteLine("{0} - {1}", s.SectionID, s.AvgResult);
                //}

                //Console.WriteLine();
                //foreach (var s in Result42Bis)
                //{
                //    Console.WriteLine("{0} - {1}", s.SectionID, s.AvgResult);
                //}
            }
            #endregion

            #region EX 4.3
            {
                //var Result43 = from s in dc.Students
                //               where s.BirthDate.Year >= 1970 && s.BirthDate.Year <= 1985
                //               group s by s.BirthDate.Month into IGroupStudents
                //               select new { Mois = IGroupStudents.Key, AVGResult = IGroupStudents.Average(s => s.Year_Result) };

                //var Result43Bis = dc.Students.Where(s => s.BirthDate.Year >= 1970 && s.BirthDate.Year <= 1985)
                //                             .GroupBy(s => s.BirthDate.Month)
                //                             .Select(IGroupStudents => new { Mois = IGroupStudents.Key, AVGResult = IGroupStudents.Average(s => s.Year_Result) });

                //Console.WriteLine("Exercice 4.3 : {0} résultat(s)", Result43.Count());
                //foreach (var s in Result43)
                //{
                //    Console.WriteLine("{0} - {1}", s.Mois, s.AVGResult);
                //}

                //Console.WriteLine();
                //foreach (var s in Result43Bis)
                //{
                //    Console.WriteLine("{0} - {1}", s.Mois, s.AVGResult);
                //}
            }
            #endregion

            #region EX 4.4
            {
                //var Result44 = from st in dc.Students
                //               group st by st.Section_ID into IGroupStudents
                //               where IGroupStudents.Count() > 3
                //               select new
                //               {
                //                   Section_ID = IGroupStudents.Key,
                //                   AVGResult = IGroupStudents.Average(st => st.Year_Result)
                //               };

                //var Result44Bis = dc.Students.GroupBy(s => s.Section_ID)
                //                             .Where(IGroupStudents => IGroupStudents.Count() > 3)
                //                             .Select(IGroupStudents => new
                //                             {
                //                                 Section_ID = IGroupStudents.Key,
                //                                 AVGResult = IGroupStudents.Average(st => st.Year_Result)
                //                             });

                //Console.WriteLine("Exercice 4.4 : {0} résultat(s)", Result44.Count());
                //foreach (var s in Result44)
                //{
                //    Console.WriteLine("{0} - {1}", s.Section_ID, s.AVGResult);
                //}

                //Console.WriteLine();
                //foreach (var s in Result44Bis)
                //{
                //    Console.WriteLine("{0} - {1}", s.Section_ID, s.AVGResult);
                //}
            }
            #endregion

            #region EX 4.5
            {
                //var Result45 = from c in dc.Courses
                //               join p in dc.Professors on c.Professor_ID equals p.Professor_ID
                //               join s in dc.Sections on p.Section_ID equals s.Section_ID
                //               select new { c.Course_Name, s.Section_Name, p.Professor_Name };

                //var Result45Bis = dc.Courses.Join(dc.Professors, c => c.Professor_ID, p => p.Professor_ID, (c, p) => new { Course = c, Professor = p })
                //                            .Join(dc.Sections, cp => cp.Professor.Section_ID, s => s.Section_ID, (cp, s) => new { cp.Course.Course_Name, s.Section_Name, cp.Professor.Professor_Name });

                //Console.WriteLine("Exercice 4.5 : {0} résultat(s)", Result45.Count());
                //foreach (var r in Result45)
                //{
                //    Console.WriteLine("{0} - {1} - {2}", r.Course_Name, r.Section_Name, r.Professor_Name);
                //}

                //Console.WriteLine("Exercice 4.5 : {0} résultat(s)", Result45Bis.Count());
                //foreach (var r in Result45Bis)
                //{
                //    Console.WriteLine("{0} - {1} - {2}", r.Course_Name, r.Section_Name, r.Professor_Name);
                //}
            }
            #endregion

            #region EX 4.6
            {
                //var Result46 = from se in dc.Sections
                //               join st in dc.Students on se.Delegate_ID equals st.Student_ID
                //               orderby se.Section_ID descending
                //               select new { se.Section_ID, se.Section_Name, Delegate_Last_Name = st.Last_Name };

                //var Result46Bis = dc.Sections.Join(dc.Students, se => se.Delegate_ID, st => st.Student_ID, (se, st) => new { se.Section_ID, se.Section_Name, Delegate_Last_Name = st.Last_Name })
                //                             .OrderByDescending(jointure => jointure.Section_ID);


                //Console.WriteLine("Exercice 4.6 : {0} résultat(s)", Result46.Count());
                //foreach (var r in Result46)
                //{
                //    Console.WriteLine("{0} - {1} - {2}", r.Section_ID, r.Section_Name, r.Delegate_Last_Name);
                //}

                //Console.WriteLine();
                //foreach (var r in Result46Bis)
                //{
                //    Console.WriteLine("{0} - {1} - {2}", r.Section_ID, r.Section_Name, r.Delegate_Last_Name);
                //}
            }
            #endregion

            #region EX 4.7
            {
                //var Result47 = from se in dc.Sections
                //               join p in dc.Professors on se.Section_ID equals p.Section_ID into SubProfs
                //               select new { se.Section_ID, se.Section_Name, Professors = SubProfs.Select(pr => pr.Professor_Name) };

                //var Result47Bis = dc.Sections.GroupJoin(dc.Professors, se => se.Section_ID, p => p.Section_ID, (se, SubProfs) => new { se.Section_ID, se.Section_Name, Professors = SubProfs.Select(pr => pr.Professor_Name) });

                //Console.WriteLine("Exercice 4.7 : {0} résultat(s)", Result47.Count());
                //foreach (var r in Result47)
                //{
                //    Console.WriteLine("{0} - {1} Professors : ", r.Section_ID, r.Section_Name);
                //    foreach (string p_name in r.Professors)
                //    {
                //        Console.WriteLine("- {0}", p_name);
                //    }
                //}

                //Console.WriteLine();
                //foreach (var r in Result47Bis)
                //{
                //    Console.WriteLine("{0} - {1} Professors : ", r.Section_ID, r.Section_Name);
                //    foreach (string p_name in r.Professors)
                //    {
                //        Console.WriteLine("- {0}", p_name);
                //    }
                //}
            }
            #endregion

            #region EX 4.8
            {
                //var Result48 = from se in dc.Sections
                //               join p in dc.Professors on se.Section_ID equals p.Section_ID into SubProfs
                //               where SubProfs.Count() > 0
                //               select new { se.Section_ID, se.Section_Name, Professors = SubProfs.Select(pr => pr.Professor_Name) };

                //var Result48Bis = dc.Sections.GroupJoin(dc.Professors, se => se.Section_ID, p => p.Section_ID, (se, SubProfs) => new { se.Section_ID, se.Section_Name, Professors = SubProfs.Select(pr => pr.Professor_Name) })
                //                             .Where(Jointure => Jointure.Professors.Count() > 0);

                //Console.WriteLine("Exercice 4.8 : {0} résultat(s)", Result48.Count());
                //foreach (var r in Result48)
                //{
                //    Console.WriteLine("{0} - {1} Professors : ", r.Section_ID, r.Section_Name);
                //    foreach (string p_name in r.Professors)
                //    {
                //        Console.WriteLine("- {0}", p_name);
                //    }
                //}

                //Console.WriteLine();
                //foreach (var r in Result48Bis)
                //{
                //    Console.WriteLine("{0} - {1} Professors : ", r.Section_ID, r.Section_Name);
                //    foreach (string p_name in r.Professors)
                //    {
                //        Console.WriteLine("- {0}", p_name);
                //    }
                //}
            }
            #endregion

            #region EX 4.9 (Cross Join)
            {
                //var Result49 = from s in dc.Students
                //               from g in dc.Grades
                //               where s.Year_Result >= 12 && s.Year_Result >= g.Lower_Bound && s.Year_Result <= g.Upper_Bound
                //               orderby g.GradeName
                //               select new { s.Last_Name, s.Year_Result, Grade = g.GradeName };

                //var Result49Bis = dc.Students.Join(dc.Grades, st => true, gr => true, (st, grade) => new { Student = st, Grade = grade })
                //                             .Where(join => join.Student.Year_Result >= 12 && join.Student.Year_Result >= join.Grade.Lower_Bound && join.Student.Year_Result <= join.Grade.Upper_Bound)
                //                             .Select(join => new { join.Student.Last_Name, join.Student.Year_Result, Grade = join.Grade.GradeName })
                //                             .OrderBy(elt => elt.Grade);

                //Console.WriteLine("Exercice 4.9 : {0} résultat(s)", Result49.Count());
                //foreach (var r in Result49)
                //{
                //    Console.WriteLine("{0} - {1} - {2}", r.Last_Name, r.Year_Result, r.Grade);
                //}

                //Console.WriteLine();
                //foreach (var r in Result49Bis)
                //{
                //    Console.WriteLine("{0} - {1} - {2}", r.Last_Name, r.Year_Result, r.Grade);
                //}
            }
            #endregion

            #region EX 4.10 (Très Très HARD!!!)
            {
                //var Result410 = from p in dc.Professors
                //                join c in dc.Courses on p.Professor_ID equals c.Professor_ID into SubCourses
                //                from sc in SubCourses.DefaultIfEmpty()
                //                join s in dc.Sections on p.Section_ID equals s.Section_ID into SubSections
                //                from ss in SubSections.DefaultIfEmpty()
                //                select new
                //                {
                //                    p.Professor_Name,
                //                    Section_Name = (ss != null) ? ss.Section_Name : null,
                //                    Course_Name = (sc != null) ? sc.Course_Name : null,
                //                    Course_Ects = (sc != null) ? (float?)sc.Course_Ects : null
                //                } into SubResult
                //                orderby SubResult.Course_Ects descending
                //                select new
                //                {
                //                    SubResult.Professor_Name,
                //                    Section_Name = (SubResult.Section_Name != null) ? SubResult.Section_Name : "Null",
                //                    Course_Name = (SubResult.Course_Name != null) ? SubResult.Course_Name : "Null",
                //                    Course_Ects = (SubResult.Course_Ects != null) ? SubResult.Course_Ects.ToString() : "Null"
                //                };


                //var Result410Bis = dc.Professors.GroupJoin(dc.Courses, p => p.Professor_ID, c => c.Professor_ID, (p, cs) => new { Professor = p, Courses = cs })
                //                                .SelectMany(r => r.Courses.DefaultIfEmpty(), (pc, c) => new { Professor = pc.Professor, Course = c })
                //                                .GroupJoin(dc.Sections, p => p.Professor.Section_ID, s => s.Section_ID, (pc, s) => new { Professor = pc.Professor, Course = pc.Course, Sections = s })
                //                                .SelectMany(r => r.Sections.DefaultIfEmpty(), (pcs, s) => new { Professor = pcs.Professor, Course = pcs.Course, Section = s })
                //                                .Select(pcs => new
                //                                {
                //                                    pcs.Professor.Professor_Name,
                //                                    Section_Name = (pcs.Section != null) ? pcs.Section.Section_Name : null,
                //                                    Course_Name = (pcs.Course != null) ? pcs.Course.Course_Name : null,
                //                                    Course_Ects = (pcs.Course != null) ? (float?)pcs.Course.Course_Ects : null
                //                                })
                //                                .OrderByDescending(r => r.Course_Ects)
                //                                .Select(r => new
                //                                {
                //                                    r.Professor_Name,
                //                                    Section_Name = (r.Section_Name != null) ? r.Section_Name : "NULL",
                //                                    Course_Name = (r.Course_Name != null) ? r.Course_Name : "NULL",
                //                                    Course_Ects = (r.Course_Ects != null) ? r.Course_Ects.ToString() : "NULL"
                //                                });


                //Console.WriteLine("Exercice 4.10 : {0} résultat(s)", Result410.Count());
                //foreach (var r in Result410)
                //{
                //    Console.WriteLine("{0} - {1} - {2} - {3}", r.Professor_Name, r.Section_Name, r.Course_Name, r.Course_Ects);
                //}

                //Console.WriteLine();
                //foreach (var r in Result410Bis)
                //{
                //    Console.WriteLine("{0} - {1} - {2} - {3}", r.Professor_Name, r.Section_Name, r.Course_Name, r.Course_Ects);
                //}
            }
            #endregion

            #region EX 4.11
            {
                //var Result411 = from p in dc.Professors
                //                join c in dc.Courses on p.Professor_ID equals c.Professor_ID into SubCourses
                //                orderby SubCourses.Sum(c => c.Course_Ects) descending
                //                select new { p.Professor_ID, Course_Ects = (SubCourses.Count() > 0) ? (float?)SubCourses.Sum(co => co.Course_Ects) : null };

                //var Result411Bis = dc.Professors.GroupJoin(dc.Courses, p => p.Professor_ID, c => c.Professor_ID, (p, SubCourses) => new { p.Professor_ID, Course_Ects = (SubCourses.Count() > 0) ? (float?)SubCourses.Sum(co => co.Course_Ects) : null })
                //                                .OrderByDescending(r => r.Course_Ects);

                //Console.WriteLine("Exercice 4.11 : {0} résultat(s)", Result411.Count());
                //foreach (var r in Result411)
                //{
                //    Console.WriteLine("{0} - {1}", r.Professor_ID, r.Course_Ects);
                //}

                //Console.WriteLine();

                //Console.WriteLine();
                //foreach (var r in Result411Bis)
                //{
                //    Console.WriteLine("{0} - {1}", r.Professor_ID, r.Course_Ects);
                //}
            }
            #endregion


            #endregion

            #region Console.ReadLine()
            Console.ReadLine();
            #endregion
        }
    }
}