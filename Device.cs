/* 
Nguyễn Minh Tuấn
202419010 
*/
using System;
public abstract class Device
{
    // các thuộc tính ko cần kiểm tra logic khi set
    public string DeviceId { get; } 
    public string DeviceName { get; set; } 
    public DeviceStatus Status { get; set; }

    //cần kiểm tra logic khi set nên viết riêng
    private int _yearOfUsage;
    public int YearOfUsage  
    {
        get => _yearOfUsage;
        set
        {
            if (value > DateTime.Now.Year)
                throw new ArgumentException("Năm đưa vào sử dụng không được lớn hơn năm hiện tại.");
            _yearOfUsage = value;
        }
    }

    private decimal _purchasePrice;
    public decimal PurchasePrice 
    {
        get => _purchasePrice;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Giá mua phải lớn hơn 0.");
            _purchasePrice = value;
        }
    }

    //constructor
    protected Device(string deviceId, string deviceName, int yearOfUsage, decimal purchasePrice, DeviceStatus status = DeviceStatus.Active)
    {
        if (string.IsNullOrWhiteSpace(deviceId))
            throw new ArgumentException("Mã thiết bị không được để trống.");

        DeviceId = deviceId;
        DeviceName = deviceName;
        YearOfUsage = yearOfUsage;
        PurchasePrice = purchasePrice;
        Status = status;
    }

    // abstract method
    public abstract decimal CalculateAnnualMaintenanceCost();

    public override string ToString()
    {
        return $"[{DeviceId}] {DeviceName} | Năm SX: {YearOfUsage} | Giá: {PurchasePrice:N0} VND | Trạng thái: {Status}";
    }
}


//enum cho device status
public enum DeviceStatus
{
    Active,
    UnderMaintenance,
    Retired
}