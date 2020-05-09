using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HomeWork19
{
    class Program
    {
        static void Main(string[] args)
        {
           


            bool circle = true;
            while (circle)

            {

                Console.Clear();

                Console.Write("1.Create\n2.Read\n3.Update\n4.Delete\n5.Exit\nChoice:");

                var choice = Console.ReadLine();

                switch (choice)

                {

                    case "1": Create(); break;

                    case "2": Read(); break;

                    case "3": Update(); break;

                    case "4": Delete(); break;

                    case "5": circle = false; break;

                    default:

                        break;

                }

            }
        }

        private static void Delete()
        {
            

                try

                {

                    using (var context = new ShopContext())

                    {

                        Read("update");

                        Console.WriteLine("Please select");

                        Console.Write("ID:");

                        var alifId = Convert.ToInt32(Console.ReadLine());

                        var alif = context.AlifShop.Find(alifId);



                        if (alif != null)

                        {

                            Console.Write("Are you sure? Y(yes)/N(no):");

                            var confirm = Console.ReadLine();

                            if (confirm.ToUpper() == "Y") context.AlifShop.Remove(alif);



                            if (context.SaveChanges() > 0)

                            {

                                SuccessMessage("Success deleted!");

                            }

                            else

                            {

                                FailMessage("Sorry not deleted!");

                            }

                        }

                    }

                }

                catch (Exception ex)

                {

                    FailMessage(ex.Message);

                }

                finally

                {

                    ConsoleReadWithPressKeyMessage();

                }

            
        }

        private static void Update()
        {
            {

                try

                {

                    using (var context = new ShopContext())

                    {

                        Read("update");

                        Console.WriteLine("Please select");

                        Console.Write("ID:");

                        var companyId = Convert.ToInt32(Console.ReadLine());

                        var alif = context.AlifShop.Find(companyId);

                        if (alif != null)

                        {

                            Console.Write("New company name:");
                            var newCompanyName = Console.ReadLine();

                            Console.Write("New model name:");
                            var newModelyName = Console.ReadLine();

                            alif.Company = newCompanyName;
                            alif.Model = newModelyName;

                            if (context.SaveChanges() > 0)

                            {

                                SuccessMessage("Success changed!");

                            }

                            else

                            {

                                FailMessage("Sorry not changed!");

                            }

                        }



                    }

                }

                catch (Exception ex)

                {

                    FailMessage(ex.Message);

                }

                finally

                {

                    ConsoleReadWithPressKeyMessage();

                }
            }
        }

        private static void Read(string type = null)
        {
            {

                try

                {
                    using (var context = new ShopContext())

                    {
                        var companyList = context.AlifShop.ToList();

                        companyList.ForEach(p =>

                        {
      
                            Console.WriteLine($"ID:{p.Id}\tCompanyName:{p.Company}\tModelName:{p.Model}");

                        });

                    }

                }

                catch (Exception ex)

                {

                    FailMessage(ex.Message);

                }

                finally

                {

                    if (type != "update")

                    {

                        ConsoleReadWithPressKeyMessage();

                    }

                }
            }
        }

        private static void Create()

        {

            try

            {

                using (var context = new ShopContext())

                {

                    Console.Write("Enter new comapny name:");
                    var companyName = Console.ReadLine();

                    Console.Write("Enter new model name:");
                    var modelName = Console.ReadLine();

                    AlifShop alif = new AlifShop()
                    {

                        Company = companyName,
                        Model = modelName


                    };

                    context.AlifShop.Add(alif);



                    var result = context.SaveChanges();

                    if (result > 0)

                    {

                        SuccessMessage("Success added");

                    }

                }

            }

            catch (Exception ex)

            {

                FailMessage(ex.Message);

            }

            finally

            {

                 ConsoleReadWithPressKeyMessage();

            }


        }
        private static void SuccessMessage(string text)

        {

            Console.WriteLine($"Success: {text}");

        }

        private static void FailMessage(string failText)

        {

            Console.WriteLine($"Fail: {failText}");

        }

        private static void ConsoleReadWithPressKeyMessage()

        {

            Console.WriteLine("Press any key to continue...");

            Console.ReadKey();

        }
    }
}
