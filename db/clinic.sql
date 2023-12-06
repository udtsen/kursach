CREATE DATABASE IF NOT EXISTS clinic;
USE clinic;

CREATE TABLE IF NOT EXISTS clinic.Profiles (
	id INTEGER AUTO_INCREMENT,
	title VARCHAR(50) NOT NULL,
    PRIMARY KEY (id),
    UNIQUE (title)
);

INSERT INTO clinic.Profiles
    (title)
VALUES
   ('Лікар-невролог'),
   ('Лікар-алерголог'),
   ('Лікар-гастроентеролог'),
   ('Лікар-імунолог'),
   ('Лікар-кардіолог'),
   ('Лікар-травматолог'),
   ('Лікар-рентгенолог'),
   ('Лікар-терапевт');
   
CREATE TABLE IF NOT EXISTS clinic.Doctors (
	id INTEGER AUTO_INCREMENT,
	name VARCHAR(50) NOT NULL,
    surname VARCHAR(100) NOT NULL,
    experience SMALLINT NOT NULL,
    category VARCHAR(100) NOT NULL,
    profile_id INTEGER NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (profile_id) REFERENCES clinic.Profiles(id)
);

INSERT INTO clinic.Doctors
    (name, surname, experience, category, profile_id)
VALUES
    ('Олег', 'Михайленко', 6, 'Друга кваліфікаційна категорія', 1),
    ('Іван', 'Семенов', 9, 'Перша кваліфікаційна категорія', 2),
    ('Ірина', 'Оніщенко', 15, 'Вища кваліфікаційна категорія', 3),
    ('Антон', 'Малишев', 27, 'Вища кваліфікаційна категорія, к.м.н.', 4),
    ('Олена', 'Федорова', 11, 'Вища кваліфікаційна категорія', 5);

CREATE TABLE IF NOT EXISTS clinic.Schedules (
	id INTEGER AUTO_INCREMENT,
    doctor_id INTEGER NOT NULL,
    date DATE NOT NULL,
    start_time TIME NOT NULL,
    end_time TIME NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (doctor_id) REFERENCES clinic.Doctors (id)
);

INSERT INTO clinic.Schedules
    (doctor_id, date, start_time, end_time)
VALUES
   (1, CURDATE(), '08:00:00', '08:30:00'),
   (1, CURDATE(), '08:30:00', '09:00:00'),
   (1, CURDATE(), '09:00:00', '09:30:00'),
   (1, CURDATE(), '09:30:00', '10:00:00'),
   (2, CURDATE(), '11:00:00', '12:00:00'),
   (2, CURDATE(), '12:00:00', '13:00:00'),
   (2, CURDATE(), '13:00:00', '14:00:00'),
   (2, CURDATE(), '16:00:00', '16:30:00'),
   (3, CURDATE(), '16:30:00', '17:00:00'),
   (3, CURDATE(), '17:00:00', '17:30:00'),
   (3, CURDATE(), '17:30:00', '18:00:00'),
   (4, CURDATE() + INTERVAL 1 DAY, '12:00:00', '13:00:00'),
   (4, CURDATE() + INTERVAL 1 DAY, '13:00:00', '14:00:00'),
   (4, CURDATE() + INTERVAL 1 DAY, '14:00:00', '15:00:00'),
   (5, CURDATE() + INTERVAL 1 DAY, '09:00:00', '09:30:00'),
   (5, CURDATE() + INTERVAL 1 DAY, '09:30:00', '10:00:00'),
   (5, CURDATE() + INTERVAL 1 DAY, '10:00:00', '10:30:00');

CREATE TABLE IF NOT EXISTS clinic.Patients (
	id INTEGER AUTO_INCREMENT,
	name VARCHAR(50) NOT NULL,
    surname VARCHAR(100) NOT NULL,
    age SMALLINT NOT NULL, 
    gender ENUM('Жіноча стать', 'Чоловіча стать'),
    PRIMARY KEY (id)
);

INSERT INTO clinic.Patients
    (name, surname, age, gender)
VALUES
    ('Ольга', 'Матросова', 38, 'Жіноча стать'),
    ('Іван', 'Александренко', 65, 'Чоловіча стать'),
    ('Максим', 'Петренко', 51, 'Чоловіча стать');

CREATE TABLE IF NOT EXISTS clinic.Consultations (
	id INTEGER AUTO_INCREMENT,
    patient_id INTEGER NOT NULL,
    schedule_id INTEGER NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (patient_id) REFERENCES clinic.Patients (id),
    FOREIGN KEY (schedule_id) REFERENCES clinic.Schedules (id),
    CONSTRAINT unique_schedule_id UNIQUE (schedule_id) 
);

INSERT INTO clinic.Consultations
    (patient_id, schedule_id)
VALUES
    (1, 1),
    (2, 2),
    (3, 5);


SELECT s.doctor_id, COUNT(s.doctor_id) as consultations_quantity
FROM Schedules s
RIGHT JOIN Consultations c ON c.schedule_id=s.id
GROUP BY s.doctor_id
ORDER BY consultations_quantity DESC
LIMIT 1;



