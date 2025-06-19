using System.ComponentModel.DataAnnotations;

namespace Pms360.Application.Models.Requests;
public class CreatePMSTypeRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
}
