CREATE PROCEDURE [dbo].[AddSection]
	@Id int,
	@SectionName VARCHAR(50)

AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO Section
	VALUES (@Id, @SectionName)
END
