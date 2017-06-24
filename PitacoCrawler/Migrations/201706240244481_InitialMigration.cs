namespace PitacoCrawler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.resultado",
                c => new
                    {
                        idLoteria = c.Int(nullable: false),
                        concurso = c.Int(nullable: false),
                        idResultado = c.Long(nullable: false),
                        dataSorteio = c.DateTime(precision: 0),
                        bola01 = c.Int(),
                        bola02 = c.Int(),
                        bola03 = c.Int(),
                        bola04 = c.Int(),
                        bola05 = c.Int(),
                        bola06 = c.Int(),
                        bola07 = c.Int(),
                        bola08 = c.Int(),
                        bola09 = c.Int(),
                        bola10 = c.Int(),
                        bola11 = c.Int(),
                        bola12 = c.Int(),
                        bola13 = c.Int(),
                        bola14 = c.Int(),
                        bola15 = c.Int(),
                        arrecadacaoTotal = c.Decimal(precision: 18, scale: 2),
                        ganhadores15 = c.Int(),
                        ganhadores14 = c.Int(),
                        ganhadores13 = c.Int(),
                        ganhadores12 = c.Int(),
                        ganhadores11 = c.Int(),
                        ganhadores06 = c.Int(),
                        ganhadores05 = c.Int(),
                        ganhadores04 = c.Int(),
                        valorRateio15 = c.Decimal(precision: 18, scale: 2),
                        valorRateio14 = c.Decimal(precision: 18, scale: 2),
                        valorRateio13 = c.Decimal(precision: 18, scale: 2),
                        valorRateio12 = c.Decimal(precision: 18, scale: 2),
                        valorRateio11 = c.Decimal(precision: 18, scale: 2),
                        valorRateio06 = c.Decimal(precision: 18, scale: 2),
                        valorRateio05 = c.Decimal(precision: 18, scale: 2),
                        valorRateio04 = c.Decimal(precision: 18, scale: 2),
                        valorAcumulado = c.Decimal(precision: 18, scale: 2),
                        estimativaPremio = c.Decimal(precision: 18, scale: 2),
                        acumuladoEspecial = c.Decimal(precision: 18, scale: 2),
                        acumulou = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.idLoteria, t.concurso });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.resultado");
        }
    }
}
