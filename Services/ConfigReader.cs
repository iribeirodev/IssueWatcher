using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace IssueWatcher.Services
{
    public class ConfigReader
    {
        private readonly Dictionary<string, string> _settings = new Dictionary<string, string>();
        private readonly string _filePath;

        public ConfigReader()
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", ".config");
            LoadConfig();
        }

        /// <summary>
        /// Carrega e processa o arquivo de configuração linha por linha,
        /// armazenando os pares Chave:Valor em um dicionário interno.
        /// </summary>
        /// <exception cref="FileNotFoundException">Lançada se o arquivo de configuração não for encontrado.</exception>
        private void LoadConfig()
        {
            if (!File.Exists(_filePath))
                throw new FileNotFoundException($"O arquivo de configuração não foi encontrado: {_filePath}");

            // Lê todas as linhas do arquivo
            string[] lines = File.ReadAllLines(_filePath);

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();
                if (string.IsNullOrEmpty(trimmedLine) || trimmedLine.StartsWith("#") || trimmedLine.StartsWith("//"))
                {
                    continue;
                }

                // Procura o primeiro ":" para dividir a chave do valor
                int separatorIndex = trimmedLine.IndexOf(':');

                if (separatorIndex > 0)
                {
                    string key = trimmedLine.Substring(0, separatorIndex).Trim();
                    string value = trimmedLine.Substring(separatorIndex + 1).Trim();

                    // Adiciona ao dicionário
                    if (!string.IsNullOrEmpty(key))
                    {
                        _settings[key.ToLowerInvariant()] = value;
                    }
                }
            }
        }

        /// <summary>
        /// Retorna o valor de configuração associado à chave fornecida.
        /// A pesquisa da chave é case-insensitive (não sensível à maiúscula/minúscula).
        /// </summary>
        /// <param name="key">A chave de configuração a ser pesquisada (ex: "database" ou "spreadsheet").</param>
        /// <returns>O valor <see cref="string"/> associado à chave.</returns>
        /// <exception cref="KeyNotFoundException">Lançada se a chave não for encontrada no arquivo de configuração carregado.</exception>
        public string GetValue(string key)
        {
            string normalizedKey = key.ToLowerInvariant();

            if (_settings.ContainsKey(normalizedKey))
            {
                return _settings[normalizedKey];
            }

            throw new KeyNotFoundException($"A chave '{key}' não foi encontrada no arquivo de configuração.");
        }

        /// <summary>
        /// Define um novo valor para a chave especificada e salva a alteração no disco.
        /// Se a chave não existir, ela será criada.
        /// </summary>
        /// <param name="key">A chave de configuração a ser modificada ou criada.</param>
        /// <param name="value">O novo valor a ser associado à chave.</param>
        public void SetValue(string key, string value)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key), "A chave de configuração não pode ser nula ou vazia.");

            string normalizedKey = key.ToLowerInvariant();

            if (_settings.TryGetValue(normalizedKey, out var currentValue) && currentValue == value)
                return;

            var lines = File.ReadAllLines(_filePath).ToList();
            bool updated = false;

            for (int i = 0; i < lines.Count; i++)
            {
                var parts = lines[i].Split(':');
                if (parts.Length >= 2)
                {
                    var keyInFile = parts[0].Trim().ToLowerInvariant();
                    if (keyInFile == normalizedKey)
                    {
                        lines[i] = $"{normalizedKey}:{value}";
                        updated = true;
                        break;
                    }
                }
            }

            File.WriteAllLines(_filePath, lines);
            _settings[normalizedKey] = value;
        }

        /// <summary>
        /// Retorna o conteudo do script de criação de database
        /// </summary>
        public string ReadCreateScript()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "IssueWatcher.create_script.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Retorna se existe o arquivo de database no caminho definido no config
        /// </summary>
        /// <returns></returns>
        public bool DatabaseFileExists()
        {
            return File.Exists(this.GetValue("database"));
        }


    }
}
