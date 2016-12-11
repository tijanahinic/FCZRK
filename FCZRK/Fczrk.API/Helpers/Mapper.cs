using AutoMapper;
using Fczrk.API.Models.Info;
using Fczrk.API.Models.SponsorCategory;
using Fczrk.API.Models.User;
using Fczrk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fczrk.API.Helpers
{
    public static class Mapper
    {
        /// <summary>
        /// Automatically maps one object to another using AutoMapper.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static TDestination AutoMap<TSource, TDestination>(TSource source)
            where TDestination : class
            where TSource : class
        {
            var config = new MapperConfiguration(c => c.CreateMap<TSource, TDestination>());
            var mapper = config.CreateMapper();
            var result = mapper.Map<TDestination>(source);

            return result;
        }


        public static CommentModel Map(Comment comment)
        {
            return new CommentModel
            {
                Name = comment.Name,
                Text = comment.Text,
                Id = comment.Id,
                Active = comment.Active,
                DateCreated = comment.DateCreated,
                ProjectId = comment.ProjectId
            };
        }
      public static SponsorCategoryModel Map (SponsorCategory sponsorcategory)
        {
            return new SponsorCategoryModel
            {
                Name = sponsorcategory.Name,
                Id = sponsorcategory.Id
            };
        }
       public static InfoModel Map (Entities.Info info)
        {
            return new Models.Info.InfoModel
            {
                Description = info.Description,
                Id = info.Id,
                Mission = info.Mission,
                Vision = info.Vision,
                BecomeMember = info.BecomeMember,
                AboutFax = info.AboutFax,
                AboutUs = info.AboutUs
            };
        }
    }
}