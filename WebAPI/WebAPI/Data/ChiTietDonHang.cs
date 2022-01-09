﻿using System;

namespace WebAPI.Data
{
    public class ChiTietDonHang
    {
        public Guid MaHh { get; set; }
        public Guid MaDh { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }
        //relationship
        public DonHang DonHang { get; set; }
        public HangHoa HangHoa { get; set; }
        
    }
}