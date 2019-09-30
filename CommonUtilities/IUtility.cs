using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomEntity;

namespace CommonUtilities
{
    interface IUtility
    {
        DateTime? GetTerminationDate(Employee oldEmployeeInfo, Employee newEmployeeInfo);
    }
}
