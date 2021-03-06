USE [PizzaBL.DBContexts.PizzaDbContext]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 7/21/2018 3:15:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[orderItemId] [int] IDENTITY(1,1) NOT NULL,
	[orderId] [int] NOT NULL,
	[pizzaItemId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.OrderItems] PRIMARY KEY CLUSTERED 
(
	[orderItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 7/21/2018 3:15:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[orderId] [int] IDENTITY(1,1) NOT NULL,
	[customerName] [nvarchar](max) NULL,
	[customerPhone] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED 
(
	[orderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pizza]    Script Date: 7/21/2018 3:15:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pizza](
	[pizzaId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[pizzaBase] [int] NOT NULL,
	[veg] [bit] NOT NULL,
	[nonVeg] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Pizza] PRIMARY KEY CLUSTERED 
(
	[pizzaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PizzaToppings]    Script Date: 7/21/2018 3:15:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PizzaToppings](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pizzaId] [int] NOT NULL,
	[toppingId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PizzaToppings] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Toppings]    Script Date: 7/21/2018 3:15:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Toppings](
	[toppingId] [int] IDENTITY(1,1) NOT NULL,
	[topping] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Toppings] PRIMARY KEY CLUSTERED 
(
	[toppingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderItems_dbo.Orders_orderId] FOREIGN KEY([orderId])
REFERENCES [dbo].[Orders] ([orderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_dbo.OrderItems_dbo.Orders_orderId]
GO
ALTER TABLE [dbo].[PizzaToppings]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PizzaToppings_dbo.Pizza_pizzaId] FOREIGN KEY([pizzaId])
REFERENCES [dbo].[Pizza] ([pizzaId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PizzaToppings] CHECK CONSTRAINT [FK_dbo.PizzaToppings_dbo.Pizza_pizzaId]
GO
