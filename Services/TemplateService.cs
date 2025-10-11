using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace IssueWatcher.Services
{
    public class TemplateService
    {
        private string GetTemplatePath()
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Templates");
        }

        public List<string> ReadAllTemplates()
        {
            var files = Directory.GetFiles(GetTemplatePath(), "*.rtf")
                            .Select(f => Path.GetFileNameWithoutExtension(f))
                            .ToList();

            return files;
        }

        public string GetTextContent(string template)
        {
            var path = GetTemplatePath();
            var fileName = Path.Combine(path, $"{template}.rtf");

            return File.ReadAllText(fileName);
        }

        /// <summary>
        /// Salva o conteúdo em um arquivo RTF dentro da pasta de templates.
        /// </summary>
        /// <param name="name">O nome do arquivo, já incluindo a extensão .rtf.</param>
        /// <param name="content">O conteúdo do arquivo (esperado ser o texto RTF).</param>
        /// <returns>True se o salvamento for bem-sucedido, False caso contrário.</returns>
        public bool SaveTemplate(string name, string content)
        {
            var path = GetTemplatePath();

            // Combina o caminho base com o nome do arquivo
            // O parâmetro 'name' já deve vir com a extensão .rtf,
            // por exemplo: "MeuTemplate.rtf"
            var fullPath = Path.Combine(path, name);

            File.WriteAllText(fullPath, content);

            return true;
        }
    }
}
