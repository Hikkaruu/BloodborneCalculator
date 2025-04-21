using api.Mapping;
using api.Models.DTOs.Boss;
using api.Models.Entities;
using api.Persistence.Data;
using api.Services;
using AutoMapper;
using CoreEx;
using Microsoft.EntityFrameworkCore;
using api.Tests.Helpers.TestHelpers;
using api.Models.Filters;

namespace api.Tests.Services.BossTests
{
    public class BossServiceTests
    {
        private readonly DbContextOptions<AppDbContext> _dbOptions;
        private readonly IMapper _mapper;
        private readonly TestHelpers _testHelpers = new TestHelpers();

        public BossServiceTests()
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
        public async Task GetBossByIdAsync_BossExists_ReturnsDto()
        {
            using var context = new AppDbContext(_dbOptions);
            context.Bosses.Add(new Boss { Id = 1, Name = "Father Gascoigne" });
            await context.SaveChangesAsync();

            var service = new BossService(context, _mapper);

            var result = await service.GetBossByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Father Gascoigne", result.Name);
        }

        [Fact]
        public async Task GetBossByIdAsync_BossDoesNotExist_ReturnsNotFoundException()
        {
            using var context = new AppDbContext(_dbOptions);
            var service = new BossService(context, _mapper);

            await Assert.ThrowsAsync<NotFoundException>(() => service.GetBossByIdAsync(99));
        }

        [Fact]
        public async Task GetAllBossesAsync_ReturnsAllBosses()
        {
            using var context = new AppDbContext(_dbOptions);
            context.Bosses.Add(new Boss { Id = 1, Name = "Father Gascoigne" });
            context.Bosses.Add(new Boss { Id = 2, Name = "Vicar Amelia" });
            await context.SaveChangesAsync();

            var service = new BossService(context, _mapper);

            var result = await service.GetAllBossesAsync();

            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task CreateBossAsync_ValidDto_CreatesBoss()
        {
            using var context = new AppDbContext(_dbOptions);
            var createDto = new CreateBossDto { 
                Name = "Father Gascoigne",
                Health = 1000,
                BloodEchoes = 500,
                IsInterruptible = true,
                IsRequired = true,
                IsBeast = false,
                IsKin = false,
                IsWeakToSerrated = true,
                IsWeakToRighteous = false,
                PhysicalDefense = 100,
                BluntDefense = 100,
                ThrustDefense = 100,
                BloodtingeDefense = 100,
                ArcaneDefense = 100,
                FireDefense = 100,
                BoltDefense = 100,
                SlowPoisonResistance = 100,
                RapidPoisonResistance = 100,
                ImageUrl = "http://example.com/image.jpg"
            };

            _testHelpers.ValidateDto(createDto);

            var service = new BossService(context, _mapper);

            var result = await service.CreateBossAsync(createDto);

            var boss = await context.Bosses.FirstOrDefaultAsync(b => b.Name == "Father Gascoigne");
            Assert.NotNull(boss);
            Assert.Equal("Father Gascoigne", boss.Name);
        }

        [Fact]
        public async Task UpdateBossAsync_ReturnsUpdatedBossDto()
        {
            using var context = new AppDbContext(_dbOptions);

            var boss = new Boss { 
                Id = 1, 
                Name = "Old Boss",
                Health = 1000,
                BloodEchoes = 500,
                IsInterruptible = false,
                IsRequired = false,
                IsBeast = false,
                IsKin = false,
                IsWeakToSerrated = false,
                IsWeakToRighteous = false,
                PhysicalDefense = 100,
                BluntDefense = 100,
                ThrustDefense = 100,
                BloodtingeDefense = 100,
                ArcaneDefense = 100,
                FireDefense = 100,
                BoltDefense = 100,
                SlowPoisonResistance = 100,
                RapidPoisonResistance = 100,
                ImageUrl = "http://example.com/image.jpg"
            };

            _testHelpers.ValidateDto(boss);
            context.Bosses.Add(boss);
            await context.SaveChangesAsync();

            var updateDto = new UpdateBossDto { 
                Name = "Updated Boss",
                Health = 1200,
                BloodEchoes = 600,
                IsInterruptible = true,
                IsRequired = true,
                IsBeast = true,
                IsKin = true,
                IsWeakToSerrated = true,
                IsWeakToRighteous = true,
                PhysicalDefense = 150,
                BluntDefense = 150,
                ThrustDefense = 150,
                BloodtingeDefense = 150,
                ArcaneDefense = 150,
                FireDefense = 150,
                BoltDefense = 150,
                SlowPoisonResistance = 150,
                RapidPoisonResistance = 150,
                ImageUrl = "http://example.com/updated_image.jpg"
            };

            var service = new BossService(context, _mapper);

            var result = await service.UpdateBossAsync(1, updateDto);

            Assert.NotNull(result);
            Assert.Equal("Updated Boss", result.Name);
            Assert.Equal(1200, result.Health);
            Assert.Equal(600, result.BloodEchoes);
            Assert.True(result.IsInterruptible);
            Assert.True(result.IsRequired);
            Assert.True(result.IsBeast);
            Assert.True(result.IsKin);
            Assert.True(result.IsWeakToSerrated);
            Assert.True(result.IsWeakToRighteous);
            Assert.Equal(150, result.PhysicalDefense);
            Assert.Equal(150, result.BluntDefense);
            Assert.Equal(150, result.ThrustDefense);
            Assert.Equal(150, result.BloodtingeDefense);
            Assert.Equal(150, result.ArcaneDefense);
            Assert.Equal(150, result.FireDefense);
            Assert.Equal(150, result.BoltDefense);
            Assert.Equal(150, result.SlowPoisonResistance);
            Assert.Equal(150, result.RapidPoisonResistance);
            Assert.Equal("http://example.com/updated_image.jpg", result.ImageUrl);
        }

        [Fact]
        public async Task DeleteBossAsync_BossExists_DeletesBoss()
        {
            using var context = new AppDbContext(_dbOptions);
            var boss = new Boss
            {
                Id = 1,
                Name = "Old Boss",
                Health = 1000,
                BloodEchoes = 500,
                IsInterruptible = false,
                IsRequired = false,
                IsBeast = false,
                IsKin = false,
                IsWeakToSerrated = false,
                IsWeakToRighteous = false,
                PhysicalDefense = 100,
                BluntDefense = 100,
                ThrustDefense = 100,
                BloodtingeDefense = 100,
                ArcaneDefense = 100,
                FireDefense = 100,
                BoltDefense = 100,
                SlowPoisonResistance = 100,
                RapidPoisonResistance = 100,
                ImageUrl = "http://example.com/image.jpg"
            };

            _testHelpers.ValidateDto(boss);
            context.Bosses.Add(boss);
            await context.SaveChangesAsync();

            var service = new BossService(context, _mapper);

            var result = await service.DeleteBossAsync(1);

            Assert.True(result);
            var deletedBoss = await context.Bosses.FirstOrDefaultAsync(b => b.Id == 1);
            Assert.Null(deletedBoss);
        }

        [Fact]
        public async Task DeleteBossAsync_BossDoesNotExist_ReturnsFalse()
        {
            using var context = new AppDbContext(_dbOptions);
            var service = new BossService(context, _mapper);

            var result = await service.DeleteBossAsync(99);

            Assert.False(result);
        }

        public static IEnumerable<object[]> BossFilterTestData =>
        new List<object[]>
        {
            new object[] { new BossFilter { HealthMin = 1000, HealthMax = 2000 }, new string[] { "Boss A", "Boss B" } },
            new object[] { new BossFilter { PhysicalDefenseMin = 150 }, new string[] { "Boss B" } },
            new object[] { new BossFilter { PhysicalDefenseMax = 150 }, new string[] { "Boss A" } },
            new object[] { new BossFilter { BossName = "NonExistingBoss" }, new string[] { } },
            new object[] { new BossFilter { BossName = "" }, new string[] { } },
            new object[] { new BossFilter { }, new string[] { } }
        };

        [Theory]
        [MemberData(nameof(BossFilterTestData))]
        public async Task GetBossesByFilterAsync_WithVariousFilters_ReturnsExpectedBosses(BossFilter filter, string[] expectedBossNames)
        {
            using var context = new AppDbContext(_dbOptions);

            context.Bosses.AddRange(
                new Boss
                {
                    Name = "Boss A",
                    Health = 1000,
                    BloodEchoes = 500,
                    IsInterruptible = false,
                    IsRequired = false,
                    IsBeast = false,
                    IsKin = false,
                    IsWeakToSerrated = false,
                    IsWeakToRighteous = false,
                    PhysicalDefense = 100,
                    BluntDefense = 100,
                    ThrustDefense = 100,
                    BloodtingeDefense = 100,
                    ArcaneDefense = 100,
                    FireDefense = 100,
                    BoltDefense = 100,
                    SlowPoisonResistance = 100,
                    RapidPoisonResistance = 100,
                    ImageUrl = "http://example.com/image.jpg"
                },
                new Boss
                {
                    Name = "Boss B",
                    Health = 2000,
                    BloodEchoes = 1000,
                    IsInterruptible = true,
                    IsRequired = true,
                    IsBeast = true,
                    IsKin = true,
                    IsWeakToSerrated = true,
                    IsWeakToRighteous = true,
                    PhysicalDefense = 200,
                    BluntDefense = 200,
                    ThrustDefense = 200,
                    BloodtingeDefense = 200,
                    ArcaneDefense = 200,
                    FireDefense = 200,
                    BoltDefense = 200,
                    SlowPoisonResistance = 200,
                    RapidPoisonResistance = 200,
                    ImageUrl = "http://example.com/image.jpg"
                }
            );

            await context.SaveChangesAsync();

            var service = new BossService(context, _mapper);
            var result = await service.GetBossesByFilterAsync(filter);

            var resultNames = result.Select(b => b.Name).ToArray();

            Assert.Equal(expectedBossNames.OrderBy(n => n), resultNames.OrderBy(n => n));
        }

    }
}
