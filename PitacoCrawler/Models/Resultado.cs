using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PitacoCrawler.Models
{
    [Table("resultado")]
    public class Resultado
    {
        public long idResultado { get; set; }
        [Column(Order = 0), Key]
        public int idLoteria { get; set; }
        [Column(Order = 1), Key]
        public int concurso { get; set; }
        public DateTime? dataSorteio { get; set; }
        public int? bola01 { get; set; }
        public int? bola02 { get; set; }
        public int? bola03 { get; set; }
        public int? bola04 { get; set; }
        public int? bola05 { get; set; }
        public int? bola06 { get; set; }
        public int? bola07 { get; set; }
        public int? bola08 { get; set; }
        public int? bola09 { get; set; }
        public int? bola10 { get; set; }
        public int? bola11 { get; set; }
        public int? bola12 { get; set; }
        public int? bola13 { get; set; }
        public int? bola14 { get; set; }
        public int? bola15 { get; set; }
        public decimal? arrecadacaoTotal { get; set; }
        public int? ganhadores15 { get; set; }
        public int? ganhadores14 { get; set; }
        public int? ganhadores13 { get; set; }
        public int? ganhadores12 { get; set; }
        public int? ganhadores11 { get; set; }
        public int? ganhadores06 { get; set; }
        public int? ganhadores05 { get; set; }
        public int? ganhadores04 { get; set; }
        public decimal? valorRateio15 { get; set; }
        public decimal? valorRateio14 { get; set; }
        public decimal? valorRateio13 { get; set; }
        public decimal? valorRateio12 { get; set; }
        public decimal? valorRateio11 { get; set; }
        public decimal? valorRateio06 { get; set; }
        public decimal? valorRateio05 { get; set; }
        public decimal? valorRateio04 { get; set; }
        public decimal? valorAcumulado { get; set; }
        public decimal? estimativaPremio { get; set; }
        public decimal? acumuladoEspecial { get; set; }
        public bool? acumulou { get; set; }
    }
}
