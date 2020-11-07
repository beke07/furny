﻿using AutoMapper;
using Furny.Data;
using Furny.Models;
using MongoDB.Bson;
using System;

namespace Furny.MappingProfiles
{
    public class CommonMappingProfiles : Profile
    {
        public CommonMappingProfiles()
        {
            CreateMap<ObjectId, string>().ConvertUsing<ObjectIdConverter>();
            CreateMap<string, ObjectId>().ConvertUsing<StringConverter>();
            CreateMap<NotificationCommand, Notification>().ReverseMap();
        }

        public class ObjectIdConverter : ITypeConverter<ObjectId, string>
        {
            public string Convert(ObjectId source, string destination, ResolutionContext context)
            {
                return source.ToString();
            }
        }

        public class StringConverter : ITypeConverter<string, ObjectId>
        {
            public ObjectId Convert(string source, ObjectId destination, ResolutionContext context)
            {
                if(ObjectId.TryParse(source, out ObjectId dest))
                {
                    return dest;
                }
                else
                {
                    throw new Exception("Nem sikerült a mappelés!");
                }
            }
        }
    }
}
