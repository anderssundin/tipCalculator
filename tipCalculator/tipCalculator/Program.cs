using System.Runtime.CompilerServices;
using tipCalculator;
using TipCalculator;
bool exitProgram = false;
// Instanciate of class to use in program
ReviewManager reviewManager = new ReviewManager();

while (!exitProgram)
{
    //Clear console before every iteration
    Console.Clear();
    
    // Call function to show navigation
    showNavigation();
    int navChoiceConverted = 0;
    // Get navigation input from user
    string navChoice = Console.ReadLine().ToLower();
    if (navChoice == "x")
    {
        Console.WriteLine("╔════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                         HAVE A GREAT DAY!                          ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════════════╝");
        Console.ReadLine();
        exitProgram = true;
        break;
       
    } else
    { 

    // Check if input is valid for navigation
    bool validNavChoice = false;
    

    // Control if menu-choice is valid
    while (!validNavChoice)
    {
       
        // Parse from string to integer
        int.TryParse(navChoice, out navChoiceConverted);

       
        // Check if parsed integer is a valid number
        if (navChoiceConverted < 1 || navChoiceConverted > 3)
        {
            Console.Clear();
            showNavigation();

            // Change color to red to indicate a problem
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Choose a valid menu option");

            // Reset text color to default
            Console.ResetColor();

            navChoice = Console.ReadLine();
        } 
        else
        {
                Console.Clear();
                validNavChoice = true;
        }
    }
    }
    // Make decisions based on input
    switch (navChoiceConverted)
    {
        case 1:
            // Run code to recive information and calculate tip
            runTipCalculation();
            // Ask if write review
            Console.WriteLine("\nWould you like to create a review?");
            Console.WriteLine("Y/N");
            string switch1MakeReview = "";
            switch1MakeReview = Console.ReadLine().ToLower();
            bool validAskReview = false;
            while (!validAskReview)
            {
                if (switch1MakeReview != "y" && switch1MakeReview != "n")
                {

                    Console.Clear();
                    // Change color to red to indicate a problem
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nWould you like to create a review?");
                    Console.WriteLine("Y/N");
                    Console.ResetColor();
                    switch1MakeReview = Console.ReadLine();

                }
                else if (switch1MakeReview == "y")
                {
                    validAskReview = true;
                    createNewReview();
                }
                else
                {

                    validAskReview = true;

                }
            }


            break;
        case 2:
            // Code for creating a new review
            createNewReview();


            break;
        case 3:
            Console.Clear();
            var allReviews = reviewManager.getAllReviews();
            showReviewsMenu();


            // Output all reviews to the screen
            if (allReviews.Count > 0)
            {
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════╗\n");
                for (int i = 0; i < allReviews.Count; i++)
                {
                    var review = allReviews[i];
                    if (review.Sentiment == "Positive")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.WriteLine("   ----------------------------------------------------------");
                    Console.WriteLine($"        * {review.Where}          ");
                    Console.WriteLine($"            A {review.Sentiment} review");
                    Console.WriteLine($"            ** {review.Review} **");
                    Console.WriteLine("   ----------------------------------------------------------\n");

                    Console.ResetColor();
                }
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════╝");
            }
            else
            {
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║             Seems like there is no reviews written yet..           ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════╝");
            }
            string reviewMenuOptions = "";
            reviewMenuOptions = Console.ReadLine().ToLower();
            bool reviewMenuOptionsValid = false;
            while (!reviewMenuOptionsValid)
            {
                Console.Clear();
                if (reviewMenuOptions != "1" && reviewMenuOptions != "x")
                {
                    Console.Clear();
                    showReviewsMenu();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Choose a valid option");
                    reviewMenuOptions = Console.ReadLine().ToLower();
                    Console.ResetColor();
                }
                else
                {

                    Console.Clear();
                    reviewMenuOptionsValid = true;
                }
                
            }

            switch (reviewMenuOptions)
            {
                case "1":
                    {
                       
                        deleteReview();
                        
                    }
                    break;

                case "x":
                    {
                        Console.Clear();
                        break;
                    }
                    break;
                default:
                    {
                        bool correctOption = false;
                        while (!correctOption)
                        {
                            Console.Clear();
                            showReviewsMenu();
                            Console.WriteLine("Choose between options 1 and X");
                            reviewMenuOptions = Console.ReadLine().ToLower();
                            if (reviewMenuOptions == "x" || reviewMenuOptions == "1")
                            {
                                Console.Clear();
                                correctOption = true;
                            }
                            else
                            {
                                Console.Clear();
                                correctOption = false;

                            }
                        }
                    }
                    break;
            }

            break;
        default:
            Console.WriteLine("Invalid menu option");
            break;
    }
    // Code for calculation of tip
    void runTipCalculation()
    {
        // Code for calculating tip
        // Variables for calculations
        string askForBill = "";
        string askForPersons = "";
        string askForPercent = "";
        string askForCreateReview = "";
        bool billPassed = false;
        bool personsPassed = false;
        bool percentsPassed = false;
        bool createReview = false;

        double bill = 0;
        int persons = 0;
        int percent = 0;

        Console.Clear();

        // Function for showing menu-header
        void tipHeader()
        {
            Console.WriteLine("╔══════════════════════════════╗");
            Console.WriteLine("║       CALCULATE TIP          ║");
            Console.WriteLine("╚══════════════════════════════╝\n");
        }
        tipHeader();

        /*
         ASK FOR BILL
         */
        Console.WriteLine("Enter bill amount");
        askForBill = Console.ReadLine();
        while (!billPassed)
        {
            if (double.TryParse(askForBill, out bill) && bill != 0)
            {
                billPassed = true;
            }
            else
            {
                Console.Clear();
                tipHeader();
                // Change color to red to indicate a problem
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Type bill amount");
                // Reset text color to default
                Console.ResetColor();

                askForBill = Console.ReadLine();
            }
        } // Move this bracket to the correct position

        /*
         ASK FOR NUMBER OF PERSONS TO SPLIT BILL WITH
         */
        Console.Clear();
        tipHeader();
        Console.WriteLine("How many are sharing the bill?");
        askForPersons = Console.ReadLine();
        while (!personsPassed)
        {
            if (int.TryParse(askForPersons, out persons) && persons != 0)
            {
                personsPassed = true;
            }
            else
            {
                Console.Clear();
                tipHeader();
                // Change color to red to indicate a problem
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("How many are sharing the bill?");
                // Reset text color to default
                Console.ResetColor();

                askForPersons = Console.ReadLine();
            }
        }

        /*
         ASK FOR NUMBER OF PERCENTAGE
         */
        Console.Clear();
        tipHeader();
        Console.WriteLine("How many percent would you like to tip on top of the bill?");
        askForPercent = Console.ReadLine();
        while (!percentsPassed)
        {
            if (int.TryParse(askForPercent, out percent))
            {
                percentsPassed = true;

            }
            else
            {
                Console.Clear();
                tipHeader();
                // Change color to red to indicate a problem
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("How many percent would you like to tip on top of the bill??");
                // Reset text color to default
                Console.ResetColor();

                askForPercent = Console.ReadLine();
            }
        }

        /*
         CREATE INSTANSE OF  CALCULATE TIP CLASS AND MAKE CALCULATIONS FOR THE TIP
         */
        Console.Clear();

        Console.WriteLine("╔═══════════════════════════════╗");
        Console.WriteLine("║         TIP RESULT            ║");
        Console.WriteLine("╚═══════════════════════════════╝\n");
        CalculateTip calculateTip = new CalculateTip(bill, persons, percent);
        double calculatedNoteSplit = calculateTip.calcNoteSplit();
        double calculatedPercentSplit = calculateTip.calcPercentage();

        Console.WriteLine($"Each person should pay ${calculatedNoteSplit:F2} on the bill.");
        Console.WriteLine($"Tip amount at {percent}%: ${calculatedPercentSplit:F2}\n");
        Console.WriteLine("===================================");
        Console.WriteLine($"     TOTAL AMOUNT: ${calculatedNoteSplit + calculatedPercentSplit:F2}");
        Console.WriteLine("===================================");
    }

    // Code for main navigation
    void showNavigation()
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════╗");
        Console.WriteLine("║        TIP CALCULATOR        ║");
        Console.WriteLine("╚══════════════════════════════╝\n");
        Console.WriteLine("[1] Calculate tip");
        Console.WriteLine("[2] Create new review");
        Console.WriteLine("[3] Show previous reviews\n");
        Console.WriteLine("[X] To terminate program\n");
        Console.WriteLine("==========================\n");
        Console.WriteLine("Choose a number to navigate...");
    }

    void showReviewsMenu()
    {
        Console.Clear();
        // Code for showing previous reviews
        Console.WriteLine("╔════════════════════════╗");
        Console.WriteLine("║       MY REVIEWS       ║");
        Console.WriteLine("╚════════════════════════╝");
        var allReviewsCount = reviewManager.getAllReviews();
        if (allReviewsCount.Count > 0)
        {
            Console.WriteLine("[1] Delete a review\n");
        }
        Console.WriteLine("[X] Go back\n");
        Console.WriteLine("==========================\n");
        Console.WriteLine("Choose an option to navigate...");

       
    }

    // Code for making a review
    void createNewReview()
    {
        Console.Clear();

        reviewManager.Where = "";
        reviewManager.Review = "";
        string sentiment = "";
        bool wherePassed = false;
        bool reviewPassed = false;
        // Get information for review
        while (!wherePassed)
        {
            if (reviewManager.Where == "")
            {
                Console.WriteLine("Where did you eat?");
                reviewManager.Where = Console.ReadLine();
                wherePassed = false;
                Console.Clear();
            }
            else
            {
                wherePassed = true;
                while (!reviewPassed)
                {
                    if (reviewManager.Review == "")
                    {
                        Console.Clear();
                        Console.WriteLine("Enter review");
                        reviewManager.Review = Console.ReadLine();
                        reviewPassed = false;
                    }
                    else
                    {

                        
                        Console.Clear();
                        reviewPassed = true;
                    }

                }
            }
        }

        // Use Machine Learning to determine if its a good or bad review
        var sampleData = new SentimentModel.ModelInput()
        {
            Col0 = reviewManager.Review
        };

        // Load model and predict output of sample data
        var result = SentimentModel.Predict(sampleData);

        // If Prediction is 1, sentiment is "Positive"; otherwise, sentiment is "Negative"
        reviewManager.Sentiment = result.PredictedLabel == 1 ? "Positive" : "Negative";

        // add save to file
        if (reviewManager.addReview())
        {
            Console.Clear();

            Console.WriteLine($"\n Review was created!");

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }else
        {
            Console.WriteLine($"\n Something went wrong, please try again :(");
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
     

    }

    void deleteReview()
    {

        Console.Clear();
        Console.SetCursorPosition(0, 0);
        // Code for showing previous reviews


        Console.WriteLine("╔════════════════════════╗");
        Console.WriteLine("║     DELETE REVIEW      ║");
        Console.WriteLine("╚════════════════════════╝");

        Console.WriteLine("[X] Go back\n");
        Console.WriteLine("==========================\n");
        Console.WriteLine("Choose an number to delete review or go back with X...");


        var allReviews = reviewManager.getAllReviews();



        // Output all reviews to the screen

        Console.WriteLine("╔════════════════════════════════════════════════════════════════════╗\n");
        for (int i = 0; i < allReviews.Count; i++)
        {
            var review = allReviews[i];
            if (review.Sentiment == "Positive")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine("   ----------------------------------------------------------");
            Console.WriteLine($"  [{i}]   * {review.Where}          ");
            Console.WriteLine($"            A {review.Sentiment} review");
            Console.WriteLine($"            ** {review.Review} **");
            Console.WriteLine("   ----------------------------------------------------------\n");

            Console.ResetColor();
        }
        Console.WriteLine("╚════════════════════════════════════════════════════════════════════╝");
        // Get index to remove
        string removeIndex = "";
        removeIndex = Console.ReadLine().ToLower();
        if (removeIndex != "x")
        {


            // Parse to int
            int removeIndexInt = 0;


            // Check if integer is in review index range
            bool inRange = false;
            while (!inRange)
            {
                if (int.TryParse(removeIndex, out removeIndexInt))
                {
                    if (removeIndexInt > allReviews.Count - 1)
                    {
                        
                        Console.WriteLine("Choose a number that corresponds to the review you would like to delete");
                        removeIndex = Console.ReadLine().ToLower();
                        if (removeIndex == "x")
                        {
                            Console.Clear();
                            inRange = true;
                        }
                        else
                        {
                            int.TryParse(removeIndex, out removeIndexInt);
                            
                        }


                    }
                    else
                    {
                        inRange = true;
                        if (reviewManager.deleteReview(removeIndexInt))
                        {
                            Console.WriteLine("Review removed");
                            Console.ReadLine();
                        }

                    }
                }
                else
                {
                   
                    Console.WriteLine("Choose a number that corresponds to the review you would like to delete");
                    removeIndex = Console.ReadLine();
                    if (removeIndex == "x")
                    {
                        Console.Clear();
                        inRange = true;
                    } else
                    {
                        int.TryParse(removeIndex, out removeIndexInt);
                    }
                 
                }
               
            }
        } else
        {
            
        }

        //END OF FILE
    }
}