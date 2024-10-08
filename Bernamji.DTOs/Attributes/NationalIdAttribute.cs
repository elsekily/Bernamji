using System.ComponentModel.DataAnnotations;

namespace Bernamji.DTOs.Attributes;
public class NationalIdAttribute : ValidationAttribute
{
    private const int nationalIdLength = 14;
    private List<string> allowedGovernments = new List<string>()
    {
        "01",
        "02",
        "03",
        "04",
        "11",
        "12",
        "13",
        "14",
        "15",
        "16",
        "17",
        "18",
        "19",
        "21",
        "22",
        "23",
        "24",
        "25",
        "26",
        "27",
        "28",
        "29",
        "31",
        "32",
        "33",
        "34",
        "35",
        "88"
    };

    public override bool IsValid(object value)
    {
        var nationalId = value.ToString();

        if (nationalId.Length != nationalIdLength) return false;

        if(!nationalId.All(char.IsDigit)) return false;
        
        if (!IsValidBirthDate(nationalId)) return false;

        if(!allowedGovernments.Contains(nationalId.Substring(7,2))) return false;


        return true;
    }

    public override string FormatErrorMessage(string password)
    {
        return $"The National ID must be {nationalIdLength} digits long, contain only numbers, have a valid birth date, and belong to an allowed government code.";
    }

    private bool IsValidBirthDate(string nationalId)
    {
        if (nationalId[0] != '2' && nationalId[0] != '3') return false;
        return DateTime.TryParse(GetStringDate(nationalId), out DateTime date);
    }

    private string GetStringDate(string nationalId)
    {
        var day = nationalId.Substring(5, 2);
        var month = nationalId.Substring(3, 2);
        var year = string.Concat((nationalId[0] == '2' ? "19" : "20"), nationalId.Substring(1, 2));

        var dateString = string.Concat(year, '-', month, '-', day);
        return dateString;
    }
}
