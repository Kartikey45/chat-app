CREATE procedure UserRegistration
@FirstName varchar(255),
@LastName varchar(255),
@Email varchar(255),
@Password varchar(255),
@PhoneNumber varchar(255)
as
begin
if not exists (select Email from UserInfo where Email = @Email)
begin
	insert into UserInfo(FirstName,LastName,Email,Password,PhoneNumber)
	values (@FirstName, @LastName , @Email , @Password , @PhoneNumber);

	select * from UserInfo where Email = @Email
end
end