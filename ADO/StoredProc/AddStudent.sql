CREATE PROCEDURE [dbo].[AddStudent]
    @FirstName VARCHAR(50) , 
    @LastName VARCHAR(50) , 
    @BirthDate DATETIME2 , 
    @YearResult INT , 
    @SectionID INT , 
    @Active BIT 
AS
BEGIN
    SET NOCOUNT ON
    INSERT INTO Student (FirstName, LastName, BirthDate, YearResult, SectionID, Active)
    VALUES(@FirstName, @LastName, @BirthDate, @YearResult, @SectionID, @Active)
END

