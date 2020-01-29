DELIMITER //
CREATE PROCEDURE set_location(ID int, latitude double, longitude double)
BEGIN
	SET @latval = 36.16259;
    SET @longval = -86.7785;
    SET @idnum = ID;
	
	UPDATE INTERACTION
    SET location = CASE
					WHEN (((INTERACTION.latitude > 36.1493)AND(INTERACTION.latitude < 36.167)) AND ((INTERACTION.longitude > -86.786) AND (INTERACTION.longitude < -86.7702)))
						THEN 'Downtown'
					WHEN (INTERACTION.latitude > @latval AND INTERACTION.longitude < @longval) THEN 'Northside'
                    WHEN (INTERACTION.latitude < @latval AND INTERACTION.longitude > @longval) THEN 'Southside'
                    WHEN (INTERACTION.latitude > @latval AND INTERACTION.longitude > @longval) THEN 'Eastside'
                    WHEN (INTERACTION.latitude < @latval AND INTERACTION.longitude < @longval) THEN 'Westside'
                    END
                    WHERE ID = @idnum;
		
END //

DELIMITER ;
drop procedure set_location;