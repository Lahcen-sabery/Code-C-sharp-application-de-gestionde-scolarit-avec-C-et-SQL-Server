create database gestiondescolarité
use gestiondescolarité 
/*table compte pour chaque personne*/
create table Compte(
logine varchar(20) NOT NULL ,
modpasse varchar(8) NOT NULL,
profil varchar(20)
 )
 /*Table etudiant*/
create table Etudiant 
Nom varchar(20) Not null,
Prenom varchar(20)NOT NULL,
Sexe varchar(20) NOT NULL,
Date_niss date NOT NULL,
CNE varchar(15)NOT NULL Primary key,
CIN varchar(20)NOT NULL ,
Specialité varchar(20)NOT NULL,
Email varchar(30)NOT NULL ,
Tel varchar(10) NOT NULL
)

/*Table professeur*/
create table Professeur(
Nom varchar(20) NOT NULL,
Prenom varchar(20)NOT NULL,
Sexe varchar(20) NOT NULL,
Date_naiss Date NOT NULL,
CIN varchar(20) not NULL primary key,
Email varchar(30) NOT NULL,
Tel varchar(20) NOT NULL,
Moduleens varchar(20) Foreign key References Module(Nommod))
/*table professeur*/
create table surveillance(

Nom varchar(20) NOT NULL,
Prenom varchar(20)NOT NULL,
Date_niss date NOT NULL,
CIN varchar(20) NOT NULL primary key,
Email varchar(30)NOT NULL ,
Tel varchar(10) NOT NULL)
/*	Table Module*/
create table Examen(
Nommodule varchar(20) foreign key references Module(Nommod),
CNE varchar(15) foreign key references Etudiant(CNE),
Date_exam date,
Note float,
ProfesseurEns varchar(20),
DureeExam int)
/*Table Module*/
create table Module( 
Nommod varchar(20) Primary key,
filiere varchar(20),
semestre varchar(20)
)

/*Table filière*/
go
create table Filière (Nomfilière varchar(20),
CodeE varchar(20))
go
 /* trigger qui interdit la creation d'une compte s'il existe d'éja  */
 create trigger T1
 on Compte
instead of insert,update
 as
 begin
 if exists(select logine from inserted where logine in (select logine from Compte) and (logine not in (select logine from deleted)))
 begin
 RAISERROR('logine exist déja',16,1)
 rollback
 end
 if exists(select modpasse from inserted where modpasse in (select modpasse from Compte)and (modpasse not in (select modpasse from deleted)))
 begin
 RAISERROR('mod de passe exist déja',16,1)
 rollback
 end
 if exists (select Profil from inserted where profil not in ( 'Surveillance','Etudiant','Professeur'))
 begin
 RAISERROR('interdit de creer de compte a ce profile la just cet application et pour surveillance ou etudiant ou professeur ',16,1)
 rollback
 end
 else
 begin
 insert into Compte select * from inserted;
 end
 end
 /* trigger qui interdit  à l'insertion ou à la modification de la table Etudiant la dublication de CIN  et auusi il remplire automatiquement la table Filiere  */
 go
 Alter trigger T2
 on Etudiant
instead of insert,update
 as
 begin
 if exists(select CIN from inserted where CIN in (select CIN from Etudiant) and CIN not in (select CIN from deleted))
 begin
 RAISERROR('CIN exist déja',16,1)
 rollback
 end
 else 
 insert into Etudiant select * from inserted
 insert into Filière select Specialité,CNE From inserted
 end

 /* trigger qui à l'insetion sur la table Professeur interdit la saisie de matiere enseigne s'il nexiste pas dans la table module*/

  create trigger T3
 on Professeur
for insert,update
 as
 begin
 if exists(select Moduleens from inserted where Moduleens  not in (select Nommod from Module))
 begin
 RAISERROR('Module insairer nexiste pas dans la table module',16,1)
 rollback
 end
 end

 /*trigger qui interdit l'insertion de code Etudiant dans la table filiere s'il nexiste pas dans la table etudiant et aussi l'inscription de meme etudiant dans plus d'un filiere*/
 create trigger T5
 on Filière
 for insert
 as
 if exists (select codeE from inserted where codeE not in(select CNE from Etudiant ))
 begin
 raiserror('Etudiant nest pas inscrit dans notre Etablissement',16,1)
 Rollback
 end
 if exists (select codeE from inserted where codeE not in(select CNE from Etudiant ))
 begin
 raiserror('Etudiant déja inscrit dans une filiere',16,1)
 Rollback
 end
 /* interdit  à l'insertion ou à la modification  des notes <0 ou >20 sur la table Examen et aussi l'insertion d'un professeur qui n'enseigner pas le module consernons
 et aussi l'annonce de date  d'exam il faut etre avant l'examen par trois jours au minimum */
 alter trigger T6
 on Examen
 for insert, update
 as
 begin
 if exists (select Note from inserted where Note<0 or Note>20)
 begin
 raiserror('Note saisir et invalid',15,1)
 rollback
 end
 if ( datediff(day,getdate(),(select Date_exam from inserted))<3)
 begin
 raiserror('date invalide il faut que la nonce etre avant Lexamen par trois jours ',15,1)
 rollback
 end
 if exists (select ProfesseurEns  from inserted  where ProfesseurEns not in( select P.Nom+' '+P.Prenom from Professeur P, Inserted I where P.Moduleens=I.Nommodule ))
 begin
 raiserror('le nom de professeur incorrect',15,1)
 rollback
 end
 end
 /* trigger qui permet de supprimer toute les information d'un etudiant losrqu'il est supprimer dans la table etudiant*/

 Alter trigger T7
 on Etudiant
instead of delete
 as
 begin
 declare @cne varchar(20)
set @cne = (select CNE from deleted)
delete from Examen where CNE=@cne
delete from Filière where CodeE=@cne
delete from Compte where logine=@cne
delete from Etudiant where CNE=@cne
end

