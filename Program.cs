/* 
Nguyễn Minh Tuấn
202419010 
*/
using System;
using System.Text;
public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("=== KHỞI TẠO DỮ LIỆU KIỂM THỬ ===");
        // Hai máy tính (1 máy có GPU rời)
        var pc1 = new Computer("PC01", "PC Đồ Họa Dell", 2018, 25_000_000m, 32, "Core i7", hasDedicatedGpu: true);
        var pc2 = new Computer("PC02", "PC Văn Phòng HP", 2022, 12_000_000m, 16, "Core i5", hasDedicatedGpu: false);

        // Hai máy in (1 máy > 100.000 trang, hỗ trợ mạng)
        var pr1 = new NetworkPrinter("PR01", "Máy in HP Laser", 2021, 8_000_000m, PrinterTechnology.Laser, 120_000, isColor: false);
        var pr2 = new Printer("PR02", "Máy in Màu Epson", 2023, 6_000_000m, PrinterTechnology.Inkjet, 20_000, isColor: true);

        // Một máy chiếu (bóng đèn > 3000 giờ)
        var proj = new Projector("PJ01", "Máy chiếu Sony", 2017, 18_000_000m, 4000, 3500);

        // Hai phòng thực hành
        var lab1 = new LabRoom("LAB01", "Phòng Thực Hành Mạng", 40);
        var lab2 = new LabRoom("LAB02", "Phòng Đồ Họa Đa Phương Tiện", 30);

        // 1. Thêm thiết bị vào phòng
        lab1.AddDevice(pc2);
        lab1.AddDevice(pr1);

        lab2.AddDevice(pc1);
        lab2.AddDevice(pr2);
        lab2.AddDevice(proj);

        // 2. Thử thêm thiết bị bị trùng mã
        Console.WriteLine("\n--- KIỂM THỬ 1: THÊM THIẾT BỊ TRÙNG MÃ ---");
        try
        {
            var duplicatePc = new Computer("PC02", "PC Trùng Mã", 2023, 10_000_000m, 8, "Core i3", false);
            lab1.AddDevice(duplicatePc);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Lỗi bắt được]: {ex.Message}");
        }

        // 3. In danh sách thiết bị trong từng phòng
        Console.WriteLine("\n--- DANH SÁCH THIẾT BỊ TRONG PHÒNG ---");
        PrintRoomDevices(lab1);
        PrintRoomDevices(lab2);

        // 4. Tính tổng chi phí bảo trì dự kiến
        Console.WriteLine("\n--- TỔNG CHI PHÍ BẢO TRÌ MỖI PHÒNG (ĐA HÌNH) ---");
        Console.WriteLine($"{lab1.RoomName}: {lab1.CalculateAnnualMaintenanceCost():N0} VND");
        Console.WriteLine($"{lab2.RoomName}: {lab2.CalculateAnnualMaintenanceCost():N0} VND");

        // 5. Liệt kê thiết bị cần bảo trì
        Console.WriteLine("\n--- DANH SÁCH THIẾT BỊ CẦN BẢO TRÌ (Lab 2) ---");
        foreach (var dev in lab2.GetDevicesRequiringMaintenance())
        {
            Console.WriteLine($"- {dev.DeviceName} (Năm SD: {dev.YearOfUsage}, Trạng thái: {dev.Status})");
        }

        // 6. Kết nối mạng cho các đối tượng thực thi INetworkable
        Console.WriteLine("\n--- KẾT NỐI MẠNG CHO THIẾT BỊ HỖ TRỢ ---");
        pc1.Connect("192.168.1.10");
        pc2.Connect("192.168.1.11");
        pr1.Connect("192.168.1.50");

        // 7. Duyệt thiết bị mạng qua kiểu INetworkable
        Console.WriteLine("\n--- DUYỆT CÁC THIẾT BỊ THÔNG QUA INTERFACE INetworkable ---");
        var networkDevices = new List<INetworkable> { pc1, pc2, pr1 };
        foreach (var netDev in networkDevices)
        {
            Console.WriteLine($"[Interface INetworkable] IP: {netDev.IpAddress} | Trạng thái kết nối: {netDev.IsConnected}");
        }
    }

    private static void PrintRoomDevices(LabRoom room)
    {
        Console.WriteLine($"\nPhòng: {room.RoomName} [{room.RoomId}] (Sức chứa: {room.Capacity})");
        foreach (var dev in room.Devices)
        {
            Console.WriteLine($" + {dev}");
        }
    }
    }