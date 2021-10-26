using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Airport.Migrations
{
    public partial class initdatabasecreatetblsFlightTicketFlightTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DepartureFrom = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    ArrivalTo = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PassengerFullName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    PassengerPassport = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Place = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    BuyDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlightTicket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TicketId = table.Column<int>(type: "integer", nullable: false),
                    FlightId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightTicket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightTicket_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightTicket_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Flight",
                columns: new[] { "Id", "ArrivalDate", "ArrivalTo", "DepartureDate", "DepartureFrom", "Number" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 10, 30, 22, 42, 33, 279, DateTimeKind.Local).AddTicks(5188), "Port Georgette", new DateTime(2021, 10, 27, 11, 17, 19, 851, DateTimeKind.Local).AddTicks(5188), "Willton", "SMH0" },
                    { 20, new DateTime(2021, 11, 26, 8, 1, 51, 809, DateTimeKind.Local).AddTicks(5350), "Fayfurt", new DateTime(2021, 11, 24, 20, 9, 53, 676, DateTimeKind.Local).AddTicks(5350), "North Marleneside", "SNN19" },
                    { 19, new DateTime(2022, 4, 5, 23, 59, 40, 420, DateTimeKind.Local).AddTicks(7066), "Trantowview", new DateTime(2022, 4, 1, 11, 58, 50, 86, DateTimeKind.Local).AddTicks(7066), "West Riley", "JGE18" },
                    { 18, new DateTime(2022, 6, 19, 14, 42, 49, 730, DateTimeKind.Local).AddTicks(1313), "East Berniceburgh", new DateTime(2022, 6, 10, 19, 34, 10, 15, DateTimeKind.Local).AddTicks(1313), "Henrietteland", "INI17" },
                    { 17, new DateTime(2021, 11, 10, 2, 36, 26, 689, DateTimeKind.Local).AddTicks(1473), "West Willow", new DateTime(2021, 11, 9, 2, 44, 30, 549, DateTimeKind.Local).AddTicks(1473), "West Felixview", "QWQ16" },
                    { 16, new DateTime(2022, 7, 6, 2, 12, 24, 389, DateTimeKind.Local).AddTicks(3638), "East Myronshire", new DateTime(2022, 7, 3, 11, 34, 48, 14, DateTimeKind.Local).AddTicks(3638), "Chelseastad", "FUN15" },
                    { 14, new DateTime(2021, 9, 10, 19, 10, 18, 911, DateTimeKind.Local).AddTicks(2401), "West Wallacestad", new DateTime(2021, 9, 2, 13, 19, 44, 605, DateTimeKind.Local).AddTicks(2401), "Kendallmouth", "NCP13" },
                    { 13, new DateTime(2021, 9, 18, 9, 37, 36, 671, DateTimeKind.Local).AddTicks(1051), "Leanneport", new DateTime(2021, 9, 18, 0, 24, 44, 126, DateTimeKind.Local).AddTicks(1051), "Royalville", "PNQ12" },
                    { 12, new DateTime(2021, 10, 26, 14, 22, 29, 312, DateTimeKind.Local).AddTicks(9975), "West Marie", new DateTime(2021, 10, 20, 20, 48, 42, 516, DateTimeKind.Local).AddTicks(9975), "Mandymouth", "IDF11" },
                    { 11, new DateTime(2021, 6, 16, 23, 31, 49, 432, DateTimeKind.Local).AddTicks(4145), "Lake Arne", new DateTime(2021, 6, 8, 22, 33, 17, 596, DateTimeKind.Local).AddTicks(4145), "New Alena", "XRF10" },
                    { 15, new DateTime(2021, 7, 6, 19, 32, 19, 259, DateTimeKind.Local).AddTicks(6367), "South Orenton", new DateTime(2021, 6, 28, 2, 8, 40, 237, DateTimeKind.Local).AddTicks(6367), "Wilmerbury", "DCF14" },
                    { 9, new DateTime(2021, 8, 5, 7, 5, 35, 399, DateTimeKind.Local).AddTicks(8223), "New Shanna", new DateTime(2021, 8, 2, 4, 14, 23, 262, DateTimeKind.Local).AddTicks(8223), "Bayerbury", "AAO8" },
                    { 8, new DateTime(2021, 8, 1, 23, 17, 59, 648, DateTimeKind.Local).AddTicks(1459), "North Jamison", new DateTime(2021, 7, 24, 13, 49, 39, 869, DateTimeKind.Local).AddTicks(1459), "Loyceview", "NJC7" },
                    { 7, new DateTime(2021, 9, 11, 23, 26, 6, 23, DateTimeKind.Local).AddTicks(5028), "Skilesbury", new DateTime(2021, 9, 2, 20, 0, 34, 413, DateTimeKind.Local).AddTicks(5028), "Keelyton", "XJX6" },
                    { 6, new DateTime(2021, 10, 18, 1, 42, 28, 57, DateTimeKind.Local).AddTicks(4267), "Jamesonland", new DateTime(2021, 10, 15, 12, 7, 18, 891, DateTimeKind.Local).AddTicks(4267), "East Bertrandfort", "RVZ5" },
                    { 5, new DateTime(2022, 6, 20, 12, 48, 18, 618, DateTimeKind.Local).AddTicks(982), "Beckerview", new DateTime(2022, 6, 17, 10, 51, 18, 455, DateTimeKind.Local).AddTicks(982), "Jerdeshire", "ADD4" },
                    { 4, new DateTime(2022, 7, 13, 7, 20, 49, 276, DateTimeKind.Local).AddTicks(1175), "New Terence", new DateTime(2022, 7, 7, 12, 46, 19, 913, DateTimeKind.Local).AddTicks(1175), "Lake Melyssa", "OQN3" },
                    { 3, new DateTime(2021, 6, 24, 15, 4, 23, 363, DateTimeKind.Local).AddTicks(5593), "Wendellport", new DateTime(2021, 6, 20, 9, 51, 55, 579, DateTimeKind.Local).AddTicks(5593), "Kohlerhaven", "VAN2" },
                    { 2, new DateTime(2021, 4, 20, 20, 7, 19, 659, DateTimeKind.Local).AddTicks(582), "Lake Lamontchester", new DateTime(2021, 4, 20, 17, 54, 1, 619, DateTimeKind.Local).AddTicks(582), "Brekkeshire", "YNB1" },
                    { 10, new DateTime(2021, 11, 23, 5, 5, 20, 23, DateTimeKind.Local).AddTicks(2933), "Dooleyburgh", new DateTime(2021, 11, 18, 18, 35, 51, 379, DateTimeKind.Local).AddTicks(2933), "North Elda", "UKV9" }
                });

            migrationBuilder.InsertData(
                table: "Ticket",
                columns: new[] { "Id", "BuyDate", "IsActive", "Number", "PassengerFullName", "PassengerPassport", "Place", "Price" },
                values: new object[,]
                {
                    { 65, new DateTime(2021, 5, 2, 15, 44, 43, 494, DateTimeKind.Local).AddTicks(7861), true, "ARTNI84", "Glenna Windler", "WZKSVMB84", "H84", 969.14m },
                    { 66, new DateTime(2021, 4, 5, 1, 10, 42, 387, DateTimeKind.Local).AddTicks(2297), false, "WBAHZ85", "Donny Balistreri", "OKZURFI85", "H85", 264.82m },
                    { 67, new DateTime(2021, 1, 13, 14, 56, 26, 106, DateTimeKind.Local).AddTicks(7311), false, "BBVJG86", "Aurelia Jakubowski", "VICZTBH86", "L86", 333.59m },
                    { 68, new DateTime(2021, 1, 27, 10, 8, 33, 164, DateTimeKind.Local).AddTicks(5128), false, "HCTKY87", "Moshe Mohr", "NAKZBAI87", "J87", 758.27m },
                    { 72, new DateTime(2021, 8, 17, 8, 47, 23, 721, DateTimeKind.Local).AddTicks(6578), true, "GDTXH91", "Jakayla Leannon", "PIUJPJA91", "K91", 330.11m },
                    { 70, new DateTime(2021, 1, 14, 18, 33, 45, 827, DateTimeKind.Local).AddTicks(4606), true, "UDULV89", "Annabel Bechtelar", "OHXOSUT89", "F89", 577.93m },
                    { 71, new DateTime(2021, 9, 6, 16, 25, 41, 563, DateTimeKind.Local).AddTicks(3106), false, "QTNGQ90", "Aliza Fisher", "TTZRBOZ90", "F90", 410.66m },
                    { 64, new DateTime(2021, 9, 16, 3, 55, 37, 468, DateTimeKind.Local).AddTicks(7395), false, "HAYHQ83", "Loren Balistreri", "BCGVLUB83", "E83", 83.38m },
                    { 69, new DateTime(2021, 1, 10, 15, 43, 7, 384, DateTimeKind.Local).AddTicks(8300), false, "UVOGC88", "Loma Von", "IEXOBXH88", "I88", 13.44m },
                    { 63, new DateTime(2021, 6, 24, 6, 1, 40, 683, DateTimeKind.Local).AddTicks(4396), false, "JMZLR82", "Hobart Homenick", "UTWBEJS82", "B82", 632.91m },
                    { 53, new DateTime(2021, 9, 5, 17, 27, 1, 509, DateTimeKind.Local).AddTicks(4151), false, "EMKXX72", "Edythe Jakubowski", "MCCYCLQ72", "F72", 416.96m },
                    { 61, new DateTime(2021, 7, 24, 12, 19, 59, 973, DateTimeKind.Local).AddTicks(3845), false, "EGPXC80", "Annamarie Batz", "EUOLHHG80", "E80", 227.78m },
                    { 60, new DateTime(2021, 4, 25, 2, 19, 10, 191, DateTimeKind.Local).AddTicks(4272), true, "ZOERF79", "Claudine Schowalter", "EHHLEMH79", "D79", 611.87m },
                    { 59, new DateTime(2021, 7, 27, 15, 47, 19, 928, DateTimeKind.Local).AddTicks(9665), false, "NTJPK78", "Omari Donnelly", "RMRTLLN78", "B78", 366.49m },
                    { 58, new DateTime(2021, 5, 23, 5, 16, 26, 156, DateTimeKind.Local).AddTicks(2553), false, "WWWKO77", "Kyleigh Schimmel", "TQUYJEP77", "K77", 128.42m },
                    { 57, new DateTime(2021, 8, 14, 10, 23, 9, 460, DateTimeKind.Local).AddTicks(3774), false, "LGSJI76", "Karen Muller", "ULBISIS76", "B76", 614.70m },
                    { 56, new DateTime(2021, 10, 4, 12, 32, 19, 945, DateTimeKind.Local).AddTicks(9623), true, "QXEQQ75", "Florian Zemlak", "LXSTLEY75", "K75", 172.28m },
                    { 55, new DateTime(2021, 7, 25, 16, 16, 45, 776, DateTimeKind.Local).AddTicks(5800), true, "KPLOZ74", "Lambert Kreiger", "XGDFIMD74", "A74", 217.76m },
                    { 54, new DateTime(2021, 2, 11, 13, 57, 13, 480, DateTimeKind.Local).AddTicks(583), false, "EOSLS73", "Daija DuBuque", "XANXBLB73", "E73", 821.57m },
                    { 73, new DateTime(2021, 2, 7, 5, 20, 32, 932, DateTimeKind.Local).AddTicks(3401), false, "EBQXA92", "Bradford Ledner", "NVJXYFQ92", "A92", 344.77m },
                    { 52, new DateTime(2021, 4, 8, 11, 11, 57, 661, DateTimeKind.Local).AddTicks(8010), false, "PIOXI71", "Tamia Doyle", "FRUIIUF71", "D71", 531.93m },
                    { 62, new DateTime(2021, 3, 6, 3, 34, 48, 944, DateTimeKind.Local).AddTicks(1002), false, "FAIFP81", "Caleb Conn", "TJODIPJ81", "K81", 469.87m },
                    { 74, new DateTime(2021, 9, 28, 6, 52, 29, 153, DateTimeKind.Local).AddTicks(5952), false, "INHQZ93", "Cecil White", "UKVMYWT93", "G93", 381.84m },
                    { 84, new DateTime(2021, 7, 8, 14, 56, 8, 341, DateTimeKind.Local).AddTicks(2897), false, "PLMSB103", "Keshawn Beahan", "VQRBZSM103", "F103", 934.82m },
                    { 76, new DateTime(2020, 12, 12, 23, 8, 1, 90, DateTimeKind.Local).AddTicks(80), true, "SGQBT95", "Aglae Haley", "LGJRIUC95", "K95", 733.79m },
                    { 98, new DateTime(2020, 11, 22, 23, 19, 4, 23, DateTimeKind.Local).AddTicks(5536), true, "CDVAA117", "Rodrick Weber", "VUDPIUH117", "I117", 433.47m },
                    { 97, new DateTime(2021, 4, 18, 5, 57, 44, 958, DateTimeKind.Local).AddTicks(2634), true, "AGHVA116", "Donnie Connelly", "IAYKITG116", "K116", 917.31m },
                    { 96, new DateTime(2021, 8, 18, 22, 33, 25, 263, DateTimeKind.Local).AddTicks(8878), false, "IGFDV115", "Winona Christiansen", "BIGFSDR115", "I115", 223.26m },
                    { 95, new DateTime(2021, 8, 11, 18, 11, 35, 89, DateTimeKind.Local).AddTicks(2939), false, "NMDOZ114", "Isac Zieme", "UAXVEJD114", "G114", 217.56m },
                    { 94, new DateTime(2020, 12, 7, 17, 23, 49, 245, DateTimeKind.Local).AddTicks(1531), false, "UWHCK113", "Ella Jakubowski", "HVLJAWL113", "G113", 129.71m },
                    { 93, new DateTime(2021, 1, 8, 0, 41, 2, 593, DateTimeKind.Local).AddTicks(5367), false, "ZHHGB112", "Jaren Hermiston", "IUYDROT112", "K112", 835.21m },
                    { 92, new DateTime(2021, 2, 9, 1, 44, 54, 97, DateTimeKind.Local).AddTicks(516), false, "VBQES111", "Leone Huels", "THLBDIN111", "F111", 492.36m },
                    { 91, new DateTime(2021, 4, 13, 5, 55, 41, 119, DateTimeKind.Local).AddTicks(9966), false, "FALQF110", "Zachariah Hilpert", "KADFTOZ110", "K110", 464.21m },
                    { 90, new DateTime(2021, 1, 17, 5, 30, 9, 924, DateTimeKind.Local).AddTicks(4732), false, "XOCWA109", "Alison Emmerich", "FABBBGF109", "D109", 607.86m },
                    { 89, new DateTime(2021, 3, 26, 16, 59, 1, 559, DateTimeKind.Local).AddTicks(8417), true, "RIYBM108", "Robyn Bartell", "EPVKVPF108", "C108", 195.54m },
                    { 75, new DateTime(2021, 8, 22, 22, 47, 53, 904, DateTimeKind.Local).AddTicks(6398), false, "VJRDI94", "Ansley Stoltenberg", "EUKTBXD94", "K94", 800.65m },
                    { 88, new DateTime(2021, 4, 20, 22, 7, 6, 39, DateTimeKind.Local).AddTicks(7203), true, "PIXNF107", "Leo Corkery", "EAXKIRI107", "H107", 469.58m },
                    { 86, new DateTime(2021, 8, 30, 11, 56, 19, 165, DateTimeKind.Local).AddTicks(2932), true, "GABGV105", "Claude Dare", "PJIOTWS105", "I105", 26.13m },
                    { 85, new DateTime(2021, 10, 11, 18, 25, 30, 207, DateTimeKind.Local).AddTicks(7322), true, "EHSFL104", "Eldora Renner", "XHIKGEM104", "E104", 461.53m },
                    { 51, new DateTime(2021, 4, 3, 7, 13, 35, 939, DateTimeKind.Local).AddTicks(2816), false, "ZOLHC70", "Leta Jones", "RAILNXN70", "I70", 969.89m },
                    { 83, new DateTime(2021, 2, 19, 0, 13, 50, 468, DateTimeKind.Local).AddTicks(8177), false, "SOLMI102", "Jeremy Murphy", "VXCBIUV102", "D102", 433.64m },
                    { 82, new DateTime(2021, 1, 24, 12, 1, 3, 266, DateTimeKind.Local).AddTicks(8503), false, "XBFRD101", "Garrison Cummings", "PFRPBFR101", "K101", 36.20m },
                    { 81, new DateTime(2020, 11, 18, 2, 3, 46, 340, DateTimeKind.Local).AddTicks(2242), false, "NPQBW100", "Ashtyn Spinka", "PPIDEDY100", "L100", 703.52m },
                    { 80, new DateTime(2021, 8, 17, 7, 57, 22, 736, DateTimeKind.Local).AddTicks(1375), true, "MQOTN99", "Brannon Spinka", "TYODRTE99", "H99", 502.17m },
                    { 79, new DateTime(2021, 6, 14, 14, 34, 51, 121, DateTimeKind.Local).AddTicks(727), false, "WWNKY98", "Adelbert Rowe", "SOJXIAC98", "H98", 992.14m },
                    { 78, new DateTime(2021, 8, 1, 18, 27, 51, 912, DateTimeKind.Local).AddTicks(5637), false, "DOPPU97", "Monserrat Christiansen", "CHADBPI97", "E97", 125.37m },
                    { 77, new DateTime(2020, 12, 16, 13, 38, 53, 335, DateTimeKind.Local).AddTicks(5793), true, "HCTSD96", "Marques Grady", "AAOHAZM96", "E96", 877.57m },
                    { 87, new DateTime(2021, 10, 5, 7, 26, 44, 807, DateTimeKind.Local).AddTicks(6860), true, "QEGJG106", "Grant Frami", "QVNNNNW106", "B106", 613.16m },
                    { 50, new DateTime(2021, 10, 8, 3, 28, 32, 464, DateTimeKind.Local).AddTicks(2255), false, "CJIBD69", "Jess Marks", "JBWNSTC69", "D69", 670.81m },
                    { 40, new DateTime(2021, 10, 21, 11, 51, 34, 587, DateTimeKind.Local).AddTicks(6288), true, "DFJAV59", "Donnell Runte", "LOHDLHN59", "L59", 633.71m },
                    { 48, new DateTime(2021, 8, 20, 4, 36, 6, 37, DateTimeKind.Local).AddTicks(4732), true, "HPKLP67", "Zaria Heathcote", "KQFNFRU67", "A67", 794.35m },
                    { 21, new DateTime(2021, 4, 14, 18, 4, 47, 806, DateTimeKind.Local).AddTicks(506), false, "YXYFI40", "Anita Wolf", "QWNZEZV40", "B40", 219.60m },
                    { 20, new DateTime(2021, 3, 10, 5, 55, 2, 0, DateTimeKind.Local).AddTicks(6964), true, "MOPUF39", "Gavin Volkman", "WXYTVGX39", "K39", 770.14m },
                    { 19, new DateTime(2021, 8, 2, 11, 16, 2, 1, DateTimeKind.Local).AddTicks(6574), true, "VVCCA38", "Mike Rice", "AABUMJT38", "F38", 535.52m },
                    { 18, new DateTime(2021, 1, 24, 12, 6, 54, 824, DateTimeKind.Local).AddTicks(1136), true, "LULEG37", "Minnie Wyman", "LPXNZKV37", "B37", 428.49m },
                    { 17, new DateTime(2021, 4, 13, 14, 29, 5, 256, DateTimeKind.Local).AddTicks(2194), false, "PUBVA36", "Armando Ratke", "PXCMWWH36", "I36", 438.84m },
                    { 16, new DateTime(2020, 12, 27, 23, 54, 7, 984, DateTimeKind.Local).AddTicks(3958), false, "ZDUMU35", "Daisha Franecki", "WVCOXWT35", "B35", 309.17m },
                    { 15, new DateTime(2020, 12, 13, 8, 34, 10, 529, DateTimeKind.Local).AddTicks(2650), true, "TFDKP34", "Xzavier Barton", "KMXGNPM34", "B34", 950.40m },
                    { 14, new DateTime(2021, 10, 4, 0, 2, 39, 810, DateTimeKind.Local).AddTicks(7221), false, "BHMOP33", "Keshawn Predovic", "JDQUKZH33", "C33", 270.01m },
                    { 13, new DateTime(2021, 1, 27, 9, 38, 27, 820, DateTimeKind.Local).AddTicks(6852), true, "BBKMO32", "Tyree Considine", "GSOXCRW32", "I32", 208.69m },
                    { 12, new DateTime(2021, 10, 18, 18, 42, 1, 138, DateTimeKind.Local).AddTicks(1316), false, "DBIFP31", "Eloise Orn", "FZILQJV31", "J31", 178.57m },
                    { 11, new DateTime(2020, 11, 23, 18, 7, 55, 470, DateTimeKind.Local).AddTicks(7292), true, "RDVYM30", "Shirley Hills", "UUAIWPH30", "J30", 762.19m },
                    { 10, new DateTime(2021, 9, 11, 8, 49, 57, 837, DateTimeKind.Local).AddTicks(3158), true, "QOHMR29", "Pascale Kihn", "RPXQAYI29", "J29", 771.59m },
                    { 9, new DateTime(2021, 2, 7, 4, 30, 44, 525, DateTimeKind.Local).AddTicks(5823), false, "AAWDG28", "Hassan Gutmann", "JCZZIRI28", "L28", 296.26m },
                    { 8, new DateTime(2021, 5, 10, 7, 35, 59, 828, DateTimeKind.Local).AddTicks(8109), true, "UBUJM27", "Korbin Batz", "RJMNWZV27", "C27", 484.53m },
                    { 7, new DateTime(2021, 7, 25, 10, 17, 15, 823, DateTimeKind.Local).AddTicks(5865), true, "ZQYYD26", "Harvey Bashirian", "YQDJCWZ26", "J26", 10.62m },
                    { 6, new DateTime(2021, 4, 5, 9, 49, 56, 986, DateTimeKind.Local).AddTicks(5899), true, "KSHZO25", "Abby Schmidt", "OCKVNLR25", "D25", 33.60m },
                    { 5, new DateTime(2021, 10, 21, 17, 39, 46, 779, DateTimeKind.Local).AddTicks(5313), false, "NKEWM24", "Rhett Mann", "OLNANSD24", "B24", 283.22m },
                    { 4, new DateTime(2021, 8, 4, 0, 50, 4, 194, DateTimeKind.Local).AddTicks(8654), false, "BZEVT23", "Marcelle Lemke", "PRJBJDZ23", "G23", 148.00m },
                    { 3, new DateTime(2020, 12, 30, 17, 5, 30, 647, DateTimeKind.Local).AddTicks(406), true, "VAQOH22", "Otto Heaney", "LKHVYJX22", "D22", 339.38m },
                    { 2, new DateTime(2021, 7, 5, 0, 45, 42, 993, DateTimeKind.Local).AddTicks(7087), true, "LZZHL21", "Tremayne Littel", "EERMAAP21", "H21", 257.68m },
                    { 1, new DateTime(2021, 2, 16, 16, 55, 28, 782, DateTimeKind.Local).AddTicks(8804), true, "LUJPL20", "Karina Bruen", "LUUFVDY20", "H20", 265.71m },
                    { 22, new DateTime(2021, 9, 12, 1, 7, 58, 111, DateTimeKind.Local).AddTicks(7106), true, "ZOVVE41", "Chelsie Okuneva", "FSNTFLB41", "G41", 273.02m },
                    { 23, new DateTime(2021, 7, 4, 10, 58, 47, 325, DateTimeKind.Local).AddTicks(8003), false, "MXCCX42", "Vito Baumbach", "AJUVBDO42", "C42", 749.67m },
                    { 24, new DateTime(2021, 5, 9, 6, 6, 1, 487, DateTimeKind.Local).AddTicks(5437), false, "CVSPM43", "Toni Johnson", "EYFTQRR43", "C43", 226.46m },
                    { 25, new DateTime(2021, 1, 23, 6, 26, 32, 321, DateTimeKind.Local).AddTicks(2128), false, "MJUAP44", "Lizeth Rutherford", "OFCGWVP44", "D44", 719.51m },
                    { 47, new DateTime(2021, 10, 22, 22, 12, 37, 433, DateTimeKind.Local).AddTicks(9083), true, "BCDLU66", "Monroe Senger", "DPJIORN66", "J66", 57.18m },
                    { 46, new DateTime(2021, 5, 29, 21, 57, 18, 246, DateTimeKind.Local).AddTicks(6421), true, "CBOHE65", "Katherine Gorczany", "UUGUFCU65", "A65", 902.78m },
                    { 45, new DateTime(2020, 11, 28, 12, 40, 2, 534, DateTimeKind.Local).AddTicks(5000), false, "EFNJK64", "Dee O'Keefe", "DRRYIXI64", "E64", 856.94m },
                    { 44, new DateTime(2021, 1, 8, 16, 55, 36, 141, DateTimeKind.Local).AddTicks(9641), true, "ZZBOQ63", "Lauren Bradtke", "JOVZIPT63", "D63", 929.67m },
                    { 43, new DateTime(2020, 12, 20, 9, 11, 7, 4, DateTimeKind.Local).AddTicks(3001), false, "CTYKP62", "Brenna Brown", "EURKQXU62", "L62", 44.83m },
                    { 42, new DateTime(2020, 11, 16, 5, 59, 32, 901, DateTimeKind.Local).AddTicks(3182), false, "SGJGB61", "Ara Batz", "BDGVSRW61", "K61", 235.21m },
                    { 41, new DateTime(2021, 8, 24, 16, 25, 43, 491, DateTimeKind.Local).AddTicks(145), false, "UPBJY60", "Lisa Paucek", "PZKEJYO60", "E60", 932.10m },
                    { 99, new DateTime(2021, 6, 22, 6, 27, 35, 106, DateTimeKind.Local).AddTicks(5049), false, "EHFZT118", "Lelia VonRueden", "DJACTFD118", "K118", 782.85m },
                    { 39, new DateTime(2021, 5, 3, 20, 14, 3, 10, DateTimeKind.Local).AddTicks(1755), false, "SXKDW58", "Eda Hills", "GVUPJOE58", "F58", 209.83m },
                    { 38, new DateTime(2020, 11, 9, 15, 1, 57, 593, DateTimeKind.Local).AddTicks(7239), true, "OVCNK57", "Esteban Leffler", "SJNMEVK57", "L57", 221.29m },
                    { 49, new DateTime(2021, 2, 7, 22, 5, 36, 767, DateTimeKind.Local).AddTicks(5304), false, "FBREW68", "Francesco Gislason", "MLQGTCI68", "K68", 131.28m },
                    { 37, new DateTime(2021, 2, 2, 7, 55, 31, 247, DateTimeKind.Local).AddTicks(460), false, "AFIQG56", "Cindy Zboncak", "BKNMSYM56", "D56", 370.95m },
                    { 35, new DateTime(2021, 5, 11, 15, 10, 24, 185, DateTimeKind.Local).AddTicks(7416), false, "GROTQ54", "Jayne Kessler", "DXLOIZA54", "L54", 155.90m },
                    { 34, new DateTime(2020, 11, 18, 10, 36, 48, 941, DateTimeKind.Local).AddTicks(8641), true, "CDVQA53", "Rowan Fahey", "IWRJZHA53", "J53", 624.62m },
                    { 33, new DateTime(2021, 4, 30, 0, 40, 2, 112, DateTimeKind.Local).AddTicks(9800), false, "ENQGU52", "Caroline Strosin", "VZDSMMJ52", "I52", 210.02m },
                    { 32, new DateTime(2021, 10, 21, 3, 1, 8, 445, DateTimeKind.Local).AddTicks(8657), false, "OVSMJ51", "Brannon Paucek", "KLOYMDM51", "J51", 245.19m },
                    { 31, new DateTime(2021, 2, 4, 23, 36, 22, 440, DateTimeKind.Local).AddTicks(2369), true, "ORGGD50", "Lucienne Kemmer", "EHELWFT50", "F50", 344.82m },
                    { 30, new DateTime(2021, 6, 15, 13, 32, 28, 391, DateTimeKind.Local).AddTicks(4274), true, "CWPYU49", "Marlon Krajcik", "YURQXSN49", "C49", 334.61m },
                    { 29, new DateTime(2020, 12, 28, 10, 53, 17, 90, DateTimeKind.Local).AddTicks(5040), true, "KYVWW48", "Sadie Dare", "MCUHVNL48", "C48", 43.36m },
                    { 28, new DateTime(2021, 3, 21, 6, 15, 45, 987, DateTimeKind.Local).AddTicks(6404), false, "JHAHK47", "Jalen Barrows", "MPCOHDS47", "J47", 61.23m },
                    { 27, new DateTime(2021, 1, 8, 3, 33, 56, 519, DateTimeKind.Local).AddTicks(6417), true, "YZRHL46", "Elliott Emard", "UBCPHZR46", "K46", 188.99m },
                    { 26, new DateTime(2021, 1, 7, 14, 34, 36, 829, DateTimeKind.Local).AddTicks(3249), false, "ZYAXJ45", "Amber Gaylord", "YGLSVMZ45", "C45", 125.19m },
                    { 36, new DateTime(2021, 1, 25, 20, 50, 48, 232, DateTimeKind.Local).AddTicks(3097), true, "YNSEN55", "Shaylee Bauch", "IIIWBLR55", "B55", 917.39m },
                    { 100, new DateTime(2021, 8, 21, 13, 50, 22, 711, DateTimeKind.Local).AddTicks(8780), true, "CVJIT119", "Kelley Parisian", "FMORXOH119", "E119", 323.89m }
                });

            migrationBuilder.InsertData(
                table: "FlightTicket",
                columns: new[] { "Id", "FlightId", "TicketId" },
                values: new object[,]
                {
                    { 1, 16, 1 },
                    { 73, 11, 73 },
                    { 72, 16, 72 },
                    { 71, 13, 71 },
                    { 70, 18, 70 },
                    { 69, 8, 69 },
                    { 68, 14, 68 },
                    { 67, 9, 67 },
                    { 66, 14, 66 },
                    { 65, 17, 65 },
                    { 64, 3, 64 },
                    { 63, 2, 63 },
                    { 62, 6, 62 },
                    { 61, 2, 61 },
                    { 60, 19, 60 },
                    { 59, 2, 59 },
                    { 58, 14, 58 },
                    { 57, 12, 57 },
                    { 56, 18, 56 },
                    { 55, 17, 55 },
                    { 54, 3, 54 },
                    { 53, 7, 53 },
                    { 74, 15, 74 },
                    { 52, 15, 52 },
                    { 75, 9, 75 },
                    { 77, 10, 77 },
                    { 98, 5, 98 },
                    { 97, 10, 97 },
                    { 96, 6, 96 },
                    { 95, 3, 95 },
                    { 94, 7, 94 },
                    { 93, 9, 93 },
                    { 92, 15, 92 },
                    { 91, 7, 91 },
                    { 90, 9, 90 },
                    { 89, 19, 89 },
                    { 88, 4, 88 },
                    { 87, 18, 87 },
                    { 86, 5, 86 },
                    { 85, 10, 85 },
                    { 84, 3, 84 },
                    { 83, 7, 83 },
                    { 82, 6, 82 },
                    { 81, 11, 81 },
                    { 80, 4, 80 },
                    { 79, 14, 79 },
                    { 78, 8, 78 },
                    { 76, 16, 76 },
                    { 51, 14, 51 },
                    { 50, 14, 50 },
                    { 49, 8, 49 },
                    { 22, 17, 22 },
                    { 21, 7, 21 },
                    { 20, 1, 20 },
                    { 19, 19, 19 },
                    { 18, 18, 18 },
                    { 17, 6, 17 },
                    { 16, 3, 16 },
                    { 15, 16, 15 },
                    { 14, 15, 14 },
                    { 13, 10, 13 },
                    { 12, 15, 12 },
                    { 11, 19, 11 },
                    { 10, 16, 10 },
                    { 9, 6, 9 },
                    { 8, 17, 8 },
                    { 7, 1, 7 },
                    { 6, 5, 6 },
                    { 5, 14, 5 },
                    { 4, 14, 4 },
                    { 3, 1, 3 },
                    { 2, 19, 2 },
                    { 23, 7, 23 },
                    { 24, 6, 24 },
                    { 25, 13, 25 },
                    { 26, 15, 26 },
                    { 48, 18, 48 },
                    { 47, 4, 47 },
                    { 46, 10, 46 },
                    { 45, 12, 45 },
                    { 44, 19, 44 },
                    { 43, 7, 43 },
                    { 42, 11, 42 },
                    { 41, 12, 41 },
                    { 40, 4, 40 },
                    { 39, 7, 39 },
                    { 99, 3, 99 },
                    { 38, 10, 38 },
                    { 36, 18, 36 },
                    { 35, 7, 35 },
                    { 34, 16, 34 },
                    { 33, 6, 33 },
                    { 32, 6, 32 },
                    { 31, 19, 31 },
                    { 30, 4, 30 },
                    { 29, 16, 29 },
                    { 28, 14, 28 },
                    { 27, 4, 27 },
                    { 37, 9, 37 },
                    { 100, 17, 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightTicket_FlightId",
                table: "FlightTicket",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightTicket_TicketId",
                table: "FlightTicket",
                column: "TicketId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightTicket");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Ticket");
        }
    }
}
