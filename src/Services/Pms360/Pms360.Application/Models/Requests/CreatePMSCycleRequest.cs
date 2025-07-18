﻿namespace Pms360.Application.Models.Requests;
public class CreatePMSCycleRequest
{
    public string Title { get; set; }
    public Guid PMSTypeId { get; set; }
    public Guid PMSDurationTypeId { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}
