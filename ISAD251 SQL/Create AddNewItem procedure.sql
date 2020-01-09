SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddNewItem] (@ItemName as VARCHAR(20), @ItemPrice as decimal(4,2), 
@ItemStock as int, @ItemType as VARCHAR(20)) AS
BEGIN
    BEGIN TRANSACTION
        DECLARE @Error NVARCHAR(Max);
        BEGIN TRY

            INSERT INTO Stock
            VALUES(((SELECT MAX(Stock.ItemID) FROM Stock) + 1), @ItemName, @ItemPrice, @ItemStock, @ItemType)

        END TRY
        BEGIN CATCH
            SET @Error = @Error+'New item could not be added';
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            RAISERROR(@Error, 1, 0);
        END CATCH; 
END;
GO
