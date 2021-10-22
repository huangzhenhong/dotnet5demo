using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet5.WebApi.EFCoreDemo.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public Guid? ComputedValue { get; set; }
        public Guid ComputedValue2 { get; set; }
    }
}
