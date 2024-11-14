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
        public static DrivingSchoolDBEntities1 db = new DrivingSchoolDBEntities1();
        public static users user;
        public static Students students;
        public static Notifications notifications;
    }
}
