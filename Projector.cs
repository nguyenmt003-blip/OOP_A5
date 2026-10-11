/* 
Nguyễn Minh Tuấn
202419010 
*/
using System;

public class Projector : Device
{
    public int Lumens { get; set; }
    public int LampUsageHours { get; set; }

    public Projector(string deviceId, string deviceName, int yearOfUsage, decimal purchasePrice,
                     int lumens, int lampUsageHours, DeviceStatus status = DeviceStatus.Active)
        : base(deviceId, deviceName, yearOfUsage, purchasePrice, status)
    {
        Lumens = lumens;
        LampUsageHours = lampUsageHours;
    }

    public override decimal CalculateAnnualMaintenanceCost()
    {
        decimal cost = PurchasePrice * 0.03m; // 3% giá mua
        if (LampUsageHours > 3000) cost += 1_500_000m;
        return cost;
    }

    public override string ToString()
    {
        return base.ToString() + $" | Độ sáng: {Lumens}lm, Giờ bóng đèn: {LampUsageHours}h";
    }
}