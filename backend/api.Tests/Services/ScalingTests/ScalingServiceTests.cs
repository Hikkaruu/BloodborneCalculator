﻿using api.Services;
using api.Models.Entities;
using api.Models.DTOs.Scaling;
using api.Persistence.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using api.Interfaces;
using api.Mapping;

namespace api.Tests.Services.ScalingTests
{
    public class ScalingServiceTests
    {
        private readonly DbContextOptions<AppDbContext> _dbOptions;
        private readonly IMapper _mapper;

        public ScalingServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = config.CreateMapper();

            _dbOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: $"TestDatabase{Guid.NewGuid().ToString()}")
                .Options;
        }

        [Fact]
        public async Task GetScalingByIdAsync_ReturnsScalingDto_WhenScalingExists()
        {
            using var context = new AppDbContext(_dbOptions);
            context.Scalings.Add(new Scaling { Id = 1, Name = "Test Scaling" });
            await context.SaveChangesAsync();

            var service = new ScalingService(context, _mapper);

            var result = await service.GetScalingByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Test Scaling", result.Name);
        }

        [Fact]
        public async Task GetAllScalingsAsync_ReturnsScalingDtos()
        {
            using var context = new AppDbContext(_dbOptions);
            var scaling1 = new Scaling { Id = 1, Name = "Scaling 1" };
            var scaling2 = new Scaling { Id = 2, Name = "Scaling 2" };
            context.Scalings.Add(scaling1);
            context.Scalings.Add(scaling2);
            await context.SaveChangesAsync();

            var service = new ScalingService(context, _mapper);

            var result = await service.GetAllScalingsAsync();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task CreateScalingAsync_ReturnsCreatedScalingDto()
        {
            using var context = new AppDbContext(_dbOptions);

            var createDto = new CreateScalingDto { Name = "New Scaling" };

            var service = new ScalingService(context, _mapper);

            var result = await service.CreateScalingAsync(createDto);

            Assert.NotNull(result);
            Assert.Equal("New Scaling", result.Name);
        }

        [Fact]
        public async Task UpdateScalingAsync_ReturnsUpdatedScalingDto()
        {
            using var context = new AppDbContext(_dbOptions);

            var scaling = new Scaling { Id = 1, Name = "Old Scaling" };
            context.Scalings.Add(scaling);
            await context.SaveChangesAsync();

            var updateDto = new UpdateScalingDto { Name = "Updated Scaling" };

            var service = new ScalingService(context, _mapper);

            var result = await service.UpdateScalingAsync(1, updateDto);

            Assert.NotNull(result);
            Assert.Equal("Updated Scaling", result.Name);
        }

        [Fact]
        public async Task DeleteScalingAsync_RemovesScaling()
        {
            using var context = new AppDbContext(_dbOptions);

            var scaling = new Scaling { Id = 1, Name = "Scaling to Delete" };
            context.Scalings.Add(scaling);
            await context.SaveChangesAsync();

            var service = new ScalingService(context, _mapper);

            await service.DeleteScalingAsync(1);

            var result = await context.Scalings.FindAsync(1);
            Assert.Null(result);
        }

        [Fact]
        public async Task GetScalingByWeaponNameAsync_ReturnsScalingDto_WhenWeaponExists()
        {
            using var context = new AppDbContext(_dbOptions);

            var scaling = new Scaling
            {
                Id = 1,
                TricksterWeapons = new TricksterWeapon { Name = "Weapon 1" }
            };
            context.Scalings.Add(scaling);
            await context.SaveChangesAsync();

            var service = new ScalingService(context, _mapper);

            var result = await service.GetScalingByWeaponNameAsync("Weapon 1");

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }
    }
}
