using GeoGem.Data.Repositories;
using GeoGem.Domain.Entities;
using GeoGem.Service.DTOs.Bookings;
using GeoGem.Service.DTOs.Cities;
using GeoGem.Service.DTOs.Hotels;
using GeoGem.Service.DTOs.LandMarks;
using GeoGem.Service.DTOs.Tickets;
using GeoGem.Service.DTOs.Users;
using GeoGem.Service.Services;
using NuGet.Protocol.Core.Types;
using System.Runtime.InteropServices;

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
                    Console.Clear();
                    await Console.Out.WriteLineAsync(user.Name + " " + "your account has been created");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("             ██████╗ ███████╗ ██████╗  ██████╗ ███████╗███╗   ███╗\r\n            ██╔════╝ ██╔════╝██╔═══██╗██╔════╝ ██╔════╝████╗ ████║\r\n            ██║  ███╗█████╗  ██║   ██║██║  ███╗█████╗  ██╔████╔██║\r\n            ██║   ██║██╔══╝  ██║   ██║██║   ██║██╔══╝  ██║╚██╔╝██║\r\n            ╚██████╔╝███████╗╚██████╔╝╚██████╔╝███████╗██║ ╚═╝ ██║\r\n             ╚═════╝ ╚══════╝ ╚═════╝  ╚═════╝ ╚══════╝╚═╝     ╚═╝\r\n                                                                  ");

                    break;
                case 2:
                    Console.WriteLine("Enter the email: ");
                    var email = Console.ReadLine();
                    Console.WriteLine("Enter the password: ");
                    var password = Console.ReadLine();
                    var authentication = new AuthenticationService();
                    var check = await authentication.AuthoriseAsync(email, password);
                    if(check == 0)
                    {
                        Console.WriteLine("Email or password is incorrect");
                        break;
                    }
                    switch (check)
                    {
                        case 1:
                            var cheking = true;
                            while (cheking)
                            {
                                Console.WriteLine("1 ==>> Create for traveling ");
                                Console.WriteLine("2 ==>> See all bookings");
                                Console.WriteLine("3 ==>> See all users");
                                Console.WriteLine("4 ==>> See all Cities");
                                Console.WriteLine("5 ==>> See all landmarks");
                                Console.WriteLine("6 ==>> See all Hotels");
                                Console.WriteLine("7 ==>> See all Tickets");
                                Console.WriteLine("8 ==>> Back to registration page");
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
                                        Console.Write("Enter the latitude of City: ");
                                        cityForCeationDto.Latitude = double.Parse(Console.ReadLine());
                                        Console.Write("Enter the Longtitude of City: ");
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
                                            Console.Write("Enter the description: ");
                                            landMarkCreationDto.Description = Console.ReadLine();
                                            Console.Write("Enter the latitude of LandMark: ");
                                            landMarkCreationDto.Latitude = double.Parse(Console.ReadLine());
                                            Console.Write("Enter the Longtitude of LandMark: ");
                                            landMarkCreationDto.Longitude = double.Parse(Console.ReadLine());
                                            landMarkCreationDto.CityId = resultDtoOfCity.Id;
                                            var resultDtoOfLandMark = await landMarkService.CreateAsync(landMarkCreationDto);
                                            idOfLandMark = resultDtoOfLandMark.Id;
                                            Console.WriteLine("Successfully LandMark for city has been created");

                                            Console.WriteLine("Do you want to enter again landMark for this city: ");
                                            Console.WriteLine("1 ==>> Ok");
                                            Console.WriteLine("AnyNumber ==>> No");
                                            var numberForCreateLandMark = int.Parse(Console.ReadLine());
                                            if (numberForCreateLandMark != 1)
                                                break;
                                        }

                                        Console.WriteLine($"Please Create ticket for this landMark");
                                        long idOfTicket = 0;
                                        while (true)
                                        {
                                            var ticketForCreationDto = new TicketForCreationDto();
                                            var ticketService = new TicketService();
                                            ticketForCreationDto.LandMarkId = idOfLandMark;
                                            Console.Write("Entetr the Flight duration of ticket: ");
                                            ticketForCreationDto.FlightDuration = double.Parse(Console.ReadLine());
                                            Console.Write("Enter the Flight time(MM/DD/YY): ");
                                            ticketForCreationDto.FlightTime = DateTime.Parse(Console.ReadLine());
                                            Console.Write("Enter the Price of ticket: ");
                                            ticketForCreationDto.Price = decimal.Parse(Console.ReadLine());
                                            var resultDtoOfTicket = await ticketService.CreateAsync(ticketForCreationDto);
                                            idOfTicket = resultDtoOfTicket.Id;

                                            Console.WriteLine("Successfully Ticket has been created");

                                            Console.WriteLine("Do you want to enter again landMark for this city: ");
                                            Console.WriteLine("1 ==>> Ok");
                                            Console.WriteLine("AnyNumber ==>> No");
                                            var numberForCreateLandMark = int.Parse(Console.ReadLine());
                                            if (numberForCreateLandMark != 1)
                                                break;
                                        }

                                        Console.WriteLine("Please Create hotels for this LandMark ");
                                        long idOfHotel = 0;
                                        while (true)
                                        {
                                            var hotelForCreationDto = new HotelForCreationDto();
                                            var hotelService = new HotelService();
                                            hotelForCreationDto.LandMarkId = idOfLandMark;
                                            Console.Write("Enter the name of hotel: ");
                                            hotelForCreationDto.Name = Console.ReadLine();
                                            Console.Write("Enter the price of hotel: ");
                                            hotelForCreationDto.Price = decimal.Parse(Console.ReadLine());
                                            Console.Write("Enter the number of rooms of hotel: ");
                                            hotelForCreationDto.NumberOfRoom = int.Parse(Console.ReadLine());
                                            var resultDtoOfHotel = await hotelService.CreateAsync(hotelForCreationDto);
                                            idOfHotel = resultDtoOfHotel.Id;

                                            Console.WriteLine("Successfully Hotel has been created");

                                            Console.WriteLine("Do you want to enter again landMark for this city: ");
                                            Console.WriteLine("1 ==>> Ok");
                                            Console.WriteLine("AnyNumber ==>> No");
                                            var numberForCreateLandMark = int.Parse(Console.ReadLine());
                                            if (numberForCreateLandMark != 1)
                                                Console.Clear();
                                                break;
                                        }

                                        break;
                                    case 2:
                                        var bookingService = new BookingService();
                                        var bookings = await bookingService.GetAllAsync();
                                        foreach(var booking in bookings)
                                        {
                                            Console.WriteLine($"Id of booking: {booking.Id} | ");
                                            var userServiceForGetting = new UserService();
                                            var userForGetting = await userServiceForGetting.GetByIdAsync(booking.UserId);
                                            Console.WriteLine($"Name of user: {userForGetting.Name} | ");

                                            var landMarkForGettingService = new LandMarkService();
                                            var landMarkForGetting = await landMarkForGettingService.GetByIdAsync(booking.LandMarkId);
                                            if (landMarkForGetting != null)
                                                Console.WriteLine($"{landMarkForGetting.Name} | {landMarkForGetting.Description} | ");
                                            else
                                                Console.WriteLine("null |");

                                            var ticketForGettingService = new TicketService();
                                            var ticketForGetting = await ticketForGettingService.GetByIdAsync(booking.TicketId);
                                            if (ticketForGetting != null)
                                                Console.WriteLine($"{ticketForGetting.FlightTime} | {ticketForGetting.Price} | ");
                                            else
                                                Console.WriteLine("null |");

                                            var hotelForGettingService = new HotelService();
                                            if (booking.HotelId != 0)
                                            {
                                                var hotelForGetting = await hotelForGettingService.GetByIdAsync(booking.HotelId);
                                                if (hotelForGetting != null)
                                                    Console.WriteLine($"{hotelForGetting.Name} | {hotelForGetting.Price} | {hotelForGetting.NumberOfRoom} ");
                                                else
                                                    Console.WriteLine("null ");
                                            }
                                            else
                                                Console.WriteLine($"null ");

                                            Console.WriteLine("\n ------------------------------------------------------------------------------------------------ \n");
                                            
                                        }
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    case 3:
                                        var cityServiceForGettings = new UserService();
                                        var usersForGetting = await cityServiceForGettings.GetAllAsync();
                                        foreach(var u in usersForGetting)
                                        {
                                            Console.WriteLine($"Id: {u.Id} | Name: {u.Name} | Balance: {u.Balance} | CreatedAt: {u.CreatedAt}");
                                        }
                                        Console.WriteLine();
                                        var backToSeeAllUsersPage = true;
                                        while (backToSeeAllUsersPage)
                                        {
                                            Console.WriteLine("1 ==> Do you want to delete user");
                                            Console.WriteLine("2 ==>> No");
                                            var numForDeleteUser = int.Parse(Console.ReadLine());
                                            switch (numForDeleteUser)
                                            {
                                                case 1:
                                                    Console.Write("Enter the id of user: ");
                                                    var idOfUserForDeleting = long.Parse(Console.ReadLine());
                                                    await cityServiceForGettings.RemoveAsync(idOfUserForDeleting);
                                                    Console.WriteLine("Successfully user has been deleted");
                                                    break;
                                                case 2:
                                                    backToSeeAllUsersPage = false;
                                                    break;
                                                default:
                                                    Console.WriteLine("Please, Enter the correct number of page");
                                                    break;
                                            }
                                        }
                                        Console.Clear();
                                        break;
                                    case 4:
                                        var cityServiceForGetting = new CityService();
                                        var citiesForGetting = await cityServiceForGetting.GetAllAsync();
                                        foreach(var c in citiesForGetting)
                                        {
                                            Console.WriteLine($"Id: {c.Id} | Name: {c.Name} | CraeteAt: {c.CraetedAt}");
                                        }
                                        Console.WriteLine();
                                        var backToSeeAllCitiesPage = true;
                                        while (backToSeeAllCitiesPage)
                                        {
                                            Console.WriteLine("1 ==> Do you want to delete City");
                                            Console.WriteLine("2 ==>> No");
                                            var numForDeleteUser = int.Parse(Console.ReadLine());
                                            switch (numForDeleteUser)
                                            {
                                                case 1:
                                                    Console.Write("Enter the id of city: ");
                                                    var idOfCityForDeleting = long.Parse(Console.ReadLine());
                                                    await cityServiceForGetting.RemoveAsync(idOfCityForDeleting);
                                                    Console.WriteLine("Successfully city has been deleted");
                                                    break;
                                                case 2:
                                                    backToSeeAllCitiesPage = false;
                                                    break;
                                                default:
                                                    Console.WriteLine("Please, Enter the correct number of page");
                                                    break;
                                            }
                                        }
                                        Console.Clear();
                                        break;
                                    case 5:
                                        var landMarkServiceForGetting = new LandMarkService();
                                        var landMarksForGetting = await landMarkServiceForGetting.GetAllAsync();
                                        foreach(var l in landMarksForGetting)
                                        {
                                            Console.WriteLine($"Id: {l.Id} | Name: {l.Name} | CityId: {l.CityId} | Desctiption: {l.Description} | CraetedAt: {l.CreatedAt}");
                                        }
                                        Console.WriteLine();
                                        var backToSeeAllLandMarksPage = true;
                                        while (backToSeeAllLandMarksPage)
                                        {
                                            Console.WriteLine("1 ==> Do you want to delete landmark");
                                            Console.WriteLine("2 ==>> No");
                                            var numForDeleteUser = int.Parse(Console.ReadLine());
                                            switch (numForDeleteUser)
                                            {
                                                case 1:
                                                    Console.Write("Enter the id of landMark: ");
                                                    var idOfLandMarkForDeleting = long.Parse(Console.ReadLine());
                                                    await landMarkServiceForGetting.RemoveAsync(idOfLandMarkForDeleting);
                                                    Console.WriteLine("Successfully landmark has been deleted");
                                                    break;
                                                case 2:
                                                    backToSeeAllLandMarksPage = false;
                                                    break;
                                                default:
                                                    Console.WriteLine("Please, Enter the correct number of page");
                                                    break;
                                            }
                                        }
                                        Console.Clear();
                                        break;
                                    case 6:
                                        var hotelServiceForGetting = new HotelService();
                                        var hotelsForGetting = await hotelServiceForGetting.GetAllAsync();
                                        foreach( var h in hotelsForGetting)
                                        {
                                            Console.WriteLine($"Id: {h.Id} | Name: {h.Name} | Price: {h.Price} | CratedAt: {h.CraetedAt}");
                                        }
                                        Console.WriteLine();
                                        var backToSeeAllHotelsPage = true;
                                        while (backToSeeAllHotelsPage)
                                        {
                                            Console.WriteLine("1 ==> Do you want to delete hotel");
                                            Console.WriteLine("2 ==>> No");
                                            var numForDeleteUser = int.Parse(Console.ReadLine());
                                            switch (numForDeleteUser)
                                            {
                                                case 1:
                                                    Console.Write("Enter the id of hotel: ");
                                                    var idOfHotelForDeleting = long.Parse(Console.ReadLine());
                                                    await hotelServiceForGetting.RemoveAsync(idOfHotelForDeleting);
                                                    Console.WriteLine("Successfully hotel has been deleted");
                                                    break;
                                                case 2:
                                                    backToSeeAllHotelsPage = false;
                                                    break;
                                                default:
                                                    Console.WriteLine("Please, Enter the correct number of page");
                                                    break;
                                            }
                                        }
                                        Console.Clear();
                                        break;
                                    case 7:
                                        var ticketServiceForGetting = new TicketService();
                                        var ticketsForGetting = await ticketServiceForGetting.GetAllAsync();
                                        foreach(var t in ticketsForGetting)
                                        {
                                            Console.WriteLine($"Id: {t.Id} | LandMarkId: {t.LandMarkId} | Price: {t.Price} | FlightDuration: {t.FlightDuration} | FlightTime: {t.FlightTime}");
                                        }
                                        Console.WriteLine();
                                        var backToSeeAllTicketsPage = true;
                                        while (backToSeeAllTicketsPage)
                                        {
                                            Console.WriteLine("1 ==> Do you want to delete ticket");
                                            Console.WriteLine("2 ==>> No");
                                            var numForDeleteUser = int.Parse(Console.ReadLine());
                                            switch (numForDeleteUser)
                                            {
                                                case 1:
                                                    Console.Write("Enter the id of ticket: ");
                                                    var idOfTicketForDeleting = long.Parse(Console.ReadLine());
                                                    await ticketServiceForGetting.RemoveAsync(idOfTicketForDeleting);
                                                    Console.WriteLine("Successfully ticket has been deleted");
                                                    break;
                                                case 2:
                                                    backToSeeAllTicketsPage = false;
                                                    break;
                                                default:
                                                    Console.WriteLine("Please, Enter the correct number of page");
                                                    break;
                                            }
                                        }
                                        Console.Clear();
                                        break;
                                    case 8:
                                        cheking = false;
                                        Console.Clear();
                                        Console.WriteLine("             ██████╗ ███████╗ ██████╗  ██████╗ ███████╗███╗   ███╗\r\n            ██╔════╝ ██╔════╝██╔═══██╗██╔════╝ ██╔════╝████╗ ████║\r\n            ██║  ███╗█████╗  ██║   ██║██║  ███╗█████╗  ██╔████╔██║\r\n            ██║   ██║██╔══╝  ██║   ██║██║   ██║██╔══╝  ██║╚██╔╝██║\r\n            ╚██████╔╝███████╗╚██████╔╝╚██████╔╝███████╗██║ ╚═╝ ██║\r\n             ╚═════╝ ╚══════╝ ╚═════╝  ╚═════╝ ╚══════╝╚═╝     ╚═╝\r\n                                                                  ");

                                        break;
                                    
                                    default:
                                        Console.WriteLine("Please enter the correct number: ");
                                        break;
                                }
                            }
                            break;
                        case 2:
                            Console.Clear();
                            jump:
                            var backToRegistration = true;
                            while (backToRegistration)
                            {
                                Console.WriteLine("1 ==>> See all cities");
                                Console.WriteLine("2 ==>> See all bookings");
                                Console.WriteLine("3 ==>> Back to Registration page");
                                var numm = int.Parse(Console.ReadLine());
                                switch (numm)
                                {
                                    case 1:
                                        var cityService = new CityService();
                                        var cities = await cityService.GetAllAsync();
                                        if(cities == null)
                                        {
                                            Console.WriteLine("There are not any cities here");
                                        }
                                        else
                                        {
                                            foreach(var city in cities)
                                            {
                                                Console.WriteLine($"Id: {city.Id}\n  Name: {city.Name}\n  ImageUrl: {city.ImageUrl}\n  Latitude: {city.Latitude}\n  Longtitude: {city.Longitude}");
                                            }
                                        }
                                        Console.WriteLine("-------------------------------------------------------------------------------------------------");

                                        var backToSelection = true;
                                        while (backToSelection)
                                        {
                                            Console.WriteLine("1 ==> See all landmarks in city");
                                            Console.WriteLine("2 ==>> Back to selection page");
                                            var n = int.Parse (Console.ReadLine());
                                            switch (n)
                                            {
                                                case 1:
                                                    Console.Clear();
                                                    Console.Write("Enter the id of city: ");
                                                    var idOfCity = long.Parse (Console.ReadLine());
                                                    var cityForSelectLandMark = await cityService.GetByIdAsync(idOfCity);
                                                    if(cityForSelectLandMark == null)
                                                    {
                                                        Console.WriteLine("There isn't any city");
                                                        break;
                                                    }
                                                    var landMarkService = new LandMarkService();
                                                    var landMarks = await landMarkService.GetAllAsync();
                                                    if (landMarks == null)
                                                    {
                                                        Console.WriteLine("There are not any landmarks \nThere is some issue in your databases, Check this");
                                                        break;
                                                    }
                                                    foreach(var l in landMarks)
                                                    {
                                                        if(l.CityId == idOfCity)
                                                            Console.WriteLine($"  Id: {l.Id}\n  CityId: {l.CityId}\n  Name: {l.Name}\n  Latitude: {l.Latitude}\n  Longitude: {l.Longitude}");
                                                    }
                                                    Console.WriteLine("-------------------------------------------------------------------------------");

                                                    var backToSelectCityPage = true;
                                                    while (backToSelectCityPage)
                                                    {
                                                        Console.WriteLine("1 ==>> Select landmark to travel");
                                                        Console.WriteLine("2 ==>> Back to select city page");
                                                        var idOfSelectLandMark = long.Parse(Console.ReadLine());
                                                        switch(idOfSelectLandMark)
                                                        {
                                                            case 1:
                                                                Console.Write("Enter the id of landmark:  ");
                                                                var idOfLandMark = long.Parse(Console.ReadLine());
                                                                var landMarksService = new LandMarkService();
                                                                var l = await landMarksService.GetByIdAsync(idOfLandMark);
                                                                Console.Clear();
                                                                Console.WriteLine($"Id: {l.Id}\n  CityId: {l.CityId}\n  Name: {l.Name}\n  Description: {l.Description}\n  ImageUrl: {l.ImageUrl}\n  Latitude: {l.Latitude}\n  Longtitude: {l.Longitude}");
                                                                Console.WriteLine();
                                                                Console.WriteLine("      <<<<<<<<<<<<<<<<<   All tickets to travel this please  >>>>>>>>>>>>>>>>");
                                                                var ticketService = new TicketService();
                                                                var tickets = await ticketService.GetAllAsync();
                                                                foreach(var ticket in tickets)
                                                                {
                                                                    if(ticket.LandMarkId == idOfLandMark)
                                                                        Console.WriteLine($"Id: {ticket.Id} | Price: {ticket.Price} | FlightDuration: {ticket.FlightDuration}");
                                                                }
                                                                var backToLandMarkPage = true;
                                                                while (backToLandMarkPage)
                                                                {
                                                                    Console.WriteLine("1 ==>> By ticket to travel this landmark");
                                                                    Console.WriteLine("2 ==>> Back to previous page");
                                                                    var numForByingTicket = int.Parse(Console.ReadLine());
                                                                    switch (numForByingTicket)
                                                                    {
                                                                        case 1:
                                                                            var usersService = new UserService();
                                                                            var person = (await usersService.GetAllAsync()).FirstOrDefault(p => p.Email == email && p.Password == password);
                               
                                                                            Console.WriteLine($" >>>>>>>  You have {person.Balance} money");
                                                                            Console.Write("Enter the id of ticket:  ");
                                                                            var idOfTicket = long.Parse(Console.ReadLine());
                                                                            var ticketForBy = await ticketService.GetByIdAsync(idOfTicket);
                                                                            if (person.Balance >= ticketForBy.Price)
                                                                            {
                                                                                var userForUpdate = new UserForUpdateDto()
                                                                                {
                                                                                    Id = person.Id,
                                                                                    Name = person.Name,
                                                                                    Email = person.Email,
                                                                                    Password = person.Password,
                                                                                    Balance = person.Balance - ticketForBy.Price,
                                                                                };
                                                                                await usersService.UpdateAsync(userForUpdate);

                                                                                Console.Clear();
                                                                                Console.WriteLine("Successfully ticket has been bought");
                                                                                Console.WriteLine();
                                                                                var hotelService = new HotelService();
                                                                                var hotels = await hotelService.GetAllAsync();
                                                                                foreach(var  hotel in hotels)
                                                                                {
                                                                                    Console.WriteLine($"Id:  {hotel.Id} | Name: {hotel.Name} | Price: {hotel.Price} | Number of rooms: {hotel.NumberOfRoom}");
                                                                                }
                                                                                Console.WriteLine("--------------------------------------------------------------");
                                                                                var backToTicketPage = true;
                                                                                while (backToTicketPage)
                                                                                {
                                                                                    Console.WriteLine("1 ==>> By hotel");
                                                                                    Console.WriteLine("2 ==>> Back to previous page");
                                                                                    Console.WriteLine("0 ==>> Exit");
                                                                                    var numOfByHotel = int.Parse(Console.ReadLine());
                                                                                    switch(numOfByHotel)
                                                                                    {
                                                                                        case 0:
                                                                                            Console.Clear();
                                                                                            var bookingService = new BookingService();
                                                                                            var bookingCreationDto = new BookingForCreationDto()
                                                                                            {
                                                                                                UserId = person.Id,
                                                                                                LandMarkId = idOfLandMark,
                                                                                                TicketId = idOfTicket,
                                                                                            };
                                                                                            await bookingService.CreateAsync(bookingCreationDto);
                                                                                            Console.WriteLine($"Successfully you has been bought ticket ");
                                                                                            goto jump;
                                                                                            break;
                                                                                        case 1:

                                                                                            var userServiceForGettingBalance = new UserService();
                                                                                            var userForGettingNewBalanceInHotelPage = await userServiceForGettingBalance.GetByIdAsync(person.Id);
                                                                                            Console.WriteLine($">>>>>>>>>>>>>  You have {userForGettingNewBalanceInHotelPage.Balance} money\n");
                                                                                            Console.Write("Enter the id of hotel:  ");
                                                                                            var idOfHotel = long.Parse(Console.ReadLine());
                                                                                            var hotelsService = new HotelService();
                                                                                            var hotel = await hotelsService.GetByIdAsync(idOfHotel);
                                                                                            if (person.Balance >= hotel.Price)
                                                                                            {
                                                                                                var userServiceInHotelPage = new UserService();
                                                                                                var userForUpdateInHotelPage = await userServiceInHotelPage.GetByIdAsync(person.Id);
                                                                                                var userForUpdateDto = new UserForUpdateDto()
                                                                                                {
                                                                                                    Id = person.Id,
                                                                                                    Name = person.Name,
                                                                                                    Email = person.Email,
                                                                                                    Password = person.Password,
                                                                                                    Balance = userForUpdateInHotelPage.Balance - hotel.Price,
                                                                                                };
                                                                                                await userServiceInHotelPage.UpdateAsync(userForUpdateDto);
                                                                                                Console.Clear();
                                                                                                Console.WriteLine("      Successfully you have been bought hotel and ticket ");
                                                                                                var bookingForCreationDto = new BookingForCreationDto()
                                                                                                {
                                                                                                    UserId = person.Id,
                                                                                                    LandMarkId = idOfLandMark,
                                                                                                    TicketId = idOfTicket,
                                                                                                    HotelId = hotel.Id,
                                                                                                };  
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                Console.Clear();
                                                                                                Console.WriteLine("You don't have enough money to by hotel");
                                                                                            }
                                                                                            break;
                                                                                        case 2:
                                                                                            backToTicketPage = false;
                                                                                            break;
                                                                                        default:
                                                                                            Console.WriteLine("Enter the correct id of hotel");
                                                                                            break;
                                                                                    };
                                                                                }

                                                                            }
                                                                            else
                                                                            {
                                                                                Console.Clear();
                                                                                Console.WriteLine("Sorry, You don't have enough money to by ticket");
                                                                            }
                                                                            break;
                                                                        case 2:
                                                                            backToLandMarkPage = false;
                                                                            break;
                                                                        default:
                                                                            Console.WriteLine("Incorrect number of page");
                                                                            break;
                                                                    }
                                                                }
                                                                break;
                                                            case 2:
                                                                backToSelectCityPage = false;
                                                                break;
                                                            default:
                                                                Console.WriteLine("Please Enter the correct id of landmark");
                                                                break;
                                                        }
                                                    }
                                                    break;
                                                case 2:
                                                    backToSelection = false;
                                                    break;
                                                default:
                                                    Console.WriteLine("Please Select the correct number of page");
                                                    break;
                                            }
                                        }
                                        break;
                                    case 2:
                                        Console.Write("Enter the your id: ");
                                        var idOfUser = long.Parse(Console.ReadLine());
                                        var userServiceInBookingPage = new UserService();
                                        var userForBooking = ( await userServiceInBookingPage.GetAllAsync()).FirstOrDefault(u => u.Email == email && u.Password == password);
                                        if (userForBooking.Id == idOfUser)
                                        {
                                            var bookingService = new BookingService();
                                            var bookings = await bookingService.GetAllAsync();
                                            foreach(var booking in bookings)
                                            {
                                                // Console.WriteLine($"{booking.Id }{booking.UserId } {booking.LandMarkId} {booking.TicketId} {booking.HotelId}");

                                                if(booking.UserId == idOfUser)
                                                {
                                                    Console.WriteLine($" Id of booking: {booking.Id} | ");
                                                    var userServiceForGetting = new UserService();
                                                    var userForGetting = await userServiceForGetting.GetByIdAsync(booking.UserId);
                                                    Console.WriteLine($"Name of user: {userForGetting.Name} | ");
                                                    
                                                    var landMarkForGettingService = new LandMarkService();
                                                    var landMarkForGetting = await landMarkForGettingService.GetByIdAsync(booking.LandMarkId);
                                                    if(landMarkForGetting != null)
                                                        Console.WriteLine($"{landMarkForGetting.Name} | {landMarkForGetting.Description} | ");
                                                    else
                                                        Console.WriteLine(" null |");

                                                    var ticketForGettingService = new TicketService();
                                                    var ticketForGetting = await ticketForGettingService.GetByIdAsync(booking.TicketId);
                                                    if (ticketForGetting != null)
                                                        Console.WriteLine($"{ticketForGetting.FlightTime} | {ticketForGetting.Price} | ");
                                                    else
                                                        Console.WriteLine(" null |");

                                                    var hotelForGettingService = new HotelService();
                                                    if (booking.HotelId != 0)
                                                    {
                                                        var hotelForGetting = await hotelForGettingService.GetByIdAsync(booking.HotelId);
                                                        if (hotelForGetting != null)
                                                            Console.WriteLine($"{hotelForGetting.Name} | {hotelForGetting.Price} | {hotelForGetting.NumberOfRoom} ");
                                                        else
                                                            Console.WriteLine(" null ");
                                                    }
                                                    else
                                                        Console.WriteLine($" null ");

                                                    Console.WriteLine("\n ------------------------------------------------------------------------------------------------ \n");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Please enter the your id!");
                                        }
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    case 3:
                                        backToRegistration = false;
                                        break;
                                    default:
                                        Console.WriteLine("Please enter the correct number!");
                                        break;
                                }

                            }
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
