use Payroll_Service
create table Employee_PayRoll_Service
(
	EmployeeID int primary key identity,
	EmployeeName varchar(200),
	PhoneNumber bigint,
	Address varchar(100),
	Department varchar(100),
	Gender char(1),
	BasicPay float,
	Deduction float,
	TaxablePay float,
	Tax float,
	NetPay float,
	City varchar(100),
	Country varchar(100)
)

create procedure SpAddEmployeedetails
(
	@EmployeeName varchar(100),
	@PhoneNumber bigInt,
	@Address varchar(200),
	@Department varchar(100),
	@Gender char(1),
	@BasicPay float,
	@Deduction float,
	@TaxablePay float,
	@Tax float,
	@NetPay float,
	@City varchar(100),
	@Country varchar(100)
)
as
begin
	Insert into Employee_PayRoll_Service(EmployeeName,PhoneNumber,Address,Department,Gender,BasicPay,
	Deduction,TaxablePay,Tax,NetPay,City,Country)
	values(@EmployeeName,@PhoneNumber,@Address,@Department,@Gender,@BasicPay,@Deduction,@TaxablePay,@Tax,
	@NetPay,@City,@Country)
end

select * from Employee_PayRoll_Service;
