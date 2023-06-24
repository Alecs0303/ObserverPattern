using PatternModel.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternModel.AccessData.BuilderPattern
{
    public interface IEmployeeBuilder
    {
        void SetName(string name);
        void SetLastName(string lastName);
        void SetIdentification(string identification);
        void SetPosition(string position);
        Employee Build();
    }
}