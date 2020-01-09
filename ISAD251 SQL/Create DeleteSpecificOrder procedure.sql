SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteSpecificOrder](@OrderId as INT) AS
BEGIN
    BEGIN TRANSACTION
        DECLARE @Error NVARCHAR(Max);
        BEGIN TRY
        
         DELETE FROM Orders
WHERE OrderMainID = @OrderID
DELETE FROM ItemOrder 
WHERE OrderMainID = @OrderID
            
IF @@TRANCOUNT > 0 COMMIT;
        END TRY
        BEGIN CATCH
            SET @Error = 'Order could not be deleted';
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            RAISERROR(@Error, 1, 0);
        END CATCH; 
END;
GO
