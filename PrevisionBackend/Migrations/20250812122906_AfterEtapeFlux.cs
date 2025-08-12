using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrevisionBackend.Migrations
{
    /// <inheritdoc />
    public partial class AfterEtapeFlux : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cycles",
                columns: table => new
                {
                    code_cycle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    designation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    date_start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_end = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cycles", x => x.code_cycle);
                });

            migrationBuilder.CreateTable(
                name: "Flux",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreEtapes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flux", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    ModuleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.ModuleID);
                });

            migrationBuilder.CreateTable(
                name: "PermissionPrevisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Permissions = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPrevisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producteurs",
                columns: table => new
                {
                    code_producteur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producteurs", x => x.code_producteur);
                });

            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    code_prod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    designation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.code_prod);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ProfileID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ProfileID);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    cod_region = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    desi_region = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.cod_region);
                });

            migrationBuilder.CreateTable(
                name: "EtapeFlux",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFlux = table.Column<int>(type: "int", nullable: false),
                    Ordre = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FluxId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtapeFlux", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EtapeFlux_Flux_FluxId",
                        column: x => x.FluxId,
                        principalTable: "Flux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    PermissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Module_Permissions = table.Column<int>(type: "int", nullable: false),
                    PermissionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PermissionID);
                    table.ForeignKey(
                        name: "FK_Permissions_Modules_Module_Permissions",
                        column: x => x.Module_Permissions,
                        principalTable: "Modules",
                        principalColumn: "ModuleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Varietes",
                columns: table => new
                {
                    code_var = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    designation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    code_prod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Varietes", x => x.code_var);
                    table.ForeignKey(
                        name: "FK_Varietes_Produits_code_prod",
                        column: x => x.code_prod,
                        principalTable: "Produits",
                        principalColumn: "code_prod",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProfileID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Profiles_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ProfileID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fermes",
                columns: table => new
                {
                    cod_ferm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nom_ferm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    superficie = table.Column<float>(type: "real", nullable: false),
                    cod_region = table.Column<int>(type: "int", nullable: false),
                    ref_prod = table.Column<int>(type: "int", nullable: false),
                    CodeDomaine = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FluxId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fermes", x => x.cod_ferm);
                    table.ForeignKey(
                        name: "FK_Fermes_Flux_FluxId",
                        column: x => x.FluxId,
                        principalTable: "Flux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fermes_Producteurs_ref_prod",
                        column: x => x.ref_prod,
                        principalTable: "Producteurs",
                        principalColumn: "code_producteur",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fermes_Regions_cod_region",
                        column: x => x.cod_region,
                        principalTable: "Regions",
                        principalColumn: "cod_region",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfilePermissions",
                columns: table => new
                {
                    ProfileID = table.Column<int>(type: "int", nullable: false),
                    PermissionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePermissions", x => new { x.ProfileID, x.PermissionID });
                    table.ForeignKey(
                        name: "FK_ProfilePermissions_Permissions_PermissionID",
                        column: x => x.PermissionID,
                        principalTable: "Permissions",
                        principalColumn: "PermissionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfilePermissions_Profiles_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ProfileID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VarieteChamps",
                columns: table => new
                {
                    code_varchamp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    designation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    code_var = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VarieteChamps", x => x.code_varchamp);
                    table.ForeignKey(
                        name: "FK_VarieteChamps_Varietes_code_var",
                        column: x => x.code_var,
                        principalTable: "Varietes",
                        principalColumn: "code_var",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Validateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Validateurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Validateurs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrevisionFermes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    FermeId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: true),
                    CreePar = table.Column<int>(type: "int", nullable: false),
                    Statut = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrevisionFermes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrevisionFermes_Fermes_FermeId",
                        column: x => x.FermeId,
                        principalTable: "Fermes",
                        principalColumn: "cod_ferm",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Secteurs",
                columns: table => new
                {
                    code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    designation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    superficie = table.Column<float>(type: "real", nullable: false),
                    cod_ferm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FermeCodFerm = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secteurs", x => x.code);
                    table.ForeignKey(
                        name: "FK_Secteurs_Fermes_FermeCodFerm",
                        column: x => x.FermeCodFerm,
                        principalTable: "Fermes",
                        principalColumn: "cod_ferm");
                    table.ForeignKey(
                        name: "FK_Secteurs_Fermes_cod_ferm",
                        column: x => x.cod_ferm,
                        principalTable: "Fermes",
                        principalColumn: "cod_ferm",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EtapeFluxValidateurPermissions",
                columns: table => new
                {
                    EtapeFluxId = table.Column<int>(type: "int", nullable: false),
                    ValidateurId = table.Column<int>(type: "int", nullable: false),
                    PermissionPrevId = table.Column<int>(type: "int", nullable: false),
                    DateAssigned = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtapeFluxValidateurPermissions", x => new { x.EtapeFluxId, x.ValidateurId, x.PermissionPrevId });
                    table.ForeignKey(
                        name: "FK_EtapeFluxValidateurPermissions_EtapeFlux_EtapeFluxId",
                        column: x => x.EtapeFluxId,
                        principalTable: "EtapeFlux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EtapeFluxValidateurPermissions_PermissionPrevisions_PermissionPrevId",
                        column: x => x.PermissionPrevId,
                        principalTable: "PermissionPrevisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EtapeFluxValidateurPermissions_Validateurs_ValidateurId",
                        column: x => x.ValidateurId,
                        principalTable: "Validateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EtapePrev",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Statut = table.Column<int>(type: "int", nullable: false),
                    PrevisionId = table.Column<int>(type: "int", nullable: false),
                    EtapeFluxId = table.Column<int>(type: "int", nullable: false),
                    EtapeFluxId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtapePrev", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EtapePrev_EtapeFlux_EtapeFluxId",
                        column: x => x.EtapeFluxId,
                        principalTable: "EtapeFlux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EtapePrev_EtapeFlux_EtapeFluxId1",
                        column: x => x.EtapeFluxId1,
                        principalTable: "EtapeFlux",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EtapePrev_PrevisionFermes_PrevisionId",
                        column: x => x.PrevisionId,
                        principalTable: "PrevisionFermes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assolements",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    secteur = table.Column<int>(type: "int", nullable: false),
                    cycle = table.Column<int>(type: "int", nullable: false),
                    ferme = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    variete_champ = table.Column<int>(type: "int", nullable: false),
                    parcelle = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    num_culture = table.Column<int>(type: "int", nullable: false),
                    Date_plantation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_recolte = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_arrachage = table.Column<DateTime>(type: "datetime2", nullable: false),
                    superficiePlante = table.Column<float>(type: "real", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    hasRecieved = table.Column<bool>(type: "bit", nullable: false),
                    FermeCodFerm = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assolements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Assolements_Cycles_cycle",
                        column: x => x.cycle,
                        principalTable: "Cycles",
                        principalColumn: "code_cycle",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assolements_Fermes_FermeCodFerm",
                        column: x => x.FermeCodFerm,
                        principalTable: "Fermes",
                        principalColumn: "cod_ferm");
                    table.ForeignKey(
                        name: "FK_Assolements_Fermes_ferme",
                        column: x => x.ferme,
                        principalTable: "Fermes",
                        principalColumn: "cod_ferm",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assolements_Secteurs_secteur",
                        column: x => x.secteur,
                        principalTable: "Secteurs",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assolements_VarieteChamps_variete_champ",
                        column: x => x.variete_champ,
                        principalTable: "VarieteChamps",
                        principalColumn: "code_varchamp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrevisionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPrevision = table.Column<int>(type: "int", nullable: false),
                    SecteurCode = table.Column<int>(type: "int", nullable: false),
                    CycleId = table.Column<int>(type: "int", nullable: false),
                    NumCulture = table.Column<int>(type: "int", nullable: false),
                    Parcelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrevisionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrevisionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrevisionDetails_PrevisionFermes_PrevisionId",
                        column: x => x.PrevisionId,
                        principalTable: "PrevisionFermes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrevisionDetails_Secteurs_SecteurCode",
                        column: x => x.SecteurCode,
                        principalTable: "Secteurs",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LignePrevisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPrevisionDetails = table.Column<int>(type: "int", nullable: false),
                    Valeur = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrevisionDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LignePrevisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LignePrevisions_PrevisionDetails_PrevisionDetailsId",
                        column: x => x.PrevisionDetailsId,
                        principalTable: "PrevisionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assolements_cycle",
                table: "Assolements",
                column: "cycle");

            migrationBuilder.CreateIndex(
                name: "IX_Assolements_ferme_secteur_cycle_parcelle_num_culture_variete_champ",
                table: "Assolements",
                columns: new[] { "ferme", "secteur", "cycle", "parcelle", "num_culture", "variete_champ" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assolements_FermeCodFerm",
                table: "Assolements",
                column: "FermeCodFerm");

            migrationBuilder.CreateIndex(
                name: "IX_Assolements_secteur",
                table: "Assolements",
                column: "secteur");

            migrationBuilder.CreateIndex(
                name: "IX_Assolements_variete_champ",
                table: "Assolements",
                column: "variete_champ");

            migrationBuilder.CreateIndex(
                name: "IX_EtapeFlux_FluxId",
                table: "EtapeFlux",
                column: "FluxId");

            migrationBuilder.CreateIndex(
                name: "IX_EtapeFluxValidateurPermissions_PermissionPrevId",
                table: "EtapeFluxValidateurPermissions",
                column: "PermissionPrevId");

            migrationBuilder.CreateIndex(
                name: "IX_EtapeFluxValidateurPermissions_ValidateurId",
                table: "EtapeFluxValidateurPermissions",
                column: "ValidateurId");

            migrationBuilder.CreateIndex(
                name: "IX_EtapePrev_EtapeFluxId",
                table: "EtapePrev",
                column: "EtapeFluxId");

            migrationBuilder.CreateIndex(
                name: "IX_EtapePrev_EtapeFluxId1",
                table: "EtapePrev",
                column: "EtapeFluxId1");

            migrationBuilder.CreateIndex(
                name: "IX_EtapePrev_PrevisionId",
                table: "EtapePrev",
                column: "PrevisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Fermes_cod_region",
                table: "Fermes",
                column: "cod_region");

            migrationBuilder.CreateIndex(
                name: "IX_Fermes_FluxId",
                table: "Fermes",
                column: "FluxId");

            migrationBuilder.CreateIndex(
                name: "IX_Fermes_ref_prod",
                table: "Fermes",
                column: "ref_prod");

            migrationBuilder.CreateIndex(
                name: "IX_LignePrevisions_PrevisionDetailsId",
                table: "LignePrevisions",
                column: "PrevisionDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_Module_Permissions",
                table: "Permissions",
                column: "Module_Permissions");

            migrationBuilder.CreateIndex(
                name: "IX_PrevisionDetails_PrevisionId",
                table: "PrevisionDetails",
                column: "PrevisionId");

            migrationBuilder.CreateIndex(
                name: "IX_PrevisionDetails_SecteurCode",
                table: "PrevisionDetails",
                column: "SecteurCode");

            migrationBuilder.CreateIndex(
                name: "IX_PrevisionFermes_FermeId",
                table: "PrevisionFermes",
                column: "FermeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePermissions_PermissionID",
                table: "ProfilePermissions",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_Secteurs_cod_ferm",
                table: "Secteurs",
                column: "cod_ferm");

            migrationBuilder.CreateIndex(
                name: "IX_Secteurs_FermeCodFerm",
                table: "Secteurs",
                column: "FermeCodFerm");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfileID",
                table: "Users",
                column: "ProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_Validateurs_UserID",
                table: "Validateurs",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_VarieteChamps_code_var",
                table: "VarieteChamps",
                column: "code_var");

            migrationBuilder.CreateIndex(
                name: "IX_Varietes_code_prod",
                table: "Varietes",
                column: "code_prod");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assolements");

            migrationBuilder.DropTable(
                name: "EtapeFluxValidateurPermissions");

            migrationBuilder.DropTable(
                name: "EtapePrev");

            migrationBuilder.DropTable(
                name: "LignePrevisions");

            migrationBuilder.DropTable(
                name: "ProfilePermissions");

            migrationBuilder.DropTable(
                name: "Cycles");

            migrationBuilder.DropTable(
                name: "VarieteChamps");

            migrationBuilder.DropTable(
                name: "PermissionPrevisions");

            migrationBuilder.DropTable(
                name: "Validateurs");

            migrationBuilder.DropTable(
                name: "EtapeFlux");

            migrationBuilder.DropTable(
                name: "PrevisionDetails");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Varietes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PrevisionFermes");

            migrationBuilder.DropTable(
                name: "Secteurs");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Produits");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Fermes");

            migrationBuilder.DropTable(
                name: "Flux");

            migrationBuilder.DropTable(
                name: "Producteurs");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
