
/* Write a query to display the member id, member name, city and membership status who are all having life time membership. Hint: Life time membership status is “Permanent”.*/
SELECT MEMBER_ID, MEMBER_NAME, CITY, MEMBERSHIP_STATUS
FROM LMS_MEMBERS
WHERE MEMBERSHIP_STATUS = 'Permanent';

/* Write a query to display the member id, member name who have not returned the books. Hint: Book return status is book_issue_status ='Y' or 'N'. */
SELECT M.MEMBER_ID, M.MEMBER_NAME
FROM LMS_MEMBERS M
JOIN LMS_BOOK_ISSUE B
    ON M.MEMBER_ID = B.MEMBER_ID
WHERE B.BOOK_ISSUE_STATUS = 'N';

/* Write a query to display the member id, member name who have taken the book with book code 'BL000002'. */
SELECT M.MEMBER_ID, M.MEMBER_NAME
FROM LMS_MEMBERS M
JOIN LMS_BOOK_ISSUE B
    ON M.MEMBER_ID = B.MEMBER_ID
WHERE B.BOOK_CODE = 'BL000002';

/* Write a query to display the book code, book title and author of the books whose author name begins with 'P'. */
SELECT BOOK_CODE, BOOK_TITLE, AUTHOR
FROM LMS_BOOK_DETAILS
WHERE AUTHOR LIKE 'P%';

/* Write a query to display the total number of Java books available in library with alias name ‘NO_OF_BOOKS’. */
SELECT COUNT(*) AS NO_OF_BOOKS
FROM LMS_BOOK_DETAILS
WHERE CATEGORY = 'JAVA';

/* Write a query to list the category and number of books in each category with alias name ‘NO_OF_BOOKS’. */
SELECT CATEGORY, COUNT(*) AS NO_OF_BOOKS
FROM LMS_BOOK_DETAILS
GROUP BY CATEGORY;

/* Write a query to display the number of books published by "Prentice Hall” with the alias name “NO_OF_BOOKS”. */
SELECT COUNT(*) AS NO_OF_BOOKS
FROM LMS_BOOK_DETAILS
WHERE PUBLICATION = 'Prentice Hall';

/* Write a query to display the book code, book title of the books which are issued on the date "1st April 2012". */
SELECT BD.BOOK_CODE, BD.BOOK_TITLE
FROM LMS_BOOK_DETAILS BD
JOIN LMS_BOOK_ISSUE BI
    ON BD.BOOK_CODE = BI.BOOK_CODE
WHERE BI.DATE_ISSUE = '2012-04-01';

/* Write a query to display the member id, member name, date of registration and expiry date of the members whose membership expiry date is before APR 2013. */
SELECT MEMBER_ID,
       MEMBER_NAME,
       DATE_REGISTER,
       DATE_EXPIRE
FROM LMS_MEMBERS
WHERE DATE_EXPIRE < '2013-04-01';

/* write a query to display the member id, member name, date of registration, membership status of the members who registered before "March 2012" and membership status is "Temporary" */
SELECT MEMBER_ID,
       MEMBER_NAME,
       DATE_REGISTER,
       MEMBERSHIP_STATUS
FROM LMS_MEMBERS
WHERE DATE_REGISTER < '2012-03-01'
  AND MEMBERSHIP_STATUS = 'Temporary';