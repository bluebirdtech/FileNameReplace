using System;
using System.IO;
using NUnit.Framework;

namespace FileNameReplace
{
    [TestFixture]
    public class Test
    {
        [TestCase( true )]
        [TestCase( false )]
        public void ATest(bool alreadyExists)
        {
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] files = directory.GetFiles( "*.nupkg" );
            foreach( FileInfo file in files )
            {
                file.Delete();
            }

            string fileNameFirstPart = "BirdJournal.Windows.1.2.3." + ( new Random() ).Next( 99999 );
            File.WriteAllText( fileNameFirstPart + ".symbols.nupkg", "hi" );
            var replacer = new FileNameReplacer( "*.nupkg", "Symbols.", "" );
            replacer.Execute();
            string targetFileName = fileNameFirstPart + ".nupkg";
            if( alreadyExists )
                File.WriteAllText( targetFileName, "hi" );
            Assert.True( File.Exists( targetFileName ) );
        }
    }
}