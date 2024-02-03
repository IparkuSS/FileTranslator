using Translator.PL.Enums;

namespace Translator.PL.Models
{
    public class FileVm
    {
        public string DataText { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public TranslateLanguage TranslateLanguage { get; set; }
    }
}
