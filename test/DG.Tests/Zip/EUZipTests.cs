using Xunit;
using DG.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DG.Zip.Tests
{
    public class EUZipTests
    {
        [Fact()]
        public void EnZipTest()
        {
            Zip.ZipHelper.EnZip("D:\\QMDownload\\Hotfix", "E:\\testzip\\44.zip");
            Zip.ZipHelper.UnZip("E:\\44.zip", "E:\\testzip\\44");
            Assert.True(false, "This test needs an implementation");
        }
    }
}