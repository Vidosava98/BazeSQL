DROP TABLE ANGAZOVANJE_T;
DROP TABLE ANGAZOVANJE_RM;
DROP TABLE VOZI;
DROP TABLE UPRAVLJA;
DROP TABLE SPOLJNI_SARADNIK;
DROP TABLE DEONICA;
DROP TABLE VOZILO;
DROP TABLE GRADILISTE;
DROP TABLE RADNIK;
DROP SEQUENCE  "ID_RADNIKA_SEQ";
DROP SEQUENCE  "ID_DEONICE_SEQ";
DROP SEQUENCE  "ID_VOZILA_SEQ";
DROP SEQUENCE  "ID_SPOLJNOG_RADNIKA_SEQ"; 
DROP SEQUENCE  "ID_UPRAVLJA_SEQ";
DROP SEQUENCE  "ID_VOZI_SEQ";
DROP SEQUENCE  "ID_ANGAZOVANJE_RM_SEQ";
DROP SEQUENCE  "ID_ANGAZOVANJE_T_SEQ";






CREATE TABLE RADNIK
(
 ID_RADNIKA INTEGER PRIMARY KEY,
 GODINA_RODJ VARCHAR2(10) NOT NULL,
 ADRESA VARCHAR2(20) NOT NULL,
 JMBG VARCHAR2(13) NOT NULL UNIQUE,
 IME VARCHAR2(10) NOT NULL,
 PREZIME VARCHAR2(15) NOT NULL,
 IME_OCA VARCHAR2(10) NOT NULL,
 TIP_RADNIKA VARCHAR2(20) NOT NULL,
 SPECIJALNOST VARCHAR2(25) ,
 DATUM_POSTAVLJANJA DATE,
 ID_NADREDJENOG INTEGER,
 CONSTRAINT RADNIK_FK FOREIGN KEY(ID_NADREDJENOG) REFERENCES RADNIK(ID_RADNIKA));


CREATE TABLE GRADILISTE
(
 ID_GRADILISTA INTEGER PRIMARY KEY,
 TIP_GRADILISTA VARCHAR2(20) NOT NULL);

CREATE TABLE DEONICA
(
 ID_DEONICE INTEGER PRIMARY KEY,
 OD_KILOMETARA INTEGER NOT NULL,
 DO_KILOMETARA INTEGER NOT NULL,
 GRAD1 VARCHAR(20) NOT NULL,
 GRAD2 VARCHAR(20) NOT NULL,
 ID_GRADILISTA INTEGER NOT NULL,
 ID_IZVRSIOCA INTEGER,
 POCETAK DATE,
 KRAJ DATE,
 CONSTRAINT DEONICA_FK1 FOREIGN KEY(ID_GRADILISTA) REFERENCES GRADILISTE(ID_GRADILISTA),
 CONSTRAINT DEONICA_FK2 FOREIGN KEY(ID_IZVRSIOCA) REFERENCES RADNIK(ID_RADNIKA));


CREATE TABLE VOZILO
(
 ID_VOZILA INTEGER PRIMARY KEY,
 REGISTRACIJA VARCHAR2(10) NOT NULL UNIQUE,
 BOJA VARCHAR2(10) NOT NULL,
 TIP_GORIVA VARCHAR2(10) NOT NULL,
 ZAPREMINA_MOTORA INTEGER NOT NULL,
 TIP_VOZILA VARCHAR2(15) NOT NULL,
 NOSIVOST INTEGER ,
 BROJ_OSOVINA INTEGER ,
 BROJ_MESTA INTEGER ,
 TIP_RADNE_MASINE VARCHAR2(10)  ,
 TIP_POGONA VARCHAR2(10)  );

CREATE TABLE SPOLJNI_SARADNIK
(
 ID_SPOLJNOG_SARADNIKA INTEGER PRIMARY KEY,
 BR_UGOVORA INTEGER NOT NULL UNIQUE,
 ID_NADZORNIKA INTEGER NOT NULL,
 CONSTRAINT SPOLJNI_SARADNIK_FK FOREIGN KEY (ID_NADZORNIKA) REFERENCES RADNIK(ID_RADNIKA));

CREATE TABLE UPRAVLJA
(
 ID_UPRAVLJA INTEGER PRIMARY KEY,
 POCETAK DATE NOT NULL,
 KRAJ DATE NOT NULL,
 ID_IZVRSIOCA INTEGER NOT NULL,
 ID_VOZILA INTEGER NOT NULL,
 CONSTRAINT UPRAVLJA_FK1 FOREIGN KEY(ID_IZVRSIOCA) REFERENCES RADNIK(ID_RADNIKA),
 CONSTRAINT UPRAVLJA_FK2 FOREIGN KEY (ID_VOZILA) REFERENCES VOZILO(ID_VOZILA) );

 CREATE TABLE VOZI
(
 ID_VOZI INTEGER PRIMARY KEY,
 POCETAK DATE NOT NULL,
 KRAJ DATE NOT NULL,
 ID_NADZORNIKA INTEGER NOT NULL,
 ID_PUTNICKOG INTEGER NOT NULL,
 CONSTRAINT VOZI_FK1 FOREIGN KEY (ID_NADZORNIKA) REFERENCES RADNIK(ID_RADNIKA),
 CONSTRAINT VOZI_FK2 FOREIGN KEY (ID_PUTNICKOG) REFERENCES VOZILO(ID_VOZILA));

CREATE TABLE ANGAZOVANJE_RM
(
 ID_ANGAZOVANJE_RM INTEGER PRIMARY KEY,
 POCETAK DATE NOT NULL,
 KRAJ DATE ,
 ID_RADNE_MASINE INTEGER NOT NULL,
 ID_DEONICE INTEGER NOT NULL,
 CONSTRAINT ANGAZOVANJE_RM_FK1 FOREIGN KEY (ID_RADNE_MASINE) REFERENCES VOZILO(ID_VOZILA),
 CONSTRAINT ANGAZOVANJE_RM_FK2 FOREIGN KEY(ID_DEONICE) REFERENCES DEONICA(ID_DEONICE));



 CREATE TABLE ANGAZOVANJE_T
(
 ID_ANGAZOVANJE_T INTEGER PRIMARY KEY,
 POCETAK DATE NOT NULL,
 KRAJ DATE ,
 ID_TERETNOG INTEGER NOT NULL,
 ID_DEONICE INTEGER NOT NULL,
 CONSTRAINT ANGAZOVANJE_T_FK1 FOREIGN KEY (ID_TERETNOG) REFERENCES VOZILO(ID_VOZILA),
 CONSTRAINT ANGAZOVANJE_T_FK2 FOREIGN KEY (ID_DEONICE) REFERENCES DEONICA(ID_DEONICE));


 

 CREATE SEQUENCE  "ID_RADNIKA_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 ORDER  NOCYCLE;
 CREATE SEQUENCE  "ID_DEONICE_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 ORDER  NOCYCLE;
 CREATE SEQUENCE  "ID_VOZILA_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 ORDER  NOCYCLE;
 CREATE SEQUENCE  "ID_SPOLJNOG_RADNIKA_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 ORDER  NOCYCLE;
 CREATE SEQUENCE  "ID_UPRAVLJA_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 ORDER  NOCYCLE;
 CREATE SEQUENCE  "ID_VOZI_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 ORDER  NOCYCLE;
 CREATE SEQUENCE  "ID_ANGAZOVANJE_RM_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 ORDER  NOCYCLE;
 CREATE SEQUENCE  "ID_ANGAZOVANJE_T_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 ORDER  NOCYCLE;
 



INSERT INTO RADNIK (ID_RADNIKA,GODINA_RODJ,ADRESA,JMBG,IME,PREZIME,IME_OCA,TIP_RADNIKA,SPECIJALNOST,DATUM_POSTAVLJANJA,ID_NADREDJENOG)
VALUES(1,'1980','Koce Racina 27','1001976546337','Boban','Jovanovic','Marko','nadzornik',NULL,'10-Jun-20', null);
INSERT INTO RADNIK (ID_RADNIKA,GODINA_RODJ,ADRESA,JMBG,IME,PREZIME,IME_OCA,TIP_RADNIKA,SPECIJALNOST,DATUM_POSTAVLJANJA,ID_NADREDJENOG)
VALUES(2,'1975','Skadarska 3','1001976546338','Darko','Cvetkovic','Nenad','izvrsioc','kolovoz','14-Jul-20',1);
INSERT INTO RADNIK (ID_RADNIKA,GODINA_RODJ,ADRESA,JMBG,IME,PREZIME,IME_OCA,TIP_RADNIKA,SPECIJALNOST,DATUM_POSTAVLJANJA,ID_NADREDJENOG)
VALUES(3,'1990','Brace Jugovica 79','1001976546339','Aleksandar','Arsic','Goran','izvrsioc','gradska saobracajnica','2-Jul-20',1);
INSERT INTO RADNIK (ID_RADNIKA,GODINA_RODJ,ADRESA,JMBG,IME,PREZIME,IME_OCA,TIP_RADNIKA,SPECIJALNOST,DATUM_POSTAVLJANJA,ID_NADREDJENOG)
VALUES(4,'1995','Beogradska 27','1001976546359','Milos','Ganic','Aleksandar','nadzornik',NULL,'3-Sep-20',1);
INSERT INTO RADNIK (ID_RADNIKA,GODINA_RODJ,ADRESA,JMBG,IME,PREZIME,IME_OCA,TIP_RADNIKA,SPECIJALNOST,DATUM_POSTAVLJANJA,ID_NADREDJENOG)
VALUES(5,'1998','Nemanjina 7','1001976546347','Janko','Jovanovic','Marko','izvrsioc','kolovoz','26-Jan-20',1);
INSERT INTO RADNIK (ID_RADNIKA,GODINA_RODJ,ADRESA,JMBG,IME,PREZIME,IME_OCA,TIP_RADNIKA,SPECIJALNOST,DATUM_POSTAVLJANJA,ID_NADREDJENOG)
VALUES(6,'1974','Markovska 2','1001976546837','Zelimir','Simic','Cvetko','nadzornik',NULL,'23-Jan-20', null);
INSERT INTO RADNIK (ID_RADNIKA,GODINA_RODJ,ADRESA,JMBG,IME,PREZIME,IME_OCA,TIP_RADNIKA,SPECIJALNOST,DATUM_POSTAVLJANJA,ID_NADREDJENOG)
VALUES(7,'1987','Zagrebacka 33','1001979546337','Jovan','Bankovic','Stefan','nadzornik',NULL,'16-Jan-20',6);
INSERT INTO RADNIK (ID_RADNIKA,GODINA_RODJ,ADRESA,JMBG,IME,PREZIME,IME_OCA,TIP_RADNIKA,SPECIJALNOST,DATUM_POSTAVLJANJA,ID_NADREDJENOG)
VALUES(8,'1969','Partizanski put 7','1001986546337','Nikola','Antic','Vojin','izvrsioc','gradska saobracajnica','18-Jan-20',1);
INSERT INTO RADNIK (ID_RADNIKA,GODINA_RODJ,ADRESA,JMBG,IME,PREZIME,IME_OCA,TIP_RADNIKA,SPECIJALNOST,DATUM_POSTAVLJANJA,ID_NADREDJENOG)
VALUES(9,'1978','Beogradska 65','1881976546337','Nemanja','Tasic','Zarko','izvrsioc','kolovoz','1-Jun-20',6);
INSERT INTO RADNIK (ID_RADNIKA,GODINA_RODJ,ADRESA,JMBG,IME,PREZIME,IME_OCA,TIP_RADNIKA,SPECIJALNOST,DATUM_POSTAVLJANJA,ID_NADREDJENOG)
VALUES(10,'1993','Mirka Goce 45','1001446546337','Milan','Mladenovic','Spasa','nadzornik',NULL,'8-Sep-20',6);









INSERT INTO GRADILISTE ( ID_GRADILISTA,TIP_GRADILISTA)
VALUES(1, 'IZGRADNJA');
INSERT INTO GRADILISTE ( ID_GRADILISTA,TIP_GRADILISTA)
VALUES(2, 'IZGRADNJA');
INSERT INTO GRADILISTE ( ID_GRADILISTA,TIP_GRADILISTA)
VALUES(3, 'REKONSTRUKCIJA');
INSERT INTO GRADILISTE ( ID_GRADILISTA,TIP_GRADILISTA)
VALUES(4, 'IZGRADNJA');
INSERT INTO GRADILISTE ( ID_GRADILISTA,TIP_GRADILISTA)
VALUES(5, 'REKONSTRUKCIJA');
INSERT INTO GRADILISTE ( ID_GRADILISTA,TIP_GRADILISTA)
VALUES(6, 'IZGRADNJA');
INSERT INTO GRADILISTE ( ID_GRADILISTA,TIP_GRADILISTA)
VALUES(7, 'REKONSTRUKCIJA');
INSERT INTO GRADILISTE ( ID_GRADILISTA,TIP_GRADILISTA)
VALUES(8, 'IZGRADNJA');



Insert into VOZILO (ID_VOZILA,REGISTRACIJA,BOJA, TIP_GORIVA, ZAPREMINA_MOTORA,TIP_VOZILA, NOSIVOST, BROJ_OSOVINA,BROJ_MESTA, TIP_RADNE_MASINE, TIP_POGONA) 
values (1,'NI123EF','crna','dizel',2140,'putnicka',null, null, 4, null, null);
Insert into VOZILO (ID_VOZILA,REGISTRACIJA,BOJA, TIP_GORIVA, ZAPREMINA_MOTORA,TIP_VOZILA, NOSIVOST, BROJ_OSOVINA,BROJ_MESTA, TIP_RADNE_MASINE, TIP_POGONA) 
values (2,'BG458RE','siva','dizel',2000,'putnicka',null, null, 4, null, null);
Insert into VOZILO (ID_VOZILA,REGISTRACIJA,BOJA, TIP_GORIVA, ZAPREMINA_MOTORA,TIP_VOZILA, NOSIVOST, BROJ_OSOVINA,BROJ_MESTA, TIP_RADNE_MASINE, TIP_POGONA) 
values (3,'NI569TG','bela','dizel',1958,'teretna', 4, 4, null, null, null);
Insert into VOZILO (ID_VOZILA,REGISTRACIJA,BOJA, TIP_GORIVA, ZAPREMINA_MOTORA,TIP_VOZILA, NOSIVOST, BROJ_OSOVINA,BROJ_MESTA, TIP_RADNE_MASINE, TIP_POGONA) 
values (4,'NI001IJ','siva','benzin',2500,'teretna', 3, 2,null, null, null);
Insert into VOZILO (ID_VOZILA,REGISTRACIJA,BOJA, TIP_GORIVA, ZAPREMINA_MOTORA,TIP_VOZILA, NOSIVOST, BROJ_OSOVINA,BROJ_MESTA, TIP_RADNE_MASINE, TIP_POGONA) 
values (5,'BG659LO','crna','benzin',2480,'teretna', 2, 4, null, null, null);
Insert into VOZILO (ID_VOZILA,REGISTRACIJA,BOJA, TIP_GORIVA,ZAPREMINA_MOTORA,TIP_VOZILA, NOSIVOST, BROJ_OSOVINA,BROJ_MESTA, TIP_RADNE_MASINE, TIP_POGONA) 
values (6,'NS2233KH','zelena','benzin',2021,'radna ma�ina',null, null, null, 'rovokopac', 'tocka�');
Insert into VOZILO (ID_VOZILA,REGISTRACIJA,BOJA, TIP_GORIVA,ZAPREMINA_MOTORA,TIP_VOZILA, NOSIVOST, BROJ_OSOVINA,BROJ_MESTA, TIP_RADNE_MASINE, TIP_POGONA) 
values (7,'VR573BV','crna','benzin',2850,'radna ma�ina',null, null, null, 'rovokopac', 'gusenicar');
Insert into VOZILO (ID_VOZILA,REGISTRACIJA,BOJA, TIP_GORIVA,ZAPREMINA_MOTORA,TIP_VOZILA, NOSIVOST, BROJ_OSOVINA,BROJ_MESTA, TIP_RADNE_MASINE, TIP_POGONA) 
values (8,'VR978JG','siva','dizel','2485','radna ma�ina',null, null, null, 'utovarivac', 'tocka�');
Insert into VOZILO (ID_VOZILA,REGISTRACIJA,BOJA,TIP_GORIVA,ZAPREMINA_MOTORA,TIP_VOZILA, NOSIVOST, BROJ_OSOVINA,BROJ_MESTA, TIP_RADNE_MASINE, TIP_POGONA) 
values (9,'LE129FT','crna','dizel',2000,'putnicka', null, null, 4, null, null);
Insert into VOZILO (ID_VOZILA,REGISTRACIJA,BOJA, TIP_GORIVA,ZAPREMINA_MOTORA,TIP_VOZILA, NOSIVOST, BROJ_OSOVINA,BROJ_MESTA, TIP_RADNE_MASINE, TIP_POGONA) 
values (10,'AL987RD','crna','benzin',2200,'putnicka', null, null,5, null, null);


Insert into SPOLJNI_SARADNIK(ID_SPOLJNOG_SARADNIKA,BR_UGOVORA, ID_NADZORNIKA)
values(1,23,6);
Insert into SPOLJNI_SARADNIK(ID_SPOLJNOG_SARADNIKA,BR_UGOVORA, ID_NADZORNIKA)
values(2,30,5);
Insert into SPOLJNI_SARADNIK(ID_SPOLJNOG_SARADNIKA,BR_UGOVORA, ID_NADZORNIKA)
values(3,27,4);
Insert into SPOLJNI_SARADNIK(ID_SPOLJNOG_SARADNIKA,BR_UGOVORA, ID_NADZORNIKA)
values(4,16,3);
Insert into SPOLJNI_SARADNIK(ID_SPOLJNOG_SARADNIKA,BR_UGOVORA, ID_NADZORNIKA)
values(5,9,2);
Insert into SPOLJNI_SARADNIK(ID_SPOLJNOG_SARADNIKA,BR_UGOVORA, ID_NADZORNIKA)
values(6,7,1);




Insert into DEONICA(ID_DEONICE,OD_KILOMETARA,DO_KILOMETARA,GRAD1,GRAD2,ID_GRADILISTA,ID_IZVRSIOCA, POCETAK, KRAJ)
values(1,23,66,'Uzice','Cacak',1,9,'01-APR-19','13-Apr-20');
Insert into DEONICA(ID_DEONICE,OD_KILOMETARA,DO_KILOMETARA,GRAD1,GRAD2,ID_GRADILISTA,ID_IZVRSIOCA, POCETAK, KRAJ)
values(2,5,15,'Uzice','Cacak',1,9,'01-Sep-20','13-Apr-21');
Insert into DEONICA(ID_DEONICE,OD_KILOMETARA,DO_KILOMETARA,GRAD1,GRAD2,ID_GRADILISTA,ID_IZVRSIOCA, POCETAK, KRAJ)
values(3,25,60,'Beograd','Vranje',2,5,'07-APR-19','30-Apr-20');
Insert into DEONICA(ID_DEONICE,OD_KILOMETARA,DO_KILOMETARA,GRAD1,GRAD2,ID_GRADILISTA,ID_IZVRSIOCA, POCETAK, KRAJ)
values(4,23,80,'Beograd','Nis',3,8,'01-Sep-18','13-Apr-20');
Insert into DEONICA(ID_DEONICE,OD_KILOMETARA,DO_KILOMETARA,GRAD1,GRAD2,ID_GRADILISTA,ID_IZVRSIOCA, POCETAK, KRAJ)
values(5,100,120,'Beograd','Vranje',2,5,'23-APR-15','13-Apr-20');
Insert into DEONICA(ID_DEONICE,OD_KILOMETARA,DO_KILOMETARA,GRAD1,GRAD2,ID_GRADILISTA,ID_IZVRSIOCA, POCETAK, KRAJ)
values(6,30,45,'Vranje','Leskovac',4,3,'01-APR-17','23-Apr-20');
Insert into DEONICA(ID_DEONICE,OD_KILOMETARA,DO_KILOMETARA,GRAD1,GRAD2,ID_GRADILISTA,ID_IZVRSIOCA, POCETAK, KRAJ)
values(7,2,72,'Novi Sad','Beograd',8,2,'01-Jun-10','13-Apr-22');
Insert into DEONICA(ID_DEONICE,OD_KILOMETARA,DO_KILOMETARA,GRAD1,GRAD2,ID_GRADILISTA,ID_IZVRSIOCA, POCETAK, KRAJ)
values(8,80,140,'Beograd','Nis',3,8,'01-Sep-17','13-Apr-21');





Insert into UPRAVLJA(ID_UPRAVLJA,POCETAK, KRAJ, ID_IZVRSIOCA, ID_VOZILA)
values(1,'06-APR-19', '16-APR-19', 9, 1);
Insert into UPRAVLJA(ID_UPRAVLJA,POCETAK, KRAJ, ID_IZVRSIOCA, ID_VOZILA)
values(2,'04-FEB-19', '10-FEB-19', 2, 5);
Insert into UPRAVLJA(ID_UPRAVLJA,POCETAK, KRAJ, ID_IZVRSIOCA, ID_VOZILA)
values(3,'17-JUN-18', '28-JUL-18', 9, 4);
Insert into UPRAVLJA(ID_UPRAVLJA,POCETAK, KRAJ, ID_IZVRSIOCA, ID_VOZILA)
values(4,'01-MAR-19', '14-MAR-19', 9, 9);
Insert into UPRAVLJA(ID_UPRAVLJA,POCETAK, KRAJ, ID_IZVRSIOCA, ID_VOZILA)
values(5,'05-SEP-18', '28-SEP-18', 9, 9);
Insert into UPRAVLJA(ID_UPRAVLJA,POCETAK, KRAJ, ID_IZVRSIOCA, ID_VOZILA)
values(6,'01-OCT-17', '23-OCT-17', 2, 7);



Insert into VOZI(ID_VOZI,POCETAK,KRAJ,ID_NADZORNIKA,ID_PUTNICKOG)
values(1,'11-JAN-19','15-JAN-19',4,1);
Insert into VOZI(ID_VOZI,POCETAK,KRAJ,ID_NADZORNIKA,ID_PUTNICKOG)
values(2,'15-JAN-19','21-JAN-19',7,2);
Insert into VOZI(ID_VOZI,POCETAK,KRAJ,ID_NADZORNIKA,ID_PUTNICKOG)
values(3,'16-JAN-19','21-JAN-19',7,9);
Insert into VOZI(ID_VOZI,POCETAK,KRAJ,ID_NADZORNIKA,ID_PUTNICKOG)
values(4,'23-JAN-19','25-JAN-19',1,9);
Insert into VOZI(ID_VOZI,POCETAK,KRAJ,ID_NADZORNIKA,ID_PUTNICKOG)
values(5,'01-FEB-19','15-FEB-19',1,10);
Insert into VOZI(ID_VOZI,POCETAK,KRAJ,ID_NADZORNIKA,ID_PUTNICKOG)
values(6,'09-JAN-19','13-JAN-19',6,10);
Insert into VOZI(ID_VOZI,POCETAK,KRAJ,ID_NADZORNIKA,ID_PUTNICKOG)
values(7,'07-APR-19','12-APR-19',1,10);
Insert into VOZI(ID_VOZI,POCETAK,KRAJ,ID_NADZORNIKA,ID_PUTNICKOG)
values(8,'14-APR-19','21-APR-19',6,9);
Insert into VOZI(ID_VOZI,POCETAK,KRAJ,ID_NADZORNIKA,ID_PUTNICKOG)
values(9,'27-JAN-19','29-JAN-19',4,10);
Insert into VOZI(ID_VOZI,POCETAK,KRAJ,ID_NADZORNIKA,ID_PUTNICKOG)
values(10,'28-JUN-19','30-JUN-19',1,1);



Insert into ANGAZOVANJE_RM(ID_ANGAZOVANJE_RM, POCETAK, KRAJ, ID_RADNE_MASINE, ID_DEONICE)
values(1,'11-JAN-19','15-JAN-19',6,3);
Insert into ANGAZOVANJE_RM(ID_ANGAZOVANJE_RM, POCETAK, KRAJ, ID_RADNE_MASINE, ID_DEONICE)
values(2,'15-JAN-19','21-JAN-19',7,4);
Insert into ANGAZOVANJE_RM(ID_ANGAZOVANJE_RM, POCETAK, KRAJ, ID_RADNE_MASINE, ID_DEONICE)
values(3,'21-JAN-19','28-JAN-19',7,5);
Insert into ANGAZOVANJE_RM(ID_ANGAZOVANJE_RM, POCETAK, KRAJ, ID_RADNE_MASINE, ID_DEONICE)
values(4,'23-JAN-19','25-JAN-19',8,6);
Insert into ANGAZOVANJE_RM(ID_ANGAZOVANJE_RM, POCETAK, KRAJ, ID_RADNE_MASINE, ID_DEONICE)
values(5,'01-FEB-19','15-FEB-19',8,7);


Insert into ANGAZOVANJE_T(ID_ANGAZOVANJE_T, POCETAK, KRAJ, ID_TERETNOG, ID_DEONICE)
values(1,'11-JAN-19','15-JAN-19',3,3);
Insert into ANGAZOVANJE_T(ID_ANGAZOVANJE_T, POCETAK, KRAJ, ID_TERETNOG, ID_DEONICE)
values(2,'15-JAN-19','21-JAN-19',4,4);
Insert into ANGAZOVANJE_T(ID_ANGAZOVANJE_T, POCETAK, KRAJ, ID_TERETNOG, ID_DEONICE)
values(3,'21-JAN-19','28-JAN-19',4,8);
Insert into ANGAZOVANJE_T(ID_ANGAZOVANJE_T, POCETAK, KRAJ, ID_TERETNOG, ID_DEONICE)
values(4,'23-JAN-19','25-JAN-19',5,6);
Insert into ANGAZOVANJE_T(ID_ANGAZOVANJE_T, POCETAK, KRAJ, ID_TERETNOG, ID_DEONICE)
values(5,'01-FEB-19','15-FEB-19',3,1);





