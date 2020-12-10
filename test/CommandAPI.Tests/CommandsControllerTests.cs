using System;
using Xunit;
using CommandAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using CommandAPI.Data;
using AutoMapper;
using CommandAPI.Controllers;
using System.Collections.Generic;
using CommandAPI.Profiles;

namespace CommandAPI.Tests
{
    public class CommandsControllerTests
    {
        [Fact]
        public void GetCommandItems_ReturnZeroItems_WhenDBIsEmpty()
        {
            //Arrange
            var mockRepo = new Mock<ICommandAPIRepo>();
            mockRepo.Setup(repo => 
            repo.GetAllCommands()).Returns(GetCommands(0));

            var realProfile = new CommandsProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(realProfile));
            IMapper mapper = new Mapper(configuration);

            var controller = new CommandsController(mockRepo.Object, mapper);
        }

        private List<Command> GetCommands(int num)
        {
            var commands = new List<Command>();
            if (num > 0)
            {
                commands.Add(new Command
                {
                    Id = 0,
                    HowTo = "How to generate a migration",
                    CommandLine = "dotnet ef migrations add <Name of Migrations>",
                    Platform = ".NET Core EF"
                });
            }
            return commands;
        }
    }
}