namespace TimeSheet.WebApi.DTOs.Responses
{
    public class ReportInstanceDTO
    {
        public DateOnly Date {  get; set; }
        public string TeamMember {  get; set; }
        public string ProjectName {  get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public float Time {  get; set; }



    }
}
