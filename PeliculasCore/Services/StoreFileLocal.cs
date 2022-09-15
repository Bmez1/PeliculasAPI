using PeliculasCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace PeliculasCore.Services
{
    public class StoreFileLocal : IStoreFile
    {

        private readonly IHostEnvironment env;
        private readonly IHttpContextAccessor accesor;

        public StoreFileLocal(IHostEnvironment env, IHttpContextAccessor accesor)
        {
            this.env = env;
            this.accesor = accesor;
        }
        public Task DeleteFile(string ruta, string container)
        {
            if (ruta != null)
            {
                string nameFile = Path.GetFileName(ruta);
                string fileDirectory = Path.Combine(env.ContentRootPath, container, nameFile);

                if (File.Exists(fileDirectory))
                {
                    File.Delete(fileDirectory);
                }

            }
            return Task.FromResult(0);
        }

        public async Task<string> EditFile(byte[] content, string extension, string container, string path, string contentType)
        {
            await DeleteFile(path, container);
            return await SaveFile(content, extension, container, contentType);
        }

        public async Task<string> SaveFile(byte[] content, string extension, string container, string contentType)
        {
            string nameFile = $"{Guid.NewGuid()}{extension}";
            string folder = Path.Combine(env.ContentRootPath, container);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string route = Path.Combine(folder, nameFile);
            await File.WriteAllBytesAsync(route, content);

            var pathCurrent = $"{accesor.HttpContext.Request.Scheme}://{accesor.HttpContext.Request.Host}";
            var urlDB = Path.Combine(pathCurrent, container, nameFile).Replace("\\", "/");
            return urlDB;
        }
    }
}
