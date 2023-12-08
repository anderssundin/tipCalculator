using Newtonsoft.Json;

namespace tipCalculator
{
    class ReviewManager
    {
        private string where;
        private string review;
        private string sentiment;
  
    public string Where
    {
        get { return where; }
        set { where = value; }
    }

        // Setters and getters
        public string Review
        {
            get { return review; }
            set { review = value; }
        }

        public string Sentiment
        {
            get { return sentiment; }
            set { sentiment = value; }
        }


        //Method to add a new review
        public bool addReview() 
        {
         
        // create a list for reviews
        List<ReviewManager> reviews = new List<ReviewManager>();
            // Check if file exists
            if (File.Exists("reviews.json"))
            {
                string json = File.ReadAllText("reviews.json");
                reviews = JsonConvert.DeserializeObject<List<ReviewManager>>(json);
            }

            // add a new review to file

            reviews.Add(new ReviewManager { where = where, review = review, sentiment = sentiment });

            // convert to Json

            string newJson = JsonConvert.SerializeObject(reviews, Formatting.Indented);

            // Write to file
            File.WriteAllText("reviews.json", newJson);
            return true;
            
        }

        // Method to get all reviews

        public List<ReviewManager> getAllReviews ()
        {
            // Check if file exists
            if (!File.Exists("reviews.json"))
            {
                // return an empty list if no file
                return new List<ReviewManager>();
            }

            // Create a list to hold the reviews
            List<ReviewManager> reviews = new List<ReviewManager> ();

            // Get the reviews
            string getReviews = File.ReadAllText("reviews.json");
            

            // deserialize
            reviews = JsonConvert.DeserializeObject<List<ReviewManager>>(getReviews);
            
          
            return reviews;
        }

        public bool deleteReview (int index)
        {

            // Create a list to hold the reviews
            List<ReviewManager> reviews = new List<ReviewManager>();

            // Get file of reviews
            string json = File.ReadAllText("reviews.json");

            // deserialize 
            reviews = JsonConvert.DeserializeObject<List<ReviewManager>>(json);
            // Remove by passed index
            reviews.RemoveAt(index);

            // convert to Json

            string newJson = JsonConvert.SerializeObject(reviews, Formatting.Indented);

            // Write to file
            File.WriteAllText("reviews.json", newJson);

            return true;
        }


        // class and namespace }
    }
}
