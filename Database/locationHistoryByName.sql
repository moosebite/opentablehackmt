DELIMITER //

CREATE PROCEDURE locationHistoryByName(inputName VARCHAR(65535))
BEGIN
	SELECT name_input, date_input, location, latitude, longitude FROM INTERACTION WHERE name_input = inputName;

END //

DELIMITER ;


CALL OpenT.locationHistoryByName('Emily');
