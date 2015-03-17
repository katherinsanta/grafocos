
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