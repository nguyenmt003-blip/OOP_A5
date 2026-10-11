/* 
Nguyễn Minh Tuấn
202419010 
*/
using System;
public enum PrinterTechnology
{
    Laser,
    Inkjet
}

// Lớp máy in cơ bản không có kết nối mạng
public class Printer : Device
{
    public PrinterTechnology Technology { get; set; }
    public int PrintedPages { get; set; }
    public bool IsColor { get; set; } // Thuộc tính bổ sung để tính phí bảo trì màu

    public Printer(string deviceId, string deviceName, int yearOfUsage, decimal purchasePrice,
                   PrinterTechnology tech, int printedPages, bool isColor, DeviceStatus status = DeviceStatus.Active)
        : base(deviceId, deviceName, yearOfUsage, purchasePrice, status)
    {
        Technology = tech;
        PrintedPages = printedPages;
        IsColor = isColor;
    }

    public override decimal CalculateAnnualMaintenanceCost()
    {
        decimal cost = PurchasePrice * 0.04m; // 4% giá mua
        if (PrintedPages > 100_000) cost += 500_000m;
        if (IsColor) cost += 300_000m;
        return cost;
    }

    public override string ToString()
    {
        return base.ToString() + $" | Loại: {Technology}, Số trang: {PrintedPages}, In màu: {(IsColor ? "Có" : "Không")}";
    }
}