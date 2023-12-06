using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Classes
{
    abstract class Consultations : Model
    {
        public string tableName = "Consultations";
        private int patient_id;
        private int schedule_id;
    }
}
