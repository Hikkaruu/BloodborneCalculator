using api.Mapping;
using api.Models.DTOs.Attack;
using api.Models.Entities;
using api.Models.Enums;
using api.Models.Filters;
using api.Persistence.Data;
using api.Services;
using api.Tests.Helpers.TestHelpers;
using AutoMapper;
using CoreEx;
using Microsoft.EntityFrameworkCore;

namespace api.Tests.Services.AttackTests
{
    public class AttackServiceTests
    {
        private readonly DbContextOptions<AppDbContext> _dbOptions;
        private readonly IMapper _mapper;
        private readonly TestHelpers _testHelpers = new TestHelpers();

        public AttackServiceTests()
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
        public async Task GetAttackByIdAsync_AttackExists_ReturnsDto()
        {
            using var context = new AppDbContext(_dbOptions);

            context.TricksterWeapons.Add(new TricksterWeapon
            {
                Id = 1,
                Name = "Test Weapon"
            });

            context.Attacks.Add(new Attack
            {
                Id = 1,
                Name = "Fire Thrust",
                Damage = 2.50m,
                ExtraDamage = 3.00m,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Fire,
                AttackType2 = AttackType.Thrust,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            });

            await context.SaveChangesAsync();

            var service = new AttackService(context, _mapper);

            var result = await service.GetAttackByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Fire Thrust", result.Name);
        }

        [Fact]
        public async Task GetAttackByIdAsync_AttackDoesNotExist_ReturnsNotFoundException()
        {
            using var context = new AppDbContext(_dbOptions);
            var service = new AttackService(context, _mapper);

            await Assert.ThrowsAsync<NotFoundException>(() => service.GetAttackByIdAsync(999));
        }

        [Fact]
        public async Task GetAllAttacksAsync_ReturnsAllAttacks()
        {
            using var context = new AppDbContext(_dbOptions);

            context.TricksterWeapons.Add(new TricksterWeapon
            {
                Id = 1,
                Name = "Test Weapon"
            });

            context.TricksterWeapons.Add(new TricksterWeapon
            {
                Id = 2,
                Name = "Test Weapon 2"
            });

            context.Attacks.Add(new Attack
            {
                Id = 1,
                Name = "Fire Thrust",
                Damage = 2.50m,
                ExtraDamage = 3.00m,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Fire,
                AttackType2 = AttackType.Thrust,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            });
            context.Attacks.Add(new Attack
            {
                Id = 2,
                Name = "Bolt Blunt",
                Damage = 5.00m,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Bolt,
                AttackType2 = AttackType.Blunt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            });
            await context.SaveChangesAsync();

            var service = new AttackService(context, _mapper);

            var result = await service.GetAllAttacksAsync();

            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task CreateAttackAsync_ValidDto_CreatesAttack()
        {
            using var context = new AppDbContext(_dbOptions);
            var createDto = new CreateAttackDto
            {
                Name = "Fire Thrust",
                Damage = 2.50m,
                ExtraDamage = 3.00m,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Fire,
                AttackType2 = AttackType.Thrust,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            };

            _testHelpers.ValidateDto(createDto);

            var service = new AttackService(context, _mapper);

            var result = await service.CreateAttackAsync(createDto);

            var attack = await context.Attacks.FirstOrDefaultAsync(b => b.Name == "Fire Thrust");
            Assert.NotNull(attack);
            Assert.Equal("Fire Thrust", attack.Name);
        }

        [Fact]
        public async Task UpdateAttackAsync_ReturnsUpdatedAttackDto()
        {
            using var context = new AppDbContext(_dbOptions);

            var attack = new Attack
            {
                Name = "Fire Thrust",
                Damage = 2.50m,
                ExtraDamage = 3.00m,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Fire,
                AttackType2 = AttackType.Thrust,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            };

            _testHelpers.ValidateDto(attack);
            context.Attacks.Add(attack);
            await context.SaveChangesAsync();

            var updateDto = new UpdateAttackDto
            {
                Name = "Bolt Blunt",
                Damage = 5.00m,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Bolt,
                AttackType2 = AttackType.Blunt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            };

            var service = new AttackService(context, _mapper);

            var result = await service.UpdateAttackAsync(1, updateDto);

            Assert.NotNull(result);
            Assert.Equal("Bolt Blunt", result.Name);
            Assert.Equal(5.00m, result.Damage);
            Assert.Equal(0, result.ExtraDamage);
            Assert.Equal(0, result.ExtraDamageCount);
            Assert.Equal(AttackType.Bolt, result.AttackType1);
            Assert.Equal(AttackType.Blunt, result.AttackType2);
            Assert.Equal(AttackMode.Normal, result.AttackMode);
            Assert.Equal(2, result.TricksterWeaponId);
        }

        [Fact]
        public async Task DeleteAttackAsync_AttackExists_DeletesAttack()
        {
            using var context = new AppDbContext(_dbOptions);
            var attack = new Attack
            {
                Name = "Fire Thrust",
                Damage = 2.50m,
                ExtraDamage = 3.00m,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Fire,
                AttackType2 = AttackType.Thrust,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            };

            _testHelpers.ValidateDto(attack);
            context.Attacks.Add(attack);
            await context.SaveChangesAsync();

            var service = new AttackService(context, _mapper);

            var result = await service.DeleteAttackAsync(1);

            Assert.True(result);
            var deletedAttack = await context.Attacks.FirstOrDefaultAsync(b => b.Id == 1);
            Assert.Null(deletedAttack);
        }

        [Fact]
        public async Task DeleteAttackAsync_AttackDoesNotExist_ReturnsFalse()
        {
            using var context = new AppDbContext(_dbOptions);
            var service = new AttackService(context, _mapper);

            var result = await service.DeleteAttackAsync(99);

            Assert.False(result);
        }

        public static IEnumerable<object[]> AttackFilterTestData =>
        new List<object[]>
        {
            new object[] { new AttackFilter { AttackName = "Fire Thrust" }, new string[] { "Fire Thrust" } },
            new object[] { new AttackFilter { DamageMin = 1.5m, DamageMax = 8 }, new string[] { "Fire Thrust", "Bolt Blunt" } },
            new object[] { new AttackFilter { DamageMin = 4 }, new string[] { "Bolt Blunt" } },
            new object[] { new AttackFilter { AttackName = "" }, new string[] { } },
            new object[] { new AttackFilter { }, new string[] { } }
        };

        [Theory]
        [MemberData(nameof(AttackFilterTestData))]
        public async Task GetAttacksByFilterAsync_WithVariousFilters_ReturnsExpectedAttacks(AttackFilter filter, string[] expectedAttackNames)
        {
            using var context = new AppDbContext(_dbOptions);

            context.TricksterWeapons.AddRange(
                new TricksterWeapon
                {
                    Id = 1,
                    Name = "Test Weapon"
                },
                new TricksterWeapon
                {
                    Id = 2,
                    Name = "Test Weapon 2"
                }
            );

            context.Attacks.AddRange(
                new Attack
                {
                    Name = "Fire Thrust",
                    Damage = 2.50m,
                    ExtraDamage = 3.00m,
                    ExtraDamageCount = 2,
                    AttackType1 = AttackType.Fire,
                    AttackType2 = AttackType.Thrust,
                    AttackMode = AttackMode.Normal,
                    TricksterWeaponId = 1
                },
                new Attack
                {
                    Name = "Bolt Blunt",
                    Damage = 5.00m,
                    ExtraDamage = 0,
                    ExtraDamageCount = 0,
                    AttackType1 = AttackType.Bolt,
                    AttackType2 = AttackType.Blunt,
                    AttackMode = AttackMode.Normal,
                    TricksterWeaponId = 2
                }
            );

            await context.SaveChangesAsync();

            var service = new AttackService(context, _mapper);
            var result = await service.GetAttacksByFilterAsync(filter);

            var resultNames = result.Select(a => a.Name).ToArray();

            Assert.Equal(expectedAttackNames.OrderBy(n => n), resultNames.OrderBy(n => n));
        }
    }
}
