using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp
{
    abstract class Patients : Model
    {
        public string tableName = "Patients";
        private string name;
        private string surname;
        private int age;
        private string gender;
    }
}
