CREATE procedure UserLogin
@Email varchar(255),
@Password varchar(255)
as
begin
	select * from UserInfo where Email = @Email and Password = @Password
end