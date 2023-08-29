using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.AdditionalDealInformation
{
    public class AdditionalDealInformationRequest
    {
        /// <summary>
        /// Equation field code
        /// </summary>
        public string? BUEQF { get; set; }
        /// <summary>
        /// Link parameter value
        /// </summary>
        public string? BULPV { get; set; }
        /// <summary>
        /// Information group
        /// </summary>
        public string? BUIGR { get; set; }
        /// <summary>
        /// Branch
        /// </summary>
        public string? BUBRNM { get; set; }
        /// <summary>
        /// Deal prefix
        /// </summary>
        public string? BUDLP { get; set; }
        /// <summary>
        /// Deal Reference
        /// </summary>
        public string? BUDLR { get; set; }
        /// <summary>
        /// Posting sequence number
        /// </summary>
        public string? BUPSQ { get; set; }
        /// <summary>
        /// Posting date
        /// </summary>
        public string? BUPOD { get; set; }
        /// <summary>
        /// Lokasi usaha
        /// </summary>
        public string? BUD001 { get; set; }
        /// <summary>
        /// lokasi proyek
        /// </summary>
        public string? BUD002 { get; set; }
        /// <summary>
        /// Golongan penjamin
        /// </summary>
        public string? BUD003 { get; set; }
        /// <summary>
        /// Golongan kredit
        /// </summary>
        public string? BUD005 { get; set; }
        /// <summary>
        /// Orientasi penggunaan
        /// </summary>
        public string? BUD006 { get; set; }
        /// <summary>
        /// Sifat kredit
        /// </summary>
        public string? BUD008 { get; set; }
        /// <summary>
        /// Sektor ekonomi
        /// </summary>
        public string? BUD009 { get; set; }
        /// <summary>
        /// Tipe plafon
        /// </summary>
        public string? BUD011 { get; set; }
        /// <summary>
        /// Agunan yang dihitung sesuai BI
        /// </summary>
        public string? BUD012 { get; set; }
        /// <summary>
        /// Agunan yang dihitung manual
        /// </summary>
        public string? BUD013 { get; set; }
        /// <summary>
        /// PPAP yang dihitung sesuai BI
        /// </summary>
        public string? BUD014 { get; set; }
        /// <summary>
        /// Jenis pengunaan
        /// </summary>
        public string? BUD015 { get; set; }
        /// <summary>
        /// Bagian yang dijamin
        /// </summary>
        public string? BUD004 { get; set; }
        /// <summary>
        /// Kode peminjam
        /// </summary>
        public string? BUD016 { get; set; }
        /// <summary>
        /// Tanggal hapus buku
        /// </summary>
        public string? BUD018 { get; set; }
        /// <summary>
        /// Keterkaitan bmpk
        /// </summary>
        public string? BUD019 { get; set; }
        /// <summary>
        /// Kode dinas
        /// </summary>
        public string? BUD020 { get; set; }
        /// <summary>
        /// Tanggal jatuh tempo pinjaman
        /// </summary>
        public string? BUD021 { get; set; }
        /// <summary>
        /// No PK
        /// </summary>
        public string? BUD023 { get; set; }
        /// <summary>
        /// Banyak barang
        /// </summary>
        public string? BUSL02 { get; set; }
        /// <summary>
        /// Ekspektasi % bagi hasil
        /// </summary>
        public string? BUSL05 { get; set; }
        /// <summary>
        /// Ekspektasi besar bagi hasil
        /// </summary>
        public string? BUSL06 { get; set; }
        /// <summary>
        /// Margin deposito
        /// </summary>
        public string? BUMARD { get; set; }
        /// <summary>
        /// Margin
        /// </summary>
        public string? BUMARG { get; set; }
        /// <summary>
        /// Penyerapan tengan kerja mikro utama
        /// </summary>
        public string? BUD024 { get; set; }
        /// <summary>
        /// Premi asuransi
        /// </summary>
        public string? BUD025 { get; set; }
        /// <summary>
        /// Rate asuransi
        /// </summary>
        public string? BUD026 { get; set; }
        /// <summary>
        /// No Registrasi Web Scoring
        /// </summary>
        public string? BUD046 { get; set; }
        /// <summary>
        /// Tanggal pensiun
        /// </summary>
        public string? BUD027 { get; set; }
        /// <summary>
        /// KODE RO/AO
        /// </summary>
        public string? BUD035 { get; set; }
        /// <summary>
        /// Tanggal restruk awal
        /// </summary>
        public string? BUD047 { get; set; }
        /// <summary>
        /// Tanggal restruk akhir
        /// </summary>
        public string? BUD048 { get; set; }
        /// <summary>
        /// Restrukturisasi ke
        /// </summary>
        public string? BUD049 { get; set; }
        /// <summary>
        /// Hasil penjualan tahunan
        /// </summary>
        public string? BUD052 { get; set; }
        /// <summary>
        /// Kekayaan bersih tanpa TBH/BN
        /// </summary>
        public string? BUD053 { get; set; }
        /// <summary>
        /// Segmentasi kredit
        /// </summary>
        public string? BUD054 { get; set; }
        /// <summary>
        /// No SKK
        /// </summary>
        public string? BUD077 { get; set; }
        /// <summary>
        /// No SKK
        /// </summary>
        public string? BUD078 { get; set; }
        /// <summary>
        /// Apakah diasuransikan kredit
        /// </summary>
        public string? BUD081 { get; set; }
        /// <summary>
        /// Apakah diasuransikan jiwa
        /// </summary>
        public string? BUD084 { get; set; }
        /// <summary>
        /// Jenis Perikatan
        /// </summary>
        public string? BUD087 { get; set; }
        /// <summary>
        /// Fee notaris
        /// </summary>
        public string? BUD088 { get; set; }
        /// <summary>
        /// Kategori usaha berkelanjutan
        /// </summary>
        public string? BUD089 { get; set; }
        /// <summary>
        /// Status kredit
        /// </summary>
        public string? BUD094 { get; set; }
        /// <summary>
        /// Kategori portofolio
        /// </summary>
        public string? BUD095 { get; set; }
        /// <summary>
        /// Jenis kredit
        /// </summary>
        public string? BUD096 { get; set; }
        /// <summary>
        /// Tanggal Akad
        /// </summary>
        public string? BUD097 { get; set; }
        /// <summary>
        /// Sumber Dana
        /// </summary>
        public string? BUD106 { get; set; }
        public string? BUD107 { get; set; }
        public string? BUD112 { get; set; }
    }
}
