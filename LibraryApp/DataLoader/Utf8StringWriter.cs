using System.IO;
using System.Text;

namespace LibraryApp.DataLoader
{
    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}
