
declare @valueee int = (select COUNT(id) from Pedido P where P.PROD_EOQ >= 20)
select @valueee
if(@valueee >= 20)
begin 

update Pedido set ORD_QTY = 35 where P.PROD_EOQ >= 20 
end 



/*
--TAREA 1
insert into PRODUCTOS(PROD_ID,PROD_NAME,PROD_PRICE,PROD_CURRENTSTOCK,PROD_REORDERLEVEL,
PROD_EOQ) values (5,'Levadura',15,28,15,75)

--TAREA 2
update Pedido set ORD_QTY = (select SUM(12) where Pedido where P.PROD_EOQ >= 20
) where P.PROD_EOQ >= 20 

--TAREA 3
update Pedido set ORD_QTY = 35 where P.PROD_EOQ >= 20 
*/