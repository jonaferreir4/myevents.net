using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Exceptions.NotFound
{
    public class AttendanceNotFoundException(long id):
        NotFoundException("Attendance", id){ }
}