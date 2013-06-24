using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileNameReplace
{
    public class FileNameReplacer
    {
        private readonly string _filePath;
        private readonly string _findText;
        private readonly string _replaceText;

        public FileNameReplacer( string filePath, string findText, string replaceText )
        {
            _filePath = filePath;
            _findText = findText;
            _replaceText = replaceText;
        }

        public void Execute()
        {
            var file = new FileInfo( _filePath );
            string filename = Path.GetFileName( _filePath );
            string directoryName = Path.GetDirectoryName( _filePath );
            string newFilePath = Path.Combine( directoryName, filename.Replace( _findText, _replaceText ) );
            file.MoveTo( newFilePath );
        }

        public string FilePath
        {
            get { return _filePath; }
        }

        public string FindText
        {
            get { return _findText; }
        }

        public string ReplaceText
        {
            get { return _replaceText; }
        }
    }
}
