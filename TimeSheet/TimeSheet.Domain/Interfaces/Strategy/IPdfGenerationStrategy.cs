using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Domain.Strategy
{
    public interface IPdfGenerationStrategy<T>
    {
        public string GenerateHTML();
    }
}
