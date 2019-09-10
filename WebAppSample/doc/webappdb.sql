drop table userinfo;
create table userinfo (
	userid verchar(10) not null primary key
	, password verchar(255)
);

insert into userinfo (
    userid
	, password
) values (
	'puriko',
	'puriko'
);


