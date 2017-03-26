CREATE PROCEDURE [dbo].[GetPlayerById]
	@Id int
AS
	SELECT *
	FROM Players AS P
	WHERE P.Id = @Id
RETURN 0
