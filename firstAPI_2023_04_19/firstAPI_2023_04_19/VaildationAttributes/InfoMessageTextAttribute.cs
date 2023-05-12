using firstAPI_2023_04_19.Dtos;
using firstAPI_2023_04_19.Models;
using System.ComponentModel.DataAnnotations;

namespace firstAPI_2023_04_19.VaildationAttributes
{
    public class InfoMessageTextAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            RestfulApiTestContext _restfulApiTestContext = (RestfulApiTestContext)validationContext.GetService(typeof(RestfulApiTestContext));
            var text = (string)value;
            var findText = _restfulApiTestContext.InfoMessages
                           .Where(a=> a.Text == text)
                           .Select(a => a);
            var dto = validationContext.ObjectInstance;
            if(dto.GetType() == typeof(infoMessagePutDto))
            {
                var dtoPut = (infoMessagePutDto)dto;
                findText = findText.Where(a => a.Id != dtoPut.Id);
            }
            if (findText.FirstOrDefault() != null) 
            {
                return new ValidationResult("已存在相同Message");
            }
            return ValidationResult.Success;
        }
    }
}
