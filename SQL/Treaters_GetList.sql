CREATE PROCEDURE Treaters_GetList
AS
SELECT Treaters.Name AS Name, Candy.ProductName AS Candy, Costumes.Costume AS Costume
FROM Treaters
LEFT JOIN Candy ON Treaters.FavoriteCandyID = Candy.Id
LEFT JOIN Costumes ON Treaters.CostumeID = Costumes.Id;