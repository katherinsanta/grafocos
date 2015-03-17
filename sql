
select 
a.idSolicitud,
a.placa,

a.valeAsignado as vale ,
b.consecutivo,
a.movil,
a.direccionOrig,
--a.idZonaOrg,
direcciondest,
--convert (char(17),a.horaServicio,108),
CONVERT(CHAR(17),a.horaServicio,110) 'FECHA servicio',substring(b.idTarifa,5,10)as costo_vale, 
CONVERT(CHAR(17),a.horaServicio,108) 'Hora servicio', a.estado,idconductor,idPasajero
--CONVERT(CHAR(5),a.horaServicio,108) --<= DATEADD(mi,15,GETDATE())


from PDV_SolicitudesTransporte a left join valesheader b
on substring(a.valeAsignado,5,11)=b.consecutivo
where cast(fechaservicio as date)='20150310' 
and convert (char(5),horaservicio,108)between'00' and'00:03'

declare @vale
set vale=(select )


update PDV_SolicitudesTransporte
set ()
-----------------------------------------------------------

create trigger tr_cliente _actualizado
on documento
after update 
as
insert into 
	--------------------------------------------------------

--se genera una manera para cargar los datos ingresados por parte del usuario como es
--doc me saco canas
--sp_helptrigger documento
--drop trigger tr_cliente_actualizado

create trigger tr_cliente_actualizado
on dbo.documento
after update 
as
declare @fecha datetime
declare @motivo varchar(30)
declare @doc int
set @doc=(select  doc from documento where  fecha=getdate())
set @fecha=getdate()
set @motivo='cambio de estado'
--insert into estados_app (doc,fecha_mod,motivo)
--SELECT top 1 doc,GETDATE(),'modificacion' FROM dbo.documento

insert into dbo.estados_app (doc,fecha_mod,motivo) values (@doc,@fecha,@motivo)
select doc from documento where doc=@doc

SELECT * FROM estados_app
select * from dbo.documento
select getdate(),* from dbo.documento

--insert into documento(doc)values(1),(2),(3),(4),(5)

declare @conc int
set @conc=0

while (@conc<20)
begin
update documento
set fecha=getdate(),estado=1 
where doc=79240067
set @conc=@conc+1
end

select * from documento
select * from estados_app

--truncate table estados_app

	