using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Ajax.Utilities;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class Students
    {

        public static Task<Student[]> GetStudentsAsync(DateTime startDate)
        {
            var list = new List<Student>();
            var fi = new FileInfo(@".\Data\Dane\dane.txt");
            var sr = new StreamReader(fi.OpenRead());
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                if (line == null) continue;
                var s = line.Split(",");
                if (s.Length != 6
                    || s[0].IsNullOrWhiteSpace()
                    || s[1].IsNullOrWhiteSpace()
                    || s[2].IsNullOrWhiteSpace()
                    || s[3].IsNullOrWhiteSpace()
                    || s[4].IsNullOrWhiteSpace()
                    || s[5].IsNullOrWhiteSpace()
                )
                {
                    var writer = new StreamWriter(@".\Data\Logs\logs.txt", true);
                    foreach (var t in s)
                        writer.Write(t + "  ");
                    writer.WriteLineAsync();
                    writer.Dispose();
                }
                else
                {
                    list.Add(new Student
                    {
                        Avatars = s[0],
                        FirstName = s[1],
                        LastName = s[2],
                        Studies = s[3],
                        Birthdate = Convert.ToDateTime(s[4]),
                        Index = (s[5])
                    });
                }
            }

            sr.Dispose();
            return Task.FromResult(list.ToArray());
        }

        
    }
}
