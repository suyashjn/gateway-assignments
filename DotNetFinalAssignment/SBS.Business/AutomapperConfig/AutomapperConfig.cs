using AutoMapper;
using SBS.Data.AutoMapperConfig;

namespace SBS.Business.AutomapperConfig
{
    public class AutomapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<AutomapperProfile>();
            });
        }
    }
}
