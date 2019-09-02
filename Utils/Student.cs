using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class Student
    {
        public string First { get; set; }
        public string Last { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int ID { get; set; }
        public List<int> Scores;

        public override string ToString()
        {
            return
                "First Name: " + First + "\r\n" +
                "Last Name: " + Last + "\r\n" +
                "City: " + City + "\r\n" +
                "Country: " + Country + "\r\n" +
                "ID: " + ID + "\r\n" +
                "First Score: " + Scores.ElementAt(0) + "\r\n" +
                "Second Score: " + Scores.ElementAt(1) + "\r\n" +
                "Third Score: " + Scores.ElementAt(2) + "\r\n" +
                "Fourth Score: " + Scores.ElementAt(3) + "\r\n";
        }
    }
}
