using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] files = directory.GetFiles( _filePath );
            foreach( FileInfo file in files )
            {
                string fullPath = file.FullName;
                string filename = Path.GetFileName( fullPath );
                string directoryName = Path.GetDirectoryName( fullPath );
                string newFilePath = Path.Combine( directoryName, filename.Replace( _findText, _replaceText ) );

                // Note: Delete if it already exists, to allow overwrite.
                if( File.Exists( newFilePath ) )
                    File.Delete( newFilePath );
                file.MoveTo( newFilePath );
            }
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
