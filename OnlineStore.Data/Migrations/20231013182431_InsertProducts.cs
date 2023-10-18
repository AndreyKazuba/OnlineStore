using Microsoft.EntityFrameworkCore.Migrations;
using OnlineStore.Data.Constants.Enums;

#nullable disable

namespace OnlineStore.Data.Migrations
{
    public partial class InsertProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.Videocard, "Gigabyte GeForce RTX 3050 Gaming OC 8G GV-N3050GAMING OC-8GD", "8 ГБ GDDR6 LHR, 1550 МГц, 2560sp, 20 RT-ядер, трассировка лучей, 128 бит, 2 слота, питание 8 pin, HDMI, DisplayPort", 1159, "Gigabyte GeForce RTX 3050 Gaming OC 8G GV-N3050GAMING OC-8GD.jpg", true });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.Videocard, "Gigabyte GeForce RTX 3050 Gaming OC 8G GV-N3050GAMING OC-8GD", "8 ГБ GDDR5, 1040 МГц, 512 бит, питание 6+8 pin, HDMI, DisplayPort, DVI", 895, "MSI R9 390 8GB GDDR5 Gaming (R9 390 GAMING 8G).jpg", true });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.Videocard, "Gigabyte GeForce RTX 3050 Gaming OC 8G GV-N3050GAMING OC-8GD", "8 ГБ GDDR5, 1303 МГц, 2304sp, 256 бит, 2 слота, питание 8 pin, HDMI, DisplayPort, DVI", 1255, "MSI Radeon RX 480 Gaming X 8GB GDDR5 [RX 480 GAMING X 8G].jpg", true });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.Videocard, "AFOX Radeon RX 580 8GB GDDR5 AFRX580-8192D5H3-V2", "8 ГБ GDDR5, 1284 МГц, 2048sp, 256 бит, 2 слота, питание 8 pin, HDMI, DisplayPort, DVI", 506, "AFOX Radeon RX 580 8GB GDDR5 AFRX580-8192D5H3-V2.jpg", false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.Videocard, "Gigabyte GeForce RTX 3060 Gaming OC 12GB GDDR6 (rev. 2.0)", "12 ГБ GDDR6 LHR, 1320 МГц / 1837 МГц, 3584sp, 28 RT-ядер, трассировка лучей, 192 бит, 2 слота, питание 8 pin, HDMI, DisplayPort", 1308, "Gigabyte GeForce RTX 3060 Gaming OC 12GB GDDR6 (rev. 2.0).jpg", false });

            migrationBuilder.InsertData(
               table: "Products",
               columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
               values: new object[] { (int)ProductType.Videocard, "Gigabyte GeForce RTX 3060 Vision OC 12GB GDDR6 (rev. 2.0)", "12 ГБ GDDR6 LHR, 1320 МГц / 1837 МГц, 3584sp, 28 RT-ядер, трассировка лучей, 192 бит, 2 слота, питание 8 pin, HDMI, DisplayPort", 1150, "Gigabyte GeForce RTX 3060 Vision OC 12GB GDDR6 (rev. 2.0).jpg", false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.Videocard, "Gigabyte GeForce RTX 4080 16GB Aero OC GV-N4080AERO OC-16GD", "16 ГБ GDDR6X, 2210 МГц / 2535 МГц, 9728sp, 76 RT-ядер, трассировка лучей, 256 бит, 3.65 слота, питание 16 pin (PCIe Gen5), HDMI, DisplayPort", 5129, "Gigabyte GeForce RTX 4080 16GB Aero OC GV-N4080AERO OC-16GD.jpg", false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.Videocard, "MSI GeForce RTX 3060 Gaming X 12G", "12 ГБ GDDR6 LHR, 1320 МГц / 1837 МГц, 3584sp, 28 RT-ядер, трассировка лучей, 192 бит, 2.7 слота, питание 6+8 pin, HDMI, DisplayPort", 1272, "MSI GeForce RTX 3060 Gaming X 12G.jpg", false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.Videocard, "MSI GeForce RTX 3060 Ventus 2X 12G OC", "12 ГБ GDDR6 LHR, 1320 МГц / 1807 МГц, 3584sp, 28 RT-ядер, трассировка лучей, 192 бит, 2.2 слота, питание 8 pin, HDMI, DisplayPort", 1170, "MSI GeForce RTX 3060 Ventus 2X 12G OC.jpg", true });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.Videocard, "MSI GeForce RTX 4060 Ti Gaming X 8G", "8 ГБ GDDR6, 2310 МГц / 2655 МГц, 4352sp, 34 RT-ядер, трассировка лучей, 128 бит, питание 8 pin, HDMI, DisplayPort", 1715, "MSI GeForce RTX 4060 Ti Gaming X 8G.jpg", false });

            migrationBuilder.InsertData(
               table: "Products",
               columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
               values: new object[] { (int)ProductType.Videocard, "PNY GeForce RTX 4080 16GB TF VERTO Edition VCG408016TFXPB1", "16 ГБ GDDR6X, 2210 МГц / 2505 МГц, 9728sp, 76 RT-ядер, трассировка лучей, 256 бит, 3 слота, питание 16 pin (PCIe Gen5), HDMI, DisplayPort", 4779, "PNY GeForce RTX 4080 16GB TF VERTO Edition VCG408016TFXPB1.jpg", false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.Processor, "AMD Ryzen 7 5800X", "Vermeer, AM4, 8 ядер, частота 4.7/3.8 ГГц, кэш 4 МБ + 32 МБ, техпроцесс 7 нм, TDP 105W", 746, "AMD Ryzen 7 5800X.jpg", true });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.Processor, "Intel Core i9-13900K", "Raptor Lake, LGA1700, 24 ядра, частота 5.82.2 ГГц, кэш 32 МБ + 36 МБ, техпроцесс 10 нм, TDP 253W", 2220, "Intel Core i9-13900K.jpg", true });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.Processor, "AMD Ryzen 5 5600", "Vermeer, AM4, 6 ядер, частота 4.4/3.5 ГГц, кэш 3 МБ + 32 МБ, техпроцесс 7 нм, TDP 65W", 438, "AMD Ryzen 5 5600.jpg", false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.Processor, "AMD Ryzen 5 5600X", "Vermeer, AM4, 6 ядер, частота 4.63.7 ГГц, кэш 3 МБ + 32 МБ, техпроцесс 7 нм, TDP 65W", 523, "AMD Ryzen 5 5600X.jpg", true });

            migrationBuilder.InsertData(
               table: "Products",
               columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
               values: new object[] { (int)ProductType.Processor, "AMD Ryzen 7 7700X", "Raphael, AM5, 8 ядер, частота 5.4/4.5 ГГц, кэш 8 МБ + 32 МБ, техпроцесс 5 нм, TDP 105W", 1166, "AMD Ryzen 7 7700X.jpg", false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.Processor, "AMD Ryzen 7 7800X3D", "Raphael, AM5, 8 ядер, частота 5/4.2 ГГц, кэш 8 МБ + 96 МБ, техпроцесс 5 нм, TDP 120W", 1655, "AMD Ryzen 7 7800X3D.jpg", false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.Processor, "Intel Core i3-12100F", "Alder Lake, LGA1700, 4 ядра, частота 4.33.3 ГГц, кэш 5 МБ + 12 МБ, техпроцесс 10 нм, TDP 89W", 299, "Intel Core i3-12100F.jpg", false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.Processor, "Intel Core i5-12400F", "Alder Lake, LGA1700, 6 ядер, частота 4.4/2.5 ГГц, кэш 7.5 МБ + 18 МБ, техпроцесс 10 нм, TDP 117W", 526, "Intel Core i5-12400F.jpg", false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.Processor, "Intel Core i7-13700K", "Raptor Lake, LGA1700, 16 ядер, частота 5.4/2.5 ГГц, кэш 24 МБ + 30 МБ, техпроцесс 10 нм, TDP 253W", 1476, "Intel Core i7-13700K.png", true });

            migrationBuilder.InsertData(
               table: "Products",
               columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
               values: new object[] { (int)ProductType.ReadyAssembly, "Raspberry Pi 4 Model B 4GB", "профессиональный, RAM LPDDR4 4 ГБ, без ОС", 500, "Raspberry Pi 4 Model B 4GB.jpg", false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.ReadyAssembly, "TGPC Compact 81896 A-X", "домашний/офисный/игровой (геймерский), CPU AMD Ryzen 5 5600G 3900 МГц, RAM DDR4 16 ГБ, SSD 500 ГБ, графика: встроенная в процессор, БП 180 Вт, без ОС", 1691, "TGPC Compact 81896 A-X.jpg", true });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.ReadyAssembly, "FK BY Игровой 174711", "игровой (геймерский), CPU Intel Core i3 12100F 3300 МГц, RAM DDR4 16 ГБ, SSD 960 ГБ, графика: NVIDIA GeForce RTX 3060 12 ГБ, БП 700 Вт", 2492, "FK BY Игровой 174711.jpg", true });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.ReadyAssembly, "TGPC Action 82771 A-X", "игровой (геймерский), CPU AMD Ryzen 5 5600 3500 МГц, RAM DDR4 16 ГБ, SSD 500 ГБ, графика: NVIDIA GeForce RTX 3060 12 ГБ, БП 600 Вт, без ОС", 2883, "TGPC Action 82771 A-X.jpg", true });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.ReadyAssembly, "Apple Mac mini M2 MMFJ3", "домашний/офисный/профессиональный, SSD 256 ГБ, графика: Apple M2 GPU (10 ядер), Mac OS", 8730, "Apple Mac mini M2 MMFJ3.png", false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.ReadyAssembly, "FK BY Falcon 170335", "игровой (геймерский), CPU AMD Ryzen 5 5600X 3700 МГц, RAM DDR4 32 ГБ, SSD 240 ГБ, графика: NVIDIA GeForce RTX 3070 Ti 8 ГБ, БП 700 Вт", 3964, "FK BY Falcon 170335.jpeg", false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.ReadyAssembly, "Jet Gamer 5i10400FD16SD24X105TG3W5", "игровой (геймерский), CPU Intel Core i5 10400F 2900 МГц, RAM DDR4 16 ГБ, SSD 240 ГБ, графика: NVIDIA GeForce GTX 1050 Ti 4 ГБ, БП 500 Вт, без ОС", 1734, "Jet Gamer 5i10400FD16SD24X105TG3W5.jpg", false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.MotherBoard, "Gigabyte B450 Aorus Pro (rev. 1.0)", "ATX, сокет AMD AM4, чипсет AMD B450, память 4xDDR4 до 3600 МГц, слоты: 3xPCIe x16, 1xPCIe x1, 2xM.2", 459, "Gigabyte B450 Aorus Pro (rev. 1.0).jpg", true });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.MotherBoard, "ASRock A620M-HDVM.2", "mATX, сокет AMD AM5, чипсет AMD A620, память 2xDDR5 до 5600 МГц, слоты: 1xPCIe x16, 2xPCIe x1, 2xM.2", 315, "ASRock A620M-HDVM.2.jpg", false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.MotherBoard, "ASUS Prime B450M-K II", "mATX, сокет AMD AM4, чипсет AMD B450, память 2xDDR4 до 4400 МГц, слоты: 1xPCIe x16, 2xPCIe x1, 1xM.2", 243, "ASUS Prime B450M-K II.jpg", false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.MotherBoard, "ASUS TUF Gaming Z690-Plus", "ATX, сокет Intel LGA1700, чипсет Intel Z690, память 4xDDR5 до 6000 МГц, слоты 2xPCIe x16, 1xPCIe x4, 2xPCIe x1, 4xM.2", 783, "ASUS TUF Gaming Z690-Plus.jpg", false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.MotherBoard, "Gigabyte B550 Aorus Elite AX V2 (rev. 1.0)", "ATX, сокет AMD AM4, чипсет AMD B550, память 4xDDR4 до 4733 МГц, слоты: 3xPCIe x16, 1xPCIe x1, 2xM.2, 802.11ax (Wi-Fi 6)+Bluetooth 5.0", 625, "Gigabyte B550 Aorus Elite AX V2 (rev. 1.0).jpg", false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.MotherBoard, "Gigabyte B760 Gaming X DDR4 (rev. 1.0)", "ATX, сокет Intel LGA1700, чипсет Intel B760, память 4xDDR4 до 5333 МГц, слоты: 1xPCIe x16, 2xPCIe x1, 3xM.2", 531, "Gigabyte B760 Gaming X DDR4 (rev. 1.0).jpeg", false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Type", "Name", "Description", "Price", "ImageName", "IsBestseller" },
                values: new object[] { (int)ProductType.MotherBoard, "MSI B760 Gaming Plus WiFi", "ATX, сокет Intel LGA1700, чипсет Intel B760, память 4xDDR5 до 6800 МГц, слоты: 2xPCIe x16, 3xPCIe x1, 2xM.2, 802.11ax (Wi-Fi 6E)+Bluetooth 5.3", 610, "MSI B760 Gaming Plus WiFi.jpg", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
