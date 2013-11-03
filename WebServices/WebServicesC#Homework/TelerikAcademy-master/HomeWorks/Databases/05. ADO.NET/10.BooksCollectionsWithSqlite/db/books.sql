PRAGMA foreign_keys=ON;

-- -----------------------------------------------------
-- Table `books`.`Books`
-- -----------------------------------------------------
DROP TABLE IF EXISTS Books;

CREATE  TABLE IF NOT EXISTS Books (
  idBooks INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT ,
  titleBook TEXT NOT NULL ,
  publishDate DATETIME NOT NULL ,
  ISBN INTEGER NOT NULL UNIQUE );

CREATE UNIQUE INDEX IF NOT EXISTS idBooks_UNIQUE ON Books (idBooks ASC);
CREATE UNIQUE INDEX IF NOT EXISTS ISBN_UNIQUE ON Books (ISBN ASC);

-- -----------------------------------------------------
-- Table `books`.`Authors`
-- -----------------------------------------------------
DROP TABLE IF EXISTS Authors;

CREATE  TABLE IF NOT EXISTS Authors (
  idAuthors INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT ,
  AuthorName TEXT NULL DEFAULT NULL ,
  Books_idBooks INTEGER NOT NULL ,
  FOREIGN KEY(Books_idBooks) REFERENCES Books(idBooks));

CREATE UNIQUE INDEX IF NOT EXISTS idAuthors_UNIQUE ON Authors (idAuthors ASC);
CREATE UNIQUE INDEX IF NOT EXISTS AuthorName_UNIQUE ON Authors (AuthorName ASC);
CREATE INDEX IF NOT EXISTS fk_Authors_Books_idx ON Authors (Books_idBooks ASC);

