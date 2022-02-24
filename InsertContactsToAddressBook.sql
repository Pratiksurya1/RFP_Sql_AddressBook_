ALTER PROCEDURE [dbo].[AddressBookProcedure]
@firstName varchar(10)='',
@lastName varchar(15)='',
@address varchar(50)='',
@city varchar(15)='',
@state varchar(15)='',
@zip varchar(7)='',
@mobileNo varchar(10)='',
@email varchar(30)='',
@stmnt varchar(20)='',
@position varchar(20)=''

AS 
BEGIN

IF @stmnt='Insert'
BEGIN
INSERT INTO address_book(firstName,lastName,address,city,state,zip,mobileNo,email)VALUES(@firstName,@lastName,@address,@city,@state,@zip,@mobileNo,@email)
END

IF @stmnt='Update'
BEGIN
UPDATE address_book SET firstName=@firstName,lastName=@lastName,address=@address,city=@city,state=@state,zip=@zip,mobileNo=@mobileNo,email=@email WHERE firstName=@position
END
END