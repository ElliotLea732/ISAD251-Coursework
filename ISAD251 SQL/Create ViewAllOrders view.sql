SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewAllOrders] AS
SELECT ItemOrder.OrderMainID, Stock.ItemName, ItemOrder.Quantity
FROM ItemOrder, Stock
WHERE ItemOrder.ItemID = Stock.ItemID
GO
