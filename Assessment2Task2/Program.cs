/* 
 * Project Name: LANGHAM HOTEL MANAGEMENT SYSTEM
 * Author Name: Maha Subh
 * Date: 04/10/2022
 * Application Purpose: Langham hotel managment system is an application 
 *        that helps the hotel staff in their day-to-day operations 
 *        like the Allocation of Rooms, Deallocation of Rooms, 
 *        Displaying the status of Rooms, and other functionalities.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assessment2Task2
{
    // Custom Class - Room
    public class Room
    {
        public int RoomNo { get; set; }
        public bool IsAllocated { get; set; }
    }
    // Custom Class - Customer
    public class Customer
    {
        public int CustomerNo { get; set; }
        public string CustomerName { get; set; }
    }
    // Custom Class - RoomAllocation
    public class RoomlAllocaltion
    {
        public int AllocatedRoomNo { get; set; }
        public Customer AllocatedCustomer { get; set; }
    }

    // Custom Main Class - Program
    internal class Program
    {
        // Variables declaration and initialization
        public static Room[] listofRooms;
        public static List<RoomlAllocaltion> listOfRoomlAllocaltions = new List<RoomlAllocaltion>();
        public static string filePath;

        // Main function
        static void Main(string[] args)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            filePath = Path.Combine(folderPath, "lhms_764703692.txt");

            char ans;
            int choice;

            do
            {
                Console.Clear();
                Console.WriteLine("***********************************************************************************");
                Console.WriteLine("                 LANGHAM HOTEL MANAGEMENT SYSTEM                  ");
                Console.WriteLine("                            MENU                                 ");
                Console.WriteLine("***********************************************************************************");
                Console.WriteLine("1. Add Rooms");
                Console.WriteLine("2. Display Rooms");
                Console.WriteLine("3. Allocate Rooms");
                Console.WriteLine("4. De-Allocate Rooms");
                Console.WriteLine("5. Display Room Allocation Details");
                Console.WriteLine("6. Billing");
                Console.WriteLine("7. Save the Room Allocations To a File");
                Console.WriteLine("8. Show the Room Allocations From a File");
                Console.WriteLine("9. Exit");
                Console.WriteLine("0. File Backup");
                Console.WriteLine("***********************************************************************************");
                Console.Write("Enter Your Choice Number Here:");


                // Validate 'choice' input from the user
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    choice = -1;
                }

                switch (choice)
                {
                    case 1:
                        // adding Rooms function
                        AddRoom();
                        break;
                    case 2:
                        // display Rooms function;
                        ShowRooms();
                        break;
                    case 3:
                        // allocate Room To Customer function
                        AllocateRoomToCustomer();
                        break;
                    case 4:
                        // De-Allocate Room From Customer function
                        DeAllocateRoomFromCustomer();
                        break;
                    case 5:
                        // display Room Alocations function;
                        ShowCurrentStatus();
                        break;
                    case 6:
                        //  Display "Billing Feature is Under Construction and will be added soon…!!!"
                        Billing();
                        break;
                    case 7:
                        // SaveRoomAllocationsToFile
                        SaveRoomAllocationsToFile();
                        break;
                    case 8:
                        //Show Room Allocations From File
                        ShowRoomAllocationsFromFile();
                        break;
                    case 9:
                        // Exit Application
                        Environment.Exit(0);
                        break;
                    case 0:
                        // Back up the file containing the rooms allocation details
                        FileBackup();
                        break;
                    default:
                        Console.WriteLine("Please check your option!");
                        break;
                }

                Console.Write("\nWould You Like To Continue(Y/N):");

                // Validate 'ans' input from the user
                try
                {
                    ans = Convert.ToChar(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    // Exit the program in case of invalid input from the user
                    ans = 'N';
                }

            } while (ans == 'y' || ans == 'Y');
        }

        // fileBackup() method is to get a backup of all rooms allocation details from the original file
        private static void FileBackup()
        {
            try
            {
                // Define the folder and file paths for the backup file
                string backupFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string backupFilePath = Path.Combine(backupFolderPath, "lhms_764703692_backup.txt");

                // Get the content of the source file
                string sourceFileContent = File.ReadAllText(filePath);

                // Append contents to the backup file
                File.AppendAllText(backupFilePath, sourceFileContent);

                // Delete the contents of the source file
                File.WriteAllText(filePath, String.Empty);

                Console.WriteLine("File backup commpleted successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // ShowRoomAllocationsFromFile() method prints rooms allocation details from a file to the Console
        private static void ShowRoomAllocationsFromFile()
        {
            try
            {
                // Open the file for reading
                FileStream f = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                StreamReader streamReader = new StreamReader(f);

                // Read the first line from the file and store in the 'line' variable
                string line = streamReader.ReadLine();

                // Loop as long as it is not the end of the file
                while (line != null)
                {
                    // Write the line on the Console 
                    Console.WriteLine(line);

                    // Read the next line from the file
                    line = streamReader.ReadLine();
                }

                // Close the file
                streamReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        // SaveRoomAllocationsToFile() method saves rooms allocation details to a file
        private static void SaveRoomAllocationsToFile()
        {

            try
            {
                // Open the file for writing and delete any previous content
                FileStream f = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
                f.SetLength(0);

                StreamWriter streamWriter = new StreamWriter(f);



                // Get the time now
                DateTime now = DateTime.Now;

                // Loop to write all room allocations on the file
                foreach (var roomAllocationZ in listOfRoomlAllocaltions)
                {
                    string strToAdd = "RoomNo: " + roomAllocationZ.AllocatedRoomNo + ", CustomerNo: " + roomAllocationZ.AllocatedCustomer.CustomerNo + ", CustomerName: " + roomAllocationZ.AllocatedCustomer.CustomerName + " " + now;

                    streamWriter.WriteLine(strToAdd);
                }

                // Close the file
                streamWriter.Close();
                Console.WriteLine("The Data is Successfully Saved to the File: {0}", filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        // Billing() method is a placeholder for billing functions and it is currently under construction
        private static void Billing()
        {
            Console.WriteLine("Billing Feature is Under Construction and will be added soon…!!!");
        }

        // ShowCurrentStatus() method shows the current status of hotel rooms allocations with the customer details
        private static void ShowCurrentStatus()
        {

            Console.WriteLine("**************************** Rooms Allocations Details ****************************************");
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("Room ID\t Customer ID\t Customer Name");
            Console.WriteLine("------------------------------------------------------------------------------------");

            // Loop to print all room allocation details on the Console
            foreach (RoomlAllocaltion roomAllocationY in listOfRoomlAllocaltions)
            {
                Console.WriteLine(roomAllocationY.AllocatedRoomNo + "\t" + roomAllocationY.AllocatedCustomer.CustomerNo + "\t" + roomAllocationY.AllocatedCustomer.CustomerName);
            }
        }

        // DeAllocateRoomFromCustomer() method deallocates the hotel room and make it available again for allocation
        private static void DeAllocateRoomFromCustomer()
        {
            try
            {
                // Get the room number to be de-allocated
                Console.Write("Please Enter the Room No: ");
                int roomNoY = Convert.ToInt32(Console.ReadLine());

                // Initialize RoomFound variable with the False value
                bool RoomFound = false;

                // Loop to check if the room number does exist
                for (int i = 0; i < listofRooms.Length; i++)
                {
                    // Check if the provided room number matches an existing room in the system
                    if (roomNoY == listofRooms[i].RoomNo)
                    {
                        RoomFound = true;
                        listofRooms[i].IsAllocated = false;
                        break;
                    }
                }

                if (RoomFound)
                {
                    // De-allocate the room if found in the system
                    RoomlAllocaltion roomAllocationX = listOfRoomlAllocaltions.Find(x => x.AllocatedRoomNo == roomNoY);
                    listOfRoomlAllocaltions.Remove(roomAllocationX);
                }
                else
                {
                    throw new InvalidOperationException("Wrong Room Nubmer!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // AllocateRoomToCustomer() method allocates the hotel room to the customer
        private static void AllocateRoomToCustomer()
        {

            try
            {
                // Get the room number to be allocated
                Console.Write("Please Enter the Room No: ");
                int roomNoX = Convert.ToInt32(Console.ReadLine());

                // Initialize a new customer object
                Customer customerX = new Customer();

                // Get the customer number            
                Console.Write("Please Enter the Customer No: ");
                customerX.CustomerNo = Convert.ToInt32(Console.ReadLine());

                // Get the customer name
                Console.Write("Please Enter the Customer Name: ");
                customerX.CustomerName = Console.ReadLine();

                // Initialize RoomFound variable with the False value
                bool RoomFound = false;

                // Loop to check if the room number does exist
                for (int i = 0; i < listofRooms.Length; i++)
                {
                    // Check if the provided room number matches an existing room in the system
                    if (roomNoX == listofRooms[i].RoomNo)
                    {
                        // Check if the room is not already allocated
                        if (listofRooms[i].IsAllocated == false)
                        {
                            RoomFound = true;
                            listofRooms[i].IsAllocated = true;
                        }
                        break;
                    }
                }

                // Add the room allocation details if the room is found in the system
                if (RoomFound)
                {
                    // Initialize new RoomlAllocaltion object
                    RoomlAllocaltion roomAllocation = new RoomlAllocaltion();

                    // Copy the room informaiton to the new new RoomlAllocaltion object named roomAllocation
                    roomAllocation.AllocatedRoomNo = roomNoX;
                    roomAllocation.AllocatedCustomer = customerX;

                    // Add the room allocation object to the list
                    listOfRoomlAllocaltions.Add(roomAllocation);

                }
                else
                {
                    throw new InvalidOperationException("Wrong Room Nubmer or the Room is Already Allocated!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        // ShowRooms() method lists the rooms details (Room number and if it is available for allocation) on the Console
        private static void ShowRooms()
        {
            Console.WriteLine("**************************** Rooms Details ****************************************");
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("Room No.\t Is-Allocated?");
            Console.WriteLine("------------------------------------------------------------------------------------");

            try
            {
                // Loop to print the information of all rooms
                foreach (Room roomX in listofRooms)
                {
                    // Print room information
                    Console.WriteLine(roomX.RoomNo + "\t\t" + roomX.IsAllocated);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        // AddRoom() method adds the hotel rooms to the system
        private static void AddRoom()
        {
            try
            {
                // Get the total number of rooms from the user and convert it to Integer
                Console.Write("Please Enter the Total Number of Rooms in the Hotel:");
                int noOfRooms = Convert.ToInt32(Console.ReadLine());

                // Initialize the array with required number of Room objects
                listofRooms = new Room[noOfRooms];

                // Loop to get the information for all rooms
                for (int i = 0; i < noOfRooms; i++)
                {
                    // Initialize a Room object and add it to the array
                    listofRooms[i] = new Room();

                    // Get the room number
                    Console.Write("Please enter the Room Number: ");
                    listofRooms[i].RoomNo = Convert.ToInt32(Console.ReadLine());

                    // Initilize the room status. All rooms are not allocated by default
                    listofRooms[i].IsAllocated = false;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

}