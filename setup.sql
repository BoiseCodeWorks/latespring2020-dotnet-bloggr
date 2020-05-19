-- CREATE TABLE blogs (
--   id INT NOT NULL AUTO_INCREMENT,
--   title VARCHAR(80) NOT NULL,
--   body VARCHAR(255),
--   description VARCHAR(255),
--   isPublished TINYINT NOT NULL,
--   PRIMARY KEY (id)
-- )
-- ALTER TABLE blogs DROP description;
-- ALTER TABLE blogs ADD CreatorEmail varchar(255) NOT NULL;

-- CREATE TABLE tags(
--   id INT NOT NULL AUTO_INCREMENT,
--   title VARCHAR(20) NOT NULL,
--   PRIMARY KEY (id)
-- )

-- CREATE TABLE tagblogs(
--   id INT NOT NULL AUTO_INCREMENT,
--   blogId INT NOT NULL,
--   tagId INT NOT NULL,
--   PRIMARY KEY (id),

--   INDEX (blogId),

--   FOREIGN KEY (blogId)
--     REFERENCES blogs(id)
--     ON DELETE CASCADE,

--   FOREIGN KEY (tagId)
--     REFERENCES tags(id)
--     ON DELETE CASCADE
-- )
-- SELECT * FROM blogs WHERE Id = 7

-- NOTE Execute sql query command with ctrl + alt + e