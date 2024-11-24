using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSchool.db
{
    class ConnectionDB : DbContext
    {
        public static DrivingSchoolDBEntities2 db = new DrivingSchoolDBEntities2();
        public static users user;
        public static Students students;
        public static Notifications notifications;
    }
}
