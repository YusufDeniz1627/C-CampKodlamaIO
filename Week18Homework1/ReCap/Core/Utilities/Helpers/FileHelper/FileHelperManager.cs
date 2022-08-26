﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Utilities.Helpers.GuidHelper;
namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file,root);
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)//uzunlugu byt olarak aldıgı için dosya göndermismi onu test ediyor.
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }

                string extension = Path.GetExtension(file.FileName);
                string guid = GuidsHelper.CreateGuild();
                string filePath = guid + extension;

                using (FileStream fileStream = File.Create(root + filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return filePath;
                }
            }
            return null;
        }
    }
}
