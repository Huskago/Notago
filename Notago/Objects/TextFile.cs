using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notago.Objects
{
    public class TextFile
    {
        /// <summary>
        /// Chemin d'accès et nom du fichier.
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Chemin d'accès et nom du fichier backup.
        /// </summary>
        public string BackupFileName { get; set; }
        /// <summary>
        /// Nom et extension du fichier. Le nom du fichier n'inclut pas le chemin d'accès.
        /// </summary>
        public string SafeFileName { get; set; }
        /// <summary>
        /// Nom et extension du fichier backup. Le nom du fichier n'inclut pas le chemin d'accès.
        /// </summary>
        public string SafeBackupFileName { get; set; }
        /// <summary>
        /// Contenu du fichier.
        /// </summary>
        public string Contents { get; set; } = string.Empty;

        /// <summary>
        /// Constructeur de la classe TextFile.
        /// </summary>
        public TextFile()
        {

        }

        /// <summary>
        /// Constructeur de la classe TextFile.
        /// </summary>
        /// <param name="fileName">Chemin d'accès et nom du fichier.</param>
        public TextFile(string fileName)
        {
            FileName = fileName;
            SafeFileName = Path.GetFileName(fileName);
        }
    }
}
