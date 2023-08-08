using Microsoft.EntityFrameworkCore;

namespace _Project_CheatSheet.Tests.Fixtures
{
    using _Project_CheatSheet.Infrastructure.Data.SQL;
    using _Project_CheatSheet.Infrastructure.Data.SQL.Models;
    using AutoMapper;
    using Common.Mapping;
    using Common.UserService.Interfaces;
    using Features.Comment.Interfaces;
    using Features.Comment.Services;
    using Features.Resources.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using System;
    using System.Collections.Generic;

    using Authentication;

    using Features.Identity.Interfaces;
    using Features.Identity.Services;
    using Features.Likes.Interfaces;
    using Features.Likes.Services;

    using IResourceService = Features.Resources.Interfaces.IResourceService;
    using System.Numerics;

    public class ResourcesTestFixture : IDisposable
    {
        public IResourceService ResourceService { get; private set; }
        public ILikeService LikeService { get; private set; }
        public ICommentService CommentService { get; private set; }
        public IAuthenticateService AuthenticateService { get; private set; }

        public CheatSheetDbContext DbContext { get; private set; }


        public ResourcesTestFixture()
        {
            const string userId = "pesho";

            

            var httpContextAccessorMock = SetupFixtureDependencies.HttpContextMock();
            var currentUserServiceMock = SetupFixtureDependencies.CurrentUserServiceMock(userId);
            var mapper = SetupFixtureDependencies.SetupMapper(currentUserServiceMock);
            this.DbContext = SetupFixtureDependencies.CheatSheetDbContextMock(httpContextAccessorMock).Object;


            var commentServiceMock = new Mock<CommentService>(DbContext, currentUserServiceMock.Object, mapper);
            var resourceServiceMock = new Mock<ResourceService>(DbContext, mapper, currentUserServiceMock.Object);
            var likeServiceMock = new Mock<LikeService>(DbContext, currentUserServiceMock.Object, mapper);

            CommentService = commentServiceMock.Object;
            ResourceService = resourceServiceMock.Object;
            LikeService = likeServiceMock.Object;
            SetupInitializeData.InitializeDataForResources(userId, DbContext).Wait();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }


}



