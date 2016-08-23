using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Domain.Models
{
    public class Paging
    {
        public int Total { get; set; }
        public int PageSize { get; set; }
        public int CurrentPageNumber { get; set; }
        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling(Total / (float)PageSize);
            }
        }
    }
}
