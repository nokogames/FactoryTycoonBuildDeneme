using System;

namespace _Main.Project.Scripts.Utilities
{
    public static class Extensions
    {
        public static string ToSuffixString(this double number)
        {
            string[] suffixes =
            {
                "", "K", "M", "B", "T", "Qa", "Qt", "Sx", "Sp", "Oc", 
                "No", "Dc", "UDc", "DDc", "TDc", "QaDc", "QtDc", "SxDc", "SpDc", "ODc", 
                "NDc", "Vg", "UVg", "DVg", "TVg", "QaVg", "QtVg", "SxVg", "SpVg", "OVg", 
                "NVg", "Tg", "UTg", "DTg", "TTg", "QaTg", "QtTg", "SxTg", "SpTg", "OTg", 
                "NTg", "Qd", "UQd", "DQd", "TQd", "QaQd", "QtQd", "SxQd", "SpQd", "OQd", 
                "NQd", "Qi", "UQi", "DQi", "TQi", "QaQi", "QtQi", "SxQi", "SpQi", "OQi", 
                "NQi", "Se", "USe", "DSe", "TSe", "QaSe", "QtSe", "SxSe", "SpSe", "OSe", 
                "NSe", "St", "USt", "DSt", "TSt", "QaSt", "QtSt", "SxSt", "SpSt", "OSt", 
                "NSt", "Og", "UOg", "DOg", "TOg", "QaOg", "QtOg", "SxOg", "SpOg", "OOg", 
                "NOg", "Nn", "UNn", "DNn", "TNn", "QaNn", "QtNn", "SxNn", "SpNn", "ONn", 
                "NNn", "Ce"
            };

            var suffixIndex = 0;
            var value = number;

            while (value >= 1000 && suffixIndex < suffixes.Length - 1)
            {
                value /= 1000;
                suffixIndex++;
            }

            var formattedNumber = value is >= 100 and < 1000
                ? Math.Floor(value).ToString()
                : (Math.Truncate(value * 10) / 10).ToString();

            return formattedNumber + suffixes[suffixIndex];
        }
    }
}