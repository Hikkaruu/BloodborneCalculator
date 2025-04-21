using api.Mapping;
using api.Models.DTOs.Firearm;
using api.Models.Entities;
using api.Models.Enums;
using api.Models.Filters;
using api.Persistence.Data;
using api.Services;
using api.Tests.Helpers.TestHelpers;
using AutoMapper;
using CoreEx;
using Microsoft.EntityFrameworkCore;

namespace api.Tests.Services.FirearmTests
{
    public class FirearmServiceTests
    {
        private readonly DbContextOptions<AppDbContext> _dbOptions;
        private readonly IMapper _mapper;
        private readonly TestHelpers _testHelpers = new TestHelpers();

        public FirearmServiceTests()
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
        public async Task GetFirearmByIdAsync_FirearmExists_ReturnsDto()
        {
            using var context = new AppDbContext(_dbOptions);

            context.Scalings.Add(
                new Scaling { 
                    Id = 1, 
                    Name = "Scaling 1",
                    StrengthScaling = 1.0m,
                    SkillScaling = 1.0m,
                    BloodtingeScaling = 1.0m,
                    ArcaneScaling = 1.0m,
                });

            context.Firearms.Add(
                new Firearm { 
                    Id = 1, 
                    Name = "Firearm 1",
                    PhysicalAttack = 10,
                    BloodAttack = 5,
                    ArcaneAttack = 3,
                    FireAttack = 2,
                    BoltAttack = 1,
                    BulletUse = 1,
                    Imprints = ImprintType.Imprint0,
                    StrengthRequirement = 10,
                    SkillRequirement = 10,
                    BloodtingeRequirement = 10,
                    ArcaneRequirement = 10,
                    ImageUrl = "http://example.com/image.png",
                    ScalingId = 1,
                });

            await context.SaveChangesAsync();

            var service = new FirearmService(context, _mapper);

            var result = await service.GetFirearmByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Firearm 1", result.Name);
        }

        [Fact]
        public async Task GetFirearmByIdAsync_FirearmDoesNotExist_ReturnsNotFoundException()
        {
            using var context = new AppDbContext(_dbOptions);
            var service = new FirearmService(context, _mapper);

            await Assert.ThrowsAsync<NotFoundException>(() => service.GetFirearmByIdAsync(99));
        }

        [Fact]
        public async Task GetAllFirearmsAsync_ReturnsAllFirearms()
        {
            using var context = new AppDbContext(_dbOptions);
            context.Scalings.AddRange(
                new Scaling
                {
                    Id = 1,
                    Name = "Scaling 1",
                    StrengthScaling = 1.0m,
                    SkillScaling = 1.0m,
                    BloodtingeScaling = 1.0m,
                    ArcaneScaling = 1.0m,
                },
                new Scaling
                {
                    Id = 2,
                    Name = "Scaling 2",
                    StrengthScaling = 2.0m,
                    SkillScaling = 2.0m,
                    BloodtingeScaling = 2.0m,
                    ArcaneScaling = 2.0m,
                });

            context.Firearms.AddRange(
                new Firearm
                {
                    Id = 1,
                    Name = "Firearm 1",
                    PhysicalAttack = 10,
                    BloodAttack = 5,
                    ArcaneAttack = 3,
                    FireAttack = 2,
                    BoltAttack = 1,
                    BulletUse = 1,
                    Imprints = ImprintType.Imprint0,
                    StrengthRequirement = 10,
                    SkillRequirement = 10,
                    BloodtingeRequirement = 10,
                    ArcaneRequirement = 10,
                    ImageUrl = "http://example.com/image.png",
                    ScalingId = 1,
                }, 
                new Firearm
                {
                    Id = 2,
                    Name = "Firearm 2",
                    PhysicalAttack = 20,
                    BloodAttack = 15,
                    ArcaneAttack = 13,
                    FireAttack = 12,
                    BoltAttack = 11,
                    BulletUse = 2,
                    Imprints = ImprintType.Imprint1,
                    StrengthRequirement = 20,
                    SkillRequirement = 20,
                    BloodtingeRequirement = 20,
                    ArcaneRequirement = 20,
                    ImageUrl = "http://example.com/image2.png",
                    ScalingId = 2,
                });
            await context.SaveChangesAsync();

            var service = new FirearmService(context, _mapper);

            var result = await service.GetAllFirearmsAsync();

            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task CreateFirearmAsync_ValidDto_CreatesFirearm()
        {
            using var context = new AppDbContext(_dbOptions);
            var createDto = new CreateFirearmDto
            {
                Name = "Firearm 1",
                PhysicalAttack = 10,
                BloodAttack = 5,
                ArcaneAttack = 3,
                FireAttack = 2,
                BoltAttack = 1,
                BulletUse = 1,
                Imprints = ImprintType.Imprint0,
                StrengthRequirement = 10,
                SkillRequirement = 10,
                BloodtingeRequirement = 10,
                ArcaneRequirement = 10,
                ImageUrl = "http://example.com/image.png",
                ScalingId = 1
            };

            _testHelpers.ValidateDto(createDto);

            var service = new FirearmService(context, _mapper);

            var result = await service.CreateFirearmAsync(createDto);

            var firearm = await context.Firearms.FirstOrDefaultAsync(b => b.Name == "Firearm 1");
            Assert.NotNull(firearm);
            Assert.Equal("Firearm 1", firearm.Name);
        }

        [Fact]
        public async Task UpdateFirearmAsync_ReturnsUpdatedFirearmDto()
        {
            using var context = new AppDbContext(_dbOptions);

            var firearm = new Firearm
            {
                Name = "Old Firearm",
                PhysicalAttack = 10,
                BloodAttack = 5,
                ArcaneAttack = 3,
                FireAttack = 2,
                BoltAttack = 1,
                BulletUse = 1,
                Imprints = ImprintType.Imprint0,
                StrengthRequirement = 10,
                SkillRequirement = 10,
                BloodtingeRequirement = 10,
                ArcaneRequirement = 10,
                ImageUrl = "http://example.com/image.png",
                ScalingId = 1
            };

            _testHelpers.ValidateDto(firearm);
            context.Firearms.Add(firearm);
            await context.SaveChangesAsync();

            var updateDto = new UpdateFirearmDto
            {
                Name = "New Firearm",
                PhysicalAttack = 10,
                BloodAttack = 5,
                ArcaneAttack = 3,
                FireAttack = 2,
                BoltAttack = 1,
                BulletUse = 1,
                Imprints = ImprintType.Imprint0,
                StrengthRequirement = 10,
                SkillRequirement = 10,
                BloodtingeRequirement = 10,
                ArcaneRequirement = 10,
                ImageUrl = "http://example.com/image2.png",
                ScalingId = 1
            };

            var service = new FirearmService(context, _mapper);

            var result = await service.UpdateFirearmAsync(1, updateDto);

            Assert.NotNull(result);
            Assert.Equal("New Firearm", result.Name);
            Assert.Equal(10, result.PhysicalAttack);
            Assert.Equal(5, result.BloodAttack);
            Assert.Equal(3, result.ArcaneAttack);
            Assert.Equal(2, result.FireAttack);
            Assert.Equal(1, result.BoltAttack);
            Assert.Equal(1, result.BulletUse);
            Assert.Equal(ImprintType.Imprint0, result.Imprints);
            Assert.Equal(10, result.StrengthRequirement);
            Assert.Equal(10, result.SkillRequirement);
            Assert.Equal(10, result.BloodtingeRequirement);
            Assert.Equal(10, result.ArcaneRequirement);
            Assert.Equal("http://example.com/image2.png", result.ImageUrl);
            Assert.Equal(1, result.ScalingId);
        }

        [Fact]
        public async Task DeleteFirearmAsync_FirearmExists_DeletesFirearm()
        {
            using var context = new AppDbContext(_dbOptions);
            var firearm = new Firearm
            {
                Name = "Firearm 1",
                PhysicalAttack = 10,
                BloodAttack = 5,
                ArcaneAttack = 3,
                FireAttack = 2,
                BoltAttack = 1,
                BulletUse = 1,
                Imprints = ImprintType.Imprint0,
                StrengthRequirement = 10,
                SkillRequirement = 10,
                BloodtingeRequirement = 10,
                ArcaneRequirement = 10,
                ImageUrl = "http://example.com/image.png",
                ScalingId = 1
            };

            _testHelpers.ValidateDto(firearm);
            context.Firearms.Add(firearm);
            await context.SaveChangesAsync();

            var service = new FirearmService(context, _mapper);

            var result = await service.DeleteFirearmAsync(1);

            Assert.True(result);
            var deletedFirearm = await context.Firearms.FirstOrDefaultAsync(b => b.Id == 1);
            Assert.Null(deletedFirearm);
        }

        [Fact]
        public async Task DeleteFirearmAsync_FirearmDoesNotExist_ReturnsFalse()
        {
            using var context = new AppDbContext(_dbOptions);
            var service = new FirearmService(context, _mapper);

            var result = await service.DeleteFirearmAsync(99);

            Assert.False(result);
        }

        public static IEnumerable<object[]> FirearmFilterTestData =>
        new List<object[]>
        {
            new object[] { new FirearmFilter { PhysicalAttack = 10 }, new string[] { "Firearm 1" } },
            new object[] { new FirearmFilter { BloodAttackMin = 5 }, new string[] { "Firearm 1", "Firearm 2" } },
            new object[] { new FirearmFilter { ArcaneAttackMax = 7 }, new string[] { "Firearm 1" } },
            new object[] { new FirearmFilter { FirearmName = "Firearm 2" }, new string[] { "Firearm 2" } },
            new object[] { new FirearmFilter { FirearmName = "" }, new string[] { } },
            new object[] { new FirearmFilter { }, new string[] { } }
        };

        [Theory]
        [MemberData(nameof(FirearmFilterTestData))]
        public async Task GetFirearmsByFilterAsync_WithVariousFilters_ReturnsExpectedFirearms(FirearmFilter filter, string[] expectedFirearmNames)
        {
            using var context = new AppDbContext(_dbOptions);

            context.Scalings.AddRange(
                new Scaling
                {
                    Id = 1,
                    Name = "Scaling 1",
                    StrengthScaling = 1.0m,
                    SkillScaling = 1.0m,
                    BloodtingeScaling = 1.0m,
                    ArcaneScaling = 1.0m,
                },
                new Scaling
                {
                    Id = 2,
                    Name = "Scaling 2",
                    StrengthScaling = 2.0m,
                    SkillScaling = 2.0m,
                    BloodtingeScaling = 2.0m,
                    ArcaneScaling = 2.0m,
                });

            context.Firearms.AddRange(
                new Firearm
                {
                    Id = 1,
                    Name = "Firearm 1",
                    PhysicalAttack = 10,
                    BloodAttack = 5,
                    ArcaneAttack = 3,
                    FireAttack = 2,
                    BoltAttack = 1,
                    BulletUse = 1,
                    Imprints = ImprintType.Imprint0,
                    StrengthRequirement = 10,
                    SkillRequirement = 10,
                    BloodtingeRequirement = 10,
                    ArcaneRequirement = 10,
                    ImageUrl = "http://example.com/image.png",
                    ScalingId = 1,
                },
                new Firearm
                {
                    Id = 2,
                    Name = "Firearm 2",
                    PhysicalAttack = 20,
                    BloodAttack = 15,
                    ArcaneAttack = 13,
                    FireAttack = 12,
                    BoltAttack = 11,
                    BulletUse = 2,
                    Imprints = ImprintType.Imprint1,
                    StrengthRequirement = 20,
                    SkillRequirement = 20,
                    BloodtingeRequirement = 20,
                    ArcaneRequirement = 20,
                    ImageUrl = "http://example.com/image2.png",
                    ScalingId = 2,
                });

            await context.SaveChangesAsync();

            var service = new FirearmService(context, _mapper);
            var result = await service.GetFirearmsByFilterAsync(filter);

            var resultNames = result.Select(b => b.Name).ToArray();

            Assert.Equal(expectedFirearmNames.OrderBy(n => n), resultNames.OrderBy(n => n));
        }
    }
}
