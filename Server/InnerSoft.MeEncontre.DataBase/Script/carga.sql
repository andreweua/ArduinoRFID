use MeEncontre
go
Delete from Acesso
Delete from Local
Delete from Colaborador
Delete from Cliente
Delete from Status

Insert into Status (Codigo, Descricao, StatusUsuario) values ('A', 'Ativo', 1)
Insert into Status (Codigo, Descricao, StatusUsuario) values ('B', 'Bloqueado', 1)
Insert into Status (Codigo, Descricao, StatusUsuario) values ('C', 'Cancelado', 1)
Insert into Status (Codigo, Descricao, StatusUsuario) values ('E', 'Excluido', 0)

declare @ativo int
Select @ativo = Id From Status where Codigo = 'A'

Insert into Cliente (Codigo, Nome, Status_id) values ('INNER', 'InnerSoft', @ativo)


declare @cliente int
Select @cliente = Id From Cliente where Codigo = 'INNER'


Insert Into Local (Nome, [Key], Endereco, Latitude, Longitude, Status_id, Cliente_id, UltimoiLive, UltimoInicializacao)
		values ('Escritorio Matriz', '0001', 'Av Paulista 110, São Paulo, SP', '-23.569792', '-46.644660', @ativo, @cliente, GetDate(), GetDate())

declare @local1 int
set @local1 = @@identity
		
Insert Into Local (Nome, [Key], Endereco, Latitude, Longitude, Status_id, Cliente_id, UltimoiLive, UltimoInicializacao)
		values ('Fabrica de Software', '0011', 'Av Gomes de Carvalho, 100, São Paulo, SP', '-23.601699', '-46.675064', @ativo, @cliente, GetDate(), GetDate()-10)
declare @local2 int
set @local2 = @@identity
		
		
Insert Into Local (Nome, [Key], Endereco, Latitude, Longitude, Status_id, Cliente_id, UltimoiLive, UltimoInicializacao)
		values ('Centro de Apoio - Help desk', '0111', 'Av Brasil, 2300, São Paulo - SP', '-23.564201', '-46.677698', @ativo, @cliente, GetDate()-5, GetDate() -5)
declare @local3 int
set @local3 = @@identity

Insert Into Local (Nome, [Key], Endereco, Latitude, Longitude, Status_id, Cliente_id, UltimoiLive, UltimoInicializacao)
		values ('Escritorio Cliente', '1111', 'Praça da Sé, 23, São Paulo - SP', '-23.550734', '-46.634978', @ativo, @cliente, GetDate()-5, GetDate() -5)
declare @local4 int
set @local4 = @@identity


--Praça da Se Lat:-23.550734 Long:-46.634978		
--http://www.geraldfinzi.org/images/finzi_map_icon_people.png

Insert into Colaborador (Documento, Nome, Email, Foto, [Key], UltimoAcesso, Status_Id, Cliente_Id )
	values ('2633115454', 'Sergio de Miranda e Castro Mokshin', '','Sergio.jpg','chave', GetDate(), @ativo, @cliente)
declare @sergio int
set @sergio = @@identity

Insert into Colaborador (Documento, Nome, Email, Foto, [Key], UltimoAcesso, Status_Id, Cliente_Id )
	values ('1321321', 'João José Silva', '','icoUserAzul.png','chave1', GetDate(), @ativo, @cliente)
declare @joao int
set @joao = @@identity


Insert into Colaborador (Documento, Nome, Email, Foto, [Key], UltimoAcesso, Status_Id, Cliente_Id )
	values ('234523457', 'Maria Lucia Silva', '','icoUserVermelho.png','chave2', GetDate(), @ativo, @cliente)
declare @maria int
set @maria = @@identity


Insert into Colaborador (Documento, Nome, Email, Foto, [Key], UltimoAcesso, Status_Id, Cliente_Id )
	values ('8-90-0-890', 'Luciana Maria Joaquina', '','icoUserMarrom.png','chave3', GetDate() -1, @ativo, @cliente)
declare @luciana int
set @luciana = @@identity


Insert into Colaborador (Documento, Nome, Email, Foto, [Key], UltimoAcesso, Status_Id, Cliente_Id )
	values ('574567456', 'Sheila Silva', '','icoUserAzul.png','chave4', GetDate() -1, @ativo, @cliente)
declare @sheila int
set @Sheila = @@identity

Insert into Acesso (LocalKey, ColaboradorKey, Data, Movimento, Cliente_id, Colaborador_Id, Local_Id) 
	values ('1111', '34231423', getdate()-1, 'E', @cliente,  @sergio, @local1)

Insert into Acesso (LocalKey, ColaboradorKey, Data, Movimento, Cliente_id, Colaborador_Id, Local_Id) 
	values ('1111', '34231423', getdate()-1, 'S', @cliente, @sergio, @local1)

Insert into Acesso (LocalKey, ColaboradorKey, Data, Movimento, Cliente_id, Colaborador_Id, Local_Id) 
	values ('22222', '34231423', getdate(), 'E', @cliente, @sergio, @local1)


Insert into Acesso (LocalKey, ColaboradorKey, Data, Movimento, Cliente_id, Colaborador_Id, Local_Id) 
	values ('2222', '2345', getdate(), 'E', @cliente, @joao, @local2)

Insert into Acesso (LocalKey, ColaboradorKey, Data, Movimento, Cliente_id, Colaborador_Id, Local_Id) 
	values ('2222', '2345', getdate(), 'E', @cliente, @maria, @local4)

Insert into Acesso (LocalKey, ColaboradorKey, Data, Movimento, Cliente_id, Colaborador_Id, Local_Id) 
	values ('3333', '2345', getdate(), 'E', @cliente, @luciana, @local3)


Insert into Acesso (LocalKey, ColaboradorKey, Data, Movimento, Cliente_id, Colaborador_Id, Local_Id) 
	values ('3333', '2345', getdate(), 'E', @cliente, @Sheila, @local3)

Select * from Status
Select * from Cliente
Select * from Local
Select * from Colaborador
Select * from Acesso




