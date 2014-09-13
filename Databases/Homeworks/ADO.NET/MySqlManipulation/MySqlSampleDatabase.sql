CREATE TABLE `books` (
  `booksID` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(45) DEFAULT NULL,
  `author` varchar(45) DEFAULT NULL,
  `publishDate` datetime DEFAULT NULL,
  `ISBN` varchar(13) DEFAULT NULL,
  PRIMARY KEY (`booksID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

INSERT INTO `bookstore`.`books`
(`title`,
`author`,
`publishDate`,
`ISBN`)
VALUES
('Killing Floor',
'Lee Child',
'1997-03-01',
'0-515-12344-7');
