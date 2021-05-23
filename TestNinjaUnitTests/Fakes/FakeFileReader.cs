using TestNinja.Mocking;

namespace TestNinjaUnitTests.Fakes
{
    public class FakeFileReader : IFileReader
    {
        string IFileReader.Read(string path)
        {
            return "";
        }
    }
}
