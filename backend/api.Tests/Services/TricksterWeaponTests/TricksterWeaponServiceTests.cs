using api.Interfaces;
using api.Mapping;
using api.Models.DTOs.TricksterWeapon;
using api.Models.Entities;
using api.Models.Enums;
using api.Models.Filters;
using api.Persistence.Data;
using api.Services;
using api.Tests.Helpers.TestHelpers;
using AutoMapper;
using CoreEx;
using Microsoft.EntityFrameworkCore;

namespace api.Tests.Services.TricksterWeaponTests
{
    public class TricksterWeaponServiceTests
    {
        private readonly DbContextOptions<AppDbContext> _dbOptions;
        private readonly IMapper _mapper;
        private readonly TestHelpers _testHelpers = new TestHelpers();

        public TricksterWeaponServiceTests()
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
        public async Task GetTricksterWeaponByIdAsync_TricksterWeaponExists_ReturnsDto()
        {
            using var context = new AppDbContext(_dbOptions);
            context.Scalings.Add(
                new Scaling
                {
                    Id = 1,
                    Name = "Scaling 1",
                    StrengthScaling = 1.0m,
                    SkillScaling = 1.0m,
                    BloodtingeScaling = 1.0m,
                    ArcaneScaling = 1.0m,
                });
            context.TricksterWeapons.Add(
                new TricksterWeapon
                {
                    Id = 1,
                    Name = "Weapon 1",
                    PhysicalAttack = 100,
                    BloodAttack = 50,
                    ArcaneAttack = 30,
                    FireAttack = 20,
                    BoltAttack = 10,
                    BulletUse = 5,
                    RapidPoison = 2,
                    ImprintsNormal = ImprintType.Imprint221,
                    ImprintsUncanny = ImprintType.Imprint234,
                    ImprintsLost = ImprintType.Imprint224,
                    Rally = 15,
                    StrengthRequirement = 10,
                    SkillRequirement = 15,
                    BloodtingeRequirement = 5,
                    ArcaneRequirement = 8,
                    MaxUpgradeAttack = 200,
                    ImageUrl = "https://example.com/image.png",
                    ScalingId = 1,
                });
            await context.SaveChangesAsync();

            var service = new TricksterWeaponService(context, _mapper);

            var result = await service.GetTricksterWeaponByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Weapon 1", result.Name);
        }

        [Fact]
        public async Task GetTricksterWeaponByIdAsync_TricksterWeaponDoesNotExist_ReturnsNotFoundException()
        {
            using var context = new AppDbContext(_dbOptions);
            var service = new TricksterWeaponService(context, _mapper);

            await Assert.ThrowsAsync<NotFoundException>(() => service.GetTricksterWeaponByIdAsync(99));
        }

        [Fact]
        public async Task GetAllTricksterWeaponsAsync_ReturnsAllTricksterWeapons()
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
                    StrengthScaling = 1.5m,
                    SkillScaling = 1.5m,
                    BloodtingeScaling = 1.5m,
                    ArcaneScaling = 1.5m,
                });

            context.TricksterWeapons.AddRange(
                new TricksterWeapon
                {
                    Id = 1,
                    Name = "Weapon 1",
                    PhysicalAttack = 100,
                    BloodAttack = 50,
                    ArcaneAttack = 30,
                    FireAttack = 20,
                    BoltAttack = 10,
                    BulletUse = 5,
                    RapidPoison = 2,
                    ImprintsNormal = ImprintType.Imprint221,
                    ImprintsUncanny = ImprintType.Imprint234,
                    ImprintsLost = ImprintType.Imprint224,
                    Rally = 15,
                    StrengthRequirement = 10,
                    SkillRequirement = 15,
                    BloodtingeRequirement = 5,
                    ArcaneRequirement = 8,
                    MaxUpgradeAttack = 200,
                    ImageUrl = "https://example.com/image.png",
                    ScalingId = 1,
                },
                new TricksterWeapon
                {
                    Id = 2,
                    Name = "Weapon 2",
                    PhysicalAttack = 120,
                    BloodAttack = 60,
                    ArcaneAttack = 35,
                    FireAttack = 25,
                    BoltAttack = 15,
                    BulletUse = 6,
                    RapidPoison = 3,
                    ImprintsNormal = ImprintType.Imprint221,
                    ImprintsUncanny = ImprintType.Imprint224,
                    ImprintsLost = ImprintType.Imprint234,
                    Rally = 20,
                    StrengthRequirement = 12,
                    SkillRequirement = 18,
                    BloodtingeRequirement = 6,
                    ArcaneRequirement = 10,
                    MaxUpgradeAttack = 220,
                    ImageUrl = "https://example.com/image2.png",
                    ScalingId = 2,
                });
            await context.SaveChangesAsync();

            var service = new TricksterWeaponService(context, _mapper);

            var result = await service.GetAllTricksterWeaponsAsync();

            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task CreateTricksterWeaponAsync_ValidDto_CreatesTricksterWeapon()
        {
            using var context = new AppDbContext(_dbOptions);

            context.Scalings.Add(
                new Scaling
                {
                    Id = 1,
                    Name = "Scaling 1",
                    StrengthScaling = 1.0m,
                    SkillScaling = 1.0m,
                    BloodtingeScaling = 1.0m,
                    ArcaneScaling = 1.0m,
                });

            var createDto = new CreateTricksterWeaponDto
            {
                Name = "Weapon 1",
                PhysicalAttack = 100,
                BloodAttack = 50,
                ArcaneAttack = 30,
                FireAttack = 20,
                BoltAttack = 10,
                BulletUse = 5,
                RapidPoison = 2,
                ImprintsNormal = ImprintType.Imprint221,
                ImprintsUncanny = ImprintType.Imprint234,
                ImprintsLost = ImprintType.Imprint224,
                Rally = 15,
                StrengthRequirement = 10,
                SkillRequirement = 15,
                BloodtingeRequirement = 5,
                ArcaneRequirement = 8,
                MaxUpgradeAttack = 200,
                ImageUrl = "https://example.com/image.png",
                ScalingId = 1
            };

            _testHelpers.ValidateDto(createDto);

            var service = new TricksterWeaponService(context, _mapper);

            var result = await service.CreateTricksterWeaponAsync(createDto);

            var tricksterWeapon = await context.TricksterWeapons.FirstOrDefaultAsync(b => b.Name == "Weapon 1");
            Assert.NotNull(tricksterWeapon);
            Assert.Equal("Weapon 1", tricksterWeapon.Name);
        }

        [Fact]
        public async Task UpdateTricksterWeaponAsync_ReturnsUpdatedTricksterWeaponDto()
        {
            using var context = new AppDbContext(_dbOptions);

            var tricksterWeapon = new TricksterWeapon
            {
                Name = "Weapon 1",
                PhysicalAttack = 100,
                BloodAttack = 50,
                ArcaneAttack = 30,
                FireAttack = 20,
                BoltAttack = 10,
                BulletUse = 5,
                RapidPoison = 2,
                ImprintsNormal = ImprintType.Imprint221,
                ImprintsUncanny = ImprintType.Imprint234,
                ImprintsLost = ImprintType.Imprint224,
                Rally = 15,
                StrengthRequirement = 10,
                SkillRequirement = 15,
                BloodtingeRequirement = 5,
                ArcaneRequirement = 8,
                MaxUpgradeAttack = 200,
                ImageUrl = "https://example.com/image.png",
                ScalingId = 1
            };


            _testHelpers.ValidateDto(tricksterWeapon);
            context.TricksterWeapons.Add(tricksterWeapon);
            await context.SaveChangesAsync();

            var updateDto = new UpdateTricksterWeaponDto
            {
                Name = "Updated Trickster Weapon",
                PhysicalAttack = 120,
                BloodAttack = 60,
                ArcaneAttack = 35,
                FireAttack = 25,
                BoltAttack = 15,
                BulletUse = 6,
                RapidPoison = 3,
                ImprintsNormal = ImprintType.Imprint221,
                ImprintsUncanny = ImprintType.Imprint224,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 20,
                StrengthRequirement = 12,
                SkillRequirement = 18,
                BloodtingeRequirement = 6,
                ArcaneRequirement = 10,
                MaxUpgradeAttack = 220,
                ImageUrl = "https://example.com/image2.png",
                ScalingId = 2,
            };

            var service = new TricksterWeaponService(context, _mapper);

            var result = await service.UpdateTricksterWeaponAsync(1, updateDto);

            Assert.NotNull(result);
            Assert.Equal("Updated Trickster Weapon", result.Name);
            Assert.Equal(120, result.PhysicalAttack);
            Assert.Equal(60, result.BloodAttack);
            Assert.Equal(35, result.ArcaneAttack);
            Assert.Equal(25, result.FireAttack);
            Assert.Equal(15, result.BoltAttack);
            Assert.Equal(6, result.BulletUse);
            Assert.Equal(3, result.RapidPoison);
            Assert.Equal(ImprintType.Imprint221, result.ImprintsNormal);
            Assert.Equal(ImprintType.Imprint224, result.ImprintsUncanny);
            Assert.Equal(ImprintType.Imprint234, result.ImprintsLost);
            Assert.Equal(20, result.Rally);
            Assert.Equal(12, result.StrengthRequirement);
            Assert.Equal(18, result.SkillRequirement);
            Assert.Equal(6, result.BloodtingeRequirement);
            Assert.Equal(10, result.ArcaneRequirement);
            Assert.Equal(220, result.MaxUpgradeAttack);
            Assert.Equal("https://example.com/image2.png", result.ImageUrl);
            Assert.Equal(2, result.ScalingId);
        }

        [Fact]
        public async Task DeleteTricksterWeaponAsync_TricksterWeaponExists_DeletesTricksterWeapon()
        {
            using var context = new AppDbContext(_dbOptions);
            var tricksterWeapon = new TricksterWeapon
            {
                Id = 1,
                Name = "Weapon 1",
                PhysicalAttack = 100,
                BloodAttack = 50,
                ArcaneAttack = 30,
                FireAttack = 20,
                BoltAttack = 10,
                BulletUse = 5,
                RapidPoison = 2,
                ImprintsNormal = ImprintType.Imprint221,
                ImprintsUncanny = ImprintType.Imprint234,
                ImprintsLost = ImprintType.Imprint224,
                Rally = 15,
                StrengthRequirement = 10,
                SkillRequirement = 15,
                BloodtingeRequirement = 5,
                ArcaneRequirement = 8,
                MaxUpgradeAttack = 200,
                ImageUrl = "https://example.com/image.png",
                ScalingId = 1
            };

            _testHelpers.ValidateDto(tricksterWeapon);
            context.TricksterWeapons.Add(tricksterWeapon);
            await context.SaveChangesAsync();

            var service = new TricksterWeaponService(context, _mapper);

            var result = await service.DeleteTricksterWeaponAsync(1);

            Assert.True(result);
            var deletedTricksterWeapon = await context.TricksterWeapons.FirstOrDefaultAsync(b => b.Id == 1);
            Assert.Null(deletedTricksterWeapon);
        }

        [Fact]
        public async Task DeleteTricksterWeaponAsync_TricksterWeaponDoesNotExist_ReturnsFalse()
        {
            using var context = new AppDbContext(_dbOptions);
            var service = new TricksterWeaponService(context, _mapper);

            var result = await service.DeleteTricksterWeaponAsync(99);

            Assert.False(result);
        }

        public static IEnumerable<object[]> TricksterWeaponFilterTestData =>
        new List<object[]>
        {
            new object[] { new TricksterWeaponFilter { PhysicalAttackMin = 60 }, new string[] { "Weapon 1", "Weapon 2" } },
            new object[] { new TricksterWeaponFilter { BloodAttackMin = 20, BloodAttackMax = 51 }, new string[] { "Weapon 1" } },
            new object[] { new TricksterWeaponFilter { TricksterWeaponName = "NonExistingWeapon" }, new string[] { } },
            new object[] { new TricksterWeaponFilter { TricksterWeaponName = "Weapon 2" }, new string[] { "Weapon 2" } },
            new object[] { new TricksterWeaponFilter { TricksterWeaponName = "" }, new string[] { } },
            new object[] { new TricksterWeaponFilter { }, new string[] { } }
        };

        [Theory]
        [MemberData(nameof(TricksterWeaponFilterTestData))]
        public async Task GetTricksterWeaponsByFilterAsync_WithVariousFilters_ReturnsExpectedTricksterWeapons(TricksterWeaponFilter filter, string[] expectedTricksterWeaponNames)
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
                    StrengthScaling = 1.5m,
                    SkillScaling = 1.5m,
                    BloodtingeScaling = 1.5m,
                    ArcaneScaling = 1.5m,
                });

            context.TricksterWeapons.AddRange(
                new TricksterWeapon
                {
                    Id = 1,
                    Name = "Weapon 1",
                    PhysicalAttack = 100,
                    BloodAttack = 50,
                    ArcaneAttack = 30,
                    FireAttack = 20,
                    BoltAttack = 10,
                    BulletUse = 5,
                    RapidPoison = 2,
                    ImprintsNormal = ImprintType.Imprint221,
                    ImprintsUncanny = ImprintType.Imprint234,
                    ImprintsLost = ImprintType.Imprint224,
                    Rally = 15,
                    StrengthRequirement = 10,
                    SkillRequirement = 15,
                    BloodtingeRequirement = 5,
                    ArcaneRequirement = 8,
                    MaxUpgradeAttack = 200,
                    ImageUrl = "https://example.com/image.png",
                    ScalingId = 1,
                },
                new TricksterWeapon
                {
                    Id = 2,
                    Name = "Weapon 2",
                    PhysicalAttack = 120,
                    BloodAttack = 60,
                    ArcaneAttack = 35,
                    FireAttack = 25,
                    BoltAttack = 15,
                    BulletUse = 6,
                    RapidPoison = 3,
                    ImprintsNormal = ImprintType.Imprint221,
                    ImprintsUncanny = ImprintType.Imprint224,
                    ImprintsLost = ImprintType.Imprint234,
                    Rally = 20,
                    StrengthRequirement = 12,
                    SkillRequirement = 18,
                    BloodtingeRequirement = 6,
                    ArcaneRequirement = 10,
                    MaxUpgradeAttack = 220,
                    ImageUrl = "https://example.com/image2.png",
                    ScalingId = 2,
                });

            await context.SaveChangesAsync();

            var service = new TricksterWeaponService(context, _mapper);
            var result = await service.GetTricksterWeaponsByFilterAsync(filter);

            var resultNames = result.Select(b => b.Name).ToArray();

            Assert.Equal(expectedTricksterWeaponNames.OrderBy(n => n), resultNames.OrderBy(n => n));
        }
    }
}
