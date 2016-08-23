using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Helpers
{
    public interface ICaptchaHelper
    {
        bool ValidateCaptcha(string response);
    }
}
