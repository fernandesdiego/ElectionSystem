using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainelCipa.Data.FileManager
{
    public interface IFileManager
    {
        Task<string> SaveImage(IFormFile image);
    }
}
