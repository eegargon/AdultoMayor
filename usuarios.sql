DROP TABLE users
GO
CREATE TABLE users
(
    username varchar(200) NOT NULL CONSTRAINT users_PK PRIMARY KEY,
    password varchar(200) NOT NULL,
    roles varchar(200)
)
GO
CREATE INDEX credentials ON users
(
    username,
    password
)
GO
TRUNCATE TABLE users
GO
-- admon
INSERT INTO users VALUES ('admin', '5BB7B7A44C2F02464D807231F0083F0F1C221011', 'Administrador')
GO