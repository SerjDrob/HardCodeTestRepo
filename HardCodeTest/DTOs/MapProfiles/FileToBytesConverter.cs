using AutoMapper;

namespace HardCodeTest.DTOs.MapProfiles
{
    public class FileToBytesConverter : IValueConverter<string, string>
    {
        public string Convert(string sourceMember, ResolutionContext context)
        {
            return System.Convert.ToBase64String(File.ReadAllBytes(sourceMember));
        }
    }
}
