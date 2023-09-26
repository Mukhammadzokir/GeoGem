using GeoGem.Service.DTOs.Bookings;
using GeoGem.Service.DTOs.Cities;
using GeoGem.Service.DTOs.Hotels;
using GeoGem.Service.DTOs.LandMarks;
using GeoGem.Service.DTOs.Tickets;
using GeoGem.Service.DTOs.Users;
using GeoGem.Service.Services;

namespace GeoGem.Presentation.Presentations;

public class UserInterface
{
    public async Task RunningCodeAsync()
    {
        Console.WriteLine("             ██████╗ ███████╗ ██████╗  ██████╗ ███████╗███╗   ███╗\r\n            ██╔════╝ ██╔════╝██╔═══██╗██╔════╝ ██╔════╝████╗ ████║\r\n            ██║  ███╗█████╗  ██║   ██║██║  ███╗█████╗  ██╔████╔██║\r\n            ██║   ██║██╔══╝  ██║   ██║██║   ██║██╔══╝  ██║╚██╔╝██║\r\n            ╚██████╔╝███████╗╚██████╔╝╚██████╔╝███████╗██║ ╚═╝ ██║\r\n             ╚═════╝ ╚══════╝ ╚═════╝  ╚═════╝ ╚══════╝╚═╝     ╚═╝\r\n                                                                  ");
        while (true)
        {
            Console.WriteLine("Sign Up ===>>> 1");
            Console.WriteLine("Sing In ===>>> 2");

            int num = int.Parse(Console.ReadLine());
            switch (num)
            {
                case 1:
                    var userService = new UserService();
                    var userCreationdto = new UserForCreationDto();
                    Console.Write("Enter the name:  ");
                    userCreationdto.Name = Console.ReadLine();
                    Console.Write("Enter the email: ");
                    userCreationdto.Email = Console.ReadLine();
                    Console.Write("Enter the password: ");
                    userCreationdto.Password = Console.ReadLine();
                    Console.Write("Enter the amount of balance: ");
                    userCreationdto.Balance = decimal.Parse(Console.ReadLine());
                    var user = await userService.CreateAsync(userCreationdto);
                    await Console.Out.WriteLineAsync(user.Name + "Your account has been created");
                    break;
                case 2:
                    Console.WriteLine("Enter the email: ");
                    var email = Console.ReadLine();
                    Console.WriteLine("Enter the password: ");
                    var password = Console.ReadLine();
                    var authentication = new AuthenticationService();
                    var check = await authentication.AuthoriseAsync(email, password);
                    switch (check)
                    {
                        case 1:
                            var cheking = true;
                            while (cheking)
                            {
                                Console.WriteLine("1 ==>> Create for traveling: ");
                                Console.WriteLine("2 ==>> Ortga qaytish");
                                int number = int.Parse(Console.ReadLine());
                                switch (number)
                                {
                                    case 1:
                                        var cityForCeationDto = new CityForCreationDto();
                                        var cityService = new CityService();
                                        Console.Write("Enter the name of City: ");
                                        cityForCeationDto.Name = Console.ReadLine();
                                        Console.Write("Enter the imgageUrl of City: ");
                                        cityForCeationDto.ImageUrl = Console.ReadLine();
                                        Console.WriteLine("Enter the latitude of City: ");
                                        cityForCeationDto.Latitude = double.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter the Longtitude of City: ");
                                        cityForCeationDto.Longitude = double.Parse(Console.ReadLine());
                                        var resultDtoOfCity = await cityService.CreateAsync(cityForCeationDto);
                                        Console.WriteLine("Successfully city has been created");

                                        Console.WriteLine($"Please Create landmarks for {cityForCeationDto.Name}");

                                        long idOfLandMark = 0;
                                        while (true)
                                        {
                                            var landMarkCreationDto = new landMarkCreationDto();
                                            var landMarkService = new LandMarkService();
                                            Console.Write("Enter the name: ");
                                            landMarkCreationDto.Name = Console.ReadLine();
                                            Console.Write("Enter the imgageUrl of landMark: ");
                                            landMarkCreationDto.ImageUrl = Console.ReadLine();
                                            Console.WriteLine("Enter the latitude of LandMark: ");
                                            landMarkCreationDto.Latitude = double.Parse(Console.ReadLine());
                                            Console.WriteLine("Enter the Longtitude of LandMark: ");
                                            landMarkCreationDto.Longitude = double.Parse(Console.ReadLine());
                                            landMarkCreationDto.CityId = resultDtoOfCity.Id;
                                            var resultDtoOfLandMark = await landMarkService.CreateAsync(landMarkCreationDto);
                                            idOfLandMark = resultDtoOfLandMark.Id;
                                            Console.WriteLine("Successfully LandMark for city has been created");

                                            Console.WriteLine("Do you want to enter again landMark for this city: ");
                                            Console.WriteLine("1 ==>> Ok");
                                            Console.WriteLine("2 ==>> No");
                                            var numberForCreatLandMark = int.Parse(Console.ReadLine());
                                            if (numberForCreatLandMark != 1)
                                                break;
                                        }

                                        Console.WriteLine($"Please Crearte ticket for this landMark");
                                        long idOfTicket = 0;
                                        while (true)
                                        {
                                            var ticketForCreatioDto = new TicketForCreationDto();
                                            var ticketService = new TicketService();
                                            ticketForCreatioDto.LandMarkId = idOfLandMark;
                                            Console.WriteLine("Entetr the Flight duration of ticket: ");
                                            ticketForCreatioDto.FlightDuration = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Enter the Prce of ticket: ");
                                            ticketForCreatioDto.Price = decimal.Parse(Console.ReadLine());
                                            var resultDtoOfTicket = await ticketService.CreateAsync(ticketForCreatioDto);
                                            idOfTicket = resultDtoOfTicket.Id;

                                            Console.WriteLine("Successfully Ticket has been created");

                                            Console.WriteLine("Do you want to enter again landMark for this city: ");
                                            Console.WriteLine("1 ==>> Ok");
                                            Console.WriteLine("2 ==>> No");
                                            var numberForCreatLandMark = int.Parse(Console.ReadLine());
                                            if (numberForCreatLandMark != 1)
                                                break;
                                        }

                                        Console.WriteLine("Pleace Create hotels for this LandMark ");
                                        long idOfHotel = 0;
                                        while (true)
                                        {
                                            var hotelForCreationDto = new HotelForCreationDto();
                                            var hotelService = new HotelService();
                                            hotelForCreationDto.LandMarkId = idOfLandMark;
                                            Console.WriteLine("Enter the name of hotel: ");
                                            hotelForCreationDto.Name = Console.ReadLine();
                                            Console.WriteLine("Enter the price of hotel: ");
                                            hotelForCreationDto.Price = decimal.Parse(Console.ReadLine());
                                            Console.WriteLine("Enter the number of rooms of hotel: ");
                                            hotelForCreationDto.NumberOfRoom = int.Parse(Console.ReadLine());
                                            var resultDtoOfHotel = await hotelService.CreateAsync(hotelForCreationDto);
                                            idOfHotel = resultDtoOfHotel.Id;

                                            Console.WriteLine("Successfully Hotel has been created");

                                            Console.WriteLine("Do you want to enter again landMark for this city: ");
                                            Console.WriteLine("1 ==>> Ok");
                                            Console.WriteLine("2 ==>> No");
                                            var numberForCreatLandMark = int.Parse(Console.ReadLine());
                                            if (numberForCreatLandMark != 1)
                                                break;
                                        }

                                        break;
                                    case 2:
                                        cheking = false;
                                        break;
                                    
                                    default:
                                        Console.WriteLine("Please enter the correct number: ");
                                        break;
                                }
                            }
                            break;
                        case 2:

                            break;
                        case 3:
                            break;
                        default:
                            Console.WriteLine("Bolishi mumkinmas??");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Please enter correct number: ");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("             ██████╗ ███████╗ ██████╗  ██████╗ ███████╗███╗   ███╗\r\n            ██╔════╝ ██╔════╝██╔═══██╗██╔════╝ ██╔════╝████╗ ████║\r\n            ██║  ███╗█████╗  ██║   ██║██║  ███╗█████╗  ██╔████╔██║\r\n            ██║   ██║██╔══╝  ██║   ██║██║   ██║██╔══╝  ██║╚██╔╝██║\r\n            ╚██████╔╝███████╗╚██████╔╝╚██████╔╝███████╗██║ ╚═╝ ██║\r\n             ╚═════╝ ╚══════╝ ╚═════╝  ╚═════╝ ╚══════╝╚═╝     ╚═╝\r\n                                                                  ");
                    break;
            }
        }
    }
}
