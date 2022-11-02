using AutoMapper;
using MetricsAgent.Models;
using MetricsAgent.Models.Dto;
using MetricsAgent.Models.Requests;

namespace MetricsAgent.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuMetricCreateRequest, CPUMetric>().ForMember(x => x.Time,
                opt => opt.MapFrom(src => (long)src.Time.TotalSeconds));
            CreateMap<CPUMetric, CPUMetricDto>();

            CreateMap<DotNetMetricCreateRequest, DotNetMetric>();
            CreateMap<DotNetMetric, DotNetMetricDto>();

            CreateMap<HddMetricCreateRequest, HddMetric>();
            CreateMap<HddMetric, HddMetricDto>();

            CreateMap<NetworkMetricCreateRequest, NetworkMetric>();
            CreateMap<NetworkMetric, NetworkMetricDto>();

            CreateMap<RamMetricCreateRequest, RamMetric>();
            CreateMap<RamMetric, RamMetricDto>();
        }
    }
}
