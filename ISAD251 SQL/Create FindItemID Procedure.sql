SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FindItemID] (@ItemName as VARCHAR(20)) AS
BEGIN
    BEGIN TRANSACTION
        DECLARE @Error NVARCHAR(Max);
        BEGIN TRY

           SELECT Stock.ItemID From Stock WHERE Stock.ItemName = @ItemName

           IF @@TRANCOUNT > 0 COMMIT;

        END TRY
        BEGIN CATCH
            SET @Error = @Error+'ID could not be found';
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            RAISERROR(@Error, 1, 0);
        END CATCH; 
END;
GO
