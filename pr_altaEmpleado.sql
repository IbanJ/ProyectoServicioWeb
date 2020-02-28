alter procedure pr_altaEmpleado(@p_employeeID int,
		@p_firstname nvarchar(10),
		@p_lastname nvarchar(20),
		@p_country nvarchar(15),
		@p_salida smallint OUTPUT)
as
begin
	begin try
	SET IDENTITY_INSERT [dbo].empleados ON
		insert into dbo.empleados (EmployeeID, firstname, lastname, country)
		values (@p_employeeID,@p_firstname, @p_lastname, @p_country)
			SET IDENTITY_INSERT [dbo].empleados OFF
		set @p_salida= 1
		return @p_salida
	end try
	begin catch
		set @p_salida= 0

		return @p_salida
	end catch
end;

-- codigo de prueba
declare @p_salida smallint
exec dbo.pr_altaEmpleado 10,'gohan','blanco','ritania', @p_salida OUTPUT
print @p_salida
go