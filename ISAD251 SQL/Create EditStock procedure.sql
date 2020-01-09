SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditStock] (@ItemID as int, @ItemStock as int)as
BEGIN
    BEGIN TRANSACTION
        DECLARE @Error NVARCHAR(Max);
        BEGIN TRY
            UPDATE Stock
            SET ItemStock = @ItemStock
            WHERE ItemID = @ItemID
            IF @@TRANCOUNT > 0 COMMIT;
        END TRY
        BEGIN CATCH
            SET @Error = @Error+'Stock could not be changed';
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            RAISERROR(@Error, 1, 0);
        END CATCH; 
END;
GO
