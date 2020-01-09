SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ViewSpecificOrder] (@OrderID as int) AS
BEGIN
    BEGIN TRANSACTION
        DECLARE @Error NVARCHAR(Max);
        BEGIN TRY
           SELECT Stock.ItemName, ItemOrder.Quantity
           FROM Stock, ItemOrder, Orders
           WHERE Orders.OrderMainID = @OrderID AND Orders.OrderMainID = ItemOrder.OrderMainID AND ItemOrder.ItemID = Stock.ItemID
           SELECT Orders.OrderCost
           FROM Orders
           WHERE Orders.OrderMainID = @OrderID
           IF @@TRANCOUNT > 0 COMMIT;
        END TRY
        BEGIN CATCH
            SET @Error = @Error+'Order cannot be viewed';
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            RAISERROR(@Error, 1, 0);
        END CATCH; 
END;
GO
