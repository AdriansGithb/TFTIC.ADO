CREATE PROCEDURE [dbo].[DeleteStudent]
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE
    FROM Student 
    WHERE @Id = Id
END



