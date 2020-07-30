using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Dtos;
using WebAPI.Models;

namespace WebAPI.Profiles
{
    public class AuthenticationProfile : Profile
    {
        public AuthenticationProfile()
        {
            CreateMap<AuthenticationLoginDto, User>();
            CreateMap<AuthenticationRegisterDto, User>()
                .ForMember(dest => dest.Password, opt => opt.ConvertUsing(new ByteFormatter()));
        }

        public class ByteFormatter : IValueConverter<string, byte[]>
        {
            public byte[] Convert(string sourceMember, ResolutionContext context)
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] bytename = new byte[1024];
                bytename = utf8.GetBytes(sourceMember);
                return bytename;
            }
        }
    }
}
