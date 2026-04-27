CREATE TABLE Members (
    MID INT PRIMARY KEY IDENTITY(300,1),
    MemberName VARCHAR(100),
    PhoneNo VARCHAR(20),
    BookName VARCHAR(100),
    Author VARCHAR(100),
    IssueDate DATE,
    ReturnDate DATE,
    Fees INT,
    Status VARCHAR(20),
    Photo VARBINARY(MAX)
);
delete from Members;
drop table Members;

INSERT INTO Members (MemberName, PhoneNo, BookName, Author, IssueDate, ReturnDate, Fees, Status) VALUES
('Ali Khan', '03001234567', 'The Silent Patient', 'Alex Michaelides', '2024-06-01', '2024-06-10', 100, 'Returned'),
('Sara Ahmed', '03011234567', 'Atomic Habits', 'James Clear', '2024-06-02', '2024-06-12', 150, 'Not Returned'),
('Usman Raza', '03021234567', 'Rich Dad Poor Dad', 'Robert Kiyosaki', '2024-06-03', '2024-06-13', 200, 'Returned'),
('Zainab Bukhari', '03031234567', 'Ikigai', 'Héctor García', '2024-06-04', '2024-06-14', 120, 'Not Returned'),
('Hassan Shah', '03041234567', 'Deep Work', 'Cal Newport', '2024-06-05', '2024-06-15', 100, 'Returned'),
('Mehwish Fatima', '03051234567', 'The Alchemist', 'Paulo Coelho', '2024-06-06', '2024-06-16', 90, 'Returned'),
('Bilal Tariq', '03061234567', 'Sapiens', 'Yuval Noah Harari', '2024-06-07', '2024-06-17', 160, 'Not Returned'),
('Ayesha Malik', '03071234567', 'Start With Why', 'Simon Sinek', '2024-06-08', '2024-06-18', 130, 'Returned'),
('Hamza Yousuf', '03081234567', 'Thinking Fast and Slow', 'Daniel Kahneman', '2024-06-09', '2024-06-19', 110, 'Not Returned'),
('Nimra Asad', '03091234567', 'Man’s Search for Meaning', 'Viktor Frankl', '2024-06-10', '2024-06-20', 100, 'Returned'),
('Tariq Mehmood', '03101234567', 'The Power of Habit', 'Charles Duhigg', '2024-06-11', '2024-06-21', 140, 'Returned'),
('Marium Khan', '03111234567', 'Grit', 'Angela Duckworth', '2024-06-12', '2024-06-22', 150, 'Not Returned'),
('Junaid Iqbal', '03121234567', '12 Rules for Life', 'Jordan Peterson', '2024-06-13', '2024-06-23', 180, 'Returned'),
('Iqra Shah', '03131234567', 'Educated', 'Tara Westover', '2024-06-14', '2024-06-24', 200, 'Returned'),
('Waleed Anwar', '03141234567', 'Can’t Hurt Me', 'David Goggins', '2024-06-15', '2024-06-25', 160, 'Not Returned'),
('Rabia Naseer', '03151234567', 'Daring Greatly', 'Brené Brown', '2024-06-16', '2024-06-26', 170, 'Returned'),
('Adeel Hussain', '03161234567', 'Make Your Bed', 'William McRaven', '2024-06-17', '2024-06-27', 110, 'Returned'),
('Sana Yaqoob', '03171234567', 'Rework', 'Jason Fried', '2024-06-18', '2024-06-28', 100, 'Not Returned'),
('Ahmad Shahid', '03181234567', 'The Subtle Art of Not Giving a F*ck', 'Mark Manson', '2024-06-19', '2024-06-29', 90, 'Returned'),
('Hina Zafar', '03191234567', 'Mindset', 'Carol Dweck', '2024-06-20', '2024-06-30', 130, 'Returned');


select * from Members;