using System.ComponentModel.DataAnnotations;

namespace Parser.PL.Enums
{
    public enum TranslateLanguage
    {
        [Display(Name = "English")]
        English = 0,
        [Display(Name = "Russian")]
        Russian = 1,
        [Display(Name = "Belarusian")]
        Belarusian = 2
    }
}
