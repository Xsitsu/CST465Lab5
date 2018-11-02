CREATE PROCEDURE Treaters_Insert
(
	@Name varchar(50),
	@FavoriteCandyId INT,
	@CostumeId INT
)
AS
INSERT INTO Treaters(Name, FavoriteCandyID, CostumeID) 
VALUES (@Name, @FavoriteCandyId, @CostumeId);