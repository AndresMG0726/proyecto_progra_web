use master;
	
CREATE DATABASE PRUEBA1;

USE PRUEBA1;

CREATE TABLE rol(           
	id_rol int IDENTITY(1,1),              
	desc_rol varchar(100) NOT NULL,     
    PRIMARY KEY (id_rol));
    
	GO

CREATE TABLE rol_contacto(           
	id_rol_cont int IDENTITY(1,1),              
	desc_rol_cont varchar(100) NOT NULL,     
    PRIMARY KEY (id_rol_cont));
    
	GO

CREATE TABLE job(           
	id_job int IDENTITY(1,1) NOT NULL,              
	descripcion_job varchar(100) NOT NULL,     
    PRIMARY KEY (id_job));
	GO

CREATE TABLE departamento(           
	id_departamento int IDENTITY(1,1) NOT NULL,              
	descripcion_departamento varchar(100) NOT NULL,     
    PRIMARY KEY (id_departamento));
	GO

CREATE TABLE estado(           
	id_estado int IDENTITY(1,1) NOT NULL,              
	descripcion_estado varchar(100) NOT NULL,     
    PRIMARY KEY (id_estado));
	GO

CREATE TABLE tipo(           
	id_tipo int IDENTITY(1,1) NOT NULL,              
	descripcion_tipo varchar(100) NOT NULL,     
    PRIMARY KEY (id_tipo));
	GO


CREATE TABLE usuario(                                                                      
    id_usuario int IDENTITY(1,1) NOT NULL,
	id_rol int NOT NULL,
   	usuario varchar(100) NOT NULL,
	contrasenna varchar(100) NOT NULL, 
	email varchar(100) NOT NULL,
	telefono int NOT NULL,
    nombre_usuario varchar(100) NOT NULL, 
	primer_apellido_usuario varchar(100) NOT NULL,    
    segundo_apellido_usuario varchar(100) NOT NULL,    
	id_job int NOT NULL, 
	id_departamento int NOT NULL,
    encargado int NOT NULL,                                                               
    Contrasenna_usuario varchar(200) NOT NULL,                                                                
	fechaContratacion date,
    PRIMARY KEY (id_usuario),                                              
	FOREIGN KEY (id_rol) REFERENCES rol (id_rol), 
	FOREIGN KEY (id_job) REFERENCES job (id_job), 
    FOREIGN KEY (id_departamento) REFERENCES departamento (id_departamento));

	CREATE TABLE infoContactoUsuario(           
	id_info int IDENTITY(1,1) NOT NULL,
	id_usuario int NOT NULL,              
	NombreCompletoContacto varchar(100) NOT NULL,  
	id_rol_cont int  NOT NULL,    
	telefono_contacto int NOT NULL,
    PRIMARY KEY (id_info),
	FOREIGN KEY (id_rol_cont) REFERENCES rol_contacto (id_rol_cont),
	FOREIGN KEY (id_usuario) REFERENCES usuario (id_usuario));
	GO

	CREATE TABLE solicitud(           
	id_solicitud int IDENTITY(1,1) NOT NULL,
	id_usuario int NOT NULL,              
	id_estado int NOT NULL,  
	id_tipo int  NOT NULL,
	ComentarioSolicitante varchar(100) NOT NULL, 
	ComentarioEncargado varchar(100) NOT NULL,
	fecha_emicion date
    PRIMARY KEY (id_solicitud),
	FOREIGN KEY (id_usuario) REFERENCES usuario (id_usuario),
	FOREIGN KEY (id_tipo) REFERENCES tipo (id_tipo),
	FOREIGN KEY (id_estado) REFERENCES estado (id_estado));
	GO

	CREATE TABLE horas_extra(           
	id_h_e int IDENTITY(1,1) NOT NULL,
	id_usuario int NOT NULL,              
	dia date NOT NULL,
	hora_inicio int NOT NULL,  
	hora_fin int  NOT NULL,  
	PRIMARY KEY (id_h_e),
	FOREIGN KEY (id_usuario) REFERENCES usuario (id_usuario));