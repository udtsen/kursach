using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp
{
    abstract class Profile : Model
    {
        public string tableName = "Profiles";
        private string title;
    }
}
