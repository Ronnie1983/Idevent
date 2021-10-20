using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleApp1.Database;
using ConsoleApp1.models;
using IdeKortLib.Models;
using LibUsbDotNet;
using LibUsbDotNet.Main;

namespace ConsoleApp1
{
    class start
    {
        //public static UsbDevice MyUsbDevice;

        //public static UsbDeviceFinder MyUsbFinder = new UsbDeviceFinder(1234, 1);

        private ConnectionGeneric<Chip> mgrChip = new ConnectionGeneric<Chip>();
        //private ConnectionGeneric<Product> mgrProduct = new ConnectionGeneric<Product>();
        private ConnectionGeneric<Amount> mgrAmount = new ConnectionGeneric<Amount>();


        public async Task go()
        {
            Chip chip;
            List<Amount> amounts;
            Amount selectedAmount;
            int productNumber;
            int selectedNumber;
            bool inMenu;
            int count = 1;
            int count2 = 1;
          
            while (true)
            {
                chip = new Chip();
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Please scan chip");
                
                chip = await ScanChip(Console.ReadLine());
                Console.WriteLine($"Scannet details:" + chip);
                Console.WriteLine("------------------------------------");

                if (chip.Id != 0)
                {
                    amounts = await mgrAmount.GetItemByCip(chip.Id);
                    if (amounts.Count > 1)
                    {
                        inMenu = true;
                        while (inMenu)
                        {
                            amounts = await mgrAmount.GetItemByCip(chip.Id);
                            productNumber = 0;
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine("Pick a product or scan key to exit");
                            foreach (Amount amount in amounts)
                            {
                                Console.WriteLine($"{productNumber} - {amount.ProductClass} Left: {amount.Total}");
                                productNumber++;
                            }
                            Console.WriteLine("------------------------------------");
                            string readstring = "p";
                            
                            while (!Int32.TryParse(readstring, out selectedNumber))
                            {
                                Console.WriteLine("Only numbers");
                                readstring = Console.ReadLine();
                            }
                            
                            if (selectedNumber < productNumber && selectedNumber >= 0)
                            {
                                selectedAmount = amounts[selectedNumber];

                                Console.WriteLine(selectedAmount);
                                
                                readstring = "p";
                                while (!Int32.TryParse(readstring,out count2) && count2 !<= selectedAmount.Total)
                                {
                                    Console.WriteLine("------------------------------------");
                                    Console.WriteLine($"Scan key or input numbers if you want more than 1 and less than {selectedAmount.Total}");
                                    readstring = Console.ReadLine();
                                }
                                if (count2 <= selectedAmount.Total && count2 > 0 && count2 < 500)
                                {
                                    

                                    readstring = "p";
                                    while (!Int32.TryParse(readstring, out count))
                                    {
                                        Console.WriteLine("------------------------------------");
                                        Console.WriteLine($"you want {count2}, please scan keycard");
                                        readstring = Console.ReadLine();
                                    }
                                    
                                    if (count == selectedAmount.ChipClass.Id)
                                    {
                                        //selectedAmount.Total = selectedAmount.Total - count2;
                                        selectedAmount = await mgrAmount.DecreaseByAmount(selectedAmount.Id, count2);
                                        Console.WriteLine("------------------------------------");
                                        Console.WriteLine("New amount");
                                        Console.WriteLine(selectedAmount);
                                        Console.WriteLine("------------------------------------");
                                    }
                                }
                                else
                                {
                                    if (count2 == chip.Id)
                                    {
                                        if (selectedAmount.Total != 0)
                                        {
                                            selectedAmount = await mgrAmount.DecreaseByAmount(selectedAmount.Id, 1);
                                            amounts = await mgrAmount.GetItemByCip(chip.Id);
                                            Console.WriteLine("New amount");
                                            Console.WriteLine(selectedAmount);
                                        }
                                        else
                                        {
                                            Console.WriteLine("------------------------------------");
                                            Console.WriteLine("Not enough, try again");
                                        }
                                       
                                    }
                                    else
                                    {
                                        Console.WriteLine("------------------------------------");
                                        Console.WriteLine("Not enough, try again");
                                    }
                                  
                                    
                                }

                                count = 1;
                                count2 = 1;


                            }
                            else if (selectedNumber == chip.Id)
                            {
                                Console.WriteLine("------------------------------------");
                                Console.WriteLine("Back");
                                inMenu = false;
                            }
                            else
                            {
                                Console.WriteLine("------------------------------------");
                                Console.WriteLine("No such product");
                            }
                        }
                    }
                    else
                    {
                        int controlAmounts = amounts[0].Total;
                        amounts[0] = await mgrAmount.DecreaseByAmount(amounts[0].Id, 1);
                        
                        Console.WriteLine(amounts[0].Total);
                        if (amounts[0].Total == controlAmounts)
                        {
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine("Something went wrong2");
                        }
                    }
                    
                }
                else
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Unknown chip");
                }
            }
        }

        private async Task<Chip> ScanChip(string key)
        {
            if (int.TryParse(key, out int j))
            {
                return await mgrChip.GetItemById(j);
            }

            return null;
        }
    }
}
