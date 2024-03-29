﻿using Parser.PL.Enums;

namespace Parser.PL.Models
{
    public class FileVm
    {
        public byte[] DataBytes { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public TranslateLanguage TranslateLanguage { get; set; }

    }
}
