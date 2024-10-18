using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.IO;




namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
           reservingSystem.pasweord();//اجرای تابع پسورد
            bool End = false;//در صورت درست بودن این متغیر بولی از برنامه بطور کامل خارج می شود
            Console.SetWindowSize(80, 40);//تغییر اندازه صفحه کنسول
            Console.SetBufferSize(80, 40);//تغییر اندازه کل فضای داخلی کنسول
            while (true)//تا وقتی از این حلقه خارج نشود برنامه پس از اجرای هر قسمت از ابتدا نمایش داده می شود
            {
               try {//در این محدوده در صورتی که استثنا رخ دهد به بلوک کش می رود و برنامه ادامه پیدا می کند
                    Console.WriteLine("\nplease enter a number to excute the corresponding command: \n\n\n 1_add a customer \n\n " +
                        "2_remove a customer\n\n 3_add a hotel \n\n 4_remove a hotel \n\n 5_reserve a hotel by a customer \n\n " +
                        "6_show and read all of the saved items\n\n 7_save changes\n \n 8_calculate and display the total cost" +
                        " of a costumer\n\n 9_get costomers list of a specific hotel \n\n 10_get total earning of a hotel \n\n" +
                        " 11_get list of hotels that have been reserved by a customer \n\n 12_get list of hotels and their total earning \n\n " +
                        "13_turn off the PC \n\n 14_help\n\n 15_quit\n");
                    //نمایش اعداد و دستورات ورودی برای انتخاب توسط کاربر

                    switch (Convert.ToByte(Console.ReadLine().ToString()))//این ساختار سوییچ یک ععد ازکاربر می گیرد و با توجه به آن تابع مورد نظر را احرا میکند
                    {
                        case 1:
                            reservingSystem.addCustomer();//تابع اضافه کردن یک مشتری
                            break;

                        case 2://remove a customer
                            reservingSystem.removeAcustomer();//تابع حذف یک مشتری از لیست
                            break;

                        case 3://add a hotel
                            reservingSystem.addHotel();//افزون یک هتل به لیست هتل ها
                            break;
                       
                        case 4://remove a hotel
                            reservingSystem.removeAhotel();//حذف یک هتل از لیست
                            break;
                        case 5:
                            reservingSystem.reserveHbyC();//تابع رزرو یک هتل توسط یک مشتری
                            break;
                   
                        case 6:
                            reservingSystem.ReadFromFile();//تابع خواندن اطلاعات ذخیره شده قبلی از فابل هایhotels.txt و customers.txt
                            break;

                        case 7://save as a text file in the directory file as list`s name
                            reservingSystem.saveDetails();
                            break;

                        case 8://total cost of a customer
                           reservingSystem.totalCostOfaCustomer();
                            break;

                        case 9://customersof a hotel
                            reservingSystem.cOFaH();
                            break;

                        case 10://total earning of a hotel
                            reservingSystem.aHTotalEarning();
                            break;

                        case 11://gets list of hotels reserved by a customer
                            reservingSystem.HreservedByAc();
                            break;

                        case 12:
                            reservingSystem.hotelsTotalEarning();//shows total earning for a hotel
                            break;

                        case 13:
                            reservingSystem.slowWriting("are you sure want to turn off?(y=yes)");
                            if (Console.ReadKey().Key==ConsoleKey.Y)//در صورتی که کاراکترY وارد شود کامپیوتر را خاموش خواهد کرد
                            System.Diagnostics.Process.Start("ShutDown", "/s");
                            break;

                        case 14://help
                            reservingSystem.Help();//در صورت ورودی 14 صفحه help را نمایش خواهد داد
                            break;

                        case 15://exit
                            End = true;// از حلقه تکرار بی نهایت خارج شده و برنامه با پایان خواهد رسید
                            break;

                        default:
                            throw new Exception(":)");//ورودی غیر از موارد ذکر شده

                    }
                    Console.Clear();//بعد از اجزای یک تابع برای بازگشت دوباره به صفحه اصلی صفحه را پاک میکند
                    if (End == true)
                        break;
                }
                catch (Exception e)//در صورت رخ دادن استثنا به این قسمت وارد می شود و بعد از آن برنامه دوباره اجرا خواهد شد
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;//پس از تغییر رنگ قلم پیام زیر و متن استثنا را نمایش میدهد و سپس دوباره صفحه اصلی اجرا خواهد شد
                    Console.WriteLine("sorry. incorrect input! please retry.");
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }
            }
        }
 }
    static class reservingSystem
    {
        static public List<hotel> hotels = new List<hotel>();//لیستی برای ذخیره کردن شخصات هر هتل خاص
        static public List<customer> customers = new List<customer>();//لیتس برای ذخیره مشخصات مشتری ها
        static public List<reserve> reserves = new List<reserve>();//لیست اطلاعات رزرو ها

        static public List<customer> alijun(int roomNum)
        {
            var customerList = from item in reserves
                               where item.roomn == roomNum
                               select item.customer;

        }

        public static void Help()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;//رنگ صفحه کنسول را به قرمز تیره تغییر میدهد
            Console.Clear();
            slowWriting("thank for using our program;:. \n\n notice:\n you will lost your last datas if you select save\n while you didn`t selected read option." +
                "\n\"select save changes\" option after add or delete an item\n\nAli Aslani Katuli 23/1/2019\n\npress any key to go back to main menu... ");
            //نمایش متن help
            Console.ResetColor();
            Console.ReadKey();//در صورت انتخاب یک کلید تابع به پایان میرسد و به صفحه اصلی بر میگردد
        }
        public static void HreservedByAc()//نمایش هتل هایی ک توسط یک مشتری رزرو شده اند
        {
            Console.Clear();
            showCustomers();//shows list of customers with its details
            if (customers.Count != 0)
            {
                Console.WriteLine("please select a customer:");
                int n11 = Convert.ToInt16(Console.ReadLine()) - 1;//gets the number entered by the user
                var customer11 = customers[n11]; //مشتری مورد نظر را در یک متغیر جدید میریزد
                Console.Clear();
                var filtered11 =//با استفاده از کوئری لینک هتل هایی که یک مشتری انها را رزرو کرده است را جدا میکند 
                    from item in reserves
                    where item.customer == customer11
                    select item.hotel;

                foreach (var item in filtered11)
                    Console.WriteLine(item);//هتل هایی ک شرایط بالا را داشته باشد را نمایش خواهد داد

                if (filtered11.Count()==0)// اگر هتلی توسط یک مشتری رزرو نشده باشد پیغام زیر را نمایش خواهد داد
                    slowWriting("\nany hotel hasn`t reserved!\n\n press any key to go to main menu..");
            }
            Console.ReadKey();
        }
        public static void cOFaH()//مشتری هایی ک از یک هتل خاص رزرو کرده اند را نمایش میدهد
        {
            Console.Clear();
            showHotels();
            if (hotels.Count != 0)
            {
                Console.WriteLine("please select a hotel:");
                int n = Convert.ToInt16(Console.ReadLine()) - 1;//پس از نمایش هتل ها شماره هتل مرود نظر از لیست را از کاربر میگیرد
                var hotel = hotels[n];
                var filtered =
                    from item in reserves
                    where item.hotel == hotel
                    select item.customer;//مشتری های مورد نظر را در یک متغیر فیلتر شده میریزد
                Console.Clear();
                foreach (var customers in filtered)
                {
                    Console.WriteLine(customers);// نمایش مشتری های مورد نظر
                }
                if (filtered.Count() == 0)// اگر هتلی توسط یک مشتری رزرو نشده باشد پیغام زیر را نمایش خواهد داد
                    slowWriting("\nany hotel hasn`t reserved!.");
                slowWriting("\n\npress any key to go to main menu ..");
            }
            Console.ReadKey();
        }
        public static void saveDetails()//saves the datails of hotels and customer that have been entered
        {
            string ab = Directory.GetCurrentDirectory();//مسیر فایل اجرایی در حال حاظر
            string[] c = new string[customers.Count];//creats a array of string numbering cusomers count
            for (int i = 0; i < customers.Count; i++)
            {
                c[i] = customers[i].ToString(); //اعضای لیست مشتری هارا به آرایه ساخته شده اضافه می کند
            }
            string[] h = new string[hotels.Count];//برای لیست هتل ها نیز همین کار را انجام می دهد
            for (int i = 0; i < hotels.Count; i++)
            {
                h[i] = hotels[i].ToString();
            }
            File.WriteAllLines(ab + "\\hotels.txt", h);//و رشته های تعریف شده را در قالب یک فایل متنی ذخیره میکند
            File.WriteAllLines(ab + "\\customers.txt", c);
            Console.Clear();
            slowWriting(" changes done.  press any key to go back...");//پس از اتمام عمل این پیغام را نمایش می دهد
            Console.ReadKey();
        }
        public static void hotelsTotalEarning()
        {
            Console.Clear();
            if (hotels.Count == 0)
                Console.WriteLine(" List is empty\n go to main menu and add a hotel at first  pressing a key...");
            else
            {
                Console.WriteLine("List of existing hotels:\n");
                foreach (var htel in hotels)
                {//نمایش اعضای لیست هتل ها و همه درآمد آن هادر زیر هر کدام
                    Console.WriteLine(Convert.ToString(hotels.IndexOf(htel) + 1) + "_" + htel.ToString());

                    var filtered =
                        from item in reserves
                        where item.hotel == htel
                        select item.residingexpence;//فیلتر کردن هزینه اقامت مشتزی هایی که از یک هتل رزرو کرده اند
                    int sum = 0;
                    foreach (var item in filtered)
                    {
                        sum += item;
                    }
                    Console.WriteLine("total earning : " + sum + "\n\n\n");
                }//نمایش در آمد کل هتل بعد از نمایش جزییات هر هتل
            }
            slowWriting(" pressing a key to go main menu...");
            Console.ReadKey();
        }
        public static void aHTotalEarning()//محاسبه در آمد کل برای یک هتل
        {
            Console.Clear();
            showHotels();
            int n = Convert.ToInt16(Console.ReadLine()) - 1;//ابتدا لیست هتل هارا نمایش می دهد و کاربر هتل مورد نظر خود را انتخاب می کند
            var hotel = hotels[n];
            var filtered =
                from item in reserves
                where item.hotel == hotel
                select item.residingexpence;
            int sum = 0;//برای هتل مورد نظر جمع تمام هزینه رزرو هارا نمایش می دهد
            foreach (var item in filtered)
            {
                sum += item;
            }
            Console.WriteLine("the total earning is: " + sum);//نمایش در آمد کل
            slowWriting("\npress any key to go to main menu.. ");// پس از فشردن کلید تابع به پایان  خواهد رسید
            Console.ReadKey();
        }
        public static void totalCostOfaCustomer()//جمع کل هزینه های یک مشتری را نمایش می دهد
        {
            Console.Clear();
            if (customers.Count==0)
                slowWriting("list is empty. add a customer at first\n");//در صورت عدم وجود مشتری پیغام مناسب را نمایش خواهد داد
            else
            {
                Console.WriteLine("List of existing customers:\n");
                foreach (var item in customers)
                    Console.WriteLine(Convert.ToString(customers.IndexOf(item) + 1) + "_" + item.ToString() + "\n");
                Console.WriteLine("enter the number of customer that you want to display:");
                customer w = customers[Int16.Parse(Console.ReadLine()) - 1];//نمایش لیست مشتری ها و انتخاب یک مورد توسط کاربر
                Int64 sum = 0;
                for (int i = 0; i < reserves.Count; i++)
                {
                    if (reserves[i].customer == w)
                        sum += reserves[i].residingexpence;//جمع کردن همه هزینه ها برای یک مشتری
                    else continue;
                }
                Console.WriteLine("the total cost is: " + sum);//نمایش جمع کل
            }
            slowWriting("\npress any key to go to main menu.. ");
            Console.ReadKey();
        }
        public static void removeAhotel()//to delete a hotel from list
        {
            Console.Clear();
            if (hotels.Count == 0)
               slowWriting("\n List is empty\n go to main menu and add a hotel at first pressing a key...");
            else
            {
                Console.WriteLine("List of existing hotels:\n");
                foreach (var item in hotels)
                {
                    Console.WriteLine(Convert.ToString(hotels.IndexOf(item) + 1) + "_" + item.ToString() + "\n");
                }
                Console.WriteLine("enter the number of hotel that you want to delete:");
                hotels.RemoveAt(Int16.Parse(Console.ReadLine()) - 1);//انتخاب هتل مرود نظر توسط کاربر و حذف آن از لیست
                slowWriting("\nthe hotel deleted\n press any key to go to main menu...");
            }
            Console.ReadKey();
        }
        public static void removeAcustomer()
        {
            Console.Clear();
            if (customers.Count == 0)
                slowWriting("\n List is empty\n go to main menu and add a customer at first with pressing a key...");
            else
            {
                Console.WriteLine("List of existing customers:\n");
                foreach (var item in customers)
                {//نمایش مشتری های موجود در لیست به همراه شماره آن ها
                    Console.WriteLine(Convert.ToString(customers.IndexOf(item) + 1) + "_" + item.ToString() + "\n");
                }
                Console.WriteLine("enter the number of customer that you want to delete:");
                customers.RemoveAt(Int16.Parse(Console.ReadLine()) - 1);//حذف مشتری مورد نظر کاربر از لیست
                slowWriting("\nthe customer deleted\n press any key to go to main menu...");
            }
            Console.ReadKey();
        }
        public static void addCustomer()
    {
        customer customer = new customer();//ابتدا یک شی از کلاس مشتری برای گرفتن ویژگی ها ساخته می شود
        while (true)//کل تابع تا زمانی که دستور خروج وارد نشود تکرار میشود
        {
            Console.Clear();
                //موارد مورد نیاز را نمایش می دهد
            Console.WriteLine("enter the following particulars:\n name:\n lastName:\n city:\n province:\n customerID:\n cCode:\n uCode:\n sexuality:\n birthYear:\n memership Date:");
            try
            {
                Console.SetCursorPosition(25, 1);//کرسر را به مکان مقابل فیلد نام میبرد برای دریافت ورودی مورد نظر
                customer.name = (Console.ReadLine());
                Console.SetCursorPosition(25, 2);
                customer.lastName = (Console.ReadLine());
                Console.SetCursorPosition(25, 3);
                customer.city = (Console.ReadLine());
                Console.SetCursorPosition(25, 4);
                customer.province = (Console.ReadLine());//ورودی را در فیلد مورد نظر میریزد
                Console.SetCursorPosition(25, 5);
                customer.customerId = Convert.ToUInt32(Console.ReadLine());
                Console.SetCursorPosition(25, 6);
                customer.cCode = Convert.ToUInt32(Console.ReadLine());
                Console.SetCursorPosition(25, 7);
                customer.uCode = Convert.ToUInt32(Console.ReadLine());
                Console.SetCursorPosition(25, 8);
                string s = Console.ReadLine();//جنسیت را بصورت رشته دریافت میکند و اگر با موارد زیر مطابقت داشت تابع بولی در صورت مرد بود مقدار درست را برمیگرداند
                    if ((s == "man") || (s == "men") || (s == "Man")||s=="MAN")
                        customer.sexuality = true;
                    else if (s == "Female" || (s == "woman") || (s == "female") || (s == "lady")||s=="WOMEN")
                        customer.sexuality = false;

                    else//در صورتی که ورودی غیر از موارد بالا باشد یک استثنا رخ خواد داد که موجب می شود به بلوک کش برود و به لیست اضافه نشود
                        throw new Exception("the entered sexuality is incorrect");

                Console.SetCursorPosition(25, 9);
                customer.birthyear = Convert.ToUInt16(Console.ReadLine());
                Console.SetCursorPosition(25, 10);
                customer.memDate = Convert.ToDateTime(Console.ReadLine());
                if (customer.lastName == "" || customer.province == "" || customer.name == "" || customer.city == "")
                    throw new Exception("all fields should be entered");//اگر هر یک از فیلد های خواسته شده خالی باشد استثنا رخ می دهد و عملیات اتمام نمی شود
                customers.Add(customer);
                slowWriting("\nthe customer successfully added!\n press any key to go to main menu");//پس از دریافت تمام ورودی های درست پیغام متناسب نمایش داده می شود
                Console.ReadKey();
                break;
            }

            catch (Exception e)//در صورت رخ دادن هرگونه استثنا کد های زیر اجرا میشود
            {
                Console.SetCursorPosition(5, 15);
                Console.WriteLine(e.Message);//پیغام استثنای رخ داده را نیز نمایش می دهد
                slowWriting("         press esc to go to main menu\n          or any key to retry");

                if (Console.ReadKey().Key == ConsoleKey.Escape)//در صورت فشردن کلید اسکپ به منوی اصلی و برای هر کلید دیگر تابع دوباره اجرا خواهد شد
                {
                    Console.Clear();
                            break;
                }
              }
            }
        }

        public static void addHotel()//اضافه کردن یک هتل جدید به لیست هتل ها
        {
            hotel hotel = new hotel();//ابتدا یک شی از کلاس هتل میساریم
            while (true)
            {
                Console.Clear();
                Console.WriteLine("enter the following particulars:\nhotel name:\n owners name:\n owner's lastName:\n city:\n province:\n hotel code:\n address:");
                try//در صورتی که در این محدوده استثنا ایجاد شود به بلوک کش میرود و برنامه ادامه میابد
                {
                    Console.SetCursorPosition(25, 1);
                    hotel.Hname = (Console.ReadLine());
                    Console.SetCursorPosition(25, 2);
                    hotel.Oname = (Console.ReadLine());

                    Console.SetCursorPosition(25, 3);
                    hotel.OlastName = (Console.ReadLine());
                    Console.SetCursorPosition(25, 4);//کرسر را مقابل هر کدام از موارد خواسته شده تنظیم میکند
                    hotel.city = (Console.ReadLine());
                    Console.SetCursorPosition(25, 5);
                    hotel.province = (Console.ReadLine());
                    Console.SetCursorPosition(25, 6);
                    hotel.Hcode = Convert.ToInt32(Console.ReadLine());
                    Console.SetCursorPosition(25, 7);
                    hotel.address = (Console.ReadLine());

                    if (hotel.address == "" || hotel.Hname == "" || hotel.OlastName == "" || hotel.Oname == "" || hotel.province == "" || hotel.city == "")
                        throw new Exception("all fields should be entered");//اگر یکی از فیلد ها خالی باشد استثنا رخ میدهد 
                    hotels.Add(hotel);
                    Console.WriteLine("\nthe hotel successfully added!\n press any key to go to main menu");
                    Console.ReadKey();
                    break;
                }
                catch (Exception e)
                {
                    Console.SetCursorPosition(5, 15);
                    Console.WriteLine(e.Message);
                    Console.Write("         press esc to go to main menu\n          or any key to retry");
                    //Console.WriteLine(Console.ReadKey().KeyChar.ToString());

                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        //Program.Main(new string[] { });
                        break;
                    }
                }
            }
        }
        public static void reserveHbyC()//to reserve a hotel by a customer
        {
                showCustomers();//
            if (customers.Count != 0)//در صورتی که مشتری در لیست وجو داشته باشد کد های زیر اجرا خواهند شد
            {
                Console.WriteLine("enter the number of the customer which want`s to reserve");
                var customerr = customers[Convert.ToInt16(Console.ReadLine()) - 1];//پس از نمایش لیست مشتری ها شماره مشتری مورد نظر را از کابر می گیرد

                Console.Clear();
                showHotels();
                //سپس لیست هتل ها را نمایش داده و شماره هتل مورد نظر برای رزرو را میگیرد
                Console.WriteLine("enter the number of hotel that you want to reserve:");
                var hotell = hotels[Convert.ToInt16(Console.ReadLine()) - 1];
                Console.Clear();
                Console.WriteLine("\n room number:\n enter date:\n exit date:\n residing expence:");
                Console.SetCursorPosition(25, 1);
                int roomn = Convert.ToInt32(Console.ReadLine());
                Console.SetCursorPosition(25, 2);
                DateTime endate = Convert.ToDateTime(Console.ReadLine());
                Console.SetCursorPosition(25, 3);
                DateTime exdate = Convert.ToDateTime(Console.ReadLine());//تاریخ ورود و خروج را بصورت یک رشته میگیرد و بصورت تاریخ در یک ویژگی از شی مورد نظر میریزد
                Console.SetCursorPosition(25, 4);
                int resEx = Convert.ToInt32(Console.ReadLine());
                reserve reserve = new reserve(roomn, endate, exdate, resEx, customerr, hotell);//چون شی رزرو را از ایتدا نساختیم حالا آن را با متغیر های دریافت شده و با تابع سازنده ی پارامتر دار میسازیم
                foreach (var item in reserves)
                {
                    if (item.roomn == reserve.roomn)
                    {//در صورتی که مشتری جدید بخواد یک اتاق را برای روزی که مشتری دیگر آن را رزرو کرده است رزرو کند استثنا رخ می دهد و به تبع آن پیغام مناسب نماش داده خواهد شد
                        for (int i = reserve.enterDate.DayOfYear; i < reserve.ExitDate.DayOfYear; i++)
                            if (i == item.enterDate.DayOfYear || i == item.ExitDate.DayOfYear||(i> item.enterDate.DayOfYear&& i <item.ExitDate.DayOfYear))
                                throw new Exception("the room is full in some of these days");
                    }
                }
                reserves.Add(reserve);//در صورتی که تمام فیلد ها به درستی وارد شده باشند شی شاخته شده از رزرو را به لیست رزرو ها اضافه می کند
                slowWriting("\n\n the reservation successfully done ;:..\n press any key to go to main menu...");
            }
            Console.ReadKey();
        }
        public static void ReadFromFile()//اطلاعات ذخیره شده را از فایل متنی می خواند و بعنوان مشتری و هتل جدید اضافه میکند
        {
            Console.Clear();
            string a = Directory.GetCurrentDirectory();//مسیر برنامه موجود را که فایل هتی ذخیره شده نیز همانجا هستند را میگیرد و در یک متغیر جدید میریزد
            string[] hhotels = File.ReadAllLines(a + "\\hotels.txt");//هر یک از هتل های ذخیره شده را از فابل مربوطه در یک خانه از ارایه میریزد
            for (int i = 0; i < hhotels.Length; i++)
            {
                hotel howtel = new hotel();//ابتدا یک شی از کلاس هتل ساخته شده به ازای هر خانه از ارایه رشته ها
                for (int j = 0; j < 5; i++)//و روی آن 5 مورد را بررسی میکند که شامل ویزگی های هتل ذخیره شده میشود
                {

                    if (hhotels[i].Contains("hotel name:"))
                        howtel.Hname = hhotels[i].Substring(12, hhotels[i].Length - 12);//کاراکتر های از رشته را که در این محدوده هستند را بعنوان نام هتل اضافه میکند 

                    else if (hhotels[i].Contains("hotel's owner:"))
                        howtel.Oname = hhotels[i].Substring(15, hhotels[i].Length - 15); // و همینطور مشخصات دیگر را اضافه میکند

                    else if (hhotels[i].Contains("province."))//بررسی میکند که هر رشته مختص به کدام ویژگی میباشد
                    {
                        howtel.province = hhotels[i].Substring(3, hhotels[i].IndexOf("province.")-3);
                        howtel.city = hhotels[i].Substring(hhotels[i].IndexOf("province.") + 13, hhotels[i].IndexOf("City.")- hhotels[i].IndexOf("province.") - 13);
                    }//چون دو ویژگی در یک رشته امده اند قسمت های خاصی از رشته ک مختص به هرکدام میباشد را میگیرد و تخصیص میدهد
                    else if (hhotels[i].Contains("address:"))
                        howtel.address = hhotels[i].Remove(0,10);//با حذف کاراکتر های اولیه بقیه که شامل مقادیر مورد نظر میباشد را میگیرد

                    else if (hhotels[i].Contains("Hotel code:"))
                    {
                        string s = hhotels[i].Substring(12,hhotels[i].Length-12);
                        howtel.Hcode =Convert.ToInt32(s);
                    }

                    else if (hhotels[i] == "")//در صورتی که رشته خالی باشد هیچ عملی انجام نمیشود و به رشته بعدی خواهد رفت
                        break;

                }
                        if (hotels.Count >0)//بررسی میکند درصورتی که از قبل در لیست هتلی وجود داشته باشد و کد آن با کد هتل جدید برابر باشد این هتل اضافه نشود
                {
                for (int w = 0; w < hotels.Count; w++)
                    {
                        if (howtel.Hcode == hotels[w].Hcode)
                        {
                            howtel.Hname="";
                        }
                    }
                }
                        if (howtel.Hcode != 0)
                        {
                    if(howtel.Hname != "")
                        hotels.Add(howtel);
                         }
            }
            //کلیه اعمال بالا را برای مشتری ها نیز انجام میدهد
            string[] ccustomers = File.ReadAllLines(a + "\\customers.txt");
            for (int i = 0; i < ccustomers.Length; i++)
            {
                customer cuwstomer = new customer();

                for (int j = 0; j < 8; i++)
                {

                    if (ccustomers[i].Contains("full name:"))
                        cuwstomer.name = ccustomers[i].Substring(10, ccustomers[i].Length - 10);

                    else if (ccustomers[i].Contains("City:"))
                        cuwstomer.city = ccustomers[i].Substring(5, ccustomers[i].Length - 5);

                    else if (ccustomers[i].Contains("province:"))
                    {
                        cuwstomer.province = ccustomers[i].Substring(9, ccustomers[i].Length-9) ;
                    }
                    else if (ccustomers[i].Contains("customer code:"))
                        cuwstomer.ccode = Convert.ToUInt32( ccustomers[i].Remove(0, 14));

                    else if (ccustomers[i].Contains("national code is:"))
                    {
                        cuwstomer.uCode = UInt32.Parse(ccustomers[i].Substring(17, ccustomers[i].Length - 17));
                    }
                    else if (ccustomers[i].Contains("sexuality(man):"))
                    {
                        cuwstomer.sexuality = Convert.ToBoolean( ccustomers[i].Substring(15, ccustomers[i].Length - 15));
                    }
                    else if (ccustomers[i].Contains("birthYear"))
                        cuwstomer.birthyear =  Convert.ToInt32( ccustomers[i].Remove(0, 9));

                    else if (ccustomers[i].Contains("membership date"))
                    {
                        string s = ccustomers[i].Substring(15, ccustomers[i].Length - 15);
                        cuwstomer.memDate = Convert.ToDateTime(s);
                    }

                    else if (ccustomers[i] == "")
                        break;
                    
                }
                if (customers.Count > 0)
                {
                    for (int w = 0; w < customers.Count; w++)
                    {
                        if (cuwstomer.cCode == customers[w].cCode)
                        {
                            cuwstomer.name = "";
                        }
                    }
                }
                if (cuwstomer.cCode != 0)
                {
                    if (cuwstomer.name != "")
                        customers.Add(cuwstomer);
                }
            }//کلیه مشتری های خوانده شده از فایل را نمایش می دهد
            slowWriting("               list of saved customers\n\n");
            for (int i = 0; i < customers.Count; i++)
            {
                Console.WriteLine(customers[i]);
            }

            slowWriting("               list of saved hotels\n\n");
            for (int i = 0; i < hotels.Count; i++)
            {
                Console.WriteLine(hotels[i]);
                //نمایش هتل های خوانده شده از فایل
            }
            slowWriting("  the existing details have been displayed\n press any key to go to main menu..");
            Console.ReadKey();

        }
        public static void showCustomers()//نمایش لیست مشتری ها با جزییات
        {
            Console.Clear();
            if (customers.Count == 0)
            {//در صورتی که مشتری یی وارد نشده باشد:
                slowWriting(" List is empty\n go to main menu and add a customer at first  pressing a key...");
            }
            else
            {
                Console.WriteLine("List of existing customers:\n");//یکایک مشتری های موجود در لیست را با شماره نمایش می دهد
                foreach (var item in customers)
                    Console.WriteLine(Convert.ToString(customers.IndexOf(item) + 1) + "_" + item.ToString() + "\n");
            }
        }
        public static void showHotels()
        {
            if (hotels.Count == 0)
                slowWriting(" List is empty\n go to main menu and add a hotel at first  pressing a key...");
            else
            {//لیست هتل های موجود را نمایش می دهد
                Console.WriteLine("List of existing hotels:\n");
                foreach (var item in hotels)
                    Console.WriteLine(Convert.ToString(hotels.IndexOf(item) + 1) + "_" + item.ToString() + "\n");
            }
        }

        public static void slowWriting(string steri)//تابع نوشتن رشته بصورت آرام و ردیفی
        {
            Console.ForegroundColor = ConsoleColor.White;//رنگ نوشته را تغییر می دهد
            for (int i = 0; i < steri.Length; i++)
            {
                Console.Write(steri[i]);//جاپ کارکتر ها بترتیب
                Thread.Sleep(30);// وقفه بین چاپ هر کاراکتر از رشته
            }
            Console.ResetColor();//برگرداندن رنگ قلم کنسول به حالت اولیه
        }
        static public void pasweord()//تابع پسورد ورودی
        {
            string userName = "ali134";//یک نام کاربری و رمز عبرو دلخواه
            string pass = "121314";//میتوان چندین نام کاربری داشت یا از کاربر گرفت
            while (true)
            {
                slowWriting("\n plase enter username: ");
                var a = Convert.ToString(Console.ReadLine());
                slowWriting(" plase enter password: ");
                string s= Console.ReadLine();//پسورد را از کابر میگیرد

                Console.Clear();
                if (a != userName && pass !=s )
                {
                    Console.ForegroundColor = ConsoleColor.Red;//در صورتی که اشتباه وارد شوند پیغام زیر نمایش دهده و کد ها از ابتدای حلقه اجرا خواهد شد
                    Console.WriteLine("incorrect username or password");
                    Console.ResetColor();//رنک هشدار تغیر کرده و سپس  رنگ قلم به حالت اولیه برمیگردد
                }
                else break;//از حلقه خارج شده تابع به پایان می رسد
            }
            
            
        }
    }


    class reserve
    {
        private int roomN;//شماره اتاق
        public DateTime enterDate;//تاریخ ورود
        private DateTime exitDate;//تاریخ خروج از نوع تریخ و زمان
        private int residingExpence;//هزینه اقامت
        public customer customer;//یا ارجا از کلاس مشتری نیاز دارد
        public hotel hotel;//و یک ارجا از هتل برای رزرو

        public int residingexpence
        {
            get { return residingExpence; }
            set
            {//هزینه اقامت نمیتواند صفر یامنفی باشد
                if (1 > value)
                    throw new Exception("risiding expence is too little");
                else
                    residingExpence = value;
            }
        }
        public int roomn
        {
            get { return roomN; }
            set
            {//پراپرتی برای شماره اتاق نمیتواند مقدار منفی بگیرد در اینصورت استثنا رخ می دهد
                if (0 > value)
                    throw new Exception("room number is incorrect");
                else
                    roomN = value;
            }
        }
        public DateTime ExitDate
        {
            get { return exitDate; }
            set
            {
                if (value.Year > enterDate.Year)
                    exitDate = value;
               else if (value.Year == enterDate.Year&&value.Month>enterDate.Month)
                    exitDate = value;
                else if (value.Year == enterDate.Year && value.Month == enterDate.Month && value.Day >= enterDate.Day)
                    exitDate = value;
                //بررسی میکند در صورتی که تاریخ خروج از تاریخ ورود کوچکتر وترد شده باشد استثنا ایجتد کند
                else
                throw new Exception("the entered date is incorrect");
            }
        }

        public reserve(int roomN, DateTime enterDate, DateTime exitDate, int residingExpence, customer customer, hotel hotel)
        {//تابع سازنده با پارامتر    همه ویژگی هارا دریافت کرده و تخصیص می دهد
            this.roomN = roomN;
            this.enterDate = enterDate;
            ExitDate = exitDate;
            this.residingExpence = residingExpence;
            this.customer = customer;
            this.hotel = hotel;
        }
        public reserve()
        {//تابع سازنده بدون پارامتر
        }
    }

    class customer//کلاس مشتری
    {
        public string name;
        public string lastName;
        public string city;
        public string province;
        private UInt32 customerID;//شماره شناسه مشتری
        public UInt32 cCode;//کد مشتری
        public UInt32 uCode;//منفی نمیتواند باشد//کد ملی
        public bool sexuality;
        private int birthYear;//سال تولد
        public DateTime memDate;//تاریخ عضویت

        public UInt32 customerId
        {
            get { return customerID; }
            set
            {//اگر مقدار منفی تخصیص داده شود استثنا رخ خواهد داد
                if (value > 0)
                    customerID = value;
                else
                    throw new Exception("invalid id number");
            }
        }
        public UInt32 ccode//پراپرتی برای کد کشتری
        {
            get { return cCode; }
            set
            {//اگر مقدار منفی تخصیص داده شود استثنا رخ خواهد داد
                if (value > 0)
                    cCode = value;
                else
                    throw new Exception("invalid customer code");
            }
        }
        public UInt32 ucode
        {
            get { return customerID; }
            set
            {//اگر مقدار منفی تخصیص داده شود استثنا رخ خواهد داد
                if (value > 0)
                    uCode = value;
                else
                    throw new Exception("invalid natiional code");
            }
        }
        public int birthyear
        {
            get { return birthYear; }
            set
            {//سال تولد در بازه مورد نظر قابل قبول است در غیر اینصورت استثنا با پیام متناسب رخ خواهد داد
                if (value < 2100 && value > 1850)
                    birthYear = value;
                else
                    throw new Exception("invalid birth year number");
            }
        }

        public customer(string name, string lastName, string city, string province, UInt32 customerId, UInt32 cCode, UInt32 uCode, bool sexuality, int birthYear, DateTime memDate)
        {//تابع سازنده با پارامتر برای مشتری
            this.name = name;
            this.lastName = lastName;
            this.city = city;
            this.province = province;
            this.customerId = customerId;
            this.cCode = cCode;
            this.uCode = uCode;
            this.sexuality = sexuality;
            this.birthYear = birthYear;
            this.memDate = memDate;
        }
        public customer()//تابع سازنده بدون پارامتر
        {
        }
      public override string ToString()
        {//رشته ای شامل ویژگی های کلاس را برمیگرداند
            return "full name:" + name + " " + lastName +
                "\nCity: " + city + "\nprovince:" + province + "\ncustomer code:" + cCode + "\nnational code is:"
                + uCode+"\nsexuality(man):" + sexuality + "\nbirthYear" + birthYear+"\n" +"membership date"+ memDate+"\n\n";
        }
        
    }
    class hotel
    {
        public string Hname;//name of hotel
        public string Oname;//name of owner
        public string OlastName;//owners lastname
        public string city;
        public string province;
       private int hCode;//hotel code
        public string address;

   
        public int Hcode//پراپرتی برای ویژگی کد هتل
        {
            get { return hCode; }
            set
            {
                if (value > 1)//در صورتی که کد هتل عددی بیشتر از 1 باشد تخصیص داده میشود در غیر اینصورت استثنا رخ خواهد داد
                    hCode = value;
                else
                    throw new Exception("invalid Hotel code");
            }
        }
        public hotel(string hname, string oname, string olastName, string city, string province, int hcode, string address)
        {//تابع سازنده با پارامتر برای کلااس هتل
            Hname = hname;
            Oname = oname;
            OlastName = olastName;
            this.city = city;
            this.province = province;
            hCode = hcode;//پارامتر های دریافتی را به ویژگی مربوطه اختصاص می دهد
            this.address = address;
        }
        public hotel()
        {//تابع سازنده بدون پارامتر
        }

        public override string ToString()
        {//باز نویسی تا بع to string
            return " hotel name:" + Hname + "\n hotel's owner:" + Oname +
                " " + OlastName +  "\n in " + province + " province."
                + " in " + city + " City." + "\n address: " + address + "\n Hotel code:" + hCode+"\n\n" ;
        }//رشته ای شامل هر ویژگی در هر خط بر میگرداند
    }
}
