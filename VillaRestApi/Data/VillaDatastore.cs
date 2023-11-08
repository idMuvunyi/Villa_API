using VillaRestApi.Models.Dto;

namespace VillaRestApi.Data
{
    public static class VillaDatastore
    {
        public static List<VillaDto> VillaList = new List<VillaDto>
        {
            new VillaDto{ Id=1, Name="Royal Merchant"},
            new VillaDto{ Id=2,Name="Milly Estate" }   
        };  
    }
}
