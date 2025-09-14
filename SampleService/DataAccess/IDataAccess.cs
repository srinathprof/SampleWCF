using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleService
{
    public interface IDataAccess
    {
        GetUserAttributesOutput RetrieveUserAttributes(GetUserAttributesInput input);

        SetUserAttributesOutput SaveUserAttributes(SetUserAttributesInput input);
    }
}
