using CbMaker.Application.DTOs;

namespace CbMaker.Application.Features.Platform.Options.Get
{
    public class OptionsResponse
    {
        public List<OptionDTO> AcademicFields { get; set; } = new List<OptionDTO>();

        public List<OptionDTO> Degrees { get; set; } = new List<OptionDTO>();

        public List<OptionDTO> JobTitles { get; set; } = new List<OptionDTO>();

        public List<OptionDTO> Languages { get; set; } = new List<OptionDTO>();

        public List<OptionDTO> Skills { get; set; } = new List<OptionDTO>();
    }
}
