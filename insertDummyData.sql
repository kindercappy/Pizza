
Declare @pizzaTable int
Set @pizzaTable = 1

While @pizzaTable <= 100
Begin
	IF @pizzaTable % 2 = 0
		INSERT INTO Pizza VALUES ('Pizza - ' + CAST(@pizzaTable AS NVARCHAR(10)),
			1,
			1,
			0
		)
	IF @pizzaTable % 2 = 1
		INSERT INTO Pizza VALUES ('Pizza - ' + CAST(@pizzaTable AS NVARCHAR(10)),
			1,
			0,
			1
		)
	PRINT @pizzaTable
	SET @pizzaTable = @pizzaTable + 1
END

Declare @Toppings int
Declare @ToppingType int
Set @ToppingType = 1
Set @Toppings = 1

While @Toppings <= 10
Begin
	IF @Toppings < 5
		INSERT INTO Toppings VALUES (1)
	IF @Toppings > 5
		INSERT INTO Toppings VALUES (2)

	PRINT @Toppings
	SET @Toppings = @Toppings + 1
END


Declare @PizzaRowsCount int
Select @PizzaRowsCount =  COUNT(pizzaId) From Pizza
Declare @StartPizzaCount int
Set @StartPizzaCount = 0


