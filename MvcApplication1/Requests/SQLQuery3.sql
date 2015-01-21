insert into Projects( Description,Title,UserLogin,Path,Date, Settings) 
	select 'new project created','Settings','root','Settings',01.21, 
	'<book> <theme>Book</theme></book>'
--see DB entry
select * from Projects;