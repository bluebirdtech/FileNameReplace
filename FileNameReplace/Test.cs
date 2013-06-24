using System;
using System.IO;
using NUnit.Framework;

namespace FileNameReplace
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void ATest()
        {
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] files = directory.GetFiles( "*.nupkg" );
            foreach( FileInfo file in files )
            {
                file.Delete();
            }

            string fileNameFirstPart = "BirdJournal.Windows.1.2.3." + ( new Random() ).Next( 99999 );
            File.WriteAllText( fileNameFirstPart + ".Symbols.nupkg", "hi" );
            var replacer = new FileNameReplacer( "*.nupkg", "Symbols.", "" );
            replacer.Execute();
            Assert.True( File.Exists( fileNameFirstPart + ".nupkg" ) );
        }
    }
}