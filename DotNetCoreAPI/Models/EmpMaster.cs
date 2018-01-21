using System;
using System.Collections.Generic;

namespace DotNetCoreAPI.Models
{
    public partial class EmpMaster
    {
        public decimal RowId { get; set; }
        public string EmpCode { get; set; }
        public string EmpFname { get; set; }
        public string EmpLname { get; set; }
        public bool? EmpStatus { get; set; }
        public DateTime? EmpDob { get; set; }
        public string EmpMaritalstatus { get; set; }
        public string EmpRole { get; set; }
        public string EmpDepartment { get; set; }
        public string EmpAddress { get; set; }
        public int? EmpProfilestatus { get; set; }
        public int? EmpExpriance { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
