CREATE PROCEDURE [dbo].[UpdateStudent]
    @Id INT, 
    @YearResult INT , 
    @SectionID INT  
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Student 
    SET YearResult = @YearResult, SectionID = @SectionID
    WHERE @Id = Id
END
