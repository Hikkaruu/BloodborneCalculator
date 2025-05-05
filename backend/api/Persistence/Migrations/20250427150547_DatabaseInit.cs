using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bosses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    health = table.Column<int>(type: "integer", nullable: false),
                    blood_echoes = table.Column<int>(type: "integer", nullable: false),
                    is_interruptible = table.Column<bool>(type: "boolean", nullable: false),
                    is_required = table.Column<bool>(type: "boolean", nullable: false),
                    is_beast = table.Column<bool>(type: "boolean", nullable: false),
                    is_kin = table.Column<bool>(type: "boolean", nullable: false),
                    is_weak_to_serrated = table.Column<bool>(type: "boolean", nullable: false),
                    is_weak_to_righteous = table.Column<bool>(type: "boolean", nullable: false),
                    physical_defense = table.Column<int>(type: "integer", nullable: false),
                    blunt_defense = table.Column<int>(type: "integer", nullable: false),
                    thrust_defense = table.Column<int>(type: "integer", nullable: false),
                    bloodtinge_defense = table.Column<int>(type: "integer", nullable: false),
                    arcane_defense = table.Column<int>(type: "integer", nullable: false),
                    fire_defense = table.Column<int>(type: "integer", nullable: false),
                    bolt_defense = table.Column<int>(type: "integer", nullable: false),
                    slow_poison_resistance = table.Column<int>(type: "integer", nullable: false),
                    rapid_poison_resistance = table.Column<int>(type: "integer", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bosses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "echoes_per_level",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    level = table.Column<int>(type: "integer", nullable: false),
                    required_blood_echoes = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_echoes_per_level", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "origins",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    level = table.Column<int>(type: "integer", nullable: false),
                    blood_echoes = table.Column<int>(type: "integer", nullable: false),
                    discovery = table.Column<int>(type: "integer", nullable: false),
                    vitality = table.Column<int>(type: "integer", nullable: false),
                    endurance = table.Column<int>(type: "integer", nullable: false),
                    strength = table.Column<int>(type: "integer", nullable: false),
                    skill = table.Column<int>(type: "integer", nullable: false),
                    bloodtinge = table.Column<int>(type: "integer", nullable: false),
                    arcane = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_origins", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "scalings",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    strength_scaling = table.Column<decimal>(type: "numeric(3,2)", precision: 3, scale: 2, nullable: false),
                    skill_scaling = table.Column<decimal>(type: "numeric(3,2)", precision: 3, scale: 2, nullable: false),
                    bloodtinge_scaling = table.Column<decimal>(type: "numeric(3,2)", precision: 3, scale: 2, nullable: false),
                    arcane_scaling = table.Column<decimal>(type: "numeric(3,2)", precision: 3, scale: 2, nullable: false),
                    strength_step = table.Column<decimal>(type: "numeric(3,2)", precision: 3, scale: 2, nullable: false),
                    skill_step = table.Column<decimal>(type: "numeric(3,2)", precision: 3, scale: 2, nullable: false),
                    bloodtinge_step = table.Column<decimal>(type: "numeric(3,2)", precision: 3, scale: 2, nullable: false),
                    arcane_step = table.Column<decimal>(type: "numeric(4,3)", precision: 4, scale: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scalings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "firearms",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    physical_attack = table.Column<int>(type: "integer", nullable: false),
                    blood_attack = table.Column<int>(type: "integer", nullable: false),
                    arcane_attack = table.Column<int>(type: "integer", nullable: false),
                    fire_attack = table.Column<int>(type: "integer", nullable: false),
                    bolt_attack = table.Column<int>(type: "integer", nullable: false),
                    bullet_use = table.Column<int>(type: "integer", nullable: false),
                    imprints = table.Column<string>(type: "varchar(20)", nullable: false),
                    strength_requirement = table.Column<int>(type: "integer", nullable: false),
                    skill_requirement = table.Column<int>(type: "integer", nullable: false),
                    bloodtinge_requirement = table.Column<int>(type: "integer", nullable: false),
                    arcane_requirement = table.Column<int>(type: "integer", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: false),
                    scaling_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_firearms", x => x.id);
                    table.ForeignKey(
                        name: "FK_firearms_scalings_scaling_id",
                        column: x => x.scaling_id,
                        principalTable: "scalings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trickster_weapons",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    physical_attack = table.Column<int>(type: "integer", nullable: false),
                    blood_attack = table.Column<int>(type: "integer", nullable: false),
                    arcane_attack = table.Column<int>(type: "integer", nullable: false),
                    fire_attack = table.Column<int>(type: "integer", nullable: false),
                    bolt_attack = table.Column<int>(type: "integer", nullable: false),
                    bullet_use = table.Column<int>(type: "integer", nullable: false),
                    rapid_poison = table.Column<int>(type: "integer", nullable: false),
                    imprints_normal = table.Column<string>(type: "varchar(20)", nullable: false),
                    imprints_uncanny = table.Column<string>(type: "varchar(20)", nullable: false),
                    imprints_lost = table.Column<string>(type: "varchar(20)", nullable: false),
                    rally = table.Column<int>(type: "integer", nullable: false),
                    strength_requirement = table.Column<int>(type: "integer", nullable: false),
                    skill_requirement = table.Column<int>(type: "integer", nullable: false),
                    bloodtinge_requirement = table.Column<int>(type: "integer", nullable: false),
                    arcane_requirement = table.Column<int>(type: "integer", nullable: false),
                    max_upgrade_attack = table.Column<int>(type: "integer", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: false),
                    scaling_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trickster_weapons", x => x.id);
                    table.ForeignKey(
                        name: "FK_trickster_weapons_scalings_scaling_id",
                        column: x => x.scaling_id,
                        principalTable: "scalings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "attacks",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    damage = table.Column<decimal>(type: "numeric(3,2)", precision: 3, scale: 2, nullable: false),
                    extra_damage = table.Column<decimal>(type: "numeric(3,2)", precision: 3, scale: 2, nullable: false),
                    extra_damage_count = table.Column<int>(type: "integer", nullable: false),
                    attack_type1 = table.Column<string>(type: "varchar(20)", nullable: false),
                    attack_type2 = table.Column<string>(type: "varchar(20)", nullable: false),
                    attack_mode = table.Column<string>(type: "varchar(20)", nullable: false),
                    trickster_weapon_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attacks", x => x.id);
                    table.ForeignKey(
                        name: "FK_attacks_trickster_weapons_trickster_weapon_id",
                        column: x => x.trickster_weapon_id,
                        principalTable: "trickster_weapons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_attacks_trickster_weapon_id",
                table: "attacks",
                column: "trickster_weapon_id");

            migrationBuilder.CreateIndex(
                name: "IX_firearms_scaling_id",
                table: "firearms",
                column: "scaling_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trickster_weapons_scaling_id",
                table: "trickster_weapons",
                column: "scaling_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attacks");

            migrationBuilder.DropTable(
                name: "bosses");

            migrationBuilder.DropTable(
                name: "echoes_per_level");

            migrationBuilder.DropTable(
                name: "firearms");

            migrationBuilder.DropTable(
                name: "origins");

            migrationBuilder.DropTable(
                name: "trickster_weapons");

            migrationBuilder.DropTable(
                name: "scalings");
        }
    }
}
