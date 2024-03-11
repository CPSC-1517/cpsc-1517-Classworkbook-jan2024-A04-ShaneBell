using BlazorApp1.Data;
 
namespace BlazorApp1.Pages.Samples
{
    public partial class Services
    {
        private string? ContactName { get; set; }
        private string? PhoneNumber { get; set; }
        private int YearsAsCustomer { get; set; }
        private bool IsCurrentCustomer { get; set; }

        private string? ServiceType { get; set; }

        private string? Reason { get; set; }
        private string? RequestInformation { get; set; }
        private string? Output { get; set; }

        private bool Success { get; set; } = false;

        private bool ShowReport { get; set; } = false;

        //Instantiate a new dictionary property
        public Dictionary<string, string> ErrorList { get; set; } = new();

        public List<ServiceRequest> ServiceRequests { get; set; } = new();
        private string? Color { get; set; }

        string csvFilePath = @".\Data\Requests.csv";
        public void DisplayData()
        {
            Success = false;

            ErrorList.Clear();
            if (string.IsNullOrWhiteSpace(ContactName))
            {
                ErrorList.Add("contact_name", "Contact name is required");
            }
            if (string.IsNullOrWhiteSpace(PhoneNumber))
            {
                ErrorList.Add("phone_number", "Phone number is required");
            }

            if (ErrorList.Count == 0)
            {
                Success = true;
                Output = $@"<strong>Contact Name:</strong> {ContactName},
        <strong>Phone Number:</strong> {PhoneNumber}
         <strong>Years as Customer:</strong> {YearsAsCustomer}
         <strong>CurrentCustomer:</strong> {IsCurrentCustomer}
         <strong>Service Type:</strong> {ServiceType}
        <strong>Reason:</strong>  {Reason}
        <strong>Request Information:</strong>  {RequestInformation}";

                //Reset the controls(by initializing the properties)
                PhoneNumber = "";
                ContactName = "";
                YearsAsCustomer = 0;
                IsCurrentCustomer = false;
                ServiceType = null;
                Reason = "";
                RequestInformation = "";
            }
        }
        public void AddToList()
        {
            //Add a new service request object to the list
            ServiceRequests.Add(new ServiceRequest(ContactName, PhoneNumber, YearsAsCustomer, IsCurrentCustomer, ServiceType, Reason, RequestInformation));
        }
        public void ClearList()
        {
            ServiceRequests.Clear();
        }
        public void SaveToFile()
        {
            using (StreamWriter writer = new StreamWriter(csvFilePath,true)) 
            {
            foreach (ServiceRequest aRequest in ServiceRequests) 
                {
                writer.WriteLine(aRequest.ToString());
                }
            }
        }
        public void ReadFromFile()
        {
            //Empty the list before loading the file contents
            ServiceRequests.Clear();
            //Array to hold the csv records
            //Each element holds one line of the file 
            string[] userData;
            userData=System.IO.File.ReadAllLines(csvFilePath);
            //Loop through the array and parse each line and add to the list
            foreach(string line in userData) 
            {
            ServiceRequests.Add(ServiceRequest.Parse(line));
            }
        }
        public void DisplayRequests()
        {
            if (ServiceRequests.Count==0)
            {
                ErrorList.Add("empty_list", "The list is empty");
            }
            if (ServiceRequests.Count > 0)
            {
                ShowReport = true;
            }
        }
        protected override void OnInitialized()
        {
            Color = "#ffffff";
            base.OnInitialized();
        }
    }
}
