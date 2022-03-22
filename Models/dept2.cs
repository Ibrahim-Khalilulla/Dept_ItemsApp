using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dept_ItemsApp.Models
{
    public class dept2
    {
        [Key]
        public string deptid { get; set; }
        public string deptname { get; set; }
        public string location { get; set; }
        public virtual ICollection<items2> items2 { get; set; }
    }
    public partial class items2
    {
        [Key]
        public string itemcode { get; set; }
        public string itemname { get; set; }
        [ForeignKey("dept2")]
        public string deptid { get; set; }
        public Nullable<decimal> cost { get; set; }
        public Nullable<decimal> rate { get; set; }
        public DateTime date { get; set; }
        public string picture { get; set; }
        public virtual dept2 dept2 { get; set; }
    }
    public class Dept_Items
    {

        public string DeptId { get; set; }
        [Required(ErrorMessage = "Please enter Dept Name")]
        [Display(Name = "DeptName")]
        [MaxLength(50)]
        public string DeptName { get; set; }
        public string Location { get; set; }
        public string ItemCode { get; set; }//primary key and foreign Foreign Key
        public string ItemName { get; set; }
        public double Cost { get; set; }
        public double Rate { get; set; }
        public DateTime date { get; set; }
        public string picture { get; set; }
    }
}