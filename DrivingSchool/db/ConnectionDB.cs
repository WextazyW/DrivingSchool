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
        public static DriveDBEntities db = new DriveDBEntities();
        public static users user;
        public static Students students;
        public static Notifications notifications;
    }
}
