--### BACKUP ###
--### Use Ctrl + A then Ctrl + K, U and then Ctrl + Shift +E
--delete all data for cleaning DB
delete from UserProfile;
delete from Roles;
delete from SecretQuestions;
delete from Documents;
--set default values into Roles DB
set identity_insert Roles  ON
insert into  Roles(id, prioritylevel, levelname) values(1, 100, 'Super Admin');
insert into  Roles(id, prioritylevel,levelname) values(2, 80, 'Simple Admin');
insert into  Roles(id, prioritylevel,levelname) values(3, 50, 'Platinum User');
insert into  Roles(id, prioritylevel,levelname) values(4, 30, 'Gold User');
insert into  Roles(id, prioritylevel,levelname) values(5, 15, 'Simple User');
insert into  Roles(id, prioritylevel,levelname) values(6, 0, 'Demo User');
--set defalut values into SecretQestion
set identity_insert Roles  OFF
set identity_insert  SecretQuestions  ON
insert into SecretQuestions(id, question) values (1, 'What is your second first name?');
insert into SecretQuestions(id, question) values (2, 'What is your first pet name?');
insert into SecretQuestions(id, question) values (3, 'What is surname of your grandmother?');
insert into SecretQuestions(id, question) values (4, 'What is your special secret word?');
insert into SecretQuestions(id, question) values (5, 'What is your mother name?');
--set identity_insert  SecretQuestions  OFF
--set default Super User with simple bad password
insert into UserProfile(login,mail,password,secretquestion,secretanswer,age,fullname,role) 
	select 'root','root@mail.com','root',SecretQuestions.Id,'root',null,'root', Roles.Id 
	from SecretQuestions, Roles where SecretQuestions.question = 'What is your special secret word?'
								 and Roles.levelname = 'Super Admin'; 
--see DB entry
select * from Roles;
select * from UserProfile;
select * from SecretQuestions;