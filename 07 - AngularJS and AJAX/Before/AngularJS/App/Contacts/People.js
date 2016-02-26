/// <reference path="../../Scripts/angular.js" />

(function (angular) {
    "use strict";

    angular.module("contactsApp.data.people", []).service("peopleLoader", function () {
        var people = [{
            "id": 0,
            "firstName": "Enid",
            "lastName": "Howell",
            "gender": "female",
            "company": "Cipromox",
            "email": "enidhowell@cipromox.com",
            "address": "Neptune Avenue 71",
            "city": "Warsaw",
            "country": "Honduras"
        }, {
            "id": 1,
            "firstName": "Claudine",
            "lastName": "Tate",
            "gender": "female",
            "company": "Buzzmaker",
            "email": "claudinetate@buzzmaker.com",
            "address": "Tampa Court 59",
            "city": "Volta",
            "country": "Luxembourg"
        }, {
            "id": 2,
            "firstName": "Alba",
            "lastName": "West",
            "gender": "female",
            "company": "Geoform",
            "email": "albawest@geoform.com",
            "address": "Schaefer Street 60",
            "city": "Takilma",
            "country": "Jamaica"
        }, {
            "id": 3,
            "firstName": "Craig",
            "lastName": "Nieves",
            "gender": "male",
            "company": "Flexigen",
            "email": "craignieves@flexigen.com",
            "address": "Kimball Street 63",
            "city": "Rosedale",
            "country": "Pakistan"
        }, {
            "id": 4,
            "firstName": "Obrien",
            "lastName": "Turner",
            "gender": "male",
            "company": "Bleendot",
            "email": "obrienturner@bleendot.com",
            "address": "Belvidere Street 16",
            "city": "Cannondale",
            "country": "Madagascar"
        }, {
            "id": 5,
            "firstName": "Terri",
            "lastName": "Henson",
            "gender": "female",
            "company": "Qualitex",
            "email": "terrihenson@qualitex.com",
            "address": "Osborn Street 74",
            "city": "Northchase",
            "country": "China"
        }, {
            "id": 6,
            "firstName": "Freda",
            "lastName": "Reynolds",
            "gender": "female",
            "company": "Neocent",
            "email": "fredareynolds@neocent.com",
            "address": "Visitation Place 57",
            "city": "Lewis",
            "country": "Togo"
        }, {
            "id": 7,
            "firstName": "Consuelo",
            "lastName": "Farrell",
            "gender": "female",
            "company": "Senmao",
            "email": "consuelofarrell@senmao.com",
            "address": "Perry Place 26",
            "city": "Johnsonburg",
            "country": "Moldova"
        }, {
            "id": 8,
            "firstName": "Virginia",
            "lastName": "Emerson",
            "gender": "female",
            "company": "Portica",
            "email": "virginiaemerson@portica.com",
            "address": "Utica Avenue 43",
            "city": "Fresno",
            "country": "Belgium"
        }, {
            "id": 9,
            "firstName": "Dillard",
            "lastName": "Walter",
            "gender": "male",
            "company": "Furnigeer",
            "email": "dillardwalter@furnigeer.com",
            "address": "Harman Street 42",
            "city": "Islandia",
            "country": "Andorra"
        }, {
            "id": 10,
            "firstName": "Ladonna",
            "lastName": "Pace",
            "gender": "female",
            "company": "Cincyr",
            "email": "ladonnapace@cincyr.com",
            "address": "Chestnut Street 17",
            "city": "Wauhillau",
            "country": "Guinea Bissau"
        }, {
            "id": 11,
            "firstName": "Odom",
            "lastName": "Gilmore",
            "gender": "male",
            "company": "Cedward",
            "email": "odomgilmore@cedward.com",
            "address": "Noll Street 86",
            "city": "Wheatfields",
            "country": "Netherlands"
        }, {
            "id": 12,
            "firstName": "Williamson",
            "lastName": "Francis",
            "gender": "male",
            "company": "Pasturia",
            "email": "williamsonfrancis@pasturia.com",
            "address": "Dewitt Avenue 44",
            "city": "Orovada",
            "country": "Nigeria"
        }, {
            "id": 13,
            "firstName": "Reva",
            "lastName": "Hoffman",
            "gender": "female",
            "company": "Exosis",
            "email": "revahoffman@exosis.com",
            "address": "Kosciusko Street 77",
            "city": "Weeksville",
            "country": "Switzerland"
        }, {
            "id": 14,
            "firstName": "Middleton",
            "lastName": "Shields",
            "gender": "male",
            "company": "Biflex",
            "email": "middletonshields@biflex.com",
            "address": "Commercial Street 57",
            "city": "Kapowsin",
            "country": "Hungary"
        }, {
            "id": 15,
            "firstName": "Chasity",
            "lastName": "Tyson",
            "gender": "female",
            "company": "Skybold",
            "email": "chasitytyson@skybold.com",
            "address": "Calder Place 79",
            "city": "Yukon",
            "country": "Lithuania"
        }, {
            "id": 16,
            "firstName": "Nellie",
            "lastName": "Long",
            "gender": "female",
            "company": "Euron",
            "email": "nellielong@euron.com",
            "address": "Degraw Street 30",
            "city": "Greenbush",
            "country": "United Arab Emirates"
        }, {
            "id": 17,
            "firstName": "Peters",
            "lastName": "Carter",
            "gender": "male",
            "company": "Shopabout",
            "email": "peterscarter@shopabout.com",
            "address": "Vanderveer Street 32",
            "city": "Grayhawk",
            "country": "Tanzania"
        }, {
            "id": 18,
            "firstName": "Daphne",
            "lastName": "Chase",
            "gender": "female",
            "company": "Musaphics",
            "email": "daphnechase@musaphics.com",
            "address": "Greene Avenue 8",
            "city": "Clarence",
            "country": "Burkina Faso"
        }, {
            "id": 19,
            "firstName": "Herman",
            "lastName": "Cantu",
            "gender": "male",
            "company": "Paragonia",
            "email": "hermancantu@paragonia.com",
            "address": "George Street 78",
            "city": "Frierson",
            "country": "Puerto Rico"
        }, {
            "id": 20,
            "firstName": "Tessa",
            "lastName": "Wilkinson",
            "gender": "female",
            "company": "Homelux",
            "email": "tessawilkinson@homelux.com",
            "address": "Gerald Court 5",
            "city": "Ticonderoga",
            "country": "Latvia"
        }, {
            "id": 21,
            "firstName": "Snyder",
            "lastName": "Newman",
            "gender": "male",
            "company": "Tripsch",
            "email": "snydernewman@tripsch.com",
            "address": "Falmouth Street 97",
            "city": "Jeff",
            "country": "Jersey"
        }, {
            "id": 22,
            "firstName": "Calhoun",
            "lastName": "Hull",
            "gender": "male",
            "company": "Permadyne",
            "email": "calhounhull@permadyne.com",
            "address": "Carroll Street 89",
            "city": "Nanafalia",
            "country": "Fiji"
        }, {
            "id": 23,
            "firstName": "Byrd",
            "lastName": "Mcdowell",
            "gender": "male",
            "company": "Omatom",
            "email": "byrdmcdowell@omatom.com",
            "address": "Dinsmore Place 22",
            "city": "Lacomb",
            "country": "Mali"
        }, {
            "id": 24,
            "firstName": "Jeannie",
            "lastName": "Hinton",
            "gender": "female",
            "company": "Medmex",
            "email": "jeanniehinton@medmex.com",
            "address": "Powell Street 7",
            "city": "Neibert",
            "country": "Bosnia &amp; Herzegovina"
        }, {
            "id": 25,
            "firstName": "Lenore",
            "lastName": "Justice",
            "gender": "female",
            "company": "Fishland",
            "email": "lenorejustice@fishland.com",
            "address": "President Street 48",
            "city": "Faywood",
            "country": "Iran"
        }, {
            "id": 26,
            "firstName": "Leola",
            "lastName": "Burton",
            "gender": "female",
            "company": "Comveyor",
            "email": "leolaburton@comveyor.com",
            "address": "Decatur Street 75",
            "city": "Fillmore",
            "country": "Armenia"
        }, {
            "id": 27,
            "firstName": "Nita",
            "lastName": "Hartman",
            "gender": "female",
            "company": "Ecratic",
            "email": "nitahartman@ecratic.com",
            "address": "Ludlam Place 85",
            "city": "Bowden",
            "country": "French Polynesia"
        }, {
            "id": 28,
            "firstName": "Karina",
            "lastName": "Stokes",
            "gender": "female",
            "company": "Earwax",
            "email": "karinastokes@earwax.com",
            "address": "Lewis Avenue 7",
            "city": "Katonah",
            "country": "Uganda"
        }, {
            "id": 29,
            "firstName": "Joy",
            "lastName": "Waters",
            "gender": "female",
            "company": "Terascape",
            "email": "joywaters@terascape.com",
            "address": "Turnbull Avenue 79",
            "city": "Crucible",
            "country": "Nepal"
        }, {
            "id": 30,
            "firstName": "Savage",
            "lastName": "Simmons",
            "gender": "male",
            "company": "Zolar",
            "email": "savagesimmons@zolar.com",
            "address": "Quentin Road 51",
            "city": "Fairacres",
            "country": "St Vincent"
        }, {
            "id": 31,
            "firstName": "Deirdre",
            "lastName": "Bauer",
            "gender": "female",
            "company": "Katakana",
            "email": "deirdrebauer@katakana.com",
            "address": "Milton Street 33",
            "city": "Collins",
            "country": "Liechtenstein"
        }, {
            "id": 32,
            "firstName": "Kasey",
            "lastName": "Gould",
            "gender": "female",
            "company": "Sensate",
            "email": "kaseygould@sensate.com",
            "address": "Suydam Place 21",
            "city": "Sugartown",
            "country": "Chad"
        }, {
            "id": 33,
            "firstName": "Peggy",
            "lastName": "Dillon",
            "gender": "female",
            "company": "Equitox",
            "email": "peggydillon@equitox.com",
            "address": "Randolph Street 5",
            "city": "Fowlerville",
            "country": "El Salvador"
        }, {
            "id": 34,
            "firstName": "Paige",
            "lastName": "Cummings",
            "gender": "female",
            "company": "Futuris",
            "email": "paigecummings@futuris.com",
            "address": "Boerum Street 4",
            "city": "Lowgap",
            "country": "Turkey"
        }, {
            "id": 35,
            "firstName": "Clare",
            "lastName": "Dennis",
            "gender": "female",
            "company": "Interodeo",
            "email": "claredennis@interodeo.com",
            "address": "Underhill Avenue 46",
            "city": "Bowmansville",
            "country": "Qatar"
        }, {
            "id": 36,
            "firstName": "Mcneil",
            "lastName": "Koch",
            "gender": "male",
            "company": "Buzzopia",
            "email": "mcneilkoch@buzzopia.com",
            "address": "Vanderbilt Avenue 62",
            "city": "Bordelonville",
            "country": "Turks &amp; Caicos"
        }, {
            "id": 37,
            "firstName": "Vinson",
            "lastName": "Miranda",
            "gender": "male",
            "company": "Accufarm",
            "email": "vinsonmiranda@accufarm.com",
            "address": "Barbey Street 21",
            "city": "Gwynn",
            "country": "Cruise Ship"
        }, {
            "id": 38,
            "firstName": "Nona",
            "lastName": "Myers",
            "gender": "female",
            "company": "Assistia",
            "email": "nonamyers@assistia.com",
            "address": "Neptune Court 48",
            "city": "Barrelville",
            "country": "Macau"
        }, {
            "id": 39,
            "firstName": "Tasha",
            "lastName": "Hopkins",
            "gender": "female",
            "company": "Printspan",
            "email": "tashahopkins@printspan.com",
            "address": "Willoughby Street 36",
            "city": "Dixonville",
            "country": "Sierra Leone"
        }, {
            "id": 40,
            "firstName": "Shelley",
            "lastName": "Flowers",
            "gender": "female",
            "company": "Makingway",
            "email": "shelleyflowers@makingway.com",
            "address": "Oriental Court 37",
            "city": "Belfair",
            "country": "Colombia"
        }, {
            "id": 41,
            "firstName": "Compton",
            "lastName": "Luna",
            "gender": "male",
            "company": "Marqet",
            "email": "comptonluna@marqet.com",
            "address": "Miller Avenue 70",
            "city": "Hailesboro",
            "country": "Bahrain"
        }, {
            "id": 42,
            "firstName": "Sanford",
            "lastName": "Molina",
            "gender": "male",
            "company": "Konnect",
            "email": "sanfordmolina@konnect.com",
            "address": "Oliver Street 1",
            "city": "Englevale",
            "country": "Burundi"
        }, {
            "id": 43,
            "firstName": "Lynette",
            "lastName": "Freeman",
            "gender": "female",
            "company": "Duflex",
            "email": "lynettefreeman@duflex.com",
            "address": "Cumberland Street 93",
            "city": "Aberdeen",
            "country": "Virgin Islands (US)"
        }, {
            "id": 44,
            "firstName": "Holcomb",
            "lastName": "Rasmussen",
            "gender": "male",
            "company": "Yogasm",
            "email": "holcombrasmussen@yogasm.com",
            "address": "Exeter Street 18",
            "city": "Bodega",
            "country": "Rwanda"
        }, {
            "id": 45,
            "firstName": "Marissa",
            "lastName": "Green",
            "gender": "female",
            "company": "Comcubine",
            "email": "marissagreen@comcubine.com",
            "address": "Richards Street 100",
            "city": "Wescosville",
            "country": "Bahamas"
        }, {
            "id": 46,
            "firstName": "Flores",
            "lastName": "Albert",
            "gender": "male",
            "company": "Fanfare",
            "email": "floresalbert@fanfare.com",
            "address": "Moore Street 48",
            "city": "Nile",
            "country": "Bolivia"
        }, {
            "id": 47,
            "firstName": "Monique",
            "lastName": "Cabrera",
            "gender": "female",
            "company": "Atomica",
            "email": "moniquecabrera@atomica.com",
            "address": "Colin Place 53",
            "city": "Bowie",
            "country": "Maldives"
        }, {
            "id": 48,
            "firstName": "Tisha",
            "lastName": "Parker",
            "gender": "female",
            "company": "Geekular",
            "email": "tishaparker@geekular.com",
            "address": "Vermont Court 77",
            "city": "Drytown",
            "country": "Panama"
        }, {
            "id": 49,
            "firstName": "Ingrid",
            "lastName": "Lowe",
            "gender": "female",
            "company": "Lexicondo",
            "email": "ingridlowe@lexicondo.com",
            "address": "Cook Street 80",
            "city": "Jackpot",
            "country": "Belize"
        }, {
            "id": 50,
            "firstName": "Wiggins",
            "lastName": "Franklin",
            "gender": "male",
            "company": "Assitia",
            "email": "wigginsfranklin@assitia.com",
            "address": "Elmwood Avenue 92",
            "city": "Blue",
            "country": "France"
        }, {
            "id": 51,
            "firstName": "Hurley",
            "lastName": "Goff",
            "gender": "male",
            "company": "Combogene",
            "email": "hurleygoff@combogene.com",
            "address": "Kensington Walk 40",
            "city": "Cataract",
            "country": "Tunisia"
        }, {
            "id": 52,
            "firstName": "Mcdonald",
            "lastName": "Carey",
            "gender": "male",
            "company": "Luxuria",
            "email": "mcdonaldcarey@luxuria.com",
            "address": "Shale Street 38",
            "city": "Helen",
            "country": "Hong Kong"
        }, {
            "id": 53,
            "firstName": "Blanca",
            "lastName": "Holder",
            "gender": "female",
            "company": "Fleetmix",
            "email": "blancaholder@fleetmix.com",
            "address": "India Street 48",
            "city": "Leming",
            "country": "Saint Pierre &amp; Miquelon"
        }, {
            "id": 54,
            "firstName": "Beatriz",
            "lastName": "Terry",
            "gender": "female",
            "company": "Entogrok",
            "email": "beatrizterry@entogrok.com",
            "address": "Amity Street 61",
            "city": "Rivers",
            "country": "New Zealand"
        }, {
            "id": 55,
            "firstName": "Tillman",
            "lastName": "Taylor",
            "gender": "male",
            "company": "Mangelica",
            "email": "tillmantaylor@mangelica.com",
            "address": "Stratford Road 87",
            "city": "Newcastle",
            "country": "Suriname"
        }, {
            "id": 56,
            "firstName": "Tanya",
            "lastName": "Bird",
            "gender": "female",
            "company": "Edecine",
            "email": "tanyabird@edecine.com",
            "address": "Dekalb Avenue 100",
            "city": "Noxen",
            "country": "India"
        }, {
            "id": 57,
            "firstName": "Clarissa",
            "lastName": "Richards",
            "gender": "female",
            "company": "Ronbert",
            "email": "clarissarichards@ronbert.com",
            "address": "Malta Street 16",
            "city": "Topaz",
            "country": "Algeria"
        }, {
            "id": 58,
            "firstName": "Wallace",
            "lastName": "Stevens",
            "gender": "male",
            "company": "Zanymax",
            "email": "wallacestevens@zanymax.com",
            "address": "Hendrickson Place 87",
            "city": "Kylertown",
            "country": "Niger"
        }, {
            "id": 59,
            "firstName": "Amelia",
            "lastName": "Watts",
            "gender": "female",
            "company": "Pyramia",
            "email": "ameliawatts@pyramia.com",
            "address": "Sumpter Street 5",
            "city": "Valle",
            "country": "Uzbekistan"
        }, {
            "id": 60,
            "firstName": "Marjorie",
            "lastName": "Burke",
            "gender": "female",
            "company": "Zensor",
            "email": "marjorieburke@zensor.com",
            "address": "Cooper Street 74",
            "city": "Hayes",
            "country": "Singapore"
        }, {
            "id": 61,
            "firstName": "Johanna",
            "lastName": "Carrillo",
            "gender": "female",
            "company": "Grupoli",
            "email": "johannacarrillo@grupoli.com",
            "address": "Bayview Place 6",
            "city": "Fairfield",
            "country": "Iraq"
        }, {
            "id": 62,
            "firstName": "Gentry",
            "lastName": "Welch",
            "gender": "male",
            "company": "Sultraxin",
            "email": "gentrywelch@sultraxin.com",
            "address": "Crescent Street 9",
            "city": "Strykersville",
            "country": "Reunion"
        }, {
            "id": 63,
            "firstName": "Reeves",
            "lastName": "Petersen",
            "gender": "male",
            "company": "Deepends",
            "email": "reevespetersen@deepends.com",
            "address": "Eldert Lane 32",
            "city": "Fairhaven",
            "country": "Sweden"
        }, {
            "id": 64,
            "firstName": "Hines",
            "lastName": "Boone",
            "gender": "male",
            "company": "Kyagoro",
            "email": "hinesboone@kyagoro.com",
            "address": "Brooklyn Avenue 42",
            "city": "Marshall",
            "country": "Belarus"
        }, {
            "id": 65,
            "firstName": "Dickson",
            "lastName": "Dunlap",
            "gender": "male",
            "company": "Comstar",
            "email": "dicksondunlap@comstar.com",
            "address": "Karweg Place 4",
            "city": "Snowville",
            "country": "Gibraltar"
        }, {
            "id": 66,
            "firstName": "Lucas",
            "lastName": "Bowen",
            "gender": "male",
            "company": "Quarex",
            "email": "lucasbowen@quarex.com",
            "address": "Chapel Street 63",
            "city": "Blodgett",
            "country": "Thailand"
        }, {
            "id": 67,
            "firstName": "Paul",
            "lastName": "Powers",
            "gender": "male",
            "company": "Rubadub",
            "email": "paulpowers@rubadub.com",
            "address": "Losee Terrace 63",
            "city": "Brewster",
            "country": "Jordan"
        }, {
            "id": 68,
            "firstName": "Fay",
            "lastName": "Copeland",
            "gender": "female",
            "company": "Firewax",
            "email": "faycopeland@firewax.com",
            "address": "Mill Street 3",
            "city": "Corriganville",
            "country": "Faroe Islands"
        }, {
            "id": 69,
            "firstName": "Stout",
            "lastName": "Jacobson",
            "gender": "male",
            "company": "Geekology",
            "email": "stoutjacobson@geekology.com",
            "address": "Wilson Avenue 61",
            "city": "Tecolotito",
            "country": "Greece"
        }, {
            "id": 70,
            "firstName": "Diann",
            "lastName": "Garcia",
            "gender": "female",
            "company": "Velity",
            "email": "dianngarcia@velity.com",
            "address": "Riverdale Avenue 63",
            "city": "Osage",
            "country": "Kenya"
        }, {
            "id": 71,
            "firstName": "Whitaker",
            "lastName": "Hudson",
            "gender": "male",
            "company": "Proflex",
            "email": "whitakerhudson@proflex.com",
            "address": "Schweikerts Walk 80",
            "city": "Elbert",
            "country": "Samoa"
        }, {
            "id": 72,
            "firstName": "Stacie",
            "lastName": "Pollard",
            "gender": "female",
            "company": "Quarx",
            "email": "staciepollard@quarx.com",
            "address": "Mill Road 26",
            "city": "Edgewater",
            "country": "Denmark"
        }, {
            "id": 73,
            "firstName": "Gay",
            "lastName": "Malone",
            "gender": "male",
            "company": "Zaphire",
            "email": "gaymalone@zaphire.com",
            "address": "Frost Street 89",
            "city": "Frizzleburg",
            "country": "Falkland Islands"
        }, {
            "id": 74,
            "firstName": "Livingston",
            "lastName": "Strong",
            "gender": "male",
            "company": "Geekol",
            "email": "livingstonstrong@geekol.com",
            "address": "Lorraine Street 30",
            "city": "Abrams",
            "country": "Yemen"
        }, {
            "id": 75,
            "firstName": "Victoria",
            "lastName": "Small",
            "gender": "female",
            "company": "Zolarex",
            "email": "victoriasmall@zolarex.com",
            "address": "Schenck Avenue 66",
            "city": "Russellville",
            "country": "Barbados"
        }, {
            "id": 76,
            "firstName": "Sparks",
            "lastName": "Bennett",
            "gender": "male",
            "company": "Marvane",
            "email": "sparksbennett@marvane.com",
            "address": "Union Avenue 38",
            "city": "Eggertsville",
            "country": "Brunei"
        }, {
            "id": 77,
            "firstName": "Lacy",
            "lastName": "Hyde",
            "gender": "female",
            "company": "Accruex",
            "email": "lacyhyde@accruex.com",
            "address": "Lott Avenue 62",
            "city": "Thatcher",
            "country": "Bermuda"
        }, {
            "id": 78,
            "firstName": "Casey",
            "lastName": "Moon",
            "gender": "male",
            "company": "Xurban",
            "email": "caseymoon@xurban.com",
            "address": "Ferris Street 40",
            "city": "Chelsea",
            "country": "St Kitts &amp; Nevis"
        }, {
            "id": 79,
            "firstName": "Meyers",
            "lastName": "Fuller",
            "gender": "male",
            "company": "Nexgene",
            "email": "meyersfuller@nexgene.com",
            "address": "Clay Street 60",
            "city": "Coyote",
            "country": "French West Indies"
        }, {
            "id": 80,
            "firstName": "Underwood",
            "lastName": "Munoz",
            "gender": "male",
            "company": "Quordate",
            "email": "underwoodmunoz@quordate.com",
            "address": "Oceanview Avenue 97",
            "city": "Zeba",
            "country": "Australia"
        }, {
            "id": 81,
            "firstName": "Mcfarland",
            "lastName": "Caldwell",
            "gender": "male",
            "company": "Glukgluk",
            "email": "mcfarlandcaldwell@glukgluk.com",
            "address": "Indiana Place 72",
            "city": "Shasta",
            "country": "Costa Rica"
        }, {
            "id": 82,
            "firstName": "Mabel",
            "lastName": "Kidd",
            "gender": "female",
            "company": "Scenty",
            "email": "mabelkidd@scenty.com",
            "address": "Ryder Avenue 8",
            "city": "Soham",
            "country": "Ghana"
        }, {
            "id": 83,
            "firstName": "Jannie",
            "lastName": "Johnson",
            "gender": "female",
            "company": "Steeltab",
            "email": "janniejohnson@steeltab.com",
            "address": "Kent Avenue 62",
            "city": "Garberville",
            "country": "Morocco"
        }, {
            "id": 84,
            "firstName": "Bette",
            "lastName": "Mendoza",
            "gender": "female",
            "company": "Golistic",
            "email": "bettemendoza@golistic.com",
            "address": "Lloyd Court 77",
            "city": "Cassel",
            "country": "Nicaragua"
        }, {
            "id": 85,
            "firstName": "Barber",
            "lastName": "Glenn",
            "gender": "male",
            "company": "Puria",
            "email": "barberglenn@puria.com",
            "address": "National Drive 94",
            "city": "Spelter",
            "country": "Namibia"
        }, {
            "id": 86,
            "firstName": "Grace",
            "lastName": "Austin",
            "gender": "female",
            "company": "Pushcart",
            "email": "graceaustin@pushcart.com",
            "address": "Dank Court 14",
            "city": "Detroit",
            "country": "Mauritania"
        }, {
            "id": 87,
            "firstName": "Leanne",
            "lastName": "Cooper",
            "gender": "female",
            "company": "Zerology",
            "email": "leannecooper@zerology.com",
            "address": "Wortman Avenue 31",
            "city": "Dupuyer",
            "country": "Norway"
        }, {
            "id": 88,
            "firstName": "Rodriquez",
            "lastName": "Miller",
            "gender": "male",
            "company": "Accel",
            "email": "rodriquezmiller@accel.com",
            "address": "Virginia Place 58",
            "city": "Rosewood",
            "country": "Sudan"
        }, {
            "id": 89,
            "firstName": "Harrison",
            "lastName": "Mccullough",
            "gender": "male",
            "company": "Recognia",
            "email": "harrisonmccullough@recognia.com",
            "address": "Woodside Avenue 32",
            "city": "Iberia",
            "country": "Lesotho"
        }, {
            "id": 90,
            "firstName": "Bridges",
            "lastName": "Spears",
            "gender": "male",
            "company": "Danja",
            "email": "bridgesspears@danja.com",
            "address": "Clermont Avenue 23",
            "city": "Northridge",
            "country": "Spain"
        }, {
            "id": 91,
            "firstName": "Mary",
            "lastName": "Barron",
            "gender": "female",
            "company": "Comtours",
            "email": "marybarron@comtours.com",
            "address": "Dare Court 42",
            "city": "Cowiche",
            "country": "Cyprus"
        }, {
            "id": 92,
            "firstName": "Best",
            "lastName": "Griffith",
            "gender": "male",
            "company": "Bitrex",
            "email": "bestgriffith@bitrex.com",
            "address": "Central Avenue 97",
            "city": "Ivanhoe",
            "country": "Laos"
        }, {
            "id": 93,
            "firstName": "Robert",
            "lastName": "Moreno",
            "gender": "female",
            "company": "Lotron",
            "email": "robertmoreno@lotron.com",
            "address": "Hendrickson Street 58",
            "city": "Richmond",
            "country": "San Marino"
        }, {
            "id": 94,
            "firstName": "Mack",
            "lastName": "Erickson",
            "gender": "male",
            "company": "Nspire",
            "email": "mackerickson@nspire.com",
            "address": "Knapp Street 14",
            "city": "Lund",
            "country": "Zambia"
        }, {
            "id": 95,
            "firstName": "Jenny",
            "lastName": "Randolph",
            "gender": "female",
            "company": "Octocore",
            "email": "jennyrandolph@octocore.com",
            "address": "Commerce Street 21",
            "city": "Jenkinsville",
            "country": "Estonia"
        }, {
            "id": 96,
            "firstName": "Franks",
            "lastName": "Jensen",
            "gender": "male",
            "company": "Imageflow",
            "email": "franksjensen@imageflow.com",
            "address": "Luquer Street 35",
            "city": "Hemlock",
            "country": "Montenegro"
        }, {
            "id": 97,
            "firstName": "Brandie",
            "lastName": "Chang",
            "gender": "female",
            "company": "Evidends",
            "email": "brandiechang@evidends.com",
            "address": "Varick Avenue 89",
            "city": "Bawcomville",
            "country": "Egypt"
        }, {
            "id": 98,
            "firstName": "Blair",
            "lastName": "Chandler",
            "gender": "male",
            "company": "Cognicode",
            "email": "blairchandler@cognicode.com",
            "address": "Lott Street 30",
            "city": "Bend",
            "country": "Guyana"
        }, {
            "id": 99,
            "firstName": "Hannah",
            "lastName": "Juarez",
            "gender": "female",
            "company": "Callflex",
            "email": "hannahjuarez@callflex.com",
            "address": "Meserole Street 41",
            "city": "Rew",
            "country": "Dominica"
        }];

        this.load = function () {
            return people;
        };

        this.get = function (id) {
            return people.reduce(function (result, person) {
                if (person.id == id) {
                    return person;
                }
                return result;
            }, null);
        };
    });
}(angular));
