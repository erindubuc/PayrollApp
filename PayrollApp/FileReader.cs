using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp
{
    class FileReader
    {
        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string path = "staff.txt";
            string[] separator = {", "};

            if (File.Exists(path))
            {
                /*
                using keyword ensures that the Dispose() method is called even if an exception occurs
                and prevents the sr from closing at end of block
                Dispose() closes/releases any unmanaged resources once they are no longer needed
                */
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                        result = sr.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);

                    if (result[1] == "Manager")
                        myStaff.Add(new Manager(result[0]));

                    else if (result[1] == "Admin")
                        myStaff.Add(new Admin(result[0]));

                    sr.Close();
                }
            }
            else
                Console.WriteLine("Error: The file you are looking for does not exist.");

            return myStaff;
        }
    }
}
