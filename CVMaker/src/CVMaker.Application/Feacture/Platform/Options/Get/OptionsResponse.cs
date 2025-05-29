using CVMaker.Application;
using CVMaker.Application.DTOs;

namespace CVMaker.Application.Features.Platform.Options.Get
{

    public class OptionsResponse
    {

        public List<OptionDTO> AcademicFields { get; set; } = new List<OptionDTO>();
        public List<OptionDTO> Degrees { get; set; } = new List<OptionDTO>();
        public List<OptionDTO> Jobtitles { get; set; } = new List<OptionDTO>();
        public List<OptionDTO> Languages { get; set; } = new List<OptionDTO>();
        public List<OptionDTO> Skills { get; set; } = new List<OptionDTO>();


    }
}