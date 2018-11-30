CREATE PROCEDURE Treaters_Insert
(
	@Name varchar(50),
	@FavoriteCandy VARCHAR(50),
	@Costume VARCHAR(50)
)
AS
INSERT INTO Treaters(Name, FavoriteCandyID, CostumeID) 
VALUES (@Name, 
(SELECT Id FROM Candy
WHERE @FavoriteCandy = ProductName),
(SELECT Id FROM Costumes
WHERE @Costume = Costume)
);