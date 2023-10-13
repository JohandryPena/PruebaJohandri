using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cuenta.API.Migrations
{
    public partial class Procedimentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE RealizarMovimiento
                                    @CuentaId INT,
                                    @Valor DECIMAL(18, 2)
                                AS
                                 BEGIN
                                    -- Verificar si la cuenta existe y obtener el saldo actual
                                    DECLARE @SaldoInicial DECIMAL(18, 2);
                                    SELECT @SaldoInicial = SaldoInicial
                                    FROM Cuentas
                                    WHERE CuentasId = @CuentaId;

                                    -- Validar si la cuenta existe
                                    IF @SaldoInicial IS NULL
                                    BEGIN
                                        set @Mensaje = 'Cuenta no encontrada';
                                        RETURN;
                                    END

                                    -- Determinar el tipo de movimiento según el valor
                                    DECLARE @TipoMovimiento NVARCHAR(255);
                                    IF @Valor > 0
                                        SET @TipoMovimiento = 'Deposito';
                                    ELSE IF @Valor < 0
                                        SET @TipoMovimiento = 'Retiro';
                                    ELSE
                                    BEGIN
                                         set @Mensaje = 'Valor no válido';
                                        RETURN;
                                    END

                                    -- Realizar la operación de acuerdo al tipo
                                    IF @TipoMovimiento = 'Retiro'
                                    BEGIN
                                        -- Verificar si el saldo permite el retiro
                                        IF @SaldoInicial >= ABS(@Valor)
                                        BEGIN
                                            -- Realizar el retiro
                                            UPDATE Cuentas
                                            SET SaldoInicial = @SaldoInicial + @Valor
                                            WHERE CuentasId = @CuentaId;
                                        END
                                        ELSE
                                        BEGIN
                                             set @Mensaje = 'Saldo Insuficiente';
                                            RETURN;
                                        END
                                    END
                                    ELSE IF @TipoMovimiento = 'Deposito'
                                    BEGIN
                                        -- Realizar el depósito
                                        UPDATE Cuentas
                                        SET SaldoInicial = @SaldoInicial + @Valor
                                        WHERE CuentasId = @CuentaId;
                                    END

                                    -- Registrar el movimiento
                                    INSERT INTO Movimientos (Fecha, TipoMovimineto, Valor, Saldo, CuentaId,Estado)
                                    VALUES (GETDATE(), @TipoMovimiento, @Valor, @SaldoInicial, @CuentaId,1);

                                     set @Mensaje ='Registro Exitoso' ;
                                END
                                ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE dbo.RealizarMovimiento");

        }
    }
}
