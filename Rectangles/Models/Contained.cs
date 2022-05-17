using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapePosition.Models
{
    public class Contained
    {
        public bool IsContained { get; }

        public Contained(bool isContained)
        {
            this.IsContained = isContained;
        }
    }
}
