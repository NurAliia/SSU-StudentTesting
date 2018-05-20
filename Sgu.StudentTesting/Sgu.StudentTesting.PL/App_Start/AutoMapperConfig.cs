using AutoMapper;
using Common;
using Sgu.StudentTesting.PL.ViewModel.Question;
using Sgu.StudentTesting.PL.ViewModel.Subject;
using Sgu.StudentTesting.PL.ViewModel.Test;
using Sgu.StudentTesting.PL.ViewModels.User;
using System;
using System.Web;

namespace Sgu.StudentTesting.PL.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserDisplayVM>();

                cfg.CreateMap<UserCreateVM, User>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore());

                cfg.CreateMap<UserCreateVM, UserDisplayVM>()
                  .ForMember(dest => dest.Id, opt => opt.Ignore());

                cfg.CreateMap<Question, QuestionDisplayVM>()
                    .ForMember("IdTheme", opt => opt.MapFrom(src => src.Theme))
                    .ForMember("VariantOfAnswer1", opt => opt.MapFrom(src => src.GetDataVariantsOfAnswer(src, 0)))
                    .ForMember("VariantOfAnswer2", opt => opt.MapFrom(src => src.GetDataVariantsOfAnswer(src, 1)))
                    .ForMember("VariantOfAnswer3", opt => opt.MapFrom(src => src.GetDataVariantsOfAnswer(src, 2)))
                    .ForMember("VariantOfAnswer4", opt => opt.MapFrom(src => src.GetDataVariantsOfAnswer(src, 3)));

                cfg.CreateMap<QuestionCreateVM, Question>()
                .ForMember("VariantsOfAnswer", opt => opt.MapFrom(src => src.VariantOfAnswer1 + ":" +
                    src.VariantOfAnswer2 + ":" + src.VariantOfAnswer3 + ":" + src.VariantOfAnswer4))
                 .ForMember(dest => dest.Accepted, opt => opt.Ignore());

                cfg.CreateMap<Question, QuestionCreateVM>()
                .ForMember("Id", opt => opt.MapFrom(src => src.Id))
                .ForMember("VariantOfAnswer1", opt => opt.MapFrom(src => src.GetDataVariantsOfAnswer(src, 0)))
                    .ForMember("VariantOfAnswer2", opt => opt.MapFrom(src => src.GetDataVariantsOfAnswer(src, 1)))
                    .ForMember("VariantOfAnswer3", opt => opt.MapFrom(src => src.GetDataVariantsOfAnswer(src, 2)))
                    .ForMember("VariantOfAnswer4", opt => opt.MapFrom(src => src.GetDataVariantsOfAnswer(src, 3)));

                cfg.CreateMap<QuestionInTest, QuestionInTestDisplayVM>()
                 .ForMember("VariantOfAnswer1", opt => opt.MapFrom(src => src.GetDataVariantsOfAnswer(src, 0)))
                     .ForMember("VariantOfAnswer2", opt => opt.MapFrom(src => src.GetDataVariantsOfAnswer(src, 1)))
                     .ForMember("VariantOfAnswer3", opt => opt.MapFrom(src => src.GetDataVariantsOfAnswer(src, 2)))
                     .ForMember("VariantOfAnswer4", opt => opt.MapFrom(src => src.GetDataVariantsOfAnswer(src, 3)));
                
                //cfg.CreateMap<Test, TestVM>();

                //cfg.CreateMap<TestVM, Test>()
                //.ForMember(dest => dest.IdSudent, opt => opt.Ignore());

                //cfg.CreateMap<SubjectCreateVM, Subject>()
                //.ForMember(dest => dest.IdSubject, opt => opt.Ignore());
            });
            Mapper.Configuration.AssertConfigurationIsValid();
            Mapper.AssertConfigurationIsValid();
        }       
    }
}