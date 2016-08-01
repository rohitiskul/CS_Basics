
using System;
using System.Collections.Generic;
using System.IO;

namespace StaffApp
{
    static class FileReader
    {

        public static List<Staff> CreateStaffList()
        {
            string[] separator = { "," };
            List<Staff> list = new List<Staff>();
            const string path = "D:\\Xamarin\\Projects\\C#_Projects\\StaffApp\\StaffApp\\Resources\\e_info.txt";
            if (!File.Exists(path))
                return list;

            string[] result = new string[2];

            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    result = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    Staff staff;
                    if (result[1].Trim().Equals("Manager"))
                    {
                        staff = new Manager(result[0]);
                    }
                    else
                    {
                        staff = new Admin(result[0]);
                    }
                    list.Add(staff);
                }
                reader.Close();
            }
            return list;
        }
    }
}
