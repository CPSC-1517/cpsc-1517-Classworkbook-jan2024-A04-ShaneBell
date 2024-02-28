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

        //Instantiate a new dictionary property
        public Dictionary<string, string> ErrorList { get; set; } = new();
        public void DisplayData()
        {
            if(string.IsNullOrWhiteSpace(ContactName)) 
            {
                ErrorList.Add("contact_name", "Contact name is required");
            }
            if (string.IsNullOrWhiteSpace(PhoneNumber))
            {
                ErrorList.Add("phone_number", "Phone number is required");
            }

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
}
