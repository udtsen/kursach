using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp
{
    abstract class Schedule : Model
    {
        public string tableName = "Schedules";
        private int doctorId;
        private DateTime date;
        private DateTime startTime;
        private DateTime endTime;
    }
}
