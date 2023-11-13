namespace TimeSheet.WebApi.DTOs.Responses
{
    public class WorkDayResponse
    {
        public string Id {  get; set; }
        public string ClientName {  get; set; }
        public string ClientId {  get; set; }
        public string ProjectName { get; set; }
        public string ProjectId { get; set; }
        public string CategoryName {  get; set; }
        public string CategoryId { get; set; }
        public string Description {  get; set; }
        public float Time {  get; set; }
        public float Overtime {  get; set; }
    }
}
