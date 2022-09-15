using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Interfaces.Services
{
    public interface IStoreFile
    {
        Task<string> SaveFile(byte[] content, string extension, string container, string contentType);
        Task<string> EditFile(byte[] content, string extension, string container, string path, string contentType);
        Task DeleteFile(string ruta, string container);
    }
}
