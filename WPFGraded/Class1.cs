using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGraded
{
    class User
    {
        public int id { get; set; }
        public String name { get; set; }
        public int age { get; set; }
        public int score { get; set; }

        public User(String streng)
        {
            string[] s = streng.Split(';');
            this.id = int.Parse(s[0]);
            this.name = s[1];
            this.age = int.Parse(s[2]);
            this.score = int.Parse(s[3]);
        }
        public override string ToString()
        {
            return id + " " + name;
        }
    }
}
