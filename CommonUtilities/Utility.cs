using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomEntity;

namespace CommonUtilities
{
    public class Utility : IUtility
    {
        public DateTime? GetTerminationDate(Employee oldEmployeeInfo, Employee newEmployeeInfo)
        {
            const string Active = "A";
            const string InActive = "I";
            const string LeaveWithoutPayActive = "F";
            const string LeaveWithoutPay = "L";
            DateTime? terminationDate = null;

            if (oldEmployeeInfo.Status == Active) {
                if (oldEmployeeInfo.TerminationDate.HasValue) {
                    if (newEmployeeInfo.TerminationDate >= DateTime.Today) {

                    } else {

                    }
                }
            }

            return terminationDate;
        }
    }
}
