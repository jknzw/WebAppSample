-- プライマリキー https://www.dbonline.jp/sqlite/table/index6.html
-- autoincrement https://www.dbonline.jp/sqlite/table/index9.html
-- SQLITEの自動採番 https://shobon.hatenablog.com/entry/2014/03/30/210444
--DROP TABLE yontaku;
CREATE TABLE yontaku( 
	lvl text
	, type text
	, mondai text NOT NULL
	, keyword text NOT NULL
	, answer text NOT NULL
	, choice1 text
	, choice2 text
	, choice3 text
	, PRIMARY KEY (mondai,keyword)
); 

--DROP TABLE answer;
CREATE TABLE answer( 
	keyword text NOT NULL
	, lvl text
	, type text
	, PRIMARY KEY (keyword)
); 

