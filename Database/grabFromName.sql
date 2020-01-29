DELIMITER //

CREATE PROCEDURE assistFrom(inputName VARCHAR(65535))
BEGIN
	SELECT * FROM INTERACTION WHERE name_input = inputName;

END //

DELIMITER ;


CALL OpenT.assistFrom('Emily');