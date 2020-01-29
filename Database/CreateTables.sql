CREATE TABLE INTERACTION
(
	ID					INT AUTO_INCREMENT	PRIMARY KEY,
	name_input			VARCHAR(50)			DEFAULT"No name given",
    date_input			DATETIME,
    num_assisted		INT,
    latitude			DOUBLE,
    longitude			DOUBLE,
    location			VARCHAR(50)			DEFAULT"No location given",
    staging				INT,
    mission				INT,
    launchpad			INT,
    emergency			INT,
    other				INT,
    reject_assistance	VARCHAR(256)		DEFAULT"No rejections",
    other_comment		VARCHAR(256)		DEFAULT"No extra comments"
);