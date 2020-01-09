SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditPrice] (@ItemID as int, @NewPrice as decimal(4,2)) AS
BEGIN
    BEGIN TRANSACTION
        DECLARE @Error NVARCHAR(Max);
        BEGIN TRY
            UPDATE Stock
            SET Stock.ItemPrice = @NewPrice
            WHERE Stock.ItemID = @ItemID
            IF @@TRANCOUNT > 0 COMMIT;
        END TRY
        BEGIN CATCH
            SET @Error = @Error+'Price could not be changed';
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            RAISERROR(@Error, 1, 0);
        END CATCH; 
END;
GO
