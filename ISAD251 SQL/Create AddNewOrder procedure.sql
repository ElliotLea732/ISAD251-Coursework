SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddNewOrder] (@OrderID as int, @ItemID as int, @ItemQuantity as int) AS
BEGIN

    BEGIN TRANSACTION
        DECLARE @Error NVARCHAR(Max);

        BEGIN TRY
        
         DECLARE @ItemPrice as decimal(4,2);

         SET @ItemPrice = (SELECT Stock.ItemPrice FROM Stock WHERE Stock.ItemID = @ItemID);

         IF EXISTS (SELECT * FROM Orders WHERE Orders.OrderMainID= @OrderID)
            BEGIN
             UPDATE Orders
             SET OrderCost = (OrderCost + @ItemPrice)
             WHERE Orders.OrderMainID = @OrderID
            END
         ELSE
            BEGIN
             INSERT INTO Orders
             VALUES(@OrderID, @ItemPrice)
            END

         INSERT INTO ItemOrder
         VALUES(((SELECT MAX(ItemOrder.ItemOrderID) FROM ItemOrder) + 1), @OrderID, @ItemID, @ItemQuantity)

         UPDATE Stock
         SET ItemStock = (ItemStock - @ItemQuantity)
         WHERE ItemID = @ItemID

        IF @@TRANCOUNT > 0 COMMIT;
        END TRY
        BEGIN CATCH
            SET @Error = 'Order could not be entered';
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            RAISERROR(@Error, 1, 0);
        END CATCH; 

END
GO
