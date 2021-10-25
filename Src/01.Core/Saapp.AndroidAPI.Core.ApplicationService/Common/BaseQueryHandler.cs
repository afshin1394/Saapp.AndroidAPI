using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saapp.AndroidAPI.Core.ApplicationService.Common
{
    public abstract class BaseQueryHandler<TInput, TOutput>
    {
        public abstract TOutput Handle(TInput input);
    }
}
