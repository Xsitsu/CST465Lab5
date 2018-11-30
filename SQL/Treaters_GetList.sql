CREATE PROCEDURE Treaters_GetList
AS
SELECT Treaters.Name AS Name, Candy.ProductName AS Candy, Costumes.Costume AS Costume
FROM Treaters
JOIN Candy ON Treaters.FavoriteCandyID = Candy.Id
JOIN Costumes ON Treaters.CostumeID = Costume.Id;