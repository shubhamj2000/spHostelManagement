# spHostelManagement

-----------------------------------------------------------------------------------------------------------------------

stored procedures :-


CREATE procedure [dbo].[AddNewStdDetails]  
(  
  @FirstName varchar(50),
  @LastName  varchar(50),
  @Email  varchar(50),
  @Address  varchar(50),
  @DOB  datetime,
  @GenderID int,
  @isDeleted bit,
  @isActive bit
)  
as  
begin  
   Insert into spStudent values(@FirstName,@LastName,@Email,@Address,@DOB,@GenderID,@isDeleted,@isActive)  
End 
GO



CREATE procedure [dbo].[DeleteStdById]  
(  
   @Id int  
)  
as   
begin  
   UPDATE spStudent 
   SET isDeleted='1' WHERE Id=@Id  
End 
GO





Create Procedure [dbo].[GetGenders]  
as  
begin  
   select *from spGender 
End 
GO





CREATE Procedure [dbo].[GetStudents]  
as  
begin  
   SELECT spStudent.Id,spStudent.FirstName,spStudent.LastName,spStudent.Email,spStudent.Address,spStudent.DOB,spStudent.isActive,spGender.Name
FROM spStudent
INNER JOIN spGender ON spStudent.GenderID = spGender.id
WHERE spStudent.isDeleted='0';

End 
GO




CREATE procedure [dbo].[MultipleDelete]  
(  
   @str varchar(500)  
)  
as   
begin  

UPDATE spStudent 
   SET isDeleted='1' WHERE Id IN (Select value from string_split(@str,','))
End 
GO





CREATE procedure [dbo].[UpdateStdDetails]  
(  
   @Id int,  
   @FirstName varchar(50),
  @LastName  varchar(50),
  @Email  varchar(50),
  @Address  varchar(50),
  @DOB  datetime,
   @GenderID int,
  @isDeleted bit,
  @isActive bit
)  
as  
begin  
   Update spStudent   
   set FirstName=@FirstName,  
        LastName  = @LastName ,
        Email = @Email,
        Address = @Address,
         DOB=@DOB ,
		 GenderID=@GenderID,
		 isDeleted=@isDeleted,
		 isActive=@isActive
   where Id=@Id  
End 
GO


--------------------------------------------------------------------------------------------------------------------------------------------------

