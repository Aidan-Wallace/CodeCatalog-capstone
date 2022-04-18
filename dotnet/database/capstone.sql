USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
);

CREATE TABLE code (
	code_id int IDENTITY(1,1) NOT NULL,
	programming_language varchar(50) NOT NULL,
	title varchar(50) NOT NULL,
	snippet varchar(MAX) NULL,
	code_description varchar(MAX)  NULL,
	example_date varchar(50)  NULL,
	difficulty_rank varchar(50)  NULL,
	category varchar(MAX)  NULL,
	submission_status int NOT NULL,
	is_public int NOT NULL,
	attribution varchar(MAX) NULL,
	generic_example int NOT NULL,
	CONSTRAINT PK_code PRIMARY KEY (code_id)
);

CREATE TABLE user_code (
	user_id int  NOT NULL,
	code_id int  NOT NULL,
	submission_status int NOT NULL,
	CONSTRAINT [FK_users] FOREIGN KEY (user_id) REFERENCES [users] (user_id),
	CONSTRAINT [FK_code] FOREIGN KEY (code_id) REFERENCES [code] (code_id)
	
);

CREATE TABLE search_index (
	code_id int NOT NULL,
	keyword varchar(200) NOT NULL,
	CONSTRAINT [FK_example] FOREIGN KEY (code_id) REFERENCES [code] (code_id)
);

--populate default data
-- user/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');

-- admin/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

GO
