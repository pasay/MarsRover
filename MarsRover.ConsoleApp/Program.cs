using FluentValidation;
using MarsRover.Business.Services;
using MarsRover.Business.Services.Imp;
using MarsRover.ConsoleApp.ConsolExtension;
using MarsRover.ConsoleApp.Exceptions;
using MarsRover.ConsoleApp.Validations;
using MarsRover.Models;
using MarsRover.Models.Commands.Rover;
using MarsRover.Models.Commands.Rover.Imp;
using MarsRover.Models.Enums;
using MarsRover.Models.Rover.Imp;
using MarsRover.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                do
                {
                    Console.Clear();
                    Consol.WriteLineColor(ConsoleColor.Cyan, $"[Paşa Yazıcı]");
                    Consol.WriteLineColor(ConsoleColor.Cyan, $"[pasayazici@hotmail.com]");
                    Consol.WriteLineColor(ConsoleColor.Cyan, $"[532 654 10 50]\r\n");
                    Consol.WriteLineColor(ConsoleColor.White, $"______________________________________________________________");
                    Consol.WriteLineColor(ConsoleColor.Yellow, ConsoleColor.Red, $"Type \"[{Constants.START}]\" to start the rover.");
                    Consol.WriteLineColor(ConsoleColor.Yellow, ConsoleColor.Red, $"Type \"[{Constants.EXIT}]\" to exit the application.");
                    Consol.WriteLineColor(ConsoleColor.White, $"______________________________________________________________\r\n\r\n");

                    var planetModel = GetParameters();
                    IRoverCommandService planetService = new RoverCommandService(planetModel);
                    var planetResult = planetService.Run();

                    Consol.WriteLineColor(ConsoleColor.White, $"\r\n\r\n_______________________RESULT_________________________________\r\n\r\n");
                    planetResult.ForEach(p =>
                    {
                        switch (p.VerboseType)
                        {
                            case ResultType.Warn:
                                Consol.WriteLineColor(ConsoleColor.Yellow, p.Verbose);
                                break;
                            case ResultType.Error:
                                Consol.WriteLineColor(ConsoleColor.Red, p.Verbose);
                                break;
                            case ResultType.Success:
                                Consol.WriteLineColor(ConsoleColor.Green, p.Verbose);
                                break;
                            case ResultType.Info:
                            default:
                                Consol.WriteLineColor(ConsoleColor.White, p.Verbose);
                                break;
                        }
                    });
                    Consol.WriteLineColor(ConsoleColor.White, $"\r\n\r\n______________________________________________________________\r\n\r\n");

                } while (IsRestart());
            }
            catch (ExitException) { }
            catch (Exception ex)
            {
                Consol.WriteLineColor(ConsoleColor.Red, $"Unhandled exception. [Error: {ex.Message}]");
            }
            finally
            {
                Consol.WriteLineColor(ConsoleColor.White, $"Press any key to exit");
                Console.ReadKey();
            }
        }

        private static IRoverCommandItemListModel GetParameters()
        {
            var upperRight = GetUpperRightInput();
            var roverCommand = GetRoverCommandInput(upperRight);
            RoverCommandItemListModel planet = new RoverCommandItemListModel()
            {
                RoverCommand = roverCommand,
                UpperRight = upperRight
            };

            return planet;
        }

        private static IPointModel GetUpperRightInput()
        {
            UpperRightPointModel upperRightPointModel = new UpperRightPointModel();
            UpperRightInputValidator validator = new UpperRightInputValidator();
            string upperRightCoordinateInput;

            do
            {
                Consol.WriteColor(ConsoleColor.Red, ConsoleApp.Properties.Resources.UpperRightInputLabel);
                upperRightCoordinateInput = Console.ReadLine().Trim();
            } while (CommonValidateInfo(validator, upperRightCoordinateInput));

            var values = upperRightCoordinateInput.Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            upperRightPointModel.X = Convert.ToInt32(values[0]);
            upperRightPointModel.Y = Convert.ToInt32(values[1]);

            return upperRightPointModel;
        }

        private static List<IRoverCommandItemModel> GetRoverCommandInput(IPointModel upperRight)
        {
            List<IRoverCommandItemModel> roverCommandList = new List<IRoverCommandItemModel>();

            do
            {
                var rover = GetRoverInput(upperRight);
                var moveList = GetMoveListInput();
                roverCommandList.Add(new RoverCommandItemModel { MoveListModel = moveList, RoverModel = rover });
                Consol.WriteColor(ConsoleColor.Yellow, ConsoleColor.Red, ConsoleApp.Properties.Resources.AddNewLabel);
            } while ((new List<char> { 'Y', 'y' }).Contains((char)Console.ReadLine().Trim().First()));

            return roverCommandList;
        }

        private static RectangleRoverModel GetRoverInput(IPointModel upperRight)
        {
            RectangleRoverModel rectangleRoverModel = new RectangleRoverModel();
            RectangleRoverInputValidator validator = new RectangleRoverInputValidator();
            RoverMapValidator roverMapValidator = new RoverMapValidator(upperRight);
            string rectangleRoverInput;

            do
            {
                do
                {
                    Consol.WriteColor(ConsoleColor.Red, ConsoleApp.Properties.Resources.RoverInputLabel);
                    rectangleRoverInput = Console.ReadLine().Trim();
                } while (CommonValidateInfo(validator, rectangleRoverInput));

                var values = rectangleRoverInput.Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                rectangleRoverModel.X = Convert.ToInt32(values[0]);
                rectangleRoverModel.Y = Convert.ToInt32(values[1]);
                rectangleRoverModel.Direction = Enum.Parse<DirectionType>(values[2].ToUpperInvariant());
            } while (CommonValidateInfo(roverMapValidator, rectangleRoverModel));

            return rectangleRoverModel;
        }

        private static MoveListModel GetMoveListInput()
        {
            MoveListModel moveListModel = new MoveListModel();
            MoveListInputValidator validator = new MoveListInputValidator();
            string moveListInput;

            do
            {
                Consol.WriteColor(ConsoleColor.Red, ConsoleApp.Properties.Resources.MoveListInputLabel);
                moveListInput = Console.ReadLine().Trim();
            } while (CommonValidateInfo(validator, moveListInput));

            var values = moveListInput.ToCharArray().ToList();
            values.ForEach(p => moveListModel.Add(Enum.Parse<MoveType>(p.ToString().ToUpperInvariant())));

            return moveListModel;
        }

        private static bool CommonValidateInfo<T, K>(T validator, K value) where T : IValidator<K>
        {
            var result = validator.Validate(value);
            if (result.IsValid)
            {
                return false;
            }

            bool retry = false;
            foreach (var item in result.Errors)
            {
                Consol.WriteLineColor(ConsoleColor.Red, item.ErrorMessage);
                if (item.ErrorCode == Constants.EXIT)
                {
                    throw new ExitException();
                }
                else if (item.ErrorCode == Models.Constants.ErrorCodes.RETRY)
                {
                    retry = true;
                }
            }

            return retry;
        }

        private static bool IsRestart()
        {
            Consol.WriteColor(ConsoleColor.Yellow, ConsoleColor.Red, ConsoleApp.Properties.Resources.TryAgain);
            return (new List<char> { 'Y', 'y' }).Contains((char)Console.ReadKey().KeyChar);
        }
    }
}
