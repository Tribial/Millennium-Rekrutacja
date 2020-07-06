using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Millennium_Rekrutacja.BindingModel;
using Millennium_Rekrutacja.Common.Enums;
using Millennium_Rekrutacja.Dto;
using Millennium_Rekrutacja.Model;
using Millennium_Rekrutacja.ViewModel;

namespace Millennium_Rekrutacja.Common.Mappings
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (ArticleStatus) src.Status));

            CreateMap<ArticleDto, Article>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)src.Status));

            CreateMap<ArticleBindingModel, ArticleDto>();
            CreateMap<ArticleUpdateBindingModel, ArticleDto>();
            CreateMap<ArticleDto, ArticleViewModel>()
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.Split(',', StringSplitOptions.None)));
        }
    }
}
