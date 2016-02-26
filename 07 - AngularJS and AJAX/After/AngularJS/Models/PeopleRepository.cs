using System;
using System.Collections.Generic;
using System.Linq;

namespace AngularJS.Models
{
    public class PeopleRepository : IPeopleRepository
    {
        private static readonly List<Person> People;

        static PeopleRepository()
        {
            People = new List<Person>
                {   new Person{
                            Id= 0,
                            FirstName= "Enid",
                            LastName= "Howell",
                            Gender= "female",
                            Company= "Cipromox",
                            Email= "enidhowell@cipromox.com",
                            Address= "Neptune Avenue 71",
                            City= "Warsaw",
                            Country= "Honduras"
                        }, new Person{
                            Id= 1,
                            FirstName= "Claudine",
                            LastName= "Tate",
                            Gender= "female",
                            Company= "Buzzmaker",
                            Email= "claudinetate@buzzmaker.com",
                            Address= "Tampa Court 59",
                            City= "Volta",
                            Country= "Luxembourg"
                        }, new Person{
                            Id= 2,
                            FirstName= "Alba",
                            LastName= "West",
                            Gender= "female",
                            Company= "Geoform",
                            Email= "albawest@geoform.com",
                            Address= "Schaefer Street 60",
                            City= "Takilma",
                            Country= "Jamaica"
                        }, new Person{
                            Id= 3,
                            FirstName= "Craig",
                            LastName= "Nieves",
                            Gender= "male",
                            Company= "Flexigen",
                            Email= "craignieves@flexigen.com",
                            Address= "Kimball Street 63",
                            City= "Rosedale",
                            Country= "Pakistan"
                        }, new Person{
                            Id= 4,
                            FirstName= "Obrien",
                            LastName= "Turner",
                            Gender= "male",
                            Company= "Bleendot",
                            Email= "obrienturner@bleendot.com",
                            Address= "Belvidere Street 16",
                            City= "Cannondale",
                            Country= "Madagascar"
                        }, new Person{
                            Id= 5,
                            FirstName= "Terri",
                            LastName= "Henson",
                            Gender= "female",
                            Company= "Qualitex",
                            Email= "terrihenson@qualitex.com",
                            Address= "Osborn Street 74",
                            City= "Northchase",
                            Country= "China"
                        }, new Person{
                            Id= 6,
                            FirstName= "Freda",
                            LastName= "Reynolds",
                            Gender= "female",
                            Company= "Neocent",
                            Email= "fredareynolds@neocent.com",
                            Address= "Visitation Place 57",
                            City= "Lewis",
                            Country= "Togo"
                        }, new Person{
                            Id= 7,
                            FirstName= "Consuelo",
                            LastName= "Farrell",
                            Gender= "female",
                            Company= "Senmao",
                            Email= "consuelofarrell@senmao.com",
                            Address= "Perry Place 26",
                            City= "Johnsonburg",
                            Country= "Moldova"
                        }, new Person{
                            Id= 8,
                            FirstName= "Virginia",
                            LastName= "Emerson",
                            Gender= "female",
                            Company= "Portica",
                            Email= "virginiaemerson@portica.com",
                            Address= "Utica Avenue 43",
                            City= "Fresno",
                            Country= "Belgium"
                        }, new Person{
                            Id= 9,
                            FirstName= "Dillard",
                            LastName= "Walter",
                            Gender= "male",
                            Company= "Furnigeer",
                            Email= "dillardwalter@furnigeer.com",
                            Address= "Harman Street 42",
                            City= "Islandia",
                            Country= "Andorra"
                        }, new Person{
                            Id= 10,
                            FirstName= "Ladonna",
                            LastName= "Pace",
                            Gender= "female",
                            Company= "Cincyr",
                            Email= "ladonnapace@cincyr.com",
                            Address= "Chestnut Street 17",
                            City= "Wauhillau",
                            Country= "Guinea Bissau"
                        }, new Person{
                            Id= 11,
                            FirstName= "Odom",
                            LastName= "Gilmore",
                            Gender= "male",
                            Company= "Cedward",
                            Email= "odomgilmore@cedward.com",
                            Address= "Noll Street 86",
                            City= "Wheatfields",
                            Country= "Netherlands"
                        }, new Person{
                            Id= 12,
                            FirstName= "Williamson",
                            LastName= "Francis",
                            Gender= "male",
                            Company= "Pasturia",
                            Email= "williamsonfrancis@pasturia.com",
                            Address= "Dewitt Avenue 44",
                            City= "Orovada",
                            Country= "Nigeria"
                        }, new Person{
                            Id= 13,
                            FirstName= "Reva",
                            LastName= "Hoffman",
                            Gender= "female",
                            Company= "Exosis",
                            Email= "revahoffman@exosis.com",
                            Address= "Kosciusko Street 77",
                            City= "Weeksville",
                            Country= "Switzerland"
                        }, new Person{
                            Id= 14,
                            FirstName= "Middleton",
                            LastName= "Shields",
                            Gender= "male",
                            Company= "Biflex",
                            Email= "middletonshields@biflex.com",
                            Address= "Commercial Street 57",
                            City= "Kapowsin",
                            Country= "Hungary"
                        }, new Person{
                            Id= 15,
                            FirstName= "Chasity",
                            LastName= "Tyson",
                            Gender= "female",
                            Company= "Skybold",
                            Email= "chasitytyson@skybold.com",
                            Address= "Calder Place 79",
                            City= "Yukon",
                            Country= "Lithuania"
                        }, new Person{
                            Id= 16,
                            FirstName= "Nellie",
                            LastName= "Long",
                            Gender= "female",
                            Company= "Euron",
                            Email= "nellielong@euron.com",
                            Address= "Degraw Street 30",
                            City= "Greenbush",
                            Country= "United Arab Emirates"
                        }, new Person{
                            Id= 17,
                            FirstName= "Peters",
                            LastName= "Carter",
                            Gender= "male",
                            Company= "Shopabout",
                            Email= "peterscarter@shopabout.com",
                            Address= "Vanderveer Street 32",
                            City= "Grayhawk",
                            Country= "Tanzania"
                        }, new Person{
                            Id= 18,
                            FirstName= "Daphne",
                            LastName= "Chase",
                            Gender= "female",
                            Company= "Musaphics",
                            Email= "daphnechase@musaphics.com",
                            Address= "Greene Avenue 8",
                            City= "Clarence",
                            Country= "Burkina Faso"
                        }, new Person{
                            Id= 19,
                            FirstName= "Herman",
                            LastName= "Cantu",
                            Gender= "male",
                            Company= "Paragonia",
                            Email= "hermancantu@paragonia.com",
                            Address= "George Street 78",
                            City= "Frierson",
                            Country= "Puerto Rico"
                        }, new Person{
                            Id= 20,
                            FirstName= "Tessa",
                            LastName= "Wilkinson",
                            Gender= "female",
                            Company= "Homelux",
                            Email= "tessawilkinson@homelux.com",
                            Address= "Gerald Court 5",
                            City= "Ticonderoga",
                            Country= "Latvia"
                        }, new Person{
                            Id= 21,
                            FirstName= "Snyder",
                            LastName= "Newman",
                            Gender= "male",
                            Company= "Tripsch",
                            Email= "snydernewman@tripsch.com",
                            Address= "Falmouth Street 97",
                            City= "Jeff",
                            Country= "Jersey"
                        }, new Person{
                            Id= 22,
                            FirstName= "Calhoun",
                            LastName= "Hull",
                            Gender= "male",
                            Company= "Permadyne",
                            Email= "calhounhull@permadyne.com",
                            Address= "Carroll Street 89",
                            City= "Nanafalia",
                            Country= "Fiji"
                        }, new Person{
                            Id= 23,
                            FirstName= "Byrd",
                            LastName= "Mcdowell",
                            Gender= "male",
                            Company= "Omatom",
                            Email= "byrdmcdowell@omatom.com",
                            Address= "Dinsmore Place 22",
                            City= "Lacomb",
                            Country= "Mali"
                        }, new Person{
                            Id= 24,
                            FirstName= "Jeannie",
                            LastName= "Hinton",
                            Gender= "female",
                            Company= "Medmex",
                            Email= "jeanniehinton@medmex.com",
                            Address= "Powell Street 7",
                            City= "Neibert",
                            Country= "Bosnia &amp; Herzegovina"
                        }, new Person{
                            Id= 25,
                            FirstName= "Lenore",
                            LastName= "Justice",
                            Gender= "female",
                            Company= "Fishland",
                            Email= "lenorejustice@fishland.com",
                            Address= "President Street 48",
                            City= "Faywood",
                            Country= "Iran"
                        }, new Person{
                            Id= 26,
                            FirstName= "Leola",
                            LastName= "Burton",
                            Gender= "female",
                            Company= "Comveyor",
                            Email= "leolaburton@comveyor.com",
                            Address= "Decatur Street 75",
                            City= "Fillmore",
                            Country= "Armenia"
                        }, new Person{
                            Id= 27,
                            FirstName= "Nita",
                            LastName= "Hartman",
                            Gender= "female",
                            Company= "Ecratic",
                            Email= "nitahartman@ecratic.com",
                            Address= "Ludlam Place 85",
                            City= "Bowden",
                            Country= "French Polynesia"
                        }, new Person{
                            Id= 28,
                            FirstName= "Karina",
                            LastName= "Stokes",
                            Gender= "female",
                            Company= "Earwax",
                            Email= "karinastokes@earwax.com",
                            Address= "Lewis Avenue 7",
                            City= "Katonah",
                            Country= "Uganda"
                        }, new Person{
                            Id= 29,
                            FirstName= "Joy",
                            LastName= "Waters",
                            Gender= "female",
                            Company= "Terascape",
                            Email= "joywaters@terascape.com",
                            Address= "Turnbull Avenue 79",
                            City= "Crucible",
                            Country= "Nepal"
                        }, new Person{
                            Id= 30,
                            FirstName= "Savage",
                            LastName= "Simmons",
                            Gender= "male",
                            Company= "Zolar",
                            Email= "savagesimmons@zolar.com",
                            Address= "Quentin Road 51",
                            City= "Fairacres",
                            Country= "St Vincent"
                        }, new Person{
                            Id= 31,
                            FirstName= "Deirdre",
                            LastName= "Bauer",
                            Gender= "female",
                            Company= "Katakana",
                            Email= "deirdrebauer@katakana.com",
                            Address= "Milton Street 33",
                            City= "Collins",
                            Country= "Liechtenstein"
                        }, new Person{
                            Id= 32,
                            FirstName= "Kasey",
                            LastName= "Gould",
                            Gender= "female",
                            Company= "Sensate",
                            Email= "kaseygould@sensate.com",
                            Address= "Suydam Place 21",
                            City= "Sugartown",
                            Country= "Chad"
                        }, new Person{
                            Id= 33,
                            FirstName= "Peggy",
                            LastName= "Dillon",
                            Gender= "female",
                            Company= "Equitox",
                            Email= "peggydillon@equitox.com",
                            Address= "Randolph Street 5",
                            City= "Fowlerville",
                            Country= "El Salvador"
                        }, new Person{
                            Id= 34,
                            FirstName= "Paige",
                            LastName= "Cummings",
                            Gender= "female",
                            Company= "Futuris",
                            Email= "paigecummings@futuris.com",
                            Address= "Boerum Street 4",
                            City= "Lowgap",
                            Country= "Turkey"
                        }, new Person{
                            Id= 35,
                            FirstName= "Clare",
                            LastName= "Dennis",
                            Gender= "female",
                            Company= "Interodeo",
                            Email= "claredennis@interodeo.com",
                            Address= "Underhill Avenue 46",
                            City= "Bowmansville",
                            Country= "Qatar"
                        }, new Person{
                            Id= 36,
                            FirstName= "Mcneil",
                            LastName= "Koch",
                            Gender= "male",
                            Company= "Buzzopia",
                            Email= "mcneilkoch@buzzopia.com",
                            Address= "Vanderbilt Avenue 62",
                            City= "Bordelonville",
                            Country= "Turks &amp; Caicos"
                        }, new Person{
                            Id= 37,
                            FirstName= "Vinson",
                            LastName= "Miranda",
                            Gender= "male",
                            Company= "Accufarm",
                            Email= "vinsonmiranda@accufarm.com",
                            Address= "Barbey Street 21",
                            City= "Gwynn",
                            Country= "Cruise Ship"
                        }, new Person{
                            Id= 38,
                            FirstName= "Nona",
                            LastName= "Myers",
                            Gender= "female",
                            Company= "Assistia",
                            Email= "nonamyers@assistia.com",
                            Address= "Neptune Court 48",
                            City= "Barrelville",
                            Country= "Macau"
                        }, new Person{
                            Id= 39,
                            FirstName= "Tasha",
                            LastName= "Hopkins",
                            Gender= "female",
                            Company= "Printspan",
                            Email= "tashahopkins@printspan.com",
                            Address= "Willoughby Street 36",
                            City= "Dixonville",
                            Country= "Sierra Leone"
                        }, new Person{
                            Id= 40,
                            FirstName= "Shelley",
                            LastName= "Flowers",
                            Gender= "female",
                            Company= "Makingway",
                            Email= "shelleyflowers@makingway.com",
                            Address= "Oriental Court 37",
                            City= "Belfair",
                            Country= "Colombia"
                        }, new Person{
                            Id= 41,
                            FirstName= "Compton",
                            LastName= "Luna",
                            Gender= "male",
                            Company= "Marqet",
                            Email= "comptonluna@marqet.com",
                            Address= "Miller Avenue 70",
                            City= "Hailesboro",
                            Country= "Bahrain"
                        }, new Person{
                            Id= 42,
                            FirstName= "Sanford",
                            LastName= "Molina",
                            Gender= "male",
                            Company= "Konnect",
                            Email= "sanfordmolina@konnect.com",
                            Address= "Oliver Street 1",
                            City= "Englevale",
                            Country= "Burundi"
                        }, new Person{
                            Id= 43,
                            FirstName= "Lynette",
                            LastName= "Freeman",
                            Gender= "female",
                            Company= "Duflex",
                            Email= "lynettefreeman@duflex.com",
                            Address= "Cumberland Street 93",
                            City= "Aberdeen",
                            Country= "Virgin Islands (US)"
                        }, new Person{
                            Id= 44,
                            FirstName= "Holcomb",
                            LastName= "Rasmussen",
                            Gender= "male",
                            Company= "Yogasm",
                            Email= "holcombrasmussen@yogasm.com",
                            Address= "Exeter Street 18",
                            City= "Bodega",
                            Country= "Rwanda"
                        }, new Person{
                            Id= 45,
                            FirstName= "Marissa",
                            LastName= "Green",
                            Gender= "female",
                            Company= "Comcubine",
                            Email= "marissagreen@comcubine.com",
                            Address= "Richards Street 100",
                            City= "Wescosville",
                            Country= "Bahamas"
                        }, new Person{
                            Id= 46,
                            FirstName= "Flores",
                            LastName= "Albert",
                            Gender= "male",
                            Company= "Fanfare",
                            Email= "floresalbert@fanfare.com",
                            Address= "Moore Street 48",
                            City= "Nile",
                            Country= "Bolivia"
                        }, new Person{
                            Id= 47,
                            FirstName= "Monique",
                            LastName= "Cabrera",
                            Gender= "female",
                            Company= "Atomica",
                            Email= "moniquecabrera@atomica.com",
                            Address= "Colin Place 53",
                            City= "Bowie",
                            Country= "Maldives"
                        }, new Person{
                            Id= 48,
                            FirstName= "Tisha",
                            LastName= "Parker",
                            Gender= "female",
                            Company= "Geekular",
                            Email= "tishaparker@geekular.com",
                            Address= "Vermont Court 77",
                            City= "Drytown",
                            Country= "Panama"
                        }, new Person{
                            Id= 49,
                            FirstName= "Ingrid",
                            LastName= "Lowe",
                            Gender= "female",
                            Company= "Lexicondo",
                            Email= "ingridlowe@lexicondo.com",
                            Address= "Cook Street 80",
                            City= "Jackpot",
                            Country= "Belize"
                        }, new Person{
                            Id= 50,
                            FirstName= "Wiggins",
                            LastName= "Franklin",
                            Gender= "male",
                            Company= "Assitia",
                            Email= "wigginsfranklin@assitia.com",
                            Address= "Elmwood Avenue 92",
                            City= "Blue",
                            Country= "France"
                        }, new Person{
                            Id= 51,
                            FirstName= "Hurley",
                            LastName= "Goff",
                            Gender= "male",
                            Company= "Combogene",
                            Email= "hurleygoff@combogene.com",
                            Address= "Kensington Walk 40",
                            City= "Cataract",
                            Country= "Tunisia"
                        }, new Person{
                            Id= 52,
                            FirstName= "Mcdonald",
                            LastName= "Carey",
                            Gender= "male",
                            Company= "Luxuria",
                            Email= "mcdonaldcarey@luxuria.com",
                            Address= "Shale Street 38",
                            City= "Helen",
                            Country= "Hong Kong"
                        }, new Person{
                            Id= 53,
                            FirstName= "Blanca",
                            LastName= "Holder",
                            Gender= "female",
                            Company= "Fleetmix",
                            Email= "blancaholder@fleetmix.com",
                            Address= "India Street 48",
                            City= "Leming",
                            Country= "Saint Pierre &amp; Miquelon"
                        }, new Person{
                            Id= 54,
                            FirstName= "Beatriz",
                            LastName= "Terry",
                            Gender= "female",
                            Company= "Entogrok",
                            Email= "beatrizterry@entogrok.com",
                            Address= "Amity Street 61",
                            City= "Rivers",
                            Country= "New Zealand"
                        }, new Person{
                            Id= 55,
                            FirstName= "Tillman",
                            LastName= "Taylor",
                            Gender= "male",
                            Company= "Mangelica",
                            Email= "tillmantaylor@mangelica.com",
                            Address= "Stratford Road 87",
                            City= "Newcastle",
                            Country= "Suriname"
                        }, new Person{
                            Id= 56,
                            FirstName= "Tanya",
                            LastName= "Bird",
                            Gender= "female",
                            Company= "Edecine",
                            Email= "tanyabird@edecine.com",
                            Address= "Dekalb Avenue 100",
                            City= "Noxen",
                            Country= "India"
                        }, new Person{
                            Id= 57,
                            FirstName= "Clarissa",
                            LastName= "Richards",
                            Gender= "female",
                            Company= "Ronbert",
                            Email= "clarissarichards@ronbert.com",
                            Address= "Malta Street 16",
                            City= "Topaz",
                            Country= "Algeria"
                        }, new Person{
                            Id= 58,
                            FirstName= "Wallace",
                            LastName= "Stevens",
                            Gender= "male",
                            Company= "Zanymax",
                            Email= "wallacestevens@zanymax.com",
                            Address= "Hendrickson Place 87",
                            City= "Kylertown",
                            Country= "Niger"
                        }, new Person{
                            Id= 59,
                            FirstName= "Amelia",
                            LastName= "Watts",
                            Gender= "female",
                            Company= "Pyramia",
                            Email= "ameliawatts@pyramia.com",
                            Address= "Sumpter Street 5",
                            City= "Valle",
                            Country= "Uzbekistan"
                        }, new Person{
                            Id= 60,
                            FirstName= "Marjorie",
                            LastName= "Burke",
                            Gender= "female",
                            Company= "Zensor",
                            Email= "marjorieburke@zensor.com",
                            Address= "Cooper Street 74",
                            City= "Hayes",
                            Country= "Singapore"
                        }, new Person{
                            Id= 61,
                            FirstName= "Johanna",
                            LastName= "Carrillo",
                            Gender= "female",
                            Company= "Grupoli",
                            Email= "johannacarrillo@grupoli.com",
                            Address= "Bayview Place 6",
                            City= "Fairfield",
                            Country= "Iraq"
                        }, new Person{
                            Id= 62,
                            FirstName= "Gentry",
                            LastName= "Welch",
                            Gender= "male",
                            Company= "Sultraxin",
                            Email= "gentrywelch@sultraxin.com",
                            Address= "Crescent Street 9",
                            City= "Strykersville",
                            Country= "Reunion"
                        }, new Person{
                            Id= 63,
                            FirstName= "Reeves",
                            LastName= "Petersen",
                            Gender= "male",
                            Company= "Deepends",
                            Email= "reevespetersen@deepends.com",
                            Address= "Eldert Lane 32",
                            City= "Fairhaven",
                            Country= "Sweden"
                        }, new Person{
                            Id= 64,
                            FirstName= "Hines",
                            LastName= "Boone",
                            Gender= "male",
                            Company= "Kyagoro",
                            Email= "hinesboone@kyagoro.com",
                            Address= "Brooklyn Avenue 42",
                            City= "Marshall",
                            Country= "Belarus"
                        }, new Person{
                            Id= 65,
                            FirstName= "Dickson",
                            LastName= "Dunlap",
                            Gender= "male",
                            Company= "Comstar",
                            Email= "dicksondunlap@comstar.com",
                            Address= "Karweg Place 4",
                            City= "Snowville",
                            Country= "Gibraltar"
                        }, new Person{
                            Id= 66,
                            FirstName= "Lucas",
                            LastName= "Bowen",
                            Gender= "male",
                            Company= "Quarex",
                            Email= "lucasbowen@quarex.com",
                            Address= "Chapel Street 63",
                            City= "Blodgett",
                            Country= "Thailand"
                        }, new Person{
                            Id= 67,
                            FirstName= "Paul",
                            LastName= "Powers",
                            Gender= "male",
                            Company= "Rubadub",
                            Email= "paulpowers@rubadub.com",
                            Address= "Losee Terrace 63",
                            City= "Brewster",
                            Country= "Jordan"
                        }, new Person{
                            Id= 68,
                            FirstName= "Fay",
                            LastName= "Copeland",
                            Gender= "female",
                            Company= "Firewax",
                            Email= "faycopeland@firewax.com",
                            Address= "Mill Street 3",
                            City= "Corriganville",
                            Country= "Faroe Islands"
                        }, new Person{
                            Id= 69,
                            FirstName= "Stout",
                            LastName= "Jacobson",
                            Gender= "male",
                            Company= "Geekology",
                            Email= "stoutjacobson@geekology.com",
                            Address= "Wilson Avenue 61",
                            City= "Tecolotito",
                            Country= "Greece"
                        }, new Person{
                            Id= 70,
                            FirstName= "Diann",
                            LastName= "Garcia",
                            Gender= "female",
                            Company= "Velity",
                            Email= "dianngarcia@velity.com",
                            Address= "Riverdale Avenue 63",
                            City= "Osage",
                            Country= "Kenya"
                        }, new Person{
                            Id= 71,
                            FirstName= "Whitaker",
                            LastName= "Hudson",
                            Gender= "male",
                            Company= "Proflex",
                            Email= "whitakerhudson@proflex.com",
                            Address= "Schweikerts Walk 80",
                            City= "Elbert",
                            Country= "Samoa"
                        }, new Person{
                            Id= 72,
                            FirstName= "Stacie",
                            LastName= "Pollard",
                            Gender= "female",
                            Company= "Quarx",
                            Email= "staciepollard@quarx.com",
                            Address= "Mill Road 26",
                            City= "Edgewater",
                            Country= "Denmark"
                        }, new Person{
                            Id= 73,
                            FirstName= "Gay",
                            LastName= "Malone",
                            Gender= "male",
                            Company= "Zaphire",
                            Email= "gaymalone@zaphire.com",
                            Address= "Frost Street 89",
                            City= "Frizzleburg",
                            Country= "Falkland Islands"
                        }, new Person{
                            Id= 74,
                            FirstName= "Livingston",
                            LastName= "Strong",
                            Gender= "male",
                            Company= "Geekol",
                            Email= "livingstonstrong@geekol.com",
                            Address= "Lorraine Street 30",
                            City= "Abrams",
                            Country= "Yemen"
                        }, new Person{
                            Id= 75,
                            FirstName= "Victoria",
                            LastName= "Small",
                            Gender= "female",
                            Company= "Zolarex",
                            Email= "victoriasmall@zolarex.com",
                            Address= "Schenck Avenue 66",
                            City= "Russellville",
                            Country= "Barbados"
                        }, new Person{
                            Id= 76,
                            FirstName= "Sparks",
                            LastName= "Bennett",
                            Gender= "male",
                            Company= "Marvane",
                            Email= "sparksbennett@marvane.com",
                            Address= "Union Avenue 38",
                            City= "Eggertsville",
                            Country= "Brunei"
                        }, new Person{
                            Id= 77,
                            FirstName= "Lacy",
                            LastName= "Hyde",
                            Gender= "female",
                            Company= "Accruex",
                            Email= "lacyhyde@accruex.com",
                            Address= "Lott Avenue 62",
                            City= "Thatcher",
                            Country= "Bermuda"
                        }, new Person{
                            Id= 78,
                            FirstName= "Casey",
                            LastName= "Moon",
                            Gender= "male",
                            Company= "Xurban",
                            Email= "caseymoon@xurban.com",
                            Address= "Ferris Street 40",
                            City= "Chelsea",
                            Country= "St Kitts &amp; Nevis"
                        }, new Person{
                            Id= 79,
                            FirstName= "Meyers",
                            LastName= "Fuller",
                            Gender= "male",
                            Company= "Nexgene",
                            Email= "meyersfuller@nexgene.com",
                            Address= "Clay Street 60",
                            City= "Coyote",
                            Country= "French West Indies"
                        }, new Person{
                            Id= 80,
                            FirstName= "Underwood",
                            LastName= "Munoz",
                            Gender= "male",
                            Company= "Quordate",
                            Email= "underwoodmunoz@quordate.com",
                            Address= "Oceanview Avenue 97",
                            City= "Zeba",
                            Country= "Australia"
                        }, new Person{
                            Id= 81,
                            FirstName= "Mcfarland",
                            LastName= "Caldwell",
                            Gender= "male",
                            Company= "Glukgluk",
                            Email= "mcfarlandcaldwell@glukgluk.com",
                            Address= "Indiana Place 72",
                            City= "Shasta",
                            Country= "Costa Rica"
                        }, new Person{
                            Id= 82,
                            FirstName= "Mabel",
                            LastName= "Kidd",
                            Gender= "female",
                            Company= "Scenty",
                            Email= "mabelkidd@scenty.com",
                            Address= "Ryder Avenue 8",
                            City= "Soham",
                            Country= "Ghana"
                        }, new Person{
                            Id= 83,
                            FirstName= "Jannie",
                            LastName= "Johnson",
                            Gender= "female",
                            Company= "Steeltab",
                            Email= "janniejohnson@steeltab.com",
                            Address= "Kent Avenue 62",
                            City= "Garberville",
                            Country= "Morocco"
                        }, new Person{
                            Id= 84,
                            FirstName= "Bette",
                            LastName= "Mendoza",
                            Gender= "female",
                            Company= "Golistic",
                            Email= "bettemendoza@golistic.com",
                            Address= "Lloyd Court 77",
                            City= "Cassel",
                            Country= "Nicaragua"
                        }, new Person{
                            Id= 85,
                            FirstName= "Barber",
                            LastName= "Glenn",
                            Gender= "male",
                            Company= "Puria",
                            Email= "barberglenn@puria.com",
                            Address= "National Drive 94",
                            City= "Spelter",
                            Country= "Namibia"
                        }, new Person{
                            Id= 86,
                            FirstName= "Grace",
                            LastName= "Austin",
                            Gender= "female",
                            Company= "Pushcart",
                            Email= "graceaustin@pushcart.com",
                            Address= "Dank Court 14",
                            City= "Detroit",
                            Country= "Mauritania"
                        }, new Person{
                            Id= 87,
                            FirstName= "Leanne",
                            LastName= "Cooper",
                            Gender= "female",
                            Company= "Zerology",
                            Email= "leannecooper@zerology.com",
                            Address= "Wortman Avenue 31",
                            City= "Dupuyer",
                            Country= "Norway"
                        }, new Person{
                            Id= 88,
                            FirstName= "Rodriquez",
                            LastName= "Miller",
                            Gender= "male",
                            Company= "Accel",
                            Email= "rodriquezmiller@accel.com",
                            Address= "Virginia Place 58",
                            City= "Rosewood",
                            Country= "Sudan"
                        }, new Person{
                            Id= 89,
                            FirstName= "Harrison",
                            LastName= "Mccullough",
                            Gender= "male",
                            Company= "Recognia",
                            Email= "harrisonmccullough@recognia.com",
                            Address= "Woodside Avenue 32",
                            City= "Iberia",
                            Country= "Lesotho"
                        }, new Person{
                            Id= 90,
                            FirstName= "Bridges",
                            LastName= "Spears",
                            Gender= "male",
                            Company= "Danja",
                            Email= "bridgesspears@danja.com",
                            Address= "Clermont Avenue 23",
                            City= "Northridge",
                            Country= "Spain"
                        }, new Person{
                            Id= 91,
                            FirstName= "Mary",
                            LastName= "Barron",
                            Gender= "female",
                            Company= "Comtours",
                            Email= "marybarron@comtours.com",
                            Address= "Dare Court 42",
                            City= "Cowiche",
                            Country= "Cyprus"
                        }, new Person{
                            Id= 92,
                            FirstName= "Best",
                            LastName= "Griffith",
                            Gender= "male",
                            Company= "Bitrex",
                            Email= "bestgriffith@bitrex.com",
                            Address= "Central Avenue 97",
                            City= "Ivanhoe",
                            Country= "Laos"
                        }, new Person{
                            Id= 93,
                            FirstName= "Robert",
                            LastName= "Moreno",
                            Gender= "female",
                            Company= "Lotron",
                            Email= "robertmoreno@lotron.com",
                            Address= "Hendrickson Street 58",
                            City= "Richmond",
                            Country= "San Marino"
                        }, new Person{
                            Id= 94,
                            FirstName= "Mack",
                            LastName= "Erickson",
                            Gender= "male",
                            Company= "Nspire",
                            Email= "mackerickson@nspire.com",
                            Address= "Knapp Street 14",
                            City= "Lund",
                            Country= "Zambia"
                        }, new Person{
                            Id= 95,
                            FirstName= "Jenny",
                            LastName= "Randolph",
                            Gender= "female",
                            Company= "Octocore",
                            Email= "jennyrandolph@octocore.com",
                            Address= "Commerce Street 21",
                            City= "Jenkinsville",
                            Country= "Estonia"
                        }, new Person{
                            Id= 96,
                            FirstName= "Franks",
                            LastName= "Jensen",
                            Gender= "male",
                            Company= "Imageflow",
                            Email= "franksjensen@imageflow.com",
                            Address= "Luquer Street 35",
                            City= "Hemlock",
                            Country= "Montenegro"
                        }, new Person{
                            Id= 97,
                            FirstName= "Brandie",
                            LastName= "Chang",
                            Gender= "female",
                            Company= "Evidends",
                            Email= "brandiechang@evidends.com",
                            Address= "Varick Avenue 89",
                            City= "Bawcomville",
                            Country= "Egypt"
                        }, new Person{
                            Id= 98,
                            FirstName= "Blair",
                            LastName= "Chandler",
                            Gender= "male",
                            Company= "Cognicode",
                            Email= "blairchandler@cognicode.com",
                            Address= "Lott Street 30",
                            City= "Bend",
                            Country= "Guyana"
                        }, new Person{
                            Id= 99,
                            FirstName= "Hannah",
                            LastName= "Juarez",
                            Gender= "female",
                            Company= "Callflex",
                            Email= "hannahjuarez@callflex.com",
                            Address= "Meserole Street 41",
                            City= "Rew",
                            Country= "Dominica"
                        }




                };

        }

        public List<Person> Get()
        {
            return People.OrderBy(b => b.Id).ToList();
        }

        public Person Get(int id)
        {
            return People.SingleOrDefault(b => b.Id == id);
        }

        public Person Add(Person newPerson)
        {
            newPerson.Id = Environment.TickCount;
            People.Add(newPerson);

            return newPerson;
        }

        public Person Update(Person newPerson)
        {
            var oldPerson = People.Single(b => b.Id == newPerson.Id);
            People.Remove(oldPerson);
            People.Add(newPerson);
            return newPerson;
        }

        public void Delete(int id)
        {
            var oldPerson = People.SingleOrDefault(b => b.Id == id);
            if (oldPerson != null)
            {
                People.Remove(oldPerson);
            }
        }

        public void Dispose()
        {
        }
    }
}