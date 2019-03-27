
-- Switch to the system (master) database --
USE master;
GO

-- Delete the StormLight Database (IF EXISTS) --
IF EXISTS(SELECT * FROM sys.databases WHERE NAME='StormLight')
DROP DATABASE StormLight;
GO

-- Create a new StormLight Database -- 
CREATE DATABASE StormLight;
GO

-- Switch to the StormLight Databse -- 
USE StormLight
GO

BEGIN TRANSACTION;

CREATE TABLE Character
(
	character_id int identity(1,1),
	character_name varchar(100) not null,
	abilities varchar(100),
	bonded_with varchar(30),
	titles varchar(1000),
	groups varchar(1000),
	knights_orders_name varchar(50),
	surges varchar(1000),
	character_image varchar(100),

	constraint pk_Character primary key(character_id),	
);

CREATE TABLE Book
(
	book_id int identity(1,1),	
	book_name varchar(100) not null,
	published varchar(50),
	back_cover varchar(5000),
	book_image varchar (100),

	constraint pk_Book primary key(book_id),	
);

CREATE TABLE Character_Book
(
	character_id int not null,
	book_id int not null,

	--constraint fk_character_book_id foreign key (character_id) references Character (character_id),
	--constraint fk_book_character_id foreign key (book_id) references Book (book_id)

);

CREATE TABLE Knight_Orders
(
	knight_orders_id int identity(1,1),	
	knight_orders_name varchar(50),
	heralds varchar(30) not null,
	spren varchar(200) not null,
	surges varchar(1000),
	knight_orders_images varchar(100)

	constraint pk_Knight_Orders primary key(knight_orders_id),	
);

CREATE TABLE Knight_Orders_Characters
(
	knight_orders_id int not null,
	character_id int not null,

	-- constraint fk_knight_orders_characters_id foreign key (knight_orders_id) references Knight_Orders (knight_orders_id),
	-- constraint fk_character_orders_id foreign key (character_id) references Character (character_id)
);

CREATE TABLE survey_result
(
	survey_id int identity(1,1) not null,
	character_id int not null,
	emailAddress varchar(100) not null,
	state varchar(30) not null,	
	
	constraint pk_survey_result primary key (survey_id),
	constraint fk_survey_result_character foreign key (character_id) references Character (character_id)
);


INSERT Character VALUES ('Kaladin Stormblessed', 'Windrunner, Shardbearer', 'Sylphrena', 'Captain of the Bridgemen, Knight Radiant', 'Knights Radiant (Windrunners), Bridge Four, Kholin army, Amaram''s army (formerly), Sadeas army (formerly), Kaladin''s squad (formerly), Takers (formerly)', 'Order of Windrunners', 'Adhesion and Gravitation', 'Kaladin.jpg')
INSERT Character VALUES ('Shallan Davar', 'Lightweaver, Shardbearer', 'Pattern', 'Veil, Radiant', 'Knights Radiant (Lightweavers), Ghostbloods', 'Order of Lightweavers', 'Illumination and Transformation', 'Shallan.jpg')
INSERT Character VALUES ('Dalinar Kholin', 'Bondsmith, Old Magic, Shardbearer', 'Stormfather', 'Highprince of Alethkar (formerly), Highprince of War', 'Knights Radiant (Bondsmiths), Kholin army', 'Order of Bondsmiths', 'Tension and Adhesion', 'Dalinar.jpg')
INSERT Character VALUES ('Jasnah Kholin', 'Elsecaller, Shardbearer', 'Ivory', 'Queen of Alethkar', 'Knights Radiant (Elsecallers) Veristitalians', 'Order of Elsecallers', 'Transformation and Transportation', 'Jasnah.jpg')
INSERT Character VALUES ('Lift', 'Edgedancer, Shardbearer, Old Magic', 'Wyndle', 'Thief', '	Huqin''s crew', 'Order of Edgedancers',  'Abrasion and Progression', 'Lift.jpg')


INSERT Book VALUES ('The Way of Kings', 'August 31, 2010', 'I long for the days before the Last Desolation. The age before the Heralds abandoned us and the Knights Radiant turned against us. A time when there was still magic in the world and honor in the hearts of men. The world became ours, and we lost it. Nothing, it appears, is more challenging to the souls of men than victory itself. Or was that victory an illusion all along? Did our enemies realize that the harder they fought, the stronger we resisted? Perhaps they saw that the heat and the hammer only make for a better grade of sword. But ignore the steel long enough, and it will eventually rust away. There are four whom we watch. The first is the surgeon, forced to put aside healing to become a soldier in the most brutal war of our time. The second is the assassin, a murderer who weeps as he kills. The third is the liar, a young woman who wears a scholar’s mantle over the heart of a thief. The last is the highprince, a warlord whose eyes have opened to the past as his thirst for battle wanes. The world can change. Surgebinding and Shardwielding can return; the magics of ancient days can become ours again. These four people are key. One of them may redeem us. And one of them will destroy us.', 'TheWayOfKings.jpg')
INSERT Book VALUES ('Words of Radiance', 'March 14, 2014', 'The Knights Radiant must stand again. The ancient oaths have at last been spoken; the spren return. Men seek that which was lost. I fear the struggle will destroy them. It is the nature of the magic. A broken soul has cracks into which something else can be fit.  Surgebindings, the powers of creation themselves.  They can brace a broken soul; but they can also widen its fissures. The Windrunner, lost in a shattered land, balanced upon the boundary between  vengeance and honor. The Lightweaver, slowly being consumed by her past, searching for the lie that she must become. The Bondsmith, born in blood and death, striving to rebuild what was destroyed. The Explorer, straddling the fates of two peoples, forced to  choose between slow death and a terrible betrayal of all she believes. It is past time for them to awaken, for the Everstorm looms. And the Assassin has arrived.', 'WordsOfRadiance.jpg')
INSERT Book VALUES ('Edgedancer', 'October 2017', 'Three years ago, Lift asked a goddess to stop her from growing older–a wish she believed was granted. Now, in Edgedancer, the barely teenage nascent Knight Radiant finds that time stands still for no one. Although the young Azish emperor granted her safe haven from an executioner she knows only as Darkness, court life is suffocating the free-spirited Lift, who can’t help heading to Yeddaw when she hears the relentless Darkness is there hunting people like her with budding powers. The downtrodden in Yeddaw have no champion, and Lift knows she must seize this awesome responsibility.', 'Edgedancer.jpg')
INSERT Book VALUES ('OathBringer', 'November 14, 2017', 'Dalinar Kholin’s Alethi armies won a fleeting victory at a terrible cost: The enemy Parshendi summoned the violent Everstorm, which now sweeps the world with destruction, and in its passing awakens the once peaceful and subservient parshmen to the horror of their millennia-long enslavement by humans. While on a desperate flight to warn his family of the threat, Kaladin Stormblessed must come to grips with the fact that the newly kindled anger of the parshmen may be wholly justified. Nestled in the mountains high above the storms, in the tower city of Urithiru, Shallan Davar investigates the wonders of the ancient stronghold of the Knights Radiant and unearths dark secrets lurking in its depths. And Dalinar realizes that his holy mission to unite his homeland of Alethkar was too narrow in scope. Unless all the nations of Roshar can put aside Dalinar’s blood-soaked past and stand together―and unless Dalinar himself can confront that past―even the restoration of the Knights Radiant will not prevent the end of civilization.', 'Oathbringer.jpg')

INSERT Character_Book VALUES (1, 1)
INSERT Character_Book VALUES (1, 2)
INSERT Character_Book VALUES (1, 3)
INSERT Character_Book VALUES (1, 4)

INSERT Character_Book VALUES (2, 1)
INSERT Character_Book VALUES (2, 2)
INSERT Character_Book VALUES (2, 3)
INSERT Character_Book VALUES (2, 4)
INSERT Character_Book VALUES (2, 5)

INSERT Character_Book VALUES (3, 5)


INSERT Character_Book VALUES (4, 1)
INSERT Character_Book VALUES (4, 2)
INSERT Character_Book VALUES (4, 3)
INSERT Character_Book VALUES (4, 4)
INSERT Character_Book VALUES (4, 5)

INSERT Knight_Orders VALUES ('Order of Windrunners', 'Jezrien', 'Honorspren', 'Adhesion and Gravitation', 'Windrunners.svg')
INSERT Knight_Orders VALUES ('Order of Skybreakers', 'Nale', 'Highspren', 'Gravitation and Division', 'Skybreakers.svg')
INSERT Knight_Orders VALUES ('Order of Dustbringers', 'Chanarach', 'Ashspren', 'Division and Abrasion', 'Dustbringers.svg')
INSERT Knight_Orders VALUES ('Order of Edgedancers', 'Vedeledev', 'Cultivationspren', 'Abrasion and Progression', 'Edgedancers.svg')
INSERT Knight_Orders VALUES ('Order of Truthwatchers', 'Pailliah', 'unknown', 'Progression and Illumination', 'Truthwatchers.svg')
INSERT Knight_Orders VALUES ('Order of Lightweavers', 'Shalash', 'Cryptic', 'Illumination and Transformation', 'Lightweavers.svg')
INSERT Knight_Orders VALUES ('Order of Elsecallers', 'Battah', 'Inkspren', 'Transformation and Transportation', 'Elsecallers.svg')
INSERT Knight_Orders VALUES ('Order of Willshapers', 'Kalak', 'Lightspren', 'Transportation and Cohesion', 'Willshapers.svg')
INSERT Knight_Orders VALUES ('Order of Stonewards', 'Talenel', 'unknown', 'Cohesion and Tension', 'Stonewards.svg')
INSERT Knight_Orders VALUES ('Order of Bondsmiths', 'Ishar', 'Nightwatcher, Stormfather, Sibling', 'Tension and Adhesion', 'Bondsmiths.svg')

INSERT Knight_Orders_Characters VALUES (1,1)
INSERT Knight_Orders_Characters VALUES (6,2)
INSERT Knight_Orders_Characters VALUES (10,3)
INSERT Knight_Orders_Characters VALUES (7,4)
INSERT Knight_Orders_Characters VALUES (4,5)

INSERT survey_result VALUES (1, 'mike@yahoo.com', 'PA')
INSERT survey_result VALUES (1, 'tom@yahoo.com', 'FL')
INSERT survey_result VALUES (2, 'emme@yahoo.com', 'WA')
INSERT survey_result VALUES (1, 'nate@yahoo.com', 'CA')
INSERT survey_result VALUES (3, 'yui@yahoo.com', 'PA')

COMMIT;