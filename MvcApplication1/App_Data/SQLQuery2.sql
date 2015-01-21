insert into Projects(Title,Description,UserLogin,Path,Date, Settings) 
	select  'Settings','new project created','root2','Settings',01.21,
	'<book> <theme>Book</theme></book>'
--see DB entry
select * from Projects;