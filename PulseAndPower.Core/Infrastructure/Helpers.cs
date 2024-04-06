using System.Text.RegularExpressions;
using PulseAndPower.BusinessLogic.Exceptions;

namespace PulseAndPower.BusinessLogic.Infrastructure;

public static class Helpers
{
    public static string NormalizePhone(string phone)
    {
        if (phone == null)
            throw new BadRequestException("Phone can not be null");
        
        var cleaned = Regex.Replace(phone, @"^[\+7|8]", "");
        cleaned = Regex.Replace(cleaned, @"\D", "");
        return "8" + cleaned;
    }
}